using DataGridSample.View;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataGrid_control
{
    public class User : INotifyPropertyChanged
    {
        private string nom;
        private string prenom;
        private string profession;
        private Adresse adresse = new Adresse();
        private int age;
        private GenreUser genre;

        //public User()
        //{
        //    this.Nom = "";
        //    this.Prenom = "";
        //    this.Profession = "";
        //    this.age = 0;
        //    this.genre = "";
        //    this.AdresseUser = new Adresse();
        //}

        //public User(string nom, string prenom, int age, char genre, string profession, Adresse adress)
        //{
        //    this.Nom = nom;
        //    this.Prenom = prenom;
        //    this.Profession = profession;
        //    this.age = age > 0 ? age : 0;
        //    this.genre = (genre == 'M') ? "Masculin" : (genre == 'F') ? "Femenin" : "";
        //    this.adresse = adress;
        //}

        //public User(string nom, string prenom, int age, char genre, string profession)
        //{
        //    //if (string.IsNullOrEmpty(nom))
        //    //{
        //    //    throw new System.ArgumentException("message", nameof(nom));
        //    //}

        //    //if (string.IsNullOrEmpty(prenom))
        //    //{
        //    //    throw new System.ArgumentException("message", nameof(prenom));
        //    //}

        //    //if (string.IsNullOrEmpty(profession))
        //    //{
        //    //    throw new System.ArgumentException("message", nameof(profession));
        //    //}

        //    this.Nom = nom;
        //    this.Prenom = prenom;
        //    this.Profession = profession;
        //    this.age = age > 0 ? age : 0;
        //    this.genre = (genre == 'M') ? "Masculin" : (genre == 'F') ? "Femenin" : "";
        //    this.adresse = new Adresse();
        //}

        //public User(string nom, string prenom, int age, string genre, string profession, Adresse adress)
        //{
        //    List<string> genres = new List<string>() { "Masculin", "Femenin" };
        //    this.Nom = nom;
        //    this.Prenom = prenom;
        //    this.Profession = profession;
        //    this.age = age > 0 ? age : 0;
        //    this.genre = (genres.Contains(genre)) ? genre : "";
        //    this.adresse = adress;
        //}


        //public User(string nom, string prenom, int age, string genre, string profession)
        //{
        //    List<string> genres = new List<string>() { "Masculin", "Femenin" };
        //    this.Nom = nom;
        //    this.Prenom = prenom;
        //    this.Profession = profession;
        //    this.age = age > 0 ? age : 0;
        //    this.genre = (genres.Contains(genre)) ? genre : "";
        //    this.adresse = new Adresse();
        //}


        public string Nom 
        { 
            get=>nom;
            set
            {
                if (value != nom)
                {
                    nom = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nom)));
                }
            }
        }

        public string Prenom
        {
            get => prenom;
            set
            {
                if (value != prenom)
                {
                    prenom = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Prenom)));
                }
            }
        }

        public int Age 
        { 
            get => age; 
            set
            { 
                if (value >= 0) 
                { 
                    age = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Age)));
                } 
            } 
        }
        public GenreUser Genre
        {
            get => genre; 
            set
            {
                if (value != genre)
                { 
                    genre = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Genre)));
                }
            }
        }

        public string Profession
        {
            get => profession;
            set
            {
                if (value != profession)
                {
                    profession = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Profession)));
                }
            }
        }


        public Adresse UserAdress
        {
            get => adresse;
            set
            {
                if (value != adresse)
                {
                    adresse = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UserAdress)));
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AdresseToString)));
                }
            }
        }


        //public string AdresseToString
        //{ 
        //    get => (adresse != null && adresse.Numero > 0) 
        //        ? $"{adresse.Numero}, {adresse.Voie}\n{adresse.CodePostal}, {adresse.Ville}\n{adresse.Pays}"
        //        : "";
        //}
              
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
