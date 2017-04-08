using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Core;

namespace AnimeCore.Areas.Admin.Controllers
{
    public abstract class DefaultController<TEntity, TRepository> : AdminController where TEntity : Entity, new() where TRepository : IBaseRepository<TEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TRepository _repository;

        protected DefaultController(IUnitOfWork unitOfWork, TRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public virtual IActionResult Index()
        {
            var model = _repository.GetAll();
            return View(model);
        }

        public virtual IActionResult Add()
        {
            ViewData["Action"] = "Add";
            var model = new TEntity();
            return PartialView("_AddEditPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Add(TEntity model)
        {
            ViewData["Action"] = "Add";
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(model);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView("_AddEditPartial", model);
        }

        public virtual IActionResult Edit(int id)
        {
            ViewData["Action"] = "Edit";
            var model = _repository.FindById(id);
            if (model == null)
            {
                return NotFound();
            }
            return PartialView("_AddEditPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(TEntity model)
        {
            ViewData["Action"] = "Edit";
            if (ModelState.IsValid)
            {
                _repository.Update(model);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView("_AddEditPartial", model);
        }

        public virtual IActionResult Delete(int id)
        {
            var model = _repository.FindById(id);
            if (model == null)
            {
                return NotFound();
            }
            return PartialView("_DeletePartial", model);
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
            return PartialView("_DeletePartial", model);
        }
    }
}