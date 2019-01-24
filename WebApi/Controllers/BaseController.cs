using Application.Domain.DataTransferObjects;
using Application.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebApi.Controllers
{
    public abstract class BaseController<TEntity> : ApiController where TEntity : class
    {
        public readonly IServiceBase<TEntity> service = null;
        public BaseController(IServiceBase<TEntity> Service)
        {
            service = Service;
            /*if (service == null)
            {
                service = (IBaseService<TEntity>)Services.Kernel.Get(typeof(IBaseService<TEntity>));
            }*/
        }
        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
       
        public virtual int GetEntityId(TEntity entity)
        {
            return 0;
        }

        protected override void Dispose(bool disposing)
        {
            service.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        [Route("")]
        // GET: api/Entity
        public JsonResult<List<TEntity>> GetAll()
        {
            return Json(service.GetAll().ToList());
        }

        [HttpGet]
        [Route("{id}")]
        // GET: api/Entity/5
        public JsonResult<TEntity> Get(int id)
        {
            return Json(service.Get(id));
        }

        [HttpPost]
        [Route("")]
        // POST: api/Entity
        public JsonResult<ResultDTO> Post([FromBody]TEntity value)
        {
            string ret = service.Add(value);
            if (string.IsNullOrWhiteSpace(ret))
                return Json(new ResultDTO() { Success = true, Message = "", Id = this.GetEntityId(value) });
            else
                return Json(new ResultDTO() { Success = false, Message = ret });
        }
        [HttpPut]
        [Route("{id}")]
        // PUT: api/Entity/5
        public JsonResult<ResultDTO> Put(int id, [FromBody]TEntity value)
        {
            string ret = service.Update(value);
            if (string.IsNullOrWhiteSpace(ret))
                return Json(new ResultDTO() { Success = true, Message = "" });
            else
                return Json(new ResultDTO() { Success = false, Message = ret });
        }

        [HttpDelete]
        [Route("{id}")]
        // DELETE: api/Entity/5
        public JsonResult<ResultDTO> Delete(int Id)
        {
            string ret = service.Remove(Id);
            if (string.IsNullOrWhiteSpace(ret))
                return Json(new ResultDTO() { Success = true, Message = "" });
            else
                return Json(new ResultDTO() { Success = false, Message = ret });
        }
        
    }
}