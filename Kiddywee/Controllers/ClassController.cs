using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Kiddywee.DAL.ViewModels.ClassesViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiddywee.Controllers
{
    [Authorize]
    public class ClassController : BaseController
    {
        public ClassController(IUnitOfWork unitOfWork) : base(unitOfWork)
        { 
            _unitOfWork = unitOfWork; 
        }


        public IActionResult Create(string id)
        { 
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ClassCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var @class = Class.Create(model, _userId);
                await _unitOfWork.Classes.Insert(@class);
                await _unitOfWork.SaveAsync();
                return Redirect(Request.Headers["Referer"].ToString());
            }
            return View(model);
        }
    }
}
