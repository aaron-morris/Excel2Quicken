namespace Excel2Quicken
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.excelTextBox = new System.Windows.Forms.TextBox();
            this.quickenTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.excelBrowseButton = new System.Windows.Forms.Button();
            this.quickenBrowseButton = new System.Windows.Forms.Button();
            this.convertButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // excelTextBox
            // 
            this.excelTextBox.Location = new System.Drawing.Point(73, 33);
            this.excelTextBox.Name = "excelTextBox";
            this.excelTextBox.ReadOnly = true;
            this.excelTextBox.Size = new System.Drawing.Size(388, 20);
            this.excelTextBox.TabIndex = 0;
            // 
            // quickenTextBox
            // 
            this.quickenTextBox.Location = new System.Drawing.Point(73, 71);
            this.quickenTextBox.Name = "quickenTextBox";
            this.quickenTextBox.ReadOnly = true;
            this.quickenTextBox.Size = new System.Drawing.Size(388, 20);
            this.quickenTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Excel File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Save As:";
            // 
            // excelBrowseButton
            // 
            this.excelBrowseButton.Location = new System.Drawing.Point(467, 31);
            this.excelBrowseButton.Name = "excelBrowseButton";
            this.excelBrowseButton.Size = new System.Drawing.Size(28, 23);
            this.excelBrowseButton.TabIndex = 4;
            this.excelBrowseButton.Text = "...";
            this.excelBrowseButton.UseVisualStyleBackColor = true;
            this.excelBrowseButton.Click += new System.EventHandler(this.excelBrowseButton_Click);
            // 
            // quickenBrowseButton
            // 
            this.quickenBrowseButton.Location = new System.Drawing.Point(467, 69);
            this.quickenBrowseButton.Name = "quickenBrowseButton";
            this.quickenBrowseButton.Size = new System.Drawing.Size(28, 23);
            this.quickenBrowseButton.TabIndex = 5;
            this.quickenBrowseButton.Text = "...";
            this.quickenBrowseButton.UseVisualStyleBackColor = true;
            this.quickenBrowseButton.Click += new System.EventHandler(this.quickenBrowseButton_Click);
            // 
            // convertButton
            // 
            this.convertButton.Enabled = false;
            this.convertButton.Location = new System.Drawing.Point(420, 121);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(75, 23);
            this.convertButton.TabIndex = 6;
            this.convertButton.Text = "Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 160);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.quickenBrowseButton);
            this.Controls.Add(this.excelBrowseButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quickenTextBox);
            this.Controls.Add(this.excelTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Excel-to-Quicken Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox excelTextBox;
        private System.Windows.Forms.TextBox quickenTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button excelBrowseButton;
        private System.Windows.Forms.Button quickenBrowseButton;
        private System.Windows.Forms.Button convertButton;
    }
}

