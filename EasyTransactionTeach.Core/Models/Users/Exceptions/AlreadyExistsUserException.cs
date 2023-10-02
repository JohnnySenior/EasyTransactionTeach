//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using System;
using Xeptions;

namespace EasyTransactionTeach.Core.Models.Users.Exceptions
{
    internal class AlreadyExistsUserException : Xeption
    {
        public AlreadyExistsUserException(Exception innerException)
            : base(message: "User already exists",
                  innerException)
        { }
    }
}
