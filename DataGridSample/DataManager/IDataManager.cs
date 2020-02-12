using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridSample.DataManager
{
    public interface IDataManager<T> where T : class
    {

        List<T> ToList();

        T GetById(int id);

        string Ajouter(T entity);

        string Modifier(int id, T entity);

        string Supprimer(int id);

        string Supprimer(T entity);
    }
}
