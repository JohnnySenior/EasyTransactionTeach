//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using System;
using Xeptions;

namespace EasyTransactionTeach.Core.Models.Accounts.Exceptions
{
    internal class FailedStorageAccountException : Xeption
    {
        public FailedStorageAccountException(Exception innerException)
            : base(message: "Failed account storage error occurred, contact support", innerException)
        { }
    }
}
