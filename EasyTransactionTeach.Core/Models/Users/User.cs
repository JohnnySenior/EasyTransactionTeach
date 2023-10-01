//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using System;

namespace EasyTransactionTeach.Core.Models.Users
{
    internal class User
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nationality { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid AccountId { get; set; }
    }
}
