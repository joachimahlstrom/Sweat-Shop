using Microsoft.EntityFrameworkCore;


namespace ASPprojekt.Models
{
    //ärver från DbContext
    public class TraningContext: DbContext
    {
        public DbSet<TraningModel> tOvningar { get; set; }
        public TraningContext()
        {
            Database.EnsureCreated();//skapa databasen
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=MinDatabas.db");//databasens namn
        }
    }
}
