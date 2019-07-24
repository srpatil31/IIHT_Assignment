using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwitterClone.Models
{
    public class PersonTweetModel
    {
        [Key]
        public string Id { get; set; }
        public IEnumerable<TWEET> TweetsList { get; set; }
        public TWEET Tweet { get; set; }
        public Person Person { get; set; }

    }
}