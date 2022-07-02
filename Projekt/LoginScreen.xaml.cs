using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
            try
            {
                using (DataContext context = new DataContext())
                {
                    Logowanie admin = new Logowanie()
                    {
                        Login = "admin",
                        Password = "admin",
                        Role = "Admin"
                    };
                    context.Add(admin);
                    context.SaveChanges();
                }
            }
            catch(Exception exc)
            {
                
            }

        }


        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=application;Trusted_Connection=True;");

            try
            {
                if(sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT COUNT(1) FROM Logon WHERE Login=@Login AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Login", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if(count == 1)
                {
                    MainWindow dashboard = new MainWindow();
                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login or password is incorrect");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
