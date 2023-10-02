//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using Xeptions;

namespace EasyTransactionTeach.Core.Models.Accounts.Exceptions
{
    internal class AccountServiceException : Xeption
    {
        public AccountServiceException(Xeption innerException)
            : base(message: "Account service error occurred, contact support", innerException)
        { }
    }
}
