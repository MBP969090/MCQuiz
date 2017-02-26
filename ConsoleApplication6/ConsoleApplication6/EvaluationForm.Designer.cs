namespace ConsoleApplication6
{
    partial class EvaluationForm
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
            this.back_main_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // back_main_button
            // 
            this.back_main_button.Location = new System.Drawing.Point(368, 256);
            this.back_main_button.Name = "back_main_button";
            this.back_main_button.Size = new System.Drawing.Size(162, 23);
            this.back_main_button.TabIndex = 0;
            this.back_main_button.Text = "Zurück zum Hauptprogramm";
            this.back_main_button.UseVisualStyleBackColor = true;
            this.back_main_button.Click += new System.EventHandler(this.back_main_button_Click);
            // 
            // EvaluationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 305);
            this.Controls.Add(this.back_main_button);
            this.Name = "EvaluationForm";
            this.Text = "EvaluationForm";
            this.Load += new System.EventHandler(this.EvaluationForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button back_main_button;
    }
}