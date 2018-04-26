namespace RegistryToText
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
            this.StartButton = new System.Windows.Forms.Button();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(12, 132);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(482, 72);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Get and Write";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // PathBox
            // 
            this.PathBox.Location = new System.Drawing.Point(12, 72);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(482, 35);
            this.PathBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(479, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "HKEY_CURRENT_USER SOFTWARE key:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 239);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.StartButton);
            this.Name = "Form1";
            this.Text = "RegToTxt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.Label label1;
    }
}

