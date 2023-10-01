//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using EasyTransactionTeach.Core.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace EasyTransactionTeach.Core.Brokers.Storages
{
    internal partial class StorageBroker
    {
        public DbSet<User> Users { get; set; }
    }
}
