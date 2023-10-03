//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using Xeptions;

namespace EasyTransactionTeach.Core.Models.Accounts.Exceptions
{
    internal class NullAccountException : Xeption
    {
        public NullAccountException()
            : base(message: "Account is null")
        { }
    }
}
