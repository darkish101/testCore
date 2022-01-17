using Microsoft.EntityFrameworkCore;

namespace testCore.Data
{
    public class TestCoreContext : DbContext
    {
        public TestCoreContext(DbContextOptions<TestCoreContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Template> Templates { get; set; }
    }
}
