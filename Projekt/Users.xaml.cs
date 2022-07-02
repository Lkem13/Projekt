using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        public List<Logowanie> DBUsers { get; private set; }

        public Users()
        {
            InitializeComponent();
        }

        public void CreateUser()
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    var login = LoginTextBox.Text;
                    var password = PasswordTextBox.Text;

                    if(login != "" && password != "")
                    {
                        Logowanie admin = new Logowanie()
                        {
                            Login = login,
                            Password = password
                        };
                        context.Add(admin);
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong!");
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Login already exists");
            }


        }

        public void ReadUser()
        {
            using (DataContext context = new DataContext())
            {
                DBUsers = context.Logon.ToList();
                ItemList.ItemsSource = DBUsers;
            }

        }

        public void UpdateUser()
        {


            using (DataContext context = new DataContext())
            {
                Logowanie selectedUser = ItemList.SelectedItem as Logowanie;

                var login = LoginTextBox.Text;
                var password = PasswordTextBox.Text;

                if (login != "" && password != "")
                {
                    Logowanie user = context.Logon.Find(selectedUser.Id);

                    user.Login = login;
                    user.Password = password;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteUser()
        {

            using (DataContext context = new DataContext())
            {
                Logowanie selectedUser = ItemList.SelectedItem as Logowanie;

                if (selectedUser != null)
                {
                    Logowanie user = context.Logon.Single(x => x.Id == selectedUser.Id);

                    context.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        public void Return()
        {
            MainWindow dashboard = new MainWindow();
            dashboard.Show();
            this.Close();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            CreateUser();
            ReadUser();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            ReadUser();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateUser();
            ReadUser();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteUser();
            ReadUser();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            Return();
        }
    }
}
