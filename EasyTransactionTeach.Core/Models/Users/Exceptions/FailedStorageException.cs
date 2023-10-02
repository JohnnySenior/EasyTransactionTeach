//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using System;
using Xeptions;

namespace EasyTransactionTeach.Core.Models.Users.Exceptions
{
    internal class FailedStorageException : Xeption
    {
        public FailedStorageException(Exception innerException)
            : base(message: "User storage error occured, contact support",
                  innerException)
        { }
    }
}
