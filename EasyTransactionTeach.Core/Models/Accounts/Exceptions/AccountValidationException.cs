//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using Xeptions;

namespace EasyTransactionTeach.Core.Models.Accounts.Exceptions
{
    internal class AccountValidationException : Xeption
    {
        public AccountValidationException(Xeption innerException)
            : base(message: "Account validation error occurred, fox the error and try again", innerException)
        { }
    }
}
