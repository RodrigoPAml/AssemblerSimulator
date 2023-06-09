﻿namespace AssemblerEmulator
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.ButtonRun = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.listBoxOutput = new System.Windows.Forms.ListBox();
            this.richTextBoxCode = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControlInfo = new System.Windows.Forms.TabControl();
            this.tabPageRegisters = new System.Windows.Forms.TabPage();
            this.listViewRegisters = new System.Windows.Forms.ListView();
            this.tabPageMem = new System.Windows.Forms.TabPage();
            this.listViewMemory = new System.Windows.Forms.ListView();
            this.tabPageInstructions = new System.Windows.Forms.TabPage();
            this.listViewInstructions = new System.Windows.Forms.ListView();
            this.tabPageLabels = new System.Windows.Forms.TabPage();
            this.listViewLabels = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabControlInfo.SuspendLayout();
            this.tabPageRegisters.SuspendLayout();
            this.tabPageMem.SuspendLayout();
            this.tabPageInstructions.SuspendLayout();
            this.tabPageLabels.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxOutput, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.richTextBoxCode, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.84615F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.15385F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(725, 549);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.buttonSave, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonLoad, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ButtonRun, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ButtonReset, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(719, 29);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(84, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(3, 3);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // ButtonRun
            // 
            this.ButtonRun.Location = new System.Drawing.Point(165, 3);
            this.ButtonRun.Name = "ButtonRun";
            this.ButtonRun.Size = new System.Drawing.Size(75, 23);
            this.ButtonRun.TabIndex = 1;
            this.ButtonRun.Text = "Run";
            this.ButtonRun.UseVisualStyleBackColor = true;
            this.ButtonRun.Click += new System.EventHandler(this.ButtonRun_Click);
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(246, 3);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 2;
            this.ButtonReset.Text = "Reset";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // listBoxOutput
            // 
            this.listBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxOutput.FormattingEnabled = true;
            this.listBoxOutput.ItemHeight = 15;
            this.listBoxOutput.Location = new System.Drawing.Point(3, 417);
            this.listBoxOutput.Name = "listBoxOutput";
            this.listBoxOutput.Size = new System.Drawing.Size(719, 124);
            this.listBoxOutput.TabIndex = 2;
            // 
            // richTextBoxCode
            // 
            this.richTextBoxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxCode.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBoxCode.Location = new System.Drawing.Point(3, 38);
            this.richTextBoxCode.Name = "richTextBoxCode";
            this.richTextBoxCode.Size = new System.Drawing.Size(719, 373);
            this.richTextBoxCode.TabIndex = 3;
            this.richTextBoxCode.Text = "";
            this.richTextBoxCode.TextChanged += new System.EventHandler(this.richTextBoxCode_TextChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.61983F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.38017F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tabControlInfo, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(968, 555);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tabControlInfo
            // 
            this.tabControlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlInfo.Controls.Add(this.tabPageRegisters);
            this.tabControlInfo.Controls.Add(this.tabPageMem);
            this.tabControlInfo.Controls.Add(this.tabPageInstructions);
            this.tabControlInfo.Controls.Add(this.tabPageLabels);
            this.tabControlInfo.Location = new System.Drawing.Point(734, 3);
            this.tabControlInfo.Name = "tabControlInfo";
            this.tabControlInfo.SelectedIndex = 0;
            this.tabControlInfo.Size = new System.Drawing.Size(231, 549);
            this.tabControlInfo.TabIndex = 1;
            // 
            // tabPageRegisters
            // 
            this.tabPageRegisters.Controls.Add(this.listViewRegisters);
            this.tabPageRegisters.Location = new System.Drawing.Point(4, 24);
            this.tabPageRegisters.Name = "tabPageRegisters";
            this.tabPageRegisters.Size = new System.Drawing.Size(223, 521);
            this.tabPageRegisters.TabIndex = 3;
            this.tabPageRegisters.Text = "Registers";
            this.tabPageRegisters.UseVisualStyleBackColor = true;
            // 
            // listViewRegisters
            // 
            this.listViewRegisters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewRegisters.Location = new System.Drawing.Point(2, 1);
            this.listViewRegisters.Name = "listViewRegisters";
            this.listViewRegisters.Size = new System.Drawing.Size(223, 521);
            this.listViewRegisters.TabIndex = 1;
            this.listViewRegisters.UseCompatibleStateImageBehavior = false;
            // 
            // tabPageMem
            // 
            this.tabPageMem.Controls.Add(this.listViewMemory);
            this.tabPageMem.Location = new System.Drawing.Point(4, 24);
            this.tabPageMem.Name = "tabPageMem";
            this.tabPageMem.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMem.Size = new System.Drawing.Size(223, 521);
            this.tabPageMem.TabIndex = 0;
            this.tabPageMem.Text = "Memory";
            this.tabPageMem.UseVisualStyleBackColor = true;
            // 
            // listViewMemory
            // 
            this.listViewMemory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewMemory.Location = new System.Drawing.Point(0, 0);
            this.listViewMemory.Name = "listViewMemory";
            this.listViewMemory.Size = new System.Drawing.Size(217, 521);
            this.listViewMemory.TabIndex = 0;
            this.listViewMemory.UseCompatibleStateImageBehavior = false;
            // 
            // tabPageInstructions
            // 
            this.tabPageInstructions.Controls.Add(this.listViewInstructions);
            this.tabPageInstructions.Location = new System.Drawing.Point(4, 24);
            this.tabPageInstructions.Name = "tabPageInstructions";
            this.tabPageInstructions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInstructions.Size = new System.Drawing.Size(223, 521);
            this.tabPageInstructions.TabIndex = 1;
            this.tabPageInstructions.Text = "Instructions";
            this.tabPageInstructions.UseVisualStyleBackColor = true;
            // 
            // listViewInstructions
            // 
            this.listViewInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewInstructions.Location = new System.Drawing.Point(0, 2);
            this.listViewInstructions.Name = "listViewInstructions";
            this.listViewInstructions.Size = new System.Drawing.Size(217, 521);
            this.listViewInstructions.TabIndex = 1;
            this.listViewInstructions.UseCompatibleStateImageBehavior = false;
            // 
            // tabPageLabels
            // 
            this.tabPageLabels.Controls.Add(this.listViewLabels);
            this.tabPageLabels.Location = new System.Drawing.Point(4, 24);
            this.tabPageLabels.Name = "tabPageLabels";
            this.tabPageLabels.Size = new System.Drawing.Size(223, 521);
            this.tabPageLabels.TabIndex = 2;
            this.tabPageLabels.Text = "Labels";
            this.tabPageLabels.UseVisualStyleBackColor = true;
            // 
            // listViewLabels
            // 
            this.listViewLabels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewLabels.Location = new System.Drawing.Point(0, 2);
            this.listViewLabels.Name = "listViewLabels";
            this.listViewLabels.Size = new System.Drawing.Size(220, 521);
            this.listViewLabels.TabIndex = 2;
            this.listViewLabels.UseCompatibleStateImageBehavior = false;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 579);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "Form";
            this.Text = "Assembler emulator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tabControlInfo.ResumeLayout(false);
            this.tabPageRegisters.ResumeLayout(false);
            this.tabPageMem.ResumeLayout(false);
            this.tabPageInstructions.ResumeLayout(false);
            this.tabPageLabels.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button buttonLoad;
        private Button ButtonRun;
        private Button ButtonReset;
        private ListBox listBoxOutput;
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
    }
}