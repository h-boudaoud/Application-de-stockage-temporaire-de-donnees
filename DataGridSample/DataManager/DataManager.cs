
using DataGridSample.DataAccess;
using DataGridSample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridSample.DataManager
{
    public class DataManager<T> : IDataManager<T> where T : class
    {
        private EFContexte SqlContexte { get; set; } = new EFContexte();

        public List<T> ToList() => SqlContexte.Set<T>().ToList();

        public T GetById(int id)
        {
            try
            {
                return SqlContexte.Set<T>().Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }


        public string Ajouter(T entity)
        {
            try
            {
                if(entity is UserAdress)
                SqlContexte.Set<T>().Add(entity);
                SqlContexte.SaveChanges();
                return "Succes";

            }
            catch (Exception e)
            {
                return $"Error : {e.Message}";
            }
        }

        public string Modifier(int id, T entity)
        {
            try
            {

                var obj = SqlContexte.Set<T>().Find(id);
                if (obj != null)
                {
                    SqlContexte.Entry<T>(obj).CurrentValues.SetValues(entity);
                    SqlContexte.SaveChanges();
                }
                return "Succes";
            }
            catch (Exception e)
            {
                return $"Error : {e.Message}";
            }
        }

        public string Supprimer(T entity)
        {           
            try
            {
                SqlContexte.Set<T>().Remove(entity);
                SqlContexte.SaveChanges();
                return "Succes";
            }
            catch (Exception e)
            {

                return $"Error : {e.Message}";
            }

        }

        public string Supprimer(int id) => this.Supprimer(GetById(id));

        
    }
}
