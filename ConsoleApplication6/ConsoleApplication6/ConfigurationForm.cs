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
    public partial class ConfigurationForm : Form
    {
        private StartForm start_form;
        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
