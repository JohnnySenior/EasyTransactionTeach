//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using System;
using Xeptions;

namespace EasyTransactionTeach.Core.Models.Users.Exceptions
{
    internal class FailedUserException : Xeption
    {
        public FailedUserException(Exception innerException)
            : base(message: "Failed user service error occured, contact support",
                  innerException)
        { }
    }
}
