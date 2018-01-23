using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPageService.BE
{
    public class PageReactionInfo
    {
        //Unique ID        
        public int Id { get; set; }
        //Total number of likes on all posts accross the page
        public int TotalLike { get; set; }
        //Total number of likes on all posts accross the page
        public int TotalLove { get; set; }
        //Total number of likes on all posts accross the page
        public int TotalWow { get; set; }
        //Total number of likes on all posts accross the page
        public int TotalHaha { get; set; }
        //Total number of likes on all posts accross the page
        public int TotalSad { get; set; }
        //Total number of likes on all posts accross the page
        public int TotalAngry { get; set; }
        //Total number of likes on all posts accross the page
        public int TotalThankful { get; set; }
        //Records the time for the current ammounts of reactions
        public DateTime DateTime { get; set; }
    }
}
