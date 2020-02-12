namespace DataGridSample.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    [Table("User")]
    public partial class User : INotifyPropertyChanged
    {
        private int id;
        private string nom;
        private string prenom;
        private int age;
        private GenreUser genre;
        private string profession;
        private UserAdress adress;

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string str = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(str));
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get => id;
            set
            {
                if (value != id && id == 0)
                {
                    id = value;
                    //NotifyPropertyChanged();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
                }


            }
        }

        [Required]
        [StringLength(250)]
        public string Nom
        {
            get => nom;
            set
            {
                if (value != nom)
                {
                    nom = value;
                    NotifyPropertyChanged();
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nom)));
                }

            }
        }

        [Required]
        [StringLength(250)]
        public string Prenom
        {
            get => prenom;
            set
            {
                if (value != prenom)
                {
                    prenom = value;
                    NotifyPropertyChanged();
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Prenom)));
                }

            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value != age && value >= 0)
                {
                    age = value;
                    NotifyPropertyChanged();
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Age)));
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
                    NotifyPropertyChanged();
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Genre)));
                }

            }
        }

        [StringLength(250)]
        public string Profession
        {
            get => profession;
            set
            {
                if (value != profession)
                {
                    profession = value;
                    NotifyPropertyChanged();
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Profession)));
                }

            }
        }


        public int? Adress_Id
        {
            get;
            set;

        }


        [ForeignKey("Adress_Id")]
        public virtual UserAdress UserAdress
        {
            get => adress;
            set
            {
                if (value != adress && value != null)
                {
                    adress = value;
                    NotifyPropertyChanged();
                }


            }
        }

    }
}
