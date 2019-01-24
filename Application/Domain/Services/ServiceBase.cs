using Application.Domain.Entities;
using Application.Domain.Services.Interfaces;
using Application.Infra;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Services
{
    class ServiceBase
    {
    }

    public abstract class ServiceBase<T> : IDisposable, IServiceBase<T> where T : class
    {
        protected readonly BaseContext _db;

        public ServiceBase(BaseContext context)
        {
            this._db = context;
        }

        public string Add(T entity)
        {
            _db.Set<T>().Add(entity);
            return this.SaveChanges();            
        }

        public T Get(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>();
        }

        public string Update(T entity)
        {
            try
            {
                var auxentity = _db.Entry(entity);
                auxentity.State = System.Data.Entity.EntityState.Modified;                
                return this.SaveChanges();
            }
            catch
            {
                return "Error while updating.";
            }
        }

        public string Remove(int Id)
        {
            try
            {
                var entity = Get(Id);
                _db.Set<T>().Attach(entity);
                _db.Entry(entity).State = EntityState.Deleted;
                return this.SaveChanges();                

            }
            catch
            {
                return "Error while deleting.";
            }

        }


        protected string SaveChanges()
        {
            try
            {
                _db.SaveChanges();
                return "";
            }
            catch (DbEntityValidationException erro)
            {
                string mensagem = "";
                foreach (DbEntityValidationResult entityvalidationErrors in erro.EntityValidationErrors)
                    foreach (DbValidationError validationError in entityvalidationErrors.ValidationErrors)
                        mensagem += string.Format("Entity: {0} \nProperty: {1} \nError: {2}\n\r", entityvalidationErrors.Entry, validationError.PropertyName, validationError.ErrorMessage);
                return mensagem;
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    if (e.InnerException.InnerException != null)
                        return e.InnerException.InnerException.Message;
                    else
                        return e.InnerException.Message;
                }
                else
                    return e.Message;
            }
        }

        public void Dispose()
        {
            this._db.Dispose();
        }
    }
}
