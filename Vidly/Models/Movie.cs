using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

	//Say we have to create a page to randomly pick a movie and show its details
	//	/movies/random
}