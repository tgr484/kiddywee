using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiddywee.Controllers
{
    [Authorize]
    public class DownloadController : BaseController
    {
        public DownloadController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> DownloadFile(Guid fileId)
        {
            FileInfo file = await _unitOfWork.FileInfos.GetOneAsync(x => x.Id == fileId);
            return File(file.Data, file.Extention, file.Name);
        }
    }
}
