namespace ConsoleApplication6
{
    partial class ConfigurationForm
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
            this.save_back = new System.Windows.Forms.Button();
            this.NameOfProgramTextBox = new System.Windows.Forms.TextBox();
            this.SuccessHurdleTextBox = new System.Windows.Forms.TextBox();
            this.NameOfProgramTextLabel = new System.Windows.Forms.Label();
            this.SuccessHurdleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // save_back
            // 
            this.save_back.Location = new System.Drawing.Point(290, 233);
            this.save_back.Name = "save_back";
            this.save_back.Size = new System.Drawing.Size(136, 45);
            this.save_back.TabIndex = 0;
            this.save_back.Text = "Speichern und zurück\r\nzum Programm";
            this.save_back.UseVisualStyleBackColor = true;
            this.save_back.Click += new System.EventHandler(this.button1_Click);
            // 
            // NameOfProgramTextBox
            // 
            this.NameOfProgramTextBox.Location = new System.Drawing.Point(177, 24);
            this.NameOfProgramTextBox.Name = "NameOfProgramTextBox";
            this.NameOfProgramTextBox.Size = new System.Drawing.Size(249, 20);
            this.NameOfProgramTextBox.TabIndex = 1;
            // 
            // SuccessHurdleTextBox
            // 
            this.SuccessHurdleTextBox.Location = new System.Drawing.Point(274, 73);
            this.SuccessHurdleTextBox.Name = "SuccessHurdleTextBox";
            this.SuccessHurdleTextBox.Size = new System.Drawing.Size(152, 20);
            this.SuccessHurdleTextBox.TabIndex = 2;
            // 
            // NameOfProgramTextLabel
            // 
            this.NameOfProgramTextLabel.AutoSize = true;
            this.NameOfProgramTextLabel.Location = new System.Drawing.Point(47, 27);
            this.NameOfProgramTextLabel.Name = "NameOfProgramTextLabel";
            this.NameOfProgramTextLabel.Size = new System.Drawing.Size(102, 13);
            this.NameOfProgramTextLabel.TabIndex = 3;
            this.NameOfProgramTextLabel.Text = "Name des Programs";
            // 
            // SuccessHurdleLabel
            // 
            this.SuccessHurdleLabel.AutoSize = true;
            this.SuccessHurdleLabel.Location = new System.Drawing.Point(47, 76);
            this.SuccessHurdleLabel.Name = "SuccessHurdleLabel";
            this.SuccessHurdleLabel.Size = new System.Drawing.Size(199, 13);
            this.SuccessHurdleLabel.TabIndex = 4;
            this.SuccessHurdleLabel.Text = "Prüfungsbogen bestanden mit ... Prozent";
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 329);
            this.Controls.Add(this.SuccessHurdleLabel);
            this.Controls.Add(this.NameOfProgramTextLabel);
            this.Controls.Add(this.SuccessHurdleTextBox);
            this.Controls.Add(this.NameOfProgramTextBox);
            this.Controls.Add(this.save_back);
            this.Name = "ConfigurationForm";
            this.Text = "Konfiguration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save_back;
        private System.Windows.Forms.TextBox NameOfProgramTextBox;
        private System.Windows.Forms.TextBox SuccessHurdleTextBox;
        private System.Windows.Forms.Label NameOfProgramTextLabel;
        private System.Windows.Forms.Label SuccessHurdleLabel;
    }
}