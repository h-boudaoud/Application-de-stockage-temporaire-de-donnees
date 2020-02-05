using System.ComponentModel;

namespace DataGrid_control
{
    public class Adresse : INotifyPropertyChanged
    {
        private int numero;
        private string voie;
        private string codePostal;
        private string ville;
        private string pays;

        public Adresse()
        {
            this.Numero = 0;
            this.Voie = "";
            this.CodePostal = "";
            this.Ville = "";
            this.Pays = "";
        }
        //public Adresse(int numero, string voie, string codePostal, string ville, string pays)
        //{
        //    this.Numero = numero;
        //    this.Voie = voie;
        //    this.CodePostal = codePostal;
        //    this.Ville = ville;
        //    this.Pays = pays;
        //}

        public int Numero
        {
            get => numero;
            set
            {
                if (value > 0 && value != numero)
                {
                    numero = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Numero)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UserAdressToString)));
                }
            }
        }

        public string Voie
        {
            get => voie;
            set
            {
                if (value != voie)
                {
                    voie = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Voie)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UserAdressToString)));
                }
            }
        }
        public string CodePostal
        {
            get => codePostal;
            set
            {
                if (value != codePostal)
                {
                    codePostal = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CodePostal)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UserAdressToString)));
                }
            }
        }
        public string Ville
        {
            get => ville;
            set
            {
                if (value != ville)
                {
                    ville = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ville)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UserAdressToString)));
                }
            }
        }
        public string Pays
        {
            get => pays;
            set
            {
                if (value != pays)
                {
                    pays = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Pays)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UserAdressToString)));
                }
            }
        }

        public string UserAdressToString => (numero > 0)
                ? $"{numero}, {voie}"
                    + ((codePostal != "") ? $"\n{codePostal}{((ville.Length > 0) ? ','.ToString() : null)} {ville}":"") 
                    + ((pays != "") ? $"\n{pays}":"")
                : "";

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
