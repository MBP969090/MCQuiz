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
    public partial class StartForm : Form
    {
        private ConfigurationForm config_form;
        private QuestionForm ques_form;
        private EvaluationForm eval_form;
        public StartForm()
        {
            InitializeComponent();
        }

        public StartForm(ConfigurationForm config_form, QuestionForm ques_form, EvaluationForm eval_form)
        {
            InitializeComponent();
            this.config_form = config_form;
            this.ques_form = ques_form;
            this.eval_form = eval_form;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            config_form.setStartForm(this);
            config_form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ques_form.setEvalForm(this.eval_form);
            ques_form.setStartForm(this);
            ques_form.ShowDialog();
        }
    }
}
