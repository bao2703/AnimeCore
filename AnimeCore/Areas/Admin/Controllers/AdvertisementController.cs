using System.Collections.Generic;
using System.Threading.Tasks;
using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class AdvertisementController : AdminController
    {
        private readonly IAdsLocationRepository _adsLocationRepository;
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AdvertisementController(IUnitOfWork unitOfWork, IAdvertisementRepository advertisementRepository,
            IAdsLocationRepository adsLocationRepository, IInvoiceRepository invoiceRepository)
        {
            _unitOfWork = unitOfWork;
            _advertisementRepository = advertisementRepository;
            _adsLocationRepository = adsLocationRepository;
            _invoiceRepository = invoiceRepository;
        }

        public IActionResult Index()
        {
            var model = _advertisementRepository.GetAll();
            return View(model);
        }

        public IActionResult Add(int customerId)
        {
            ViewData["Action"] = "Add";
            ViewData["CustomerId"] = customerId;
            return PartialView("_AddEditPartial", new Advertisement());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Advertisement model, int customerId)
        {
            ViewData["Action"] = "Add";
            ViewData["CustomerId"] = customerId;
            if (ModelState.IsValid)
            {
                var invoice = new Invoice
                {
                    CustomerId = customerId,
                    InvoiceDetails = new List<InvoiceDetail>
                    {
                        new InvoiceDetail
                        {
                            Advertisement = model
                        }
                    }
                };
                await _invoiceRepository.AddAsync(invoice);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView("_AddEditPartial", model);
        }
    }
}