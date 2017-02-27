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
        private Controller controller;
        public ConfigurationForm(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.SaveButtonClicked();
        }
    }
}
