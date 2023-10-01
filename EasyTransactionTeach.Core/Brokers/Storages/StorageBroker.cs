//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using EasyTransactionTeach.Core.Models.Accounts;
using EFxceptions;
using Microsoft.EntityFrameworkCore;

namespace EasyTransactionTeach.Core.Brokers.Storages
{
    internal partial class StorageBroker : EFxceptionsContext
    {
        public DbSet<Account> Accounts { get; set; }

        public StorageBroker() =>
           this.Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data sourse=..\\..\\..\\EasyTransactionTeach.db";
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
