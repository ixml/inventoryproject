using System;
using System.Threading;
using System.Threading.Tasks;
using Inventory.Domain.Entities;
using Inventory.Domain.Entities.Category;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Services
{
    public class InventoryDbContext : DbContext
    {

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.BuildIndexesFromAnnotations();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasIndex(x => x.Status);
                e.Property(e => e.Status).HasConversion<string>();

            });


            modelBuilder.Entity<Category>(e =>
            {
                e.HasKey(e => e.Id);

            });



            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.HasKey(e => e.ID);
            //    entity.Property(e => e.Name).IsRequired();
            //});

            //modelBuilder.Entity<Book>(entity =>
            //{
            //    entity.HasKey(e => e.ISBN);
            //    entity.Property(e => e.Title).IsRequired();
            //    entity.HasOne(d => d.Publisher)
            //      .WithMany(p => p.Books);
            //});
        }

        //public override int SaveChanges()
        //{
        //    TriggerBeforeChangeEntityEvents();
        //    var change = base.SaveChanges();
        //    TriggerAfterChangeEntityEvents();
        //    return change;
        //}

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    TriggerBeforeChangeEntityEvents();
        //    var change = base.SaveChangesAsync(cancellationToken);
        //    TriggerAfterChangeEntityEvents();
        //    return change;
        //}

        //public void TriggerAfterChangeEntityEvents()
        //{

        //}

        //public void TriggerBeforeChangeEntityEvents()
        //{
        //    var changedEntities = ChangeTracker.Entries();
        //    foreach (var changedEntity in changedEntities)
        //    {
        //        if (changedEntity.Entity is EntityBase)
        //        {
        //            var entity = (EntityBase)changedEntity.Entity;

        //            switch (changedEntity.State)
        //            {
        //                case EntityState.Added:
        //                    entity.OnBeforeInsert();
        //                    break;

        //                case EntityState.Modified:
        //                    entity.OnBeforeUpdate();
        //                    break;
        //            }
        //        }
        //    }
        //}
    }
}
