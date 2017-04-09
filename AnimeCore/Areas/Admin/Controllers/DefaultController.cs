using System.Threading.Tasks;
using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Core;

namespace AnimeCore.Areas.Admin.Controllers
{
    public abstract class DefaultController<TEntity, TRepository> : AdminController where TEntity : Entity, new()
        where TRepository : IBaseRepository<TEntity>
    {
        private readonly TRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        protected DefaultController(IUnitOfWork unitOfWork, TRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        protected virtual string AddPartialViewName { get; set; } = "_AddPartial";
        protected virtual string EditPartialViewName { get; set; } = "_EditPartial";
        protected virtual string DeletePartialViewName { get; set; } = "_DeletePartial";

        public virtual IActionResult Index()
        {
            var model = _repository.GetAll();
            return View(model);
        }

        public virtual IActionResult Add()
        {
            var model = new TEntity();
            return PartialView(AddPartialViewName, model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Add(TEntity model)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(model);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView(AddPartialViewName, model);
        }

        public virtual IActionResult Edit(int id)
        {
            var model = _repository.FindById(id);
            if (model == null)
            {
                return NotFound();
            }
            return PartialView(EditPartialViewName, model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(TEntity model)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(model);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView(EditPartialViewName, model);
        }

        public virtual IActionResult Delete(int id)
        {
            var model = _repository.FindById(id);
            if (model == null)
            {
                return NotFound();
            }
            return PartialView(DeletePartialViewName, model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Delete(TEntity model)
        {
            if (ModelState.IsValid)
            {
                _repository.Remove(model);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView(DeletePartialViewName, model);
        }
    }
}