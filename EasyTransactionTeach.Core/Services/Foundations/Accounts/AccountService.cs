//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using EasyTransactionTeach.Core.Brokers.DateTimes;
using EasyTransactionTeach.Core.Brokers.Loggings.Logging;
using EasyTransactionTeach.Core.Brokers.Storages;
using EasyTransactionTeach.Core.Models.Accounts;
using System.Threading.Tasks;

namespace EasyTransactionTeach.Core.Services.Foundations.Accounts
{
    internal partial class AccountService
    {
        private readonly StorageBroker storageBroker;
        private readonly LoggingBroker loggingBroker;
        private readonly DateTimeBroker dateTimeBroker;

        public AccountService(StorageBroker storageBroker, LoggingBroker loggingBroker, DateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        internal Task<Account> AddAccountAsync(Account account) =>
        TryCatch(() =>
        {
            ValidateAccountOnAdd(account);

            return this.storageBroker.InsertAccountAsync(account);
        });
    }
}
