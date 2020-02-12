namespace DataGridSample.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    [Table("UserAdress")]
    public partial class UserAdress : INotifyPropertyChanged
    {

        private int id;
        private int? numero;
        private string voie;
        private string codePostal;
        private string ville;

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string str = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(str));
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserAdress()
        {
            Users = new HashSet<User>();
            numero = 0;
            voie = "";
            codePostal = "";
            ville = "";
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get => id;
            set
            {
                if (value != 0 && id == 0)
                {
                    id = value;
                    NotifyPropertyChanged();
                }
               

            }
        }



        public int? Numero
        { 
            get=>numero;
            set 
            {
                if (value != numero)
                {
                    numero = value > 0 ? value :0;
                    NotifyPropertyChanged();
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Numero)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UserAdressToString)));
                    
                }


            }
        }

        [Required]
        [StringLength(250)]
        public string Voie
        {
            get => voie;
            set
            {
                if (value != voie)
                {
                    voie = value;
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Voie)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UserAdressToString)));
                    NotifyPropertyChanged();
                }

            }
        }

        [Required]
        [StringLength(6)]
        public string CodePostal
        {
            get => codePostal;
            set
            {
                if (value != codePostal)
                {
                    codePostal = value;
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CodePostal)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UserAdressToString)));
                    NotifyPropertyChanged();
                }

            }
        }

        [Required]
        [StringLength(250)]
        public string Ville
        {
            get => ville;
            set
            {
                if (value != ville)
                {
                    ville = value;
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ville)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UserAdressToString)));
                    NotifyPropertyChanged();
                }

            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }

        public string UserAdressToString 
        {
            get => (numero >0 ? numero.ToString(): "" )+
                ((voie.Length != 0) ? (", " + voie) : "") +
                ((codePostal.Length != 0) ? ("\n " + codePostal)+", "+ville : "")
                ;
        }
    }
}
