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
            this.SuspendLayout();
            // 
            // save_back
            // 
            this.save_back.Location = new System.Drawing.Point(460, 205);
            this.save_back.Name = "save_back";
            this.save_back.Size = new System.Drawing.Size(136, 45);
            this.save_back.TabIndex = 0;
            this.save_back.Text = "Speichern und zurück\r\nzum Programm";
            this.save_back.UseVisualStyleBackColor = true;
            this.save_back.Click += new System.EventHandler(this.button1_Click);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 329);
            this.Controls.Add(this.save_back);
            this.Name = "ConfigurationForm";
            this.Text = "Konfiguration";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button save_back;
    }
}