using Avalonia.Controls;
using HarfBuzzSharp;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System;
using demo2ex.Entitymodels;

namespace demo2ex
{
    public class ClientPresenter : Client
    {
        public int ClientID { get => this.Id; }
        public int ClientGender { get => this.Gendercode; }
        public string ClientName { get => this.Firstname; }
        public string ClientLastName { get => this.Lastname; }
        public string ClientPatronymic { get => Patronymic; }
        public DateTime? ClientBirthday { get => Birthday; }
        public string ClientNumberPhone { get => Phone; }
        public DateTime? ClientLastTimeOnline { get => Registrationdate; }
        public string ClientEmail { get => Email; }
        public ObservableCollection<Tags> ClientTags { get; set; }

    }
    public class Tags : Tag
    {
        public string TagTitle { get => this.Title; set => TagTitle = value; }
        public string Color { get => this.Color; set => Color = value; }
    }
    public partial class MainWindow : Window
    {

        private List<ClientPresenter> _clients = new List<ClientPresenter>();
        private ObservableCollection<ClientPresenter> _displayClients = new ObservableCollection<ClientPresenter>();

        private string[] SortValues = new string[] { "Фамилия", "Последнее посещение", "Количество посещений" };

        private string[] FilterValues = new string[] { "Все", "Мужчина", "Женщина" };


        public MainWindow()
        {

            InitializeComponent();

            using (var dbContext = new ShaluhinContext())
            {
                _clients = dbContext.Clients.Select(clients => new ClientPresenter
                {
                    Firstname = clients.Firstname,
                    Lastname = clients.Lastname,
                    Patronymic = clients.Patronymic,
                    Gendercode = clients.Gendercode,
                    Birthday = clients.Birthday,
                    Phone = clients.Phone,
                    Email = clients.Email
                }).ToList();
                _displayClients = new ObservableCollection<ClientPresenter>(_clients);
                FilterComboBox.ItemsSource = FilterValues;
                SortComboBox.ItemsSource = SortValues;
                ClientsListBox.ItemsSource = _displayClients;

            }

        }
    }