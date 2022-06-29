﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Pracownicy> DBPracownicy { get; private set; }
        public List<Adresy> DBAdresy { get; private set; }
        public List<Stanowiska> DBStanowiska { get; private set; }
        public List<Placowki> DBPlacowki { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            
            /*using (DataContext context = new DataContext())
            {
                Logowanie admin = new Logowanie()
                {
                    Login = "admin",
                    Password = "admin",
                    Role = "Admin"
                };
                context.Add(admin);
                context.SaveChanges();3
            }*/
        }

        public void Create()
        {
            using (DataContext context = new DataContext())
            {
                var imie = ImieTextBox.Text;
                var nazwisko = NazwiskoTextBox.Text;
                var miasto = MiastoTextBox.Text;
                var ulica = UlicaTextBox.Text;
                var mieszkanie = MieszkanieTextBox.Text;
                var stanowisko = StanowiskoTextBox.Text;
                var placowka = PlacowkaTextBox.Text;

                if(imie != "" &&
                    nazwisko != "")
                {
                    Adresy adres = new Adresy() { Ulica = ulica, Mieszkanie = mieszkanie, Miasto = miasto};
                    context.SaveChanges();
                    Stanowiska stanowisk = new Stanowiska() { Stanowisko = stanowisko };
                    context.SaveChanges();
                    Placowki placowk = new Placowki() { Placowka = placowka };
                    context.SaveChanges();
                    context.Pracownik.Add(new Pracownicy() { Imie = imie, Nazwisko = nazwisko, Adres = adres, Stanowisko = stanowisk, Placowka = placowk});
                    context.SaveChanges();
                }
            }
        }

        public void Read()
        {
            using (DataContext context = new DataContext())
            {

                DBPracownicy = context.Pracownik.Include(s => s.Stanowisko).Include(x => x.Placowka).Include(c => c.Adres).ToList();
                ItemList.ItemsSource = DBPracownicy;

            }

        }

        public void Update()
        {


            using (DataContext context = new DataContext())
            {

                Pracownicy selectedUser = ItemList.SelectedItem as Pracownicy;

                var imie = ImieTextBox.Text;
                var nazwisko = NazwiskoTextBox.Text;

                if (imie != null && nazwisko != null)
                {

                    Pracownicy user = context.Pracownik.Find(selectedUser.Id);
                    user.Imie = imie;
                    user.Nazwisko = nazwisko;

                    context.SaveChanges();
                }

            }



        }

        public void Delete()
        {


            using (DataContext context = new DataContext())
            {

                Pracownicy selectedUser = ItemList.SelectedItem as Pracownicy;

                if (selectedUser != null)
                {
                    Pracownicy user = context.Pracownik.Single(x => x.Id == selectedUser.Id);

                    context.Remove(user);
                    context.SaveChanges();

                }
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }
    }
}
