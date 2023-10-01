//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using System;

namespace EasyTransactionTeach.Core.Brokers.DateTimes
{
    internal class DateTimeBroker
    {
        internal DateTimeOffset GetCurrentDateTimeOffset() =>
            DateTimeOffset.UtcNow;
    }
}
