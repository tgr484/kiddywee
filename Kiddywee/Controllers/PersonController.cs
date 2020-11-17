using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Kiddywee.DAL.ViewModels.PersonViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiddywee.Controllers
{
    public class PersonController : BaseController
    {
        public PersonController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<IActionResult> Index()
        {
            var people = await _unitOfWork.People
                .GetAsync(p => p.OrganizationId == _organizationId);

            var model = Person.Init(people);
            return View(model);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var person = Person.Create(model);
                await _unitOfWork.People.Insert(person);
                var personResult = await _unitOfWork.SaveAsync();
                if(personResult.Succeeded)
                {
                    var childInfo = ChildInfo.Create(model, new Guid("fc1d2fc6-c06f-4dda-aac3-8fb37c2d2d63"), _userId);
                    await _unitOfWork.ChildInfos.Insert(childInfo);
                    var childResult = await _unitOfWork.SaveAsync();
                    if(childResult.Succeeded)
                    {
                        person.ChildInfoId = childInfo.Id;
                        await _unitOfWork.SaveAsync();
                    }
                }

                return Redirect(Request.Headers["Referer"].ToString());
            } 
            return View(model);
        }
    }
}
