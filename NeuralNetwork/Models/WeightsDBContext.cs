using Microsoft.EntityFrameworkCore;

namespace NeuralNetwork.Models
{
    class WeightsDBContext : DbContext
    {
        public DbSet<Weight> Weights { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\Latypov Bulat\source\repos\NeuralNetwork\NeuralNetwork\weightsDB.db");
        }

    }
}
