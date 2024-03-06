using System.Text.RegularExpressions;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace AssemblerEmulator
{
    public partial class Form : System.Windows.Forms.Form
    {
        /// <summary>
        /// Assembler emulator
        /// </summary>
        private Emulator _emulator = new Emulator(OnMemoryChange, OnRegisterChange, OnSyscall);

        /// <summary>
        /// Static reference for static functions
        /// </summary>
        private static Form _form;

        /// <summary>
        /// Timer for events
        /// </summary>
        private Timer _timer = new Timer();

        /// <summary>
        /// Opened file
        /// </summary>
        private string _openFile = string.Empty;

        /// <summary>
        /// If text has changed
        /// </summary>
        private bool _hasChanged = false;

        public Form()
        {
            _form = this;

            WindowState = FormWindowState.Maximized;
            InitializeComponent();

            PopulateMemoryView();
            PopulateInstructionsView();
            PopulateRegistersView();

            _timer = new Timer();
            _timer.Interval = 5000;
            _timer.Tick += Beautify;
            _timer.Start();
        }

        /// <summary>
        /// When a register changes then show in the interface
        /// </summary>
        private static void OnRegisterChange(string name, byte[] value)
        {
            var item = _form.listViewRegisters.FindItemWithText(name);

            if (item != null)
            {
                var str = string.Join("", value.Select(x => string.Format("{0:X2}", x)));

                item.SubItems[1].Text = $"0x{str}";
                item.SubItems[2].Text = BitConverter.ToInt32(value).ToString();
            }
        }

        /// <summary>
        /// When a syscall is made
        /// </summary>
        private static void OnSyscall(int code, byte[] value)
        {
            if(code == 1)
            {
                int integer = BitConverter.ToInt32(value);

                _form.listBoxOutput.Items.Add(integer.ToString());  
            }
        }

        /// <summary>
        /// When a register changes then show in the interface
        /// </summary>
        private static void OnMemoryChange(int address, byte value)
        {
            var item = _form.listViewMemory.FindItemWithText($"0x{address.ToString("x8")}");

            if (item != null)
            {
                item.SubItems[1].Text = $"0x{value.ToString("x2")}";
            }
        }

        /// <summary>
        /// Populate the instruction tab
        /// </summary>
        private void PopulateInstructionsView()
        {
            var instuctions = richTextBoxCode.Text
                .Split('\n')
                .Where(x => x.Trim().Length > 0 && !x.Contains("--"))
                .ToList();

            var labels = new List<Tuple<string, string>>();  

            listViewInstructions.Items.Clear();
            listViewInstructions.Columns.Clear();
            listViewInstructions.View = View.Details;
            listViewInstructions.Columns.Add("Address", 100);
            listViewInstructions.Columns.Add("Instruction", 100);

            int address = 0;
            foreach (var instruction in instuctions)
            {
                if(instruction.Trim().EndsWith(":") && instruction.Trim().Count() >= 2)
                {
                    labels.Add(new Tuple<string, string>(instruction, $"0x{address.ToString("x8")}"));

                    continue;
                }

                ListViewItem item = new ListViewItem($"0x{address.ToString("x8")}");
                address++;

                item.SubItems.Add(instruction.Trim());

                listViewInstructions.Items.Add(item);
            }

            PopulateLabelsView(labels);
        }

        /// <summary>
        /// Populate the labels tab
        /// </summary>
        private void PopulateLabelsView(List<Tuple<string, string>> labels)
        {
            listViewLabels.Items.Clear();
            listViewLabels.Columns.Clear();
            listViewLabels.View = View.Details;
            listViewLabels.Columns.Add("Label", 100);
            listViewLabels.Columns.Add("Address", 100);

            foreach (var label in labels)
            {
                ListViewItem item = new ListViewItem(label.Item1.Trim().Replace(":", string.Empty));
                item.SubItems.Add(label.Item2);
              
                listViewLabels.Items.Add(item);
            }
        }

        /// <summary>
        /// Populate the registers tab
        /// </summary>
        private void PopulateRegistersView()
        {
            var registers = _emulator.GetRegisters();

            listViewRegisters.Items.Clear();
            listViewRegisters.Columns.Clear();
            listViewRegisters.View = View.Details;
            listViewRegisters.Columns.Add("Register", 50);
            listViewRegisters.Columns.Add("Value (Hex)", 80);
            listViewRegisters.Columns.Add("Value (Dec)", 70);

            foreach (var register in registers)
            {
                ListViewItem item = new ListViewItem(register.Name);

                var value = string.Join("", register.Value.Select(x => string.Format("{0:X2}", x)));

                item.SubItems.Add($"0x{value}");
                item.SubItems.Add(BitConverter.ToInt32(register.Value).ToString());

                listViewRegisters.Items.Add(item);
            }
        }

        /// <summary>
        /// Populate the memory view tab
        /// </summary>
        private void PopulateMemoryView()
        {
            var mem = _emulator.GetMemory();

            listViewMemory.Items.Clear();
            listViewMemory.Columns.Clear();
            listViewMemory.View = View.Details;
            listViewMemory.Columns.Add("Address", 100);
            listViewMemory.Columns.Add("Value", 100);

            int address = 0;
            foreach(var _byte in mem)
            {
                ListViewItem item = new ListViewItem($"0x{address.ToString("x8")}");
                address++;

                item.SubItems.Add($"0x{_byte.ToString("x2")}");

                listViewMemory.Items.Add(item);
            }
        }

        /// <summary>
        /// Reset emulator state
        /// </summary>
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            _emulator.Reset();
            PopulateMemoryView();
            PopulateInstructionsView();
            PopulateRegistersView();
            listBoxOutput.Items.Clear();
        }

        /// <summary>
        /// Run emulator
        /// </summary>
        private void ButtonRun_Click(object sender, EventArgs e)
        {
            try
            {
                _emulator.Reset();
                PopulateMemoryView();
                PopulateInstructionsView();
                PopulateRegistersView();

                listBoxOutput.Items.Clear();
                listBoxOutput.Items.Add("Running");

                var instuctions = richTextBoxCode.Text.Split('\n').ToList();

                _emulator.AddInstructions(instuctions);

                while (_emulator.ExecuteLine()) { }

                listBoxOutput.Items.Add("Finished");
            }
            catch (Exception ex)
            {
                listBoxOutput.Items.Add(ex.Message);
            }
        }

        /// <summary>
        /// When the code changes update the instruction memory and labels
        /// </summary>
        private void richTextBoxCode_TextChanged(object sender, EventArgs e)
        {
            PopulateInstructionsView();
            _hasChanged = true;
        }

        /// <summary>
        /// Put colors on syntax
        /// </summary>
        private void Beautify(object sender, EventArgs e)
        {
            if (!_hasChanged)
                return;

            this.richTextBoxCode.SuspendLayout();

            CheckKeyword("add", Color.Green);
            CheckKeyword("addi", Color.Green);
            CheckKeyword("sub", Color.Green);
            CheckKeyword("mul", Color.Green);
            CheckKeyword("muli", Color.Green);
            CheckKeyword("div", Color.Green);

            CheckKeyword("or", Color.Green);
            CheckKeyword("xor", Color.Green);
            CheckKeyword("and", Color.Green);
            CheckKeyword("not", Color.Green);
            CheckKeyword("sfl", Color.Green);
            CheckKeyword("sfr", Color.Green);

            CheckKeyword("jr", Color.Green);
            CheckKeyword("j", Color.Green);
            CheckKeyword("beq", Color.Green);
            CheckKeyword("bne", Color.Green);
            CheckKeyword("jal", Color.Green);
            CheckKeyword("slt", Color.Green);
            CheckKeyword("sgt", Color.Green);

            CheckKeyword("lw", Color.Green);
            CheckKeyword("sw", Color.Green);
            CheckKeyword("sb", Color.Green);
            CheckKeyword("lb", Color.Green);
            CheckKeyword("move", Color.Green);

            CheckKeyword("syscall", Color.Orange);

            foreach (var register in _emulator.GetRegisters())
                CheckKeyword(register.Name, Color.Blue);

            CheckKeyword(new Regex(".*--.*"), Color.DarkGreen);

            CheckKeyword("0x", Color.Red);
            CheckKeyword(":", Color.HotPink);
        
            this.richTextBoxCode.ResumeLayout();

            _hasChanged = false;
        }

        /// <summary>
        /// Change the color of a word based on regex in the text
        /// </summary>
        /// <param name="regex"></param>
        /// <param name="color"></param>
        private void CheckKeyword(Regex regex, Color color)
        {
            var matches = regex.Matches(this.richTextBoxCode.Text).ToList();

            foreach(var match in matches)
            {
                int index = match.Index;
                int size = match.Length;
                int selectStart = this.richTextBoxCode.SelectionStart;

                this.richTextBoxCode.Select(index, size);
                this.richTextBoxCode.SelectionColor = color;
                this.richTextBoxCode.Select(selectStart, 0);
                this.richTextBoxCode.SelectionColor = Color.Black;
            }
        }

        /// <summary>
        /// Change the color of a word in the text
        /// </summary>
        /// <param name="word"></param>
        /// <param name="color"></param>
        private void CheckKeyword(string word, Color color)
        {
            if (this.richTextBoxCode.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.richTextBoxCode.SelectionStart;

                while ((index = this.richTextBoxCode.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBoxCode.Select(index, word.Length);
                    this.richTextBoxCode.SelectionColor = color;
                    this.richTextBoxCode.Select(selectStart, 0);
                    this.richTextBoxCode.SelectionColor = Color.Black;
                }
            }
        }

        /// <summary>
        /// Loads the code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.Title = "Open file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _openFile = openFileDialog.FileName;
                string fileContent = File.ReadAllText(_openFile);

                richTextBoxCode.Text = fileContent;
                MessageBox.Show("Opened with success");
            }
        }

        /// <summary>
        /// Saves the code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "All files (*.*)|*.*";
            saveFileDialog.Title = "Open file";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;

                File.WriteAllText(path, richTextBoxCode.Text);
                MessageBox.Show("Saved with success");
            }
        }
    }
}