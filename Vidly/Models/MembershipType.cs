﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
	public class MembershipType
	{
		/* Every entity in Entity Framework must have a key which will be mapped to the primary key of the 
		 * corresponding table in the database. By convention this property should be called either ID or 
		 * the name of the type plus ID.
		 */
		public byte Id { get; set; }
		public short SignUpFee { get; set; }
		public byte DurationInMonths { get; set; }
		public byte DiscountRate { get; set; }

		[Required]
		public string Name { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
        //public static readonly byte Unknown = 0;
        //public static readonly byte Unknown = 0;
    }
}