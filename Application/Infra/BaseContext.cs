using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infra
{
    public class BaseContext : DbContext
    {
        public BaseContext()
        : base("ConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        
        public DbSet<Person> Persons { get; set; }
    }
}
