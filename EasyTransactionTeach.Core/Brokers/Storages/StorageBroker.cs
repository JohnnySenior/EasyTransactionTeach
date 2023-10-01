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
        public StorageBroker() =>
           this.Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data source=..\\..\\..\\EasyTransactionTeach.db";
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
