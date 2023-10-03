//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using Xeptions;

namespace EasyTransactionTeach.Core.Models.Accounts.Exceptions
{
    internal class AccountDependencyException : Xeption
    {
        public AccountDependencyException(Xeption innerException)
            : base(message: "Account dependency error occurred, contact support", innerException)
        { }
    }
}
