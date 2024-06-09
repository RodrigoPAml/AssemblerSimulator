namespace AssemblerEmulatorGUI
{
    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnReset = new Button();
            buttonSave = new Button();
            buttonLoad = new Button();
            ButtonRun = new Button();
            btnLog = new Button();
            richTextBoxCode = new RichTextBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            textBoxOutput = new TextBox();
            listBoxOutput = new ListBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            tabControlInfo = new TabControl();
            tabPageRegisters = new TabPage();
            listViewRegisters = new ListView();
            tabPageMem = new TabPage();
            listViewMemory = new ListView();
            tabPageInstructions = new TabPage();
            listViewInstructions = new ListView();
            tabPageLabels = new TabPage();
            listViewLabels = new ListView();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tabControlInfo.SuspendLayout();
            tabPageRegisters.SuspendLayout();
            tabPageMem.SuspendLayout();
            tabPageInstructions.SuspendLayout();
            tabPageLabels.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(richTextBoxCode, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 2);
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 73.84615F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 26.15385F));
            tableLayoutPanel1.Size = new Size(686, 581);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 5;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(btnReset, 0, 0);
            tableLayoutPanel2.Controls.Add(buttonSave, 0, 0);
            tableLayoutPanel2.Controls.Add(buttonLoad, 0, 0);
            tableLayoutPanel2.Controls.Add(ButtonRun, 1, 0);
            tableLayoutPanel2.Controls.Add(btnLog, 2, 0);
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(680, 29);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(165, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 4;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += ButtonReset_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(84, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(3, 3);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 23);
            buttonLoad.TabIndex = 0;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // ButtonRun
            // 
            ButtonRun.Location = new Point(246, 3);
            ButtonRun.Name = "ButtonRun";
            ButtonRun.Size = new Size(75, 23);
            ButtonRun.TabIndex = 1;
            ButtonRun.Text = "Run";
            ButtonRun.UseVisualStyleBackColor = true;
            ButtonRun.Click += ButtonRun_Click;
            // 
            // btnLog
            // 
            btnLog.Location = new Point(327, 3);
            btnLog.Name = "btnLog";
            btnLog.Size = new Size(211, 23);
            btnLog.TabIndex = 2;
            btnLog.TabStop = false;
            btnLog.Text = "Disable Feedback (Performance +)";
            btnLog.UseVisualStyleBackColor = true;
            btnLog.Click += ButtonLog_Click;
            // 
            // richTextBoxCode
            // 
            richTextBoxCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBoxCode.Font = new Font("Segoe UI", 18F);
            richTextBoxCode.Location = new Point(3, 38);
            richTextBoxCode.Name = "richTextBoxCode";
            richTextBoxCode.Size = new Size(680, 397);
            richTextBoxCode.TabIndex = 3;
            richTextBoxCode.Text = "";
            richTextBoxCode.TextChanged += richTextBoxCode_TextChanged;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.58823F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.41177F));
            tableLayoutPanel4.Controls.Add(textBoxOutput, 1, 0);
            tableLayoutPanel4.Controls.Add(listBoxOutput, 0, 0);
            tableLayoutPanel4.Location = new Point(3, 441);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(680, 137);
            tableLayoutPanel4.TabIndex = 4;
            // 
            // textBoxOutput
            // 
            textBoxOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxOutput.Font = new Font("Segoe UI", 15.75F);
            textBoxOutput.HideSelection = false;
            textBoxOutput.Location = new Point(346, 3);
            textBoxOutput.Margin = new Padding(3, 3, 3, 10);
            textBoxOutput.Multiline = true;
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.ReadOnly = true;
            textBoxOutput.ScrollBars = ScrollBars.Vertical;
            textBoxOutput.Size = new Size(331, 124);
            textBoxOutput.TabIndex = 1;
            // 
            // listBoxOutput
            // 
            listBoxOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxOutput.Font = new Font("Segoe UI", 15.75F);
            listBoxOutput.FormattingEnabled = true;
            listBoxOutput.ItemHeight = 30;
            listBoxOutput.Location = new Point(3, 3);
            listBoxOutput.Name = "listBoxOutput";
            listBoxOutput.Size = new Size(337, 124);
            listBoxOutput.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 69.6188F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.38119F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel3.Controls.Add(tabControlInfo, 1, 0);
            tableLayoutPanel3.Location = new Point(12, 12);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(995, 587);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // tabControlInfo
            // 
            tabControlInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlInfo.Controls.Add(tabPageRegisters);
            tabControlInfo.Controls.Add(tabPageMem);
            tabControlInfo.Controls.Add(tabPageInstructions);
            tabControlInfo.Controls.Add(tabPageLabels);
            tabControlInfo.Font = new Font("Segoe UI", 11.25F);
            tabControlInfo.Location = new Point(695, 3);
            tabControlInfo.Name = "tabControlInfo";
            tabControlInfo.SelectedIndex = 0;
            tabControlInfo.Size = new Size(297, 581);
            tabControlInfo.TabIndex = 1;
            // 
            // tabPageRegisters
            // 
            tabPageRegisters.Controls.Add(listViewRegisters);
            tabPageRegisters.Location = new Point(4, 29);
            tabPageRegisters.Name = "tabPageRegisters";
            tabPageRegisters.Size = new Size(289, 548);
            tabPageRegisters.TabIndex = 3;
            tabPageRegisters.Text = "Registers";
            tabPageRegisters.UseVisualStyleBackColor = true;
            // 
            // listViewRegisters
            // 
            listViewRegisters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewRegisters.Font = new Font("Segoe UI", 11.25F);
            listViewRegisters.Location = new Point(0, 1);
            listViewRegisters.Name = "listViewRegisters";
            listViewRegisters.Size = new Size(286, 548);
            listViewRegisters.TabIndex = 1;
            listViewRegisters.UseCompatibleStateImageBehavior = false;
            // 
            // tabPageMem
            // 
            tabPageMem.Controls.Add(listViewMemory);
            tabPageMem.Location = new Point(4, 29);
            tabPageMem.Name = "tabPageMem";
            tabPageMem.Padding = new Padding(3);
            tabPageMem.Size = new Size(289, 548);
            tabPageMem.TabIndex = 0;
            tabPageMem.Text = "Memory";
            tabPageMem.UseVisualStyleBackColor = true;
            // 
            // listViewMemory
            // 
            listViewMemory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewMemory.Location = new Point(0, 0);
            listViewMemory.Name = "listViewMemory";
            listViewMemory.Size = new Size(283, 548);
            listViewMemory.TabIndex = 0;
            listViewMemory.UseCompatibleStateImageBehavior = false;
            // 
            // tabPageInstructions
            // 
            tabPageInstructions.Controls.Add(listViewInstructions);
            tabPageInstructions.Location = new Point(4, 29);
            tabPageInstructions.Name = "tabPageInstructions";
            tabPageInstructions.Padding = new Padding(3);
            tabPageInstructions.Size = new Size(289, 548);
            tabPageInstructions.TabIndex = 1;
            tabPageInstructions.Text = "Instructions";
            tabPageInstructions.UseVisualStyleBackColor = true;
            // 
            // listViewInstructions
            // 
            listViewInstructions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewInstructions.Location = new Point(0, 2);
            listViewInstructions.Name = "listViewInstructions";
            listViewInstructions.Size = new Size(283, 548);
            listViewInstructions.TabIndex = 1;
            listViewInstructions.UseCompatibleStateImageBehavior = false;
            // 
            // tabPageLabels
            // 
            tabPageLabels.Controls.Add(listViewLabels);
            tabPageLabels.Location = new Point(4, 29);
            tabPageLabels.Name = "tabPageLabels";
            tabPageLabels.Size = new Size(289, 548);
            tabPageLabels.TabIndex = 2;
            tabPageLabels.Text = "Labels";
            tabPageLabels.UseVisualStyleBackColor = true;
            // 
            // listViewLabels
            // 
            listViewLabels.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewLabels.Location = new Point(0, 2);
            listViewLabels.Name = "listViewLabels";
            listViewLabels.Size = new Size(286, 548);
            listViewLabels.TabIndex = 2;
            listViewLabels.UseCompatibleStateImageBehavior = false;
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1019, 611);
            Controls.Add(tableLayoutPanel3);
            Name = "Form";
            Text = "Assembler emulator";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tabControlInfo.ResumeLayout(false);
            tabPageRegisters.ResumeLayout(false);
            tabPageMem.ResumeLayout(false);
            tabPageInstructions.ResumeLayout(false);
            tabPageLabels.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button buttonLoad;
        private Button ButtonRun;
        private Button btnLog;
        private RichTextBox richTextBoxCode;
        private TableLayoutPanel tableLayoutPanel3;
        private TabControl tabControlInfo;
        private TabPage tabPageMem;
        private TabPage tabPageInstructions;
        private ListView listViewMemory;
        private ListView listViewInstructions;
        private TabPage tabPageLabels;
        private ListView listViewLabels;
        private TabPage tabPageRegisters;
        private ListView listViewRegisters;
        private Button buttonSave;
        private Button btnReset;
        private TableLayoutPanel tableLayoutPanel4;
        private TextBox textBoxOutput;
        private ListBox listBoxOutput;
    }
}