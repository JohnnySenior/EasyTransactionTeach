//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using System;
using Xeptions;

namespace EasyTransactionTeach.Core.Models.Accounts.Exceptions
{
    internal class AlreadyExistsAccountException : Xeption
    {
        public AlreadyExistsAccountException(Exception innerException)
            : base("Account already exists", innerException)
        { }
    }
}
