using DataGridSample.Models;
using System.Data.Entity;

namespace DataGridSample
{
    internal interface IEFContexte
    {
        DbSet<User> Users { get; set; }
        DbSet<UserAdress> UserAdresses { get; set; }
    }
}
