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
