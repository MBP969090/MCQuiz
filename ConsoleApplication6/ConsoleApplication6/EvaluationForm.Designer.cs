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
            this.resultLabel = new System.Windows.Forms.Label();
            this.successLabel = new System.Windows.Forms.Label();
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
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(123, 125);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(35, 13);
            this.resultLabel.TabIndex = 1;
            this.resultLabel.Text = "label1";
            // 
            // successLabel
            // 
            this.successLabel.AutoSize = true;
            this.successLabel.Location = new System.Drawing.Point(123, 195);
            this.successLabel.Name = "successLabel";
            this.successLabel.Size = new System.Drawing.Size(35, 13);
            this.successLabel.TabIndex = 2;
            this.successLabel.Text = "label2";
            // 
            // EvaluationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 305);
            this.Controls.Add(this.successLabel);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.back_main_button);
            this.Name = "EvaluationForm";
            this.Text = "EvaluationForm";
            this.Load += new System.EventHandler(this.EvaluationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button back_main_button;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label successLabel;
    }
}