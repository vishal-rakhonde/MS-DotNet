using Microsoft.EntityFrameworkCore;

namespace CodeFirstExample.Models
{
    //JKJune2024CodeFirstContext
    public partial class JKJune2024CodeFirstContext : DbContext
    {
        public JKJune2024CodeFirstContext()
        {
        }

        public JKJune2024CodeFirstContext(DbContextOptions<JKJune2024CodeFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

       
    }
}
