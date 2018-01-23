using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPageService.BE
{
    public class PostInfo
    {
        //Unique ID
        public int Id { get; set; }


        //String ID used to get Data from the Graph API
        public string PostId { get; set; }
        //The posts message
        public string Message { get; set; }
        //Total number of likes on all posts accross the page
        public int Like { get; set; }
        //Total number of likes on all posts accross the page
        public int Love { get; set; }
        //Total number of likes on all posts accross the page
        public int Wow { get; set; }
        //Total number of likes on all posts accross the page
        public int Haha { get; set; }
        //Total number of likes on all posts accross the page
        public int Sad { get; set; }
        //Total number of likes on all posts accross the page
        public int Angry { get; set; }
        //Total number of likes on all posts accross the page
        public int Thankful { get; set; }
        //Records the time for the current ammounts of reactions
        public DateTime DateTime { get; set; }
        
    }
}
