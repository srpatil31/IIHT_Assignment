using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using TwitterClone.Models;

namespace TwitterClone.Business
{
    public class TweetsDomain
    {
        private TwitterCloneDbContext db = new TwitterCloneDbContext();
        public TweetsDomain()
        {

        }
        public void SetTweetId() { }
        public int GetTweetId()
        {
            return 0;
        }
        public void SetUser(Person person) { }

        public Person GetUser()
        {
            return new Person();
        }
        public void SetMessage(TWEET obj)
        {
            db.TWEETs.Add(obj);
            
            db.SaveChanges();
        }
        public string GetMessage()
        {
            return string.Empty;
        }
        public void SetCreated(DateTime createdate)
        {

        }
        public DateTime GetCreated()
        {
            return DateTime.Now;
        }

        public void RemoveTweet(int id)
        {
            var tweet = db.TWEETs.FirstOrDefault(t => t.tweet_id == id);
            db.TWEETs.Remove(tweet);

            db.SaveChanges();
        }

    }
}