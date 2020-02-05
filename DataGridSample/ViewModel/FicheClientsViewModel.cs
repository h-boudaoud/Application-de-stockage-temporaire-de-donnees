using System;
using DataGridSample.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DataGrid_control
{
    public class FicheClientsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<User> users;  // ObservableCollection<User>
        //private User userSelected;
        private ICommand addUser;
        private ICommand removeUser;
        //private ICommand editeUser;

        public void NotifyPropertyChanged([CallerMemberName] string str = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(str));
        }

        public ObservableCollection<User> Users  // ObservableCollection<User>
        {
            get => users;
            set
            {
                if (users != value)
                {
                    users = value;
                    NotifyPropertyChanged();
                }
            }
        }

        //public User UserSelected
        //{
        //    get => userSelected;
        //    set
        //    {
        //        if (userSelected != value)
        //        {
        //            userSelected = value;
        //            NotifyPropertyChanged();
        //        }
        //    }
        //}

        public ICommand InitializeUser { get; } = new RelayCommand<User>((user) =>
        {
            if (user ==null) { user = new User(); }
            //user.Age = 0;
            //user.Nom = "";
            //user.Prenom = "";
            //user.Profession = "";
            user.UserAdress = new Adresse();
        });

        public ICommand AddUser
        {
            get
            {
                if (addUser == null)
                {
                    addUser = new RelayCommand<object>((obj) => users.Add(new User()));
                }
                return addUser;
            }
        }

        public ICommand RemoveUser
        {
            get
            {
                if (removeUser == null)
                {
                    removeUser = new RelayCommand<User>((user) => users.Remove(user));
                }
                return removeUser;
            }
        }

        //public ICommand EditeUser
        //{
        //    get
        //    {
        //        if (editeUser == null)
        //        {
        //            editeUser = new RelayCommand<User>((user) => userSelected = user);
        //        }
        //        return editeUser;
        //    }
        //}


        public FicheClientsViewModel()
        {
            users = new ObservableCollection<User>()  // ObservableCollection<User>
            {
                new User (){Nom="DUPON",Prenom="Maxim",Age= 42, Genre=GenreUser.Masculin, Profession="Ouvrier Agricol" },
                new User (){Nom="DURON",Prenom="Amelie", Age=38, Genre=GenreUser.Femenin,Profession="Médecin"
                            ,UserAdress=new Adresse(){Numero=5,Voie="rue du commerces",CodePostal="69100",Ville="Villeurbanne",Pays="France" } },
                new User (){Nom="DUBOIS", Prenom = "Christine", Age = 47, Genre = GenreUser.Femenin, Profession="Directeur de banque"},
                new User (){Nom="MARTIN", Prenom = "Thomas", Age= 24, Genre= GenreUser.Masculin, Profession="Ingénieur"
                            ,UserAdress=new Adresse(){Numero=5,Voie="rue de la republique",CodePostal="69001",Ville="Lyon",Pays="France" }},
                new User (){Nom="BERNARD", Prenom = "Maxim", Age= 22,  Genre=GenreUser.Masculin, Profession="Boulangé"},
                new User (){Nom="ROBERT", Prenom = "Maxim", Age= 72, Genre= GenreUser.Masculin, Profession="Retraité"},
                new User (){Nom="DUPON", Prenom = "Maxim", Age= 42,  Genre=GenreUser.Masculin, Profession="enseignant"},
                new User (){Nom="DURON", Prenom = "Amelie", Age= 38, Genre= GenreUser.Femenin, Profession="Médecin"},
                new User (){Nom = "DUBOIS", Prenom = "Christine", Age= 47, Genre=GenreUser.Femenin, Profession="Ouvrier"},
        };
        }
    }
}