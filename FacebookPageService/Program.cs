using FacebookPageService.BE;
using FacebookPageService.DAL;
using FacebookPageService.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FacebookPageService
{
    class Program
    {
        static PageInfoContext db;
        static PageExtractor pExtractor;

        static void Main(string[] args)
        {
            db = new PageInfoContext();
            pExtractor = new PageExtractor();
            
            // Create a Timer object that knows to call our TimerCallback
            // method once every 2000 milliseconds.
            Timer t = new Timer(TimerCallback, null, 0, 10000);
            // Wait for the user to hit <Enter>
            Console.ReadLine();
        }

        //Used to repeatedly call the callback method with a 20 second interval
        private static void TimerCallback(Object o)
        {
            // Display the date/time when this method got called.
            Console.WriteLine("In TimerCallback: " + DateTime.Now);

            db.pageInfo.Add(pExtractor.ExtractPageData());
            List<PostInfo> allPosts = new List<PostInfo>();
            allPosts = pExtractor.GetAllPostsOnPage();
            db.pageReactionInfo.Add(pExtractor.getAllPostsInfo(allPosts));
            db.SaveChanges();

            // Force a garbage collection to occur for this demo.
            GC.Collect();
        }
    }
    
}
