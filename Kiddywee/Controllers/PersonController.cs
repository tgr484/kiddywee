using Kiddywee.BLL.Core;
using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Kiddywee.DAL.ViewModels.PersonViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiddywee.Controllers
{
    [Authorize]

    public class PersonController : BaseController
    {
        private ICompositeViewEngine _viewEngine;

        public PersonController(IUnitOfWork unitOfWork, ICompositeViewEngine viewEngine) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _viewEngine = viewEngine;
        }

        public async Task<IActionResult> Index(Guid? classId)
        {
            var people = new List<Person>();
            if (!classId.HasValue)
            {
                people = await _unitOfWork.People
                    .GetAsync(p => p.OrganizationId == _organizationId,
                    include: p => p.Include(x => x.StaffInfo)
                                   .Include(x => x.ChildInfo)
                                   .Include(x => x.PersonToClasses)
                                   .Include(x => x.Attendances));
            }
            else
            {
                people = await _unitOfWork.People.GetAsync(p => p.OrganizationId == _organizationId
                    && p.PersonToClasses.Any(x => x.ClassId == classId.Value && x.IsActive),
                    include: p => p.Include(x => x.PersonToClasses)
                                   .Include(x => x.StaffInfo)
                                   .Include(x => x.ChildInfo)
                                   .Include(x => x.Attendances));
            }


            var model = Person.Init(people, classId);
            return View(model);
        }


        #region Create
        [HttpGet]
        public async Task<IActionResult> CreateStaff()
        {
            var classes = await _unitOfWork.Classes.GetAsync(x => x.OrganizationId == _organizationId);
            var organizations = await _unitOfWork.Organizations.GetAsync();
            StaffCreateViewModel model = new StaffCreateViewModel() { Classes = classes, Organizations = organizations };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaff(StaffCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var person = Person.Create(model, _organizationId.Value);
                await _unitOfWork.People.Insert(person);
                var personResult = await _unitOfWork.SaveAsync();
                if (personResult.Succeeded)
                {
                    if (model.Files.Any())
                    {
                        foreach (var f in model.Files)
                        {
                            var medicalInfo = FileInfo.Create(f, _userId, DAL.Enum.EnumFileType.MedicalInfo, person.Id);
                            await _unitOfWork.FileInfos.Insert(medicalInfo);
                        }
                        await _unitOfWork.SaveFileAsync();
                    }


                    var staffInfo = StaffInfo.Create(model, _userId);
                    staffInfo.OrganizationId = _organizationId.Value;
                    await _unitOfWork.StaffInfos.Insert(staffInfo);
                    var staffInfoResult = await _unitOfWork.SaveAsync();
                    if (staffInfoResult.Succeeded)
                    {
                        person.StaffInfoId = staffInfo.Id;
                        foreach (var item in model.ClassId)
                        {
                            var personToClass = PersonToClass.Create(person.Id, item, _userId);
                            await _unitOfWork.PersonToClasses.Insert(personToClass);
                        }
                        await _unitOfWork.SaveAsync();
                    }
                }

                return Redirect(Request.Headers["Referer"].ToString());
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateChild()
        {
            var classes = await _unitOfWork.Classes.GetAsync(x => x.OrganizationId == _organizationId);
            ChildCreateViewModel model = new ChildCreateViewModel() { Classes = classes };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChild(ChildCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var person = Person.Create(model, _organizationId.Value);
                await _unitOfWork.People.Insert(person);
                var personResult = await _unitOfWork.SaveAsync();
                if (personResult.Succeeded)
                {
                    if (model.Files.Any())
                    {
                        foreach (var f in model.Files)
                        {
                            var medicalInfo = FileInfo.Create(f, _userId, DAL.Enum.EnumFileType.MedicalInfo, person.Id);
                            await _unitOfWork.FileInfos.Insert(medicalInfo);
                        }
                        await _unitOfWork.SaveFileAsync();
                    }

                    var childInfo = ChildInfo.Create(model, _userId);
                    await _unitOfWork.ChildInfos.Insert(childInfo);

                    var childResult = await _unitOfWork.SaveAsync();
                    if (childResult.Succeeded)
                    {
                        person.ChildInfoId = childInfo.Id;
                        foreach (var item in model.ClassId)
                        {
                            var personToClass = PersonToClass.Create(person.Id, item, _userId);
                            await _unitOfWork.PersonToClasses.Insert(personToClass);
                        }

                        await _unitOfWork.SaveAsync();
                    }
                }

                return Redirect(Request.Headers["Referer"].ToString());
            }
            return View(model);
        }
        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> EditStaff(Guid personId)
        {
            var person = await _unitOfWork.People.GetOneAsync(x => x.Id == personId,
                                                                   include: p => p.Include(w => w.StaffInfo)
                                                                                  //.Include(e => e.MedicalInfos)
                                                                                  .Include(r => r.PersonToClasses));

            var classes = await _unitOfWork.Classes.GetAsync(x => x.OrganizationId == _organizationId);

            var model = StaffInfo.Init(person, classes);
            var medicalInfo = await _unitOfWork.FileInfos.GetOneAsync(x => x.PersonId == model.PersonId && x.FileType == DAL.Enum.EnumFileType.MedicalInfo);
            model.MedicalInfo = medicalInfo;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditStaff(StaffEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var person = await _unitOfWork.People.GetOneAsync(x => x.Id == model.PersonId,
                                                                      include: p => p.Include(w => w.StaffInfo)
                                                                                     //.Include(e => e.MedicalInfos)
                                                                                     .Include(r => r.PersonToClasses));

                person.Update(model);

                _unitOfWork.People.Update(person);
                var result = await _unitOfWork.SaveAsync();
                if (result.Succeeded)
                {
                    var personToClasses = person.PersonToClasses;

                    personToClasses.ForEach(x => x.IsActive = false);
                    _unitOfWork.PersonToClasses.UpdateRange(personToClasses);
                    foreach (var item in model.ClassId)
                    {
                        await _unitOfWork.PersonToClasses.Insert(PersonToClass.Create(person.Id, item, _userId));
                    }
                    var result2 = await _unitOfWork.SaveAsync();
                }
                return Redirect(Request.Headers["Referer"].ToString());
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditChildEductionInformation(Guid personId)
        {
            var person = await _unitOfWork.People.GetOneAsync(x => x.Id == personId,
                                                                   include: p => p.Include(w => w.ChildInfo).Include(x => x.PersonToClasses));
            var classes = await _unitOfWork.Classes.GetAsync(x => x.OrganizationId == _organizationId && x.IsActive);

            var model = ChildInfo.Init(person, classes);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditChildMedicalInformation(Guid personId)
        {
            var person = await _unitOfWork.People.GetOneAsync(x => x.Id == personId,
                                                                   include: p => p.Include(w => w.ChildInfo));


            var model = ChildInfo.ChildEditMedicalViewModel(person);
            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> EditChildMedicalInformation(ChildEditMedicalViewModel model)
        {
            if (ModelState.IsValid)
            {

                var person = await _unitOfWork.People.GetOneAsync(x => x.Id == model.PersonId,
                                                                   include: p => p.Include(w => w.ChildInfo).Include(x => x.PersonToClasses));

                person.Update(model);
                var result = await _unitOfWork.SaveAsync();
                if (result.Succeeded)
                {
                    return Json(new JsonMessage { Color = "#ff6849", Message = "Person medical saved", Header = "Success", Icon = "success", AdditionalData = model });
                }
                return Json(new JsonMessage { Color = "#ff6849", Message = "Error", Header = "Error", Icon = "error", AdditionalData = model });

            }
            return Json(new JsonMessage { Color = "#ff6849", Message = "Error", Header = "Error", Icon = "error", AdditionalData = model });
        }


        public async Task<IActionResult> EditChildFileInformation(Guid personId)
        {
            var files = await _unitOfWork.FileInfos.GetAsync(x => x.IsActive && x.PersonId == personId && x.FileType == DAL.Enum.EnumFileType.MedicalInfo);
            var model = FileInfo.Init(files);
            ViewBag.PersonId = personId;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditChild(Guid personId)
        {
            var person = await _unitOfWork.People.GetOneAsync(x => x.Id == personId,
                                                                   include: p => p.Include(w => w.ChildInfo));


            var model = ChildInfo.Init(person);
            return View(model);
        }


        [HttpPost]
        public async Task<JsonResult> EditChildEductionInformation(ChildEditEducationViewModel model)
        {
            if (ModelState.IsValid)
            {

                var person = await _unitOfWork.People.GetOneAsync(x => x.Id == model.PersonId,
                                                                   include: p => p.Include(w => w.ChildInfo).Include(x => x.PersonToClasses));
                var classes = await _unitOfWork.Classes.GetAsync(x => x.OrganizationId == _organizationId && x.IsActive);


                person.Update(model);

                _unitOfWork.People.Update(person);
                var result = await _unitOfWork.SaveAsync();
                if (result.Succeeded)
                {
                    var personToClasses = person.PersonToClasses;

                    personToClasses.ForEach(x => x.IsActive = false);
                    _unitOfWork.PersonToClasses.UpdateRange(personToClasses);
                    foreach (var item in model.InClasses)
                    {
                        await _unitOfWork.PersonToClasses.Insert(PersonToClass.Create(person.Id, item, _userId));
                    }
                    var result2 = await _unitOfWork.SaveAsync();
                    return Json(new JsonMessage { Color = "#ff6849", Message = "Person saved", Header = "Success", Icon = "success", AdditionalData = model });
                }
            }
            return Json(new JsonMessage { Color = "#ff6849", Message = "Error", Header = "Error", Icon = "error", AdditionalData = model });
        }

        [HttpPost]
        public async Task<JsonResult> EditChildGeneralInformation(ChildEditGeneralViewModel model)
        {
            if (ModelState.IsValid)
            {
                var person = await _unitOfWork.People.GetOneAsync(x => x.Id == model.PersonId,
                                                                   include: p => p.Include(w => w.ChildInfo)

                                                                                  .Include(r => r.PersonToClasses));

                person.Update(model);

                _unitOfWork.People.Update(person);
                var result = await _unitOfWork.SaveAsync();

                return Json(new JsonMessage { Color = "#ff6849", Message = "Person saved", Header = "Success", Icon = "success", AdditionalData = model });

            }
            return Json(new JsonMessage { Color = "#ff6849", Message = "Error", Header = "Error", Icon = "error", AdditionalData = model });
        }

        [HttpGet]
        public async Task<IActionResult> EditChildContactInformation(Guid personId)
        {
            var contacts = await _unitOfWork.Contacts.GetAsync(x => x.IsActive && x.ChildId == personId);
            var model = Contact.Init(contacts, personId);

            return View(model);
        }
               
        public async Task<IActionResult> EditContact(Guid contactId)
        {
            ChildEditContactViewModel model = Contact.Edit(await _unitOfWork.Contacts.GetOneAsync(x => x.IsActive && x.Id == contactId));
            return View(model);
        }

        [HttpPost]
        public async Task<string> EditContact(ChildEditContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                Contact contact = await _unitOfWork.Contacts.GetOneAsync(x => x.IsActive && x.Id == model.ContactId);
                contact.Update(model);
                _unitOfWork.Contacts.Update(contact);
                var result = await _unitOfWork.SaveAsync();
                if(result.Succeeded)
                {
                    var contacts = await _unitOfWork.Contacts.GetAsync(x => x.IsActive && x.ChildId == model.ChildId);
                    var modelToView = Contact.Init(contacts, model.ChildId.Value);
                    var htmlPage = await RenderViewToString("EditChildContactInformation", modelToView);
                    return htmlPage;
                }
            }
            return await RenderViewToString("EditContact", model);

        }

        [HttpGet]
        public async Task<IActionResult> CreateContact(Guid childId)
        {
            ChildCreateContactViewModel model = new ChildCreateContactViewModel() { ChildId = childId };
            return View(model);
        }



        [HttpPost]
        public async Task<string> CreateContact(ChildCreateContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                Contact contact = Contact.Create(model, _userId);
                await _unitOfWork.Contacts.Insert(contact);
                var contactResult = await _unitOfWork.SaveAsync();
                if (contactResult.Succeeded)
                {
                    PersonToContact personToContact = PersonToContact.Create(model.ChildId, contact.Id, _userId);
                    await _unitOfWork.PersonToContacts.Insert(personToContact);
                    var personToContactResult = await _unitOfWork.SaveAsync();
                    if (personToContactResult.Succeeded)
                    {
                        var contacts = await _unitOfWork.Contacts.GetAsync(x => x.IsActive && x.ChildId == model.ChildId);
                        var modelToView = Contact.Init(contacts, model.ChildId);
                        var htmlPage = await RenderViewToString("EditChildContactInformation", modelToView);
                        return htmlPage;
                    }
                }
            }
            return await RenderViewToString("CreateContact", model); 
        }
        #endregion

        [HttpDelete]
        public async Task<JsonResult> DeleteContact(Guid contactId)
        {
            var contact = await _unitOfWork.Contacts.GetOneAsync(x => x.IsActive && x.Id == contactId);
            var personToContacts = await _unitOfWork.PersonToContacts.GetAsync(x => x.IsActive && x.ContactId == contactId);
            contact.IsActive = false;
            personToContacts.ForEach(x => x.IsActive = false);
            _unitOfWork.Contacts.Update(contact);
            _unitOfWork.PersonToContacts.UpdateRange(personToContacts);
            var result = await _unitOfWork.SaveAsync();
            if(result.Succeeded)
            {
                return Json(new JsonMessage { Color = "#ff6849", Message = "Contact deleted", Header = "Success", Icon = "success" });
            }
            return Json(new JsonMessage { Color = "#ff6849", Message = "Error", Header = "Error", Icon = "error" });
        }

        private async Task<string> RenderViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.ActionName;

            ViewData.Model = model;

            using (var writer = new System.IO.StringWriter())
            {
                ViewEngineResult viewResult =
                    _viewEngine.FindView(ControllerContext, viewName, true);

                ViewContext viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    ViewData,
                    TempData,
                    writer,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);

                return writer.GetStringBuilder().ToString();
            }
        }
    }
}
