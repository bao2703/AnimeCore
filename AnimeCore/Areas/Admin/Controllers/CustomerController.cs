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
    public class CustomerController : AdminController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            var model = _customerRepository.GetAll();
            return View(model);
        }

        public IActionResult Add()
        {
            ViewData["Action"] = "Add";
            var model = new Customer();
            return PartialView("_AddEditPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Customer model)
        {
            ViewData["Action"] = "Add";
            if (ModelState.IsValid)
            {
                await _customerRepository.AddAsync(model);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView("_AddEditPartial", model);
        }
    }
}