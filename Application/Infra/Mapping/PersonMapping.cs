using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infra.Mapping
{
    public class PersonMapping : EntityTypeConfiguration<Person>
    {
        public PersonMapping()
        {
            HasKey(c => c.Id);
            Property(p => p.Name);
            Property(p => p.Age);            
        }
    }
}
