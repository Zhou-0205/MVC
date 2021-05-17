using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    //public class SqlDbContext<T> : SqlDbContext where T : BaseEntity
    //{
    //    public IDbSet<T> Entities { get; set; }
    //}
    public class SqlDbContext : DbContext
    {
        public SqlDbContext() : base("18bang")
        {
            Database.Log = s => Debug.WriteLine(s);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Article>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
