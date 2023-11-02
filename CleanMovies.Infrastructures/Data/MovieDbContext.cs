using CleanMovie.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovies.Infrastructures.Data
{
	public class MovieDbContext : DbContext
	{
		public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			// One to many ( member and rental)
			modelBuilder.Entity<Member>().
				HasOne(s => s.Rental).
				WithMany(s => s.Members)
				.HasForeignKey(s => s.RentalId);

			// many to many ( Rental and movie )

			modelBuilder.Entity<MovieRental>()
				.HasKey( g => new {g.MovieId, g.RentalId});

			modelBuilder.Entity<Rental>()
				.Property(g => g.TotalCost)
				.HasColumnType("decimal(18,2)");

			modelBuilder.Entity<Movies>()
	   .HasKey(g => g.MovieId);

			modelBuilder.Entity<Movies>()
				.Property(g => g.RentalCost)
				.HasColumnType("decimal(18,2)");
		}
		public DbSet<Movies> Movies { get; set; }
		public DbSet<Member> Members { get; set; }
		public DbSet<Rental> Rentals { get; set; }
		public DbSet<MovieRental> MovieRentals { get; set; }
	}
}
