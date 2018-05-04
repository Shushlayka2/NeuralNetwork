using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
