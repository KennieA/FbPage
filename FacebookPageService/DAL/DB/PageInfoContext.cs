using FacebookPageService.BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPageService.DAL.DB
{
    public class PageInfoContext : DbContext
    {
        public PageInfoContext() : base("name=FacebookPageExtractionConnectionString")
        {
            Database.SetInitializer<PageInfoContext>(new DropCreateDatabaseIfModelChanges< PageInfoContext>());
        }
        public DbSet<PageInfo> pageInfo { get; set; }
        public DbSet<PageReactionInfo> pageReactionInfo { get; set; }
    }
}
