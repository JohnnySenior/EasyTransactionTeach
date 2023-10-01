//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using System;
using System.Threading.Tasks;
using EasyTransactionTeach.Core.Brokers.Storages;
using EasyTransactionTeach.Core.Models.Users;

namespace EasyTransaction.Core
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Firstname = "John",
                Lastname = "Doe",
                Email = "somthing",
                Nationality = "Uzbek"
            };

            using (StorageBroker broker = new StorageBroker())
            {
                var insertedUser = await broker.InsertUserAsync(user);
                var selectedUser = await broker.SelectUserById(insertedUser.Id);

                Console.WriteLine(selectedUser.Firstname);
            }
        }
    }
}