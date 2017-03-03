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
        private Controller controller;
        public StartForm()
        {
            InitializeComponent();
        }

        public StartForm(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            controller.ConfigButtonClicked();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           controller.StartButtonClicked();
        }

        public Label GetNameLabel()
        {
            return this.nameLabel;
        }

        public ListView GetListViewHistory()
        {
            return this.listView1;
        }

        public ListBox GetListBoxQuestionaire()
        {
            return this.listBox1;
        }
    }
}
