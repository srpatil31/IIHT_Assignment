using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TwitterClone.Business;
using TwitterClone.Models;

namespace TwitterClone.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private TwitterCloneDbContext db = new TwitterCloneDbContext();
        [HttpGet]
        public ActionResult Index(Person person)
        {

            var p = db.Person.FirstOrDefault(t => t.user_id == person.user_id);

            //TweetsDomain td = new TweetsDomain();
            var viewModel = new PersonTweetModel
            {
                TweetsList = db.TWEETs.ToList(),
                Tweet = new TWEET(),
                Person = p

            };

                       
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult UpdateTweet(PersonTweetModel domainObject)
        {

            var user = User.Identity.Name;

            var p = db.Person.FirstOrDefault(t => t.user_id == user);

            domainObject.Tweet.user_id = user;
            domainObject.Tweet.created = DateTime.Now;
            var viewModel = new PersonTweetModel
            {
                TweetsList = domainObject.TweetsList,
                Tweet = domainObject.Tweet,
                Person = p

            };

            TweetsDomain td = new TweetsDomain();
            td.SetMessage(domainObject.Tweet);
            viewModel.TweetsList = db.TWEETs.ToList();
            return RedirectToAction("Index", "Home", p);
        }


        public ActionResult NewTweet(PersonTweetModel domainObject)
        {
            var user = User.Identity.Name;
            domainObject.Tweet.user_id = user;
            domainObject.Tweet.created = DateTime.Now;
            var viewModel = new PersonTweetModel
            {
                TweetsList = domainObject.TweetsList,
                Tweet = domainObject.Tweet,
                Person = domainObject.Person

            };

            TweetsDomain td = new TweetsDomain();
            td.SetMessage(domainObject.Tweet);
            return View(viewModel);
        }


        public ActionResult DeleteTweet(PersonTweetModel domainObject,int id)
        {

            var user = User.Identity.Name;
            var p = db.Person.FirstOrDefault(t => t.user_id == user);

            //domainObject.Tweet.user_id = user;
            //domainObject.Tweet.created = DateTime.Now;

            TweetsDomain td = new TweetsDomain();
            td.RemoveTweet(id);

            var viewModel = new PersonTweetModel
            {
                TweetsList = db.TWEETs.ToList(),
                Tweet = domainObject.Tweet,
                Person = domainObject.Person

            };


            return RedirectToAction("Index", "Home", p);
        }

        [HttpGet]
        public ActionResult EditTweet(int id)
        {

            var user = User.Identity.Name;
            var p = db.Person.FirstOrDefault(t => t.user_id == user);

            var tweet = db.TWEETs.FirstOrDefault(t => t.tweet_id == id);

            return View(tweet);
        }

        public ActionResult EditTweet(int id, string userId, TWEET tweet)
        {
            var p = db.Person.FirstOrDefault(t => t.user_id == userId);

            var tw = db.TWEETs.FirstOrDefault(a => a.tweet_id == id);

            tw.message = tweet.message;
            db.SaveChanges();

            return RedirectToAction("Index", "Home", p);
        }

        public ActionResult SearchUser(string username)
        {
            if (username != User.Identity.Name)
            {
                var users = db.Person.FirstOrDefault(t => t.user_id == username);
                if (users != null)
                {
                  
                    return RedirectToAction("Index", "Home", users);

                }
            }

            return View();
        }
    }
}