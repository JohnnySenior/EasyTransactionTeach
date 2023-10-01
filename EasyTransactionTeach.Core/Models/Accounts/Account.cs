//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using System;

namespace EasyTransactionTeach.Core.Models.Accounts
{
    internal class Account
    {
        public Guid Id { get; set; }
        public Guid AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
