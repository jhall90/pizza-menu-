using Microsoft.EntityFrameworkCore;
using Menu_Project.Models;

namespace Menu_Project.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext( DbContextOptions<MenuContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId
            });

            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d=> d.DishId);
            modelBuilder.Entity<DishIngredient>().HasOne(i => i.Ingredient).WithMany(di => di.DishIngredients).HasForeignKey(i=> i.IngredientId);


            modelBuilder.Entity<Dish>().HasData(
                    new Dish { Id=1, Name="Jishue's DF Pizza", Price=2.99, ImageUrl= "https://www.budgetbytes.com/wp-content/uploads/2020/06/BBQ-Chicken-Pizza-one-slice.jpg" }
                );
            modelBuilder.Entity<Ingredient>().HasData(
                    new Ingredient { Id=1, Name="BBQ Sauce"},
                    new Ingredient { Id=2, Name="Onion"},
                    new Ingredient { Id=3, Name="Oat Milk Mozzarella"}
                );
            modelBuilder.Entity<DishIngredient>().HasData(
                    new DishIngredient { DishId = 1, IngredientId = 1},
                    new DishIngredient { DishId = 1, IngredientId = 2},
                    new DishIngredient { DishId = 1, IngredientId = 3}
                );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }

    }
}
