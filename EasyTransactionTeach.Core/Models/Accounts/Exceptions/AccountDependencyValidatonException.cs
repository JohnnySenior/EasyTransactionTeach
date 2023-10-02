//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using Xeptions;

namespace EasyTransactionTeach.Core.Models.Accounts.Exceptions
{
    internal class AccountDependencyValidatonException : Xeption
    {
        public AccountDependencyValidatonException(Xeption innerException)
            : base(message: "Account dependency validation error occurred, fix the error and try again", innerException)
        { }
    }
}
