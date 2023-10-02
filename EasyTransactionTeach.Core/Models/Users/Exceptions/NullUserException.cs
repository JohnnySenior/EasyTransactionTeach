//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using Xeptions;

namespace EasyTransactionTeach.Core.Models.Users.Exceptions
{
    internal class NullUserException : Xeption
    {
        public NullUserException()
            : base(message: "User is null")
        { }
    }
}
