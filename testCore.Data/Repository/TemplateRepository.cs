using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace testCore.Data
{
    public class TemplateRepository : BaseRepository<Template, TestCoreContext>
    {
        public TemplateRepository(TestCoreContext dbContext) : base(dbContext)
        {
        }
        public virtual async Task<IList<Template>> GetAllTemplate()
        {
            return await _dbSet.ToListAsync();
        }
        public virtual async Task<Template> GetTemplateById(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
