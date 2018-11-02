using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardListenerTestService
{
    public partial class Form1 : Form
    {
        private ServiceTester serviceTester;
        public Form1()
        {
            InitializeComponent();
            serviceTester = new ServiceTester();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            serviceTester.StartTest(null);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            serviceTester.StopTest();
        }
    }
}
