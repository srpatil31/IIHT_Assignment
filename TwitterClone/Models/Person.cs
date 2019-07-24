namespace TwitterClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            TWEETs = new HashSet<TWEET>();
            Following = new HashSet<Person>();
            People = new HashSet<Person>();
        }

        [Key]
        [StringLength(25)]
        [DisplayName("User ID")]
        public string user_id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Password")]
        public string password { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Full Name")]
        public string fullName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Email")]
        public string email { get; set; }

        [DisplayName("Joined")]
        public DateTime joined { get; set; }

        [DisplayName("Active")]
        public bool active { get; set; }

        public virtual ICollection<TWEET> TWEETs { get; set; }

        public virtual ICollection<Person> Following { get; set; }

        public virtual ICollection<Person> People { get; set; }

        int followers = 0;
        public int GetFollowers()
        {
            return followers;
        }

        public void SetFollowers(int count)
        {
            followers = count;
        }
    }
}
