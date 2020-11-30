using Kiddywee.BLL.Core;
using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Kiddywee.Controllers
{
    [Authorize]
    public class FileController : BaseController
    {
        public FileController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> DownloadFile(Guid fileId)
        {
            FileInfo file = await _unitOfWork.FileInfos.GetOneAsync(x => x.Id == fileId);
            return File(file.Data, file.Extention, file.Name);
        }

        public async Task<JsonResult> DeleteFile(Guid fileId)
        {
            FileInfo file = await _unitOfWork.FileInfos.GetOneAsync(x => x.Id == fileId);
            file.IsActive = false;
            _unitOfWork.FileInfos.Update(file);
            var result = await _unitOfWork.SaveFileAsync();
            return Json(new JsonMessage { Color = "#ff6849", Message = "File deleted", Header = "Success", Icon = "success", AdditionalData  = file });

        }


        public async Task<JsonResult> UploadChildMedicalFile(Guid personId, IFormFile file)
        {
            var medicalInfo = FileInfo.Create(file, _userId, DAL.Enum.EnumFileType.MedicalInfo, personId);
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
