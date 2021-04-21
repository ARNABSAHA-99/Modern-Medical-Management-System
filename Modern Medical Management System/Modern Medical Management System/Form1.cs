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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            string name = tbName.Text.Trim();
            string email = tbEmail.Text.Trim();
            string moblieNumber = tbMobileNumber.Text.Trim();
            string address = tbAddress.Text.Trim();
            string password = tbPassword.Text.Trim();
            string confirmPassword = tbConfirmPassword.Text.Trim();
            var shift = gbShift.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked).Text;
            var category = gbCategory.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked).Text;
            var gender = gbGender.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked).Text;

            var conn = DBConnection.Connect();
            int flag = 1;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                string queryName = "select * from courses where Name = '" + name + "'";
                SqlCommand cmdName = new SqlCommand(queryName, conn);

                if (cmdName.ExecuteReader().Read())
                {
                    MessageBox.Show("Course Name Exist");
                    flag = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                string queryCode = "select * from courses where Course_Code = '" + cCode + "'";
                SqlCommand cmdCode = new SqlCommand(queryCode, conn);

                if (cmdCode.ExecuteReader().Read())
                {
                    MessageBox.Show("Course Code Exist");
                    flag = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (flag == 1)
            {
                string query = string.Format("insert into courses values ('{0}','{1}')", cName, cCode);
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Course Inserted");
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert Course");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Course Already Exist");
            }
            conn.Close();

            RefreshValues();
            var courses = GetAllCourses();
            dtCourses.DataSource = courses;
        }
    }
}
