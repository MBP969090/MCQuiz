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
    public partial class QuestionForm : Form
    {
        private RadioButton[] radios;
        private Controller controller;

        public QuestionForm( Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
            
            this.radios = new RadioButton[4];
            this.radios[0] = this.radioButton1;
            this.radios[1] = this.radioButton2;
            this.radios[2] = this.radioButton3;
            this.radios[3] = this.radioButton4;
            controller.InitializeQuestionForm(this.textBox1, this.radios);
        }

        private void QuestionForm_Load(object sender, EventArgs e)
        {

        }

        private void forward_button_Click(object sender, EventArgs e)
        {
            controller.ForwardButtonClicked(this.textBox1, this.radios);
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            controller.BackButtonClicked(this.textBox1, this.radios);
        }

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
	}
}
