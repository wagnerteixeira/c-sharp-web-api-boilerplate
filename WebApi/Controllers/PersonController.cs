using Application.Domain.Entities;
using Application.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/person")]
    public class PersonController : BaseController<Person>
    {
        public PersonController(IPersonService Service)
            : base(Service)
        {

        }
    }
}