using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameMainScreen
{
    public partial class TESTBENCH_MainMenu : Form
    {
        public TESTBENCH_MainMenu()
        {
            InitializeComponent();
        }

        private void GameMainMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("..\\..\\..\\APP_ServerAssembly\\bin\\Release\\net8.0\\APP_ServerAssembly.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error launching console app: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("..\\..\\..\\APP_ClientAssembly\\bin\\Release\\net8.0\\APP_ClientAssembly.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error launching console app: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
