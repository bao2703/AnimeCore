using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class InvoiceController : AdminController
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceController(IUnitOfWork unitOfWork, IInvoiceRepository repository)
        {
            _unitOfWork = unitOfWork;
            _invoiceRepository = repository;
        }

        public IActionResult Add(int customerId)
        {
            var model = new Invoice();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Invoice model)
        {
            return View(model);
        }
    }
}