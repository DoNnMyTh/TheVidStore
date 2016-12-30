using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheVidStore.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string DateOfBirth { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        [Display(Name = "Membership type")]
        public MembershipType MembershipType { get; set; }

   
        public byte MembershipTypeId { get; set; }

    }
}