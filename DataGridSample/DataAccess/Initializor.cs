namespace DataGridSample.DataAccess
{
    using DataGridSample.DataAccess;
    using DataGridSample.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class Initializor : DropCreateDatabaseAlways<EFContexte>
    {

        protected override void Seed(EFContexte context)
        {
            base.Seed(context);

            List<UserAdress> adresses = new List<UserAdress>()  // ObservableCollection<User>
            {
                new UserAdress(){Numero=52,Voie="rue du commerces",CodePostal="69100",Ville="Villeurbanne" },
                new UserAdress(){Numero=5,Voie="rue de la republique",CodePostal="69001",Ville="Lyon" },
                new UserAdress(){Numero=27, Voie="rue du commerces",CodePostal="69001",Ville="Lyon" }
            }
            ;

            List<User> users = new List<User>()  // ObservableCollection<User>
            {
                new User (){Nom="DUPON",Prenom="Maxim",Age= 42, Genre=GenreUser.Masculin, Profession="Ouvrier Agricol" },
                new User (){Nom="DURON",Prenom="Amelie", Age=38, Genre=GenreUser.Femenin,Profession="Médecin",UserAdress = adresses[0] },
                new User (){Nom="DUBOIS", Prenom = "Christine", Age = 47, Genre = GenreUser.Femenin, Profession="Directeur de banque"},
                new User (){Nom="MARTIN", Prenom = "Thomas", Age= 24, Genre= GenreUser.Masculin, Profession="Ingénieur",UserAdress= adresses[2]},
                new User (){Nom="BERNARD", Prenom = "Maxim", Age= 22,  Genre=GenreUser.Masculin, Profession="Boulangé"},
                new User (){Nom="ROBERT", Prenom = "Maxim", Age= 72, Genre= GenreUser.Masculin, Profession="Retraité",UserAdress= adresses[1]},
                new User (){Nom="DUPON", Prenom = "Maxim", Age= 42,  Genre=GenreUser.Masculin, Profession="enseignant"},
                new User (){Nom="DURON", Prenom = "Ugo", Age= 42, Genre= GenreUser.Masculin, Profession="Médecin",UserAdress=  adresses[0]},
                new User (){Nom = "DUBOIS", Prenom = "Christine", Age= 47, Genre=GenreUser.Femenin, Profession="Ouvrier"},
            }
            ;



            //foreach (User user in users)
            //{

            //    if (user.UserAdress != null)
            //    {
            //        List<UserAdress> userAdresses = context.UserAdresses.ToList();
            //        int nbAdresse = context.UserAdresses.ToList().Where(a =>
            //               a.Numero == user.UserAdress.Numero
            //            ).Count();

            //        nbAdresse = context.UserAdresses.ToList().Where(a =>
            //               a.Numero == user.UserAdress.Numero
            //            && a.Voie == user.UserAdress.Voie
            //            ).Count();

            //        nbAdresse = context.UserAdresses.ToList().Where(a =>
            //               a.Numero == user.UserAdress.Numero
            //            && a.Voie == user.UserAdress.Voie
            //            && a.CodePostal == user.UserAdress.CodePostal
            //            ).Count();

            //        nbAdresse = context.UserAdresses.ToList().Where(a =>
            //               a.Numero == user.UserAdress.Numero
            //            && a.Voie == user.UserAdress.Voie
            //            && a.CodePostal == user.UserAdress.CodePostal
            //            && a.Ville == user.UserAdress.Ville
            //            ).Count();


            //        nbAdresse = context.UserAdresses.ToList().Where(a =>
            //               a.Numero == user.UserAdress.Numero
            //            && a.Voie == user.UserAdress.Voie
            //            && a.CodePostal == user.UserAdress.CodePostal
            //            && a.Ville == user.UserAdress.Ville
            //            && a.Pays == user.UserAdress.Pays
            //            ).Count();


            //        if (context.UserAdresses.ToList().Where(a => 
            //               a.Numero == user.UserAdress.Numero
            //            && a.Voie == user.UserAdress.Voie
            //            && a.CodePostal == user.UserAdress.CodePostal
            //            && a.Ville == user.UserAdress.Ville
            //            && a.Pays == user.UserAdress.Pays
            //            ).Count() == 0)
            //        {
            //            try
            //            {
            //                context.UserAdresses.Add(user.UserAdress);
            //            }
            //            catch (Exception)
            //            {

            //            }
            //        }

            //    }
            //}

            foreach (User user in users)
            {
                try
                {
                    context.Users.Add(user);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

        }
    }
}
