using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMP235MVCDemo.Models
{
    public class Movie

        
    {
        public Movie() { }

        public Movie(int id, string title, string director, string description)
        {
            Id = id;
            Title = title;
            Director = director;
            Description = description;
        }


        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public bool IsEditable { get; set; }
        public int EditIndex { get; set; }
        public List<Movie> Items { get; internal set; }

        public Movie(int id, string title, string director)
        {
            Id = id;
            Title = title;
            Director = director;
        }

        public class Movies // This class holds a list of Movies
        {
            public List<Movie> Items { get; set; }
            public Movies() { }
        }

    }

}