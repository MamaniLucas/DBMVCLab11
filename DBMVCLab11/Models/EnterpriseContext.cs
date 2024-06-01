using Microsoft.EntityFrameworkCore;

namespace DBMVCLab11.Models
{
    public class EnterpriseContext :DbContext

    {

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Detail> Detail { get; set; }
        public DbSet<Invoice> Invoice { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAB1504-11\\SQLEXPRESS;Initial Catalog=neptuno;User ID=roxanadb;Password=123456; Integrated Security=True; trustservercertificate=True");
        }



    }
}
