using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeAppThirteen
{
    public partial class EmployeeAppUI : Form
    {
        public EmployeeAppUI()
        {
            InitializeComponent();
        }
        EmployeeApp aeEmployeeApp = new EmployeeApp();

        private void saveButton_Click(object sender, EventArgs e)
        {
            aeEmployeeApp.name = nameTextBox.Text;
            aeEmployeeApp.email = emailTextBox.Text;
            aeEmployeeApp.address = addressTextBox.Text;
            aeEmployeeApp.salary = Convert.ToDouble(salaryTextBox.Text);


            if (IsEmailExist(aeEmployeeApp.email))
            {
                MessageBox.Show("Email Already Exist");
                return;
            }

            String connectionString =
                @"SERVER= PC-301-22\SQLEXPRESS; DATABASE= EmployeeInfoDB; Integrated Security = true";
            SqlConnection connection =new SqlConnection(connectionString);


            String query = "INSERT INTO EmployeeT VALUES('" + aeEmployeeApp.name + "','" + aeEmployeeApp.address + "','" +
                           aeEmployeeApp.email + "','" + aeEmployeeApp.salary + "')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected= command.ExecuteNonQuery();
            connection.Close();

            if (rowAffected > 0)
            {
                MessageBox.Show("Inserted Successfully!");

            }
            else
            {
                MessageBox.Show("Insertion Failed");
            }
        }

        public bool IsEmailExist(string email)
        {

            

            String connectionString =
               @"SERVER= PC-301-22\SQLEXPRESS; DATABASE= EmployeeInfoDB; Integrated Security = true";
            SqlConnection connection = new SqlConnection(connectionString);


            String query = "SELECT * FROM EmployeeT WHERE Email ='"+aeEmployeeApp.email+"' ";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isEmailExist = false;
            while (reader.Read())
            {
                isEmailExist = true;
                break;
            }
            reader.Close();
            connection.Close();
            return isEmailExist;

        }
    }
    //comment
}
