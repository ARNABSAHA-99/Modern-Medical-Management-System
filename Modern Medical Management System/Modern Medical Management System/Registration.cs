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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        public bool check(string value)
        {
            if (value == null || value == "") { return false; }
            else { return true; }
        }
        private void btnRegistration_Click(object sender, EventArgs e)
        {
            string name = tbName.Text.Trim();
            string email = tbEmail.Text.Trim();
            string moblieNumber = tbMobileNumber.Text.Trim();
            string address = tbAddress.Text.Trim();
            string password = tbPassword.Text.Trim();
            string confirmPassword = tbConfirmPassword.Text.Trim();
            string shift = "";
            string category = "";
            string gender = "";
            try
            {
                shift = gbShift.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked).Text;
                category = gbCategory.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked).Text;
                gender = gbGender.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked).Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
            string date = tbDate.Text.Trim();
            string month = tbMonth.Text.Trim();
            string year = tbYear.Text.Trim();
            string dob = date + "/" + month + "/" + year;
            string image = "";

            int flag = 1;

            if (check(name)) { }
            else { MessageBox.Show("Enter Name"); flag = 0; }
            if (check(email)) { }
            else { MessageBox.Show("Enter Email"); flag = 0; }
            if (check(moblieNumber)) { }
            else { MessageBox.Show("Enter Moblie Number"); flag = 0; }
            if (check(address)) { }
            else { MessageBox.Show("Enter Address"); flag = 0; }
            if (check(password)) { }
            else { MessageBox.Show("Enter Password"); flag = 0; }
            if (check(confirmPassword)) { }
            else { MessageBox.Show("Enter Confirm Password"); flag = 0; }
            if (check(shift)) { }
            else { MessageBox.Show("Enter Shift"); flag = 0; }
            if (check(category)) { }
            else { MessageBox.Show("Enter Category"); flag = 0; }
            if (check(gender)) { }
            else { MessageBox.Show("Enter Gender"); flag = 0; }
            if (check(date)) { }
            else { MessageBox.Show("Enter Date"); flag = 0; }
            if (check(month)) { }
            else { MessageBox.Show("Enter Month"); flag = 0; }
            if (check(year)) { }
            else { MessageBox.Show("Enter Year"); flag = 0; }

            var conn = DBConnection.Connect();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            if (flag == 1)
            {
                string query = string.Format("insert into users values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", name, email, password, moblieNumber, shift, address, category, gender, dob, image);
                try 
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Registration Completed");
                    }
                    else
                    {
                        MessageBox.Show("Registration Failed");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Input Empty");
            }
            conn.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown) { Application.Exit(); }
        }
    }
}
