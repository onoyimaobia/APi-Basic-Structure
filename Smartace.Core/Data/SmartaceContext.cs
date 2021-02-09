using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Smartace.Core.Domain.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Smartace.Core.Data
{


    public class SmartaceContext: IdentityDbContext<ApplicationUser, ApplicationRole, long,
   ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
   ApplicationRoleClaim, ApplicationUserToken>
    {
    
        public SmartaceContext(DbContextOptions<SmartaceContext> options) : base(options)
        {

        }

        public SmartaceContext()
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // LOCAL:
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-LPDAJH0\\SQLEXPRESS;Initial Catalog=SmartaceHRDB;User Id=sa; Password=onoyimaobia;Trusted_Connection=true;Encrypt=false;MultipleActiveResultSets=true;Integrated Security=true;");

            // QA:
            //optionsBuilder.UseSqlServer("Data Source=104.40.215.33\\sqlexpress,1433;Initial Catalog=SmartaceHRDB;User Id=sa; Password=p@ssw0rd123;Encrypt=false;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.RemovePluralizingTableNameConvention();
            base.OnModelCreating(modelBuilder);



        }




        public async Task<bool> TrySaveChangesAsync(ILogger logger)
        {
            try
            {
                await SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException e)
            {
                logger.LogError($"unable to add  >>>>> {e.Message}");
                logger.LogError($"DB add  Inner Exception Message >>>>> {e.InnerException?.Message}");
                return false;
            }
        }




    }
}
