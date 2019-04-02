using System;
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

        /*
         * EXERCISE 1
        1. Run the migrations for Name field addition
            PM>add-migration SetNameToMembershipTypes
            PM>update-database

        2. Create a migration so that you may update the MembershipTypes table with the name data.
            PM>add-migration add-migration PopulateMembershipTypeNames

        3. Update the new file with the following in the Up() method...
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Annual' WHERE Id = 4");

        4. Update the database
            PM>update-database
         */
    }
}