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
        private StartForm start_form;
        public EvaluationForm()
        {
            InitializeComponent();
        }

        private void EvaluationForm_Load(object sender, EventArgs e)
        {

        }

        private void back_main_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            start_form.Show();
        }

        public void setStartForm(StartForm start_form)
        {
            this.start_form = start_form;
        }
    }
}
