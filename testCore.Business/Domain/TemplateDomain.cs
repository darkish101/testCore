using Arch.EntityFrameworkCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testCore.Data;

namespace testCore.Business
{
    public class TemplateDomain : BaseDomain<Template, TemplateRepository>
    {
        private readonly TemplateRepository _TemplateRepository;
        public TemplateDomain(TemplateRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _TemplateRepository = repository;
        }
        public async Task InsertTemplate(TemplateViewModel viewModel)
        {
            try
            {
                var template = new Template();
                template.Name = viewModel.Name;
                template.Photo = viewModel.PhotoString;
                await base.InsertAsync(template);
            }
            catch
            {
                throw;
            }
        }
        public async Task UpdateTemplate(TemplateViewModel viewModel)
        {
            try
            {
                var template = await _repository.GetTemplateById(Convert.ToInt32(viewModel.Id));
                template.Name = viewModel.Name;
                template.Photo = viewModel.PhotoString;
                await base.UpdateAsync(template);
            }
            catch
            {
                throw;
            }
        }
        public async Task DeleteTemplate(int Id)
        {
            try
            {
                await base.DeleteAsync(Id);
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<TemplateViewModel>> GetAllTemplate()
        {
            try
            {
                var categories = await _TemplateRepository.GetAllTemplate();
                return categories.Select(x => new TemplateViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PhotoString = x.Photo,
                }).ToList();
            }
            catch
            {
                throw;
            }
        }
        public async Task<TemplateViewModel> TemplateById(int Id)
        {
            try
            {
                var Data = await _TemplateRepository.GetAllTemplate();
                var template = Data.First(x => x.Id == Id);
                return new TemplateViewModel
                {
                    Id = template.Id,
                    Name = template.Name,
                    PhotoString = template.Photo,
                };
            }
            catch
            {
                throw;
            }
        }
        }
}
