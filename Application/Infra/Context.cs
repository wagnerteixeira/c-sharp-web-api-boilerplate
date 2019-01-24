using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infra
{

    public class Context : BaseContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //set the table entities to plural name
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //enable cascace delete One to Many
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //enable cascace delete Many to Many
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //set database nvarchartype to c# string type
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("nvarchar"));
            //set varchar to max 300
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(300));

            //set Id to key
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //get all EntityTypeConfiguration of project and mapping to modelbuilder
            //case has two and many types of database, create a specified EntityTypeConfigurationDatabase 
            //and extend the configurations classes to the database

            IEnumerable<Type> typesToRegister = null;

            typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                            .Where(type => !String.IsNullOrEmpty(type.Namespace))
                            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            //modelBuilder.Entity<Pessoa>().HasRequired(p => p.Contatos).WithMany(p=> Contatos).WillCascadeOnDelete(true);

        }
    }
}
