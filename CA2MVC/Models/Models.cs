using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CA2MVC.Models
{
    class Dataseed:DropCreateDatabaseAlways<MovieDB>
    {
        protected override void Seed(MovieDB context)
        {
            var moviedatabase = new List<Movie>
            {
            new Movie() { MovieName="The lego Movie", Details="It has Lego!"
            , Actors = new List<Actor>()
            {
                new Actor() { ActorName="Legoman", MovieName="The lego Movie"},
                new Actor() {ActorName="Legoman2", MovieName="The lego Movie"},
                new Actor() {ActorName="Legoman3", MovieName="The lego Movie"}
            }},
             new Movie() { MovieName="X-men", Details="Bad vs Good"
            , Actors = new List<Actor>()
            {
                new Actor() { ActorName="Hugh Jackman", MovieName="X-men"}
                
            }},
             new Movie() { MovieName="Guardians of the Galaxy", Details="Protectors of galaxy"
            , Actors = new List<Actor>()
            {
                new Actor() { ActorName="Skykiller", MovieName="Guardians of the Galaxy"},
                new Actor() {ActorName="Batista", MovieName="Guardians of the Galaxy"}
            }},
             new Movie() { MovieName="The Hobbit", Details="Small man on a big adventure"
            , Actors = new List<Actor>()
            {
                new Actor() { ActorName="Orlando Bloom", MovieName="The Hobbit"},
                
            }},
             new Movie() { MovieName="Skyfall", Details="Best Bond Film!"
            , Actors = new List<Actor>()
            {
                new Actor() { ActorName="Daniel Craig", MovieName="Skyfall"},
                new Actor() {ActorName="Ralph Fiennes", MovieName="Skyfall"},
                new Actor() {ActorName="Naomie Harris", MovieName="Skyfall"},
                new Actor() {ActorName="Judi Dench", MovieName="Skyfall"}
            }}

            };
            moviedatabase.ForEach(mov => context.Movies.Add(mov));

            context.SaveChanges();
            base.Seed(context);
    }
         
        }
    
    public class MovieDB:DbContext
    {
       
        public MovieDB(): base("MovieDBConnString") { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }

    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        [Required]
        [StringLength(50,ErrorMessage="Movie name must atleast 5 characters.")]
        [Display(Name="Movie Name")]
        public string MovieName { get; set; }
        [Required]
        [Display(Name="Details of Movie"),StringLength(250)]
        public string Details { get; set; }
        
        public List<Actor> Actors { get; set; }
    }
    public class Actor
    {
        [Key]
        public int ActorID { get; set; }
        public int MovieID { get; set; }
        [Required]
        [StringLength(100,ErrorMessage="Actors Name must atleast 5 characters long.")]
        [Display(Name="Actor Name")]
        public string ActorName { get; set; }
        [Required]
        [StringLength(100,ErrorMessage="Movie Name must atleast 5 characters long")]
        [Display(Name="Movie Title")]
        public string MovieName { get; set; }
        public Movie Movie { get; set; }

    }

}