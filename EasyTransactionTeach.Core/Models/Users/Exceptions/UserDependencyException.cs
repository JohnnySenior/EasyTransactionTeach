//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using Xeptions;

namespace EasyTransactionTeach.Core.Models.Users.Exceptions
{
    internal class UserDependencyException : Xeption
    {
        public UserDependencyException(Xeption innerException)
            : base(message: "User dependency error occured, contact support",
                  innerException)
        { }
    }
}
