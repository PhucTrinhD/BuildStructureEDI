
namespace ReadFileEdiXML
{
    partial class frmReadFile
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
            System.Windows.Forms.Button btnSubmit;
            System.Windows.Forms.Button btnChoose;
            System.Windows.Forms.Button btnReset;
            this.txtNameFile = new System.Windows.Forms.TextBox();
            this.openDialogXML = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDataPure = new System.Windows.Forms.RichTextBox();
            this.txtShowData = new System.Windows.Forms.RichTextBox();
            btnSubmit = new System.Windows.Forms.Button();
            btnChoose = new System.Windows.Forms.Button();
            btnReset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnSubmit.Location = new System.Drawing.Point(1182, 12);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new System.Drawing.Size(100, 92);
            btnSubmit.TabIndex = 0;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnChoose
            // 
            btnChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnChoose.Location = new System.Drawing.Point(1076, 12);
            btnChoose.Name = "btnChoose";
            btnChoose.Size = new System.Drawing.Size(100, 43);
            btnChoose.TabIndex = 4;
            btnChoose.Text = "Choose File";
            btnChoose.UseVisualStyleBackColor = true;
            btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnReset
            // 
            btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnReset.Location = new System.Drawing.Point(1076, 61);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(100, 43);
            btnReset.TabIndex = 5;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtNameFile
            // 
            this.txtNameFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameFile.Location = new System.Drawing.Point(93, 12);
            this.txtNameFile.Multiline = true;
            this.txtNameFile.Name = "txtNameFile";
            this.txtNameFile.ReadOnly = true;
            this.txtNameFile.Size = new System.Drawing.Size(966, 84);
            this.txtNameFile.TabIndex = 2;
            // 
            // openDialogXML
            // 
            this.openDialogXML.FileName = "openDialogXML";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(357, -1781);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(559, 511);
            this.textBox1.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(btnReset);
            this.groupBox1.Controls.Add(this.txtNameFile);
            this.groupBox1.Controls.Add(btnChoose);
            this.groupBox1.Controls.Add(btnSubmit);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1305, 143);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtDataPure, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtShowData, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 143);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1305, 602);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // txtDataPure
            // 
            this.txtDataPure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDataPure.Location = new System.Drawing.Point(655, 3);
            this.txtDataPure.Name = "txtDataPure";
            this.txtDataPure.ReadOnly = true;
            this.txtDataPure.Size = new System.Drawing.Size(647, 596);
            this.txtDataPure.TabIndex = 1;
            this.txtDataPure.Text = "";
            // 
            // txtShowData
            // 
            this.txtShowData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShowData.Location = new System.Drawing.Point(3, 3);
            this.txtShowData.Name = "txtShowData";
            this.txtShowData.ReadOnly = true;
            this.txtShowData.Size = new System.Drawing.Size(646, 596);
            this.txtShowData.TabIndex = 0;
            this.txtShowData.Text = "";
            // 
            // frmReadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 745);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmReadFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Read File EDI XML";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtNameFile;
        private System.Windows.Forms.OpenFileDialog openDialogXML;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox txtShowData;
        private System.Windows.Forms.RichTextBox txtDataPure;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox txtDataShow;
    }
}

