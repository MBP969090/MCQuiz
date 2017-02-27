using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication6
{
    public partial class EvaluationForm : Form
    {
        private Controller controller;
        public EvaluationForm(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void EvaluationForm_Load(object sender, EventArgs e)
        {

        }

        private void back_main_button_Click(object sender, EventArgs e)
        {
            controller.BackToMainMenuButtonClicked();
        }

        public void SetSuccessLabel(bool success){
            if(success){
				this.successLabel.BackColor = Color.Green;
                this.successLabel.Text = "GZ du pisser hast bestanden!!!.";
            } else {
				this.successLabel.BackColor = Color.Red;
                this.successLabel.Text = "Leider nicht bestanden du LOOOOOSEEERRRR!!! BOON!!!";
            }
        }

		public void SetResultLabel(string result)
		{
			this.resultLabel.Text = result;
		}

		public void SetWrongAnswerTextbox(string s)
		{
			this.wrongAnswerTextbox.Text = s;
		}
    }
}
