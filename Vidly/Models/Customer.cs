using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
	public class Customer
	{
		public int Id { get; set; }

		//Using DataAnnotations to apply constraints to our columns
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		public bool IsSubscribedToNewsletter { get; set; }
		
		//Now associating our Customer class to Membership Type
		//This type if property is called Navigation Property
		public MembershipType MembershipType { get; set; }

		//Adding Id to the name, EF will recognize it correctly as Foreign Key
		[Display(Name = "Membership Type")]
		public byte MembershipTypeId { get; set; }

		[Display(Name = "Date Of Birth")]
		[Min18YearsIfAMember]
		public DateTime? Birthdate { get; set; }
	}
}