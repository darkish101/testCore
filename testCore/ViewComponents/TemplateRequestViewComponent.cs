using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testCore.Data;

namespace testCore.ViewComponents
{
    public class TemplateRequestViewComponent : ViewComponent
    {
        private readonly TemplateRepository _Domain;
        public TemplateRequestViewComponent(TemplateRepository Domain)
        {
            _Domain = Domain;
        }
        public async Task<IViewComponentResult> InvokeAsync(Guid id)
        {
            return View(await _Domain.GetAllTemplate());
        }
    }
}
