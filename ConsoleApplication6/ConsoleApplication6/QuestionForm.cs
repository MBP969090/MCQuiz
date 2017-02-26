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
        private EvaluationForm eval_form;
        private StartForm start_form;
		private Questionaire questionaire;

        public QuestionForm(Questionaire questionaire)
        {
            InitializeComponent();
            this.questionaire = questionaire;
			Question q = questionaire.GetFirstQuestion();
			this.textBox1.Text = q.GetText();
			radioButton1.Text = q.GetAnswer(0);
			radioButton2.Text = q.GetAnswer(1);
			radioButton3.Text = q.GetAnswer(2);
			radioButton4.Text = q.GetAnswer(3);
        }

        private void QuestionForm_Load(object sender, EventArgs e)
        {

        }

        public void setEvalForm(EvaluationForm eval_form)
        {
            this.eval_form = eval_form;
        }

        public void setStartForm(StartForm start_form)
        {
            this.start_form = start_form;
        }

        private void forward_button_Click(object sender, EventArgs e)
        {
			Question q;
            //if (this.question_count_live >= this.question_count)
			if((q = this.questionaire.GetNextQuestion()) == null)
            {
                this.Hide();
                eval_form.setStartForm(this.start_form);
                eval_form.ShowDialog();
            }
            else
            {
				this.textBox1.Text = q.GetText();
				radioButton1.Text = q.GetAnswer(0);
				radioButton2.Text = q.GetAnswer(1);
				radioButton3.Text = q.GetAnswer(2);
				radioButton4.Text = q.GetAnswer(3);
            }
        }

        private void back_button_Click(object sender, EventArgs e)
        {
			Question q;
            if ((q = this.questionaire.GetPreviousQuestion()) == null )
            {

            }
            else
            {
				this.textBox1.Text = q.GetText();
				radioButton1.Text = q.GetAnswer(0);
				radioButton2.Text = q.GetAnswer(1);
				radioButton3.Text = q.GetAnswer(2);
				radioButton4.Text = q.GetAnswer(3);
			}
        }

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
