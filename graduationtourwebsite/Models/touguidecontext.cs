using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace graduationtourwebsite.Models
{


    public class touguidecontext : DbContext
    {
        public touguidecontext(DbContextOptions<touguidecontext> options)
            : base(options)
        {

        }

        public DbSet<feedback> feedbacks { get; set; }     
        public DbSet<payment> payments { get; set; }
        public DbSet<place> places { get; set; }
        public DbSet<contact> Contacts { get; set; }
        public DbSet<contact_us> contact_Us { get; set; }
      
         public DbSet<tour> tours { get; set; }

    }
   
}
