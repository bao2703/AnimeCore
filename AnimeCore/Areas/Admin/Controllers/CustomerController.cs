using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class CustomerController : DefaultController<Customer, ICustomerRepository>
    {
        public CustomerController(IUnitOfWork unitOfWork, ICustomerRepository repository) : base(unitOfWork, repository)
        {
        }
    }
}