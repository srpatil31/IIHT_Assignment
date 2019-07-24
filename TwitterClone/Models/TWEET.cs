namespace TwitterClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TWEET")]
    public partial class TWEET
    {
        [Key]
        public int tweet_id { get; set; }

        [StringLength(25)]
        [DisplayName("User Id")]
        public string user_id { get; set; }

        [Required]
        [StringLength(130)]
        [DisplayName("Message")]
        public string message { get; set; }

        [DisplayName("Created on")]
        public DateTime created { get; set; }

        public virtual Person Person { get; set; }
    }
}
