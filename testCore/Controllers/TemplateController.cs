using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using testCore.Business;

namespace testCore.Controllers
{
    public class TemplateController : Controller
    {
        private readonly TemplateDomain _Domain;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public TemplateController(TemplateDomain Domain, IWebHostEnvironment hostingEnvironment)
        {
            _Domain = Domain;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            await SetData();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewTemplate()
        {
            ModelState.Clear();
            await SetData();
            return PartialView("SaveTemplate", null);
        }

        [HttpPost]
        public async Task<IActionResult> ShowTemplate(int id)
        {
            var model = await _Domain.TemplateById(id);
            await SetData();
            return PartialView("SaveTemplate", model);
        }

        public async Task<IActionResult> DeleteTemplate(int id)
        {
            try
            {
                await _Domain.DeleteTemplate(id);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "خطأ في الحذف");
            }
            return PartialView("GetTemplate", await _Domain.GetAllTemplate());
        }

        public async Task<IActionResult> GetTemplate()
        {
            return PartialView(await _Domain.GetAllTemplate());
        }

        [HttpPost]
        public async Task<IActionResult> SaveTemplate(TemplateViewModel Template)
        {
            if (ModelState.IsValid)
            {
                string root_path = _hostingEnvironment.WebRootPath + "\\TemplateImage\\";
                string file_name = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(Template.Photo.FileName);
                using (FileStream stream = System.IO.File.Create(root_path + file_name))
                {
                    Template.Photo.CopyTo(stream);
                    stream.Flush();
                }
                Template.PhotoString = file_name;
                if (Template.Id == null)
                {
                    await _Domain.InsertTemplate(Template);
                }
                else
                {
                    await _Domain.UpdateTemplate(Template);
                }
                await SetData("success");
                return PartialView("SaveTemplate", null);
            }
            else
            {
                ModelState.AddModelError("01", "حدث خطأ!! حاول مرة اخرى في وقت لاحق");
                return PartialView("SaveTemplate", Template);
            }
        }

        public async Task SetData(string Value = "")
        {
            ViewBag.GetAllTemplate = await _Domain.GetAllTemplate();
            ViewBag.TemplateMsg = Value;
        }
    }
}
