//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using System;
using System.Linq;
using System.Threading.Tasks;
using EasyTransactionTeach.Core.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace EasyTransactionTeach.Core.Brokers.Storages
{
    internal partial class StorageBroker
    {
        public DbSet<User> Users { get; set; }

        public async Task<User> InsertUserAsync(User user)
        {
            await this.Users.AddAsync(user);
            await this.SaveChangesAsync();

            return user;
        }

        public async Task<User> SelectUserById(Guid userId) =>
            await this.Users.FindAsync(userId);

        public IQueryable<User> SelectAllUser() =>
            this.Users.AsQueryable();

        public async Task<User> UpdateUserAsync(User user)
        {
            this.Users.Update(user);
            await this.SaveChangesAsync();

            return user;
        }
    }
}
