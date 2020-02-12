using System;
using DataGridSample.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DataGridSample.Models;
using DataGridSample.DataManager;
using System.Linq;

namespace DataGridSample.ViewModel
{
    public class FicheClientsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<User> users;  // ObservableCollection<User>
        private readonly DataManager<User> dmUser = new DataManager<User>();
        private readonly DataManager<UserAdress> dmAdress = new DataManager<UserAdress>();
        //private User userSelected;
        private ICommand addUser;
        private ICommand removeUser;
        private ICommand editeUser;
        private User userSelected = new User()
        {
            Age = 20,
            Nom = "",
            Prenom = "",
            Profession = "",
            Adress_Id = 0,
            UserAdress = new UserAdress()
            {
                Numero = 0,
                Voie = "",
                CodePostal = "",
                Ville = ""
            }
        };
        private ObservableCollection<UserAdress> adresses;
        private ICommand addAdress;

        //private ICommand editeUser;

        public event PropertyChangedEventHandler PropertyChanged;
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
        public ObservableCollection<UserAdress> Adresses  // ObservableCollection<User>
        {
            get => adresses;
            set
            {
                if (adresses != value)
                {
                    adresses = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public User UserSelected
        {
            get => userSelected;
            set
            {
                if (userSelected != value)
                {
                    bool addAdress = false;

                    //if (value.UserAdress == null
                    //    || Adresses.Where(
                    //                a =>
                    //                a.Numero == value.UserAdress.Numero
                    //                && a.Voie == value.UserAdress.Voie
                    //                && a.CodePostal == value.UserAdress.CodePostal
                    //                && a.Ville == value.UserAdress.Ville
                    //                ).Count() == 0
                    //)
                    if (value.UserAdress == null
                        || Adresses.Where(
                                    a =>
                                    a.UserAdressToString.Equals(value.UserAdress.UserAdressToString)
                                    ).Count() == 0
                    )
                    {
                        userSelected.Adress_Id = 0;
                        value.UserAdress = (value.UserAdress !=null)? value.UserAdress :  new UserAdress();
                        value.UserAdress.Id = 0;
                        addAdress = true;

                    }
                    userSelected = value;
                    if (addAdress)
                    {
                        Adresses.Add(userSelected.UserAdress);                        
                    }
                    NotifyPropertyChanged();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Users)));
                }
            }
        }

        public ICommand InitializeUser { get; } = new RelayCommand<User>((user) =>
        {
            user = new User
            {
                Age = 0,
                Nom = "",
                Prenom = "",
                Profession = "",
                Adress_Id = 0,
                UserAdress = new UserAdress()
            };
        });

        public ICommand AddUser
        {
            get
            {
                if (addUser == null)
                {
                    addUser = new RelayCommand<object>((obj) => users.Add(userSelected));
                }
                return addUser;
            }
        }
        public ICommand AddAdress
        {
            get
            {
                if (addAdress == null)
                {
                    addAdress = new RelayCommand<object>((obj) => { userSelected.UserAdress.Id = 0; Adresses.Add(userSelected.UserAdress); });
                }
                return addAdress;
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

        public ICommand EditeUser
        {
            get
            {
                if (editeUser == null)
                {
                    editeUser = new RelayCommand<User>((user) => UserSelected = user);
                }
                return editeUser;
            }
        }


        public FicheClientsViewModel()
        {
            users = new ObservableCollection<User>()  // ObservableCollection<User>
            //{
            //    new User (){Nom="DUPON",Prenom="Maxim",Age= 42, Genre=GenreUser.Masculin, Profession="Ouvrier Agricol" },
            //    new User (){Nom="DURON",Prenom="Amelie", Age=38, Genre=GenreUser.Femenin,Profession="Médecin"
            //                ,UserAdress=new UserAdress(){Numero=5,Voie="rue du commerces",CodePostal="69100",Ville="Villeurbanne" } },
            //    new User (){Nom="DUBOIS", Prenom = "Christine", Age = 47, Genre = GenreUser.Femenin, Profession="Directeur de banque"},
            //    new User (){Nom="MARTIN", Prenom = "Thomas", Age= 24, Genre= GenreUser.Masculin, Profession="Ingénieur"
            //                ,UserAdress=new UserAdress(){Numero=5,Voie="rue de la republique",CodePostal="69001",Ville="Lyon"}},
            //    new User (){Nom="BERNARD", Prenom = "Maxim", Age= 22,  Genre=GenreUser.Masculin, Profession="Boulangé"},
            //    new User (){Nom="ROBERT", Prenom = "Maxim", Age= 72, Genre= GenreUser.Masculin, Profession="Retraité"},
            //    new User (){Nom="DUPON", Prenom = "Maxim", Age= 42,  Genre=GenreUser.Masculin, Profession="enseignant"},
            //    new User (){Nom="DURON", Prenom = "Amelie", Age= 38, Genre= GenreUser.Femenin, Profession="Médecin"},
            //    new User (){Nom = "DUBOIS", Prenom = "Christine", Age= 47, Genre=GenreUser.Femenin, Profession="Ouvrier"},
            //}
            ;
            //int c = dmUser.ToList().Count;
            foreach (User user in dmUser.ToList())
            {
                users.Add(user);
            }

            adresses = new ObservableCollection<UserAdress>();
            //c = dmAdress.ToList().Count;
            foreach (UserAdress adress in dmAdress.ToList())
            {
                adresses.Add(adress);
            }


        }
    }
}