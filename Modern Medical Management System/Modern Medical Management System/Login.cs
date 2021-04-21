using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Modern_Medical_Management_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Registration().Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown) 
                { Application.Exit(); }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = tbName.Text.Trim();
            string password = tbPassword.Text.Trim();
            
            var conn = DBConnection.Connect();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string query = string.Format("select * from users where Name='{0}' and Password='{1}'", name, password);
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (cmd.ExecuteReader().Read())
                {
                    MessageBox.Show("Login Completed");
                    this.Hide();
                    new DashBord().Show(); 
                }
                else
                {
                    MessageBox.Show("Invalid User Name or Password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
