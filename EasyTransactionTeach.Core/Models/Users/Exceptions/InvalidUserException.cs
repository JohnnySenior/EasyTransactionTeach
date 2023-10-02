//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using Xeptions;

namespace EasyTransactionTeach.Core.Models.Users.Exceptions
{
    internal class InvalidUserException : Xeption
    {
        public InvalidUserException()
            : base(message: "Invalid user, fix the error and try again")
        { }
    }
}
