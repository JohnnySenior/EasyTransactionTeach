//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using Xeptions;

namespace EasyTransactionTeach.Core.Models.Accounts.Exceptions
{
    internal class InvalidAccountException : Xeption
    {
        public InvalidAccountException()
            : base(message: "Invalid account, fix the error and try again")
        { }
    }
}
