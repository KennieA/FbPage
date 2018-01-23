﻿using Facebook;
using FacebookPageService.BE;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPageService.DAL
{
    public class PageExtractor
    {
        FacebookClient client;
        //Application ID
        string appId = "162186414407079";
        //App Secret
        string appSecret = "8bfae050695a6750608b92842146e57e";
        //Current version of the Graph API
        string version = "v2.11/";
        //Change to the ID of preferred page
        string pageId = "17730497621038/1";       

        //Sets up the FacebookClients Access Token using the App ID & App Secret.
        public PageExtractor()
        {
            try
            {
                client = new FacebookClient();
                client.AccessToken = appId+"|"+appSecret;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Extratcs Data from Graph Api & adds it to the dynamic info Object and return a PageInfo Object
        public PageInfo ExtractPageData()
        {
            try
            { 
                dynamic info = client.Get(version+pageId+"?fields=name,fan_count,talking_about_count,were_here_count,about");

                PageInfo pageInfo = new PageInfo();
                pageInfo.Name = Convert.ToString(info.name);
                pageInfo.About = Convert.ToString(info.about);
                pageInfo.FanCount = Convert.ToInt32(info.fan_count);
                pageInfo.TalkingAboutCount = Convert.ToInt32(info.talking_about_count);
                pageInfo.WereHereCount = Convert.ToInt32(info.were_here_count);
                pageInfo.DateTime = DateTime.Now;

                return pageInfo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Get all posts on a page and return a list containing them
        public List<PostInfo> GetAllPostsOnPage()
        {
            List<PostInfo> allPosts = new List<PostInfo>();
            dynamic result = client.Get(version + pageId + "posts?fields=message");
            for (int i = 0; i < result.data.Count; i++)
            {
                PostInfo posts = new PostInfo();

                posts.PostId = result.data[i].id;
                posts.Message = result.data[i].message;
                allPosts.Add(posts);
            }
            return allPosts;
        }

        //Loops through all posts on a page and returns the cumulated reactions in form of a PageReactionInfo
        public PageReactionInfo getAllPostsInfo(List<PostInfo> allPosts)
        {
            try
            {
                PageReactionInfo postInfo = new PageReactionInfo();
                foreach (var post in allPosts)
                {
                    dynamic result = client.Get("v2.11/" + post.PostId + "?fields=reactions.type(LIKE).summary(total_count).limit(0).as(like),reactions.type(LOVE).summary(total_count).limit(0).as(love), reactions.type(WOW).summary(total_count).limit(0).as(wow), reactions.type(HAHA).summary(total_count).limit(0).as(haha), reactions.type(SAD).summary(total_count).limit(0).as(sad), reactions.type(ANGRY).summary(total_count).limit(0).as(angry), reactions.type(THANKFUL).summary(total_count).limit(0).as(thankful)");
                    postInfo.TotalLike += result.like.summary.total_count;
                    postInfo.TotalLove += result.love.summary.total_count;
                    postInfo.TotalWow += result.wow.summary.total_count;
                    postInfo.TotalHaha += result.haha.summary.total_count;
                    postInfo.TotalSad += result.sad.summary.total_count;
                    postInfo.TotalAngry += result.angry.summary.total_count;
                    postInfo.TotalThankful += result.thankful.summary.total_count;
                }
                return postInfo;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
