namespace ConsoleApplication6
{
    partial class QuestionForm
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
            this.forward_button = new System.Windows.Forms.Button();
            this.back_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // forward_button
            // 
            this.forward_button.Location = new System.Drawing.Point(421, 244);
            this.forward_button.Name = "forward_button";
            this.forward_button.Size = new System.Drawing.Size(75, 23);
            this.forward_button.TabIndex = 0;
            this.forward_button.Text = "Next";
            this.forward_button.UseVisualStyleBackColor = true;
            this.forward_button.Click += new System.EventHandler(this.forward_button_Click);
            // 
            // back_button
            // 
            this.back_button.Location = new System.Drawing.Point(83, 244);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(75, 23);
            this.back_button.TabIndex = 1;
            this.back_button.Text = "Back";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 290);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.forward_button);
            this.Name = "QuestionForm";
            this.Text = "QuestionForm";
            this.Load += new System.EventHandler(this.QuestionForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button forward_button;
        private System.Windows.Forms.Button back_button;
    }
}