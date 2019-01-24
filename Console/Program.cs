using Application.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Domain.Entities;
using Application.Domain.Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Services.personService.Add(new Person() { Name = "Teste", Age = 25 });
            foreach(var p in Services.personService.GetAll())
            {
                Console.WriteLine(p.Name);
            }
            
        }
    }
}

