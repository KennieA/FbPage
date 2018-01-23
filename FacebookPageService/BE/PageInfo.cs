using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPageService.BE
{
    public class PageInfo
    {
        //Id of the saved page
        public int Id { get; set; }
        //Name of the Page
        public string Name { get; set; }
        //Description of the page
        public string About { get; set; }
        //Number of followers on the page
        public int FanCount { get; set; }
        //How many has seen a post related to the page
        public int TalkingAboutCount { get; set; }
        //Number of total visits of the page
        public int WereHereCount { get; set; }
        //Records the time of the data extration
        public DateTime DateTime { get; set; }

        //Lazy loaded list of page info
        public virtual List<PageInfo> PageInfoList { get; set; }
    }
}
