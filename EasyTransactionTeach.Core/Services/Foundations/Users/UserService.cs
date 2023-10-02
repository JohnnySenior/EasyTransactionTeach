//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using System.Threading.Tasks;
using EasyTransactionTeach.Core.Brokers.DateTimes;
using EasyTransactionTeach.Core.Brokers.Loggings.Logging;
using EasyTransactionTeach.Core.Brokers.Storages;
using EasyTransactionTeach.Core.Models.Users;

namespace EasyTransactionTeach.Core.Services.Foundations.Users
{
    internal partial class UserService
    {
        private readonly StorageBroker storageBroker;
        private readonly LoggingBroker loggingBroker;
        private readonly DateTimeBroker dateTimeBroker;

        public UserService(StorageBroker storageBroker, LoggingBroker loggingBroker, DateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        internal Task<User> AddUserAsync(User user) =>
        TryCatch(() =>
        {
            ValidateUserOnAdd(user);

            return this.storageBroker.InsertUserAsync(user);
        });
    }
}
