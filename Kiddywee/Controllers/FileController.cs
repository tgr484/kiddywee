﻿using Kiddywee.BLL.Core;
using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Kiddywee.Controllers
{
    [Authorize]
    public class FileController : BaseController
    {
        public FileController(IUnitOfWork unitOfWork, ICompositeViewEngine viewEngine) : base(unitOfWork, viewEngine)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<JsonResult>  UploadProfileImage(Guid personId, IFormFile file)
        {
            var person = await _unitOfWork.People.GetOneAsync(x => x.Id == personId);
            person.ProfileImage = await file.GetBytes();
            _unitOfWork.People.Update(person);
            await _unitOfWork.SaveAsync();
            var base64String = Convert.ToBase64String(person.ProfileImage);
            string resultString = $"data:{file.ContentType};base64,{base64String}";
            return Json(new JsonMessage { Color = "#ff6849", Message = "Logo uploaded", Header = "Success", Icon = "success", AdditionalData = new {src=resultString } });

        }
        public ActionResult GetProfileImage(Guid personId)
        {
            byte[] profileImageData = _unitOfWork.People.GetOne(x => x.Id == personId)?.ProfileImage;
            //для дефолтной картинки
            if(profileImageData == null)            
            {
                profileImageData = Convert.FromBase64String(Constants.DEFAULT_USER_LOGO);                
            }
            return File(profileImageData, "image/png");
        }

        
        public async Task<IActionResult> DownloadFile(Guid fileId)
        {
            DAL.Models.FileInfo file = await _unitOfWork.FileInfos.GetOneAsync(x => x.Id == fileId);
            return File(file.Data, file.Extention, file.Name);
        }

        public async Task<JsonResult> DeleteFile(Guid fileId)
        {
            DAL.Models.FileInfo file = await _unitOfWork.FileInfos.GetOneAsync(x => x.Id == fileId);
            file.IsActive = false;
            _unitOfWork.FileInfos.Update(file);
            var result = await _unitOfWork.SaveFileAsync();
            return Json(new JsonMessage { Color = "#ff6849", Message = "File deleted", Header = "Success", Icon = "success", AdditionalData  = file });

        }


        public async Task<JsonResult> UploadMedicalFile(Guid personId, IFormFile file)
        {
            var medicalInfo = DAL.Models.FileInfo.Create(file, _userId, DAL.Enum.EnumFileType.MedicalInfo, personId);
            await _unitOfWork.FileInfos.Insert(medicalInfo);
            var result = await _unitOfWork.SaveFileAsync();
            if(result.Succeeded)
            {
                return Json(new JsonMessage { Color = "#ff6849", Message = "File uploded", Header = "Success", Icon = "success", AdditionalData = medicalInfo });

            }
            return Json(new JsonMessage { Color = "#ff6849", Message = "File error", Header = "Error", Icon = "error", AdditionalData = medicalInfo });

        }
    }
}
