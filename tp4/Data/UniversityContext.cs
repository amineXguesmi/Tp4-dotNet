using Microsoft.EntityFrameworkCore;
using tp4.Models;

namespace tp4.Data
{
    
    public class UniversityContext : DbContext 
    {
        private static UniversityContext Cont = null;
        public DbSet<Student> Student { get; set; }
        private  UniversityContext ( DbContextOptions o) : base(o) 
    {
    }
    public static UniversityContext Instantiate_UniversityContext(){
            
            
                var optionsBuilder = new DbContextOptionsBuilder<UniversityContext>();
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\semah\\source\\repos\\tp4\\tp4\\Data\\data.db");
            
    return new UniversityContext(optionsBuilder.Options);
}
        
        public static UniversityContext GetCont()
        {
            if(Cont== null)
            {
                Cont = Instantiate_UniversityContext();
            }
            return Cont;
        }
}
}
