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
        private int question_count;
        private int question_count_live = 0;
        private EvaluationForm eval_form;
        private StartForm start_form;

        public QuestionForm(int question_count)
        {
            InitializeComponent();
            this.question_count = question_count;
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
            if (this.question_count_live >= this.question_count)
            {
                this.question_count_live = 0;
                this.Hide();
                eval_form.setStartForm(this.start_form);
                eval_form.ShowDialog();
            }
            else
            {
                this.question_count_live++;
            }
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            if (this.question_count_live == 0)
            {

            }
            else
            {
                this.question_count_live--;
            }
        }
    }
}
