//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using EasyTransactionTeach.Core.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTransactionTeach.Core.Brokers.Storages
{
    internal partial class StorageBroker
    {
        public DbSet<Account> Accounts { get; set; }

        public async Task<Account> InsertAccountAsync(Account account)
        {
            await this.Accounts.AddAsync(account);
            await this.SaveChangesAsync();

            return account;
        }

        public async Task<Account> SelectAccountById(Guid accountId) =>
            await this.Accounts.FindAsync(accountId);

        public IQueryable<Account> SelectAllAccounts() =>
            this.Accounts.AsQueryable();

        public async Task<Account> UpdateAccountAsync(Account account)
        {
            this.Accounts.Update(account);
            await this.SaveChangesAsync();

            return account;
        }

        public async Task<bool> DeleteAccountAsync(Guid accountId)
        {
            var accountToDelete = await this.Accounts.FindAsync(accountId);

            if (accountToDelete == null)
                return false;

            this.Accounts.Remove(accountToDelete);
            await this.SaveChangesAsync();

            return true;
        }
    }
}
