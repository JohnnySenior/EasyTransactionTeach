//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using System;
using Xeptions;

namespace EasyTransactionTeach.Core.Models.Users.Exceptions
{
    internal class LockedUserException : Xeption
    {
        public LockedUserException(Exception innerException)
            : base(message: "User is locked, try later",
                  innerException)
        { }
    }
}
