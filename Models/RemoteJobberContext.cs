using Microsoft.EntityFrameworkCore;
 
namespace RemoteJobber.Models
{
    public class RemoteJobberContext :DbContext
    {
        public DbSet<Category> Categories{get;set;}
         
        public RemoteJobberContext(DbContextOptions<RemoteJobberContext> options) : base(options)
        {       

        }       
    }
}