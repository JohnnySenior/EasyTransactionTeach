//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using System;
using Xeptions;

namespace EasyTransactionTeach.Core.Models.Accounts.Exceptions
{
    internal class LockedAccountException : Xeption
    {
        public LockedAccountException(Exception innerException)
            : base(message: "Account is locked, try again later", innerException)
        { }
    }
}
