using System.Collections.Generic;
using System.Threading.Tasks;
using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class BannerAdsController : AdminController
    {
        private readonly IBannerAdsRepository _bannerAdsRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BannerAdsController(IUnitOfWork unitOfWork, IBannerAdsRepository bannerAdsRepository,
            IInvoiceRepository invoiceRepository)
        {
            _unitOfWork = unitOfWork;
            _bannerAdsRepository = bannerAdsRepository;
            _invoiceRepository = invoiceRepository;
        }

        public IActionResult Index()
        {
            var model = _bannerAdsRepository.GetAll();
            return View(model);
        }

        public IActionResult Add(int customerId)
        {
            ViewData["Action"] = "Add";
            ViewData["CustomerId"] = customerId;
            return PartialView("_AddEditPartial", new BannerAds());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(BannerAds model, int customerId)
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