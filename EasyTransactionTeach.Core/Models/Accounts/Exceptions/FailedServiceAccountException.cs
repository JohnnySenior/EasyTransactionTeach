//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using System;
using Xeptions;

namespace EasyTransactionTeach.Core.Models.Accounts.Exceptions
{
    internal class FailedServiceAccountException : Xeption
    {
        public FailedServiceAccountException(Exception innerException)
            : base(message: "Failed account service error occurred, contact support", innerException)
        { }
    }
}
