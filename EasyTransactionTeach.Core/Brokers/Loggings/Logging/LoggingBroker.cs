//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using System;

namespace EasyTransactionTeach.Core.Brokers.Loggings.Logging
{
    internal class LoggingBroker
    {
        public void LogError(Exception exception) =>
            Console.WriteLine(exception.Message);
    }
}
