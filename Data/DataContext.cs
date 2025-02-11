using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data
{
    public class DataContext : DbContext
    {

        // DbContextOptions<DataContext> parametresi, veritabanı bağlantı bilgileri ve yapılandırmaları içerir.
        // : base(options) ifadesi, bu yapılandırmaların DbContext sınıfına iletilmesini sağlar,
        // böylece DataContext, belirtilen veritabanıyla çalışabilir.
        // DataContext'in veritabanı bağlantısını ve ayarlarını alıp çalışmasını sağlar. 
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        // this will create the tables in the database with using model classes. 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
        public DbSet<PokemonOwner> PokemonOwners { get; set; }


        // OnModelCreating method is a method for making relational database schemas.
        // This method will be calling for the first time when DbContext class was created. 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonCategory>() // it defines the primary key of the PokemonCategory join table.
                .HasKey(pc => new { pc.PokemonId, pc.CategoryId }); //HasKey method determines the primary key for the PokemonCategory join table, which is the combination of PokemonId and CategoryId.
            // this code defines the one-to-many relationship between the PokemonCategory and the Pokemon entities. 
            modelBuilder.Entity<PokemonCategory>() // it defines the relationship between Pokemon and PokemonCategory.
                .HasOne(p => p.Pokemon) // PokemonCategory entity can has only one Pokemon entity.
                .WithMany(pc => pc.PokemonCategories) // but Pokemon entity can has many PokemonCategory entity. 
                .HasForeignKey(p => p.PokemonId); // PokemonId is a foreign key for the PokemonCategory table. 
            modelBuilder.Entity<PokemonCategory>() // it defines the relationship between Category and PokemonCategory.
                .HasOne(c => c.Category) // PokemonCategory entity can has only one Category entity.
                .WithMany(pc => pc.PokemonCategories) // but Category entity can has many PokemonCategory entity. 
                .HasForeignKey(c => c.CategoryId); // CategoryId is a foreign key for the PokemonCategory table.

            // the same things happening at these codes for PokemonOwner, Pokemon and Owner entities. 
            modelBuilder.Entity<PokemonOwner>() // it defines the primary key of the PokemonOwner join table.
                .HasKey(po => new { po.PokemonId, po.OwnerId }); // PokemonOwner join table has a primary key which is the combination of PokemonId and OwnerId.
            modelBuilder.Entity<PokemonOwner>() // it defines the relationship between Pokemon and PokemonOwner.
                .HasOne(p => p.Pokemon) // PokemonOwner can has one Pokemon.
                .WithMany(po => po.PokemonOwners) // but Pokemon can has many PokemonOwners
                .HasForeignKey(p => p.PokemonId); // the PokemonId is a foreign key for the PokemonOwners. 
            modelBuilder.Entity<PokemonOwner>() // it defines the relationship between Owner and PokemonOwner.
                .HasOne(o => o.Owner) // PokemonOwner can has one Owner.
                .WithMany(po => po.PokemonOwners) // but Owner can has many PokemonOwners
                .HasForeignKey(o => o.OwnerId); // the OwnerId is a foreign key for the PokemonOwners. 
        }

    }
}
