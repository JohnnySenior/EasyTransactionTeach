//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using System;
using System.Text.RegularExpressions;
using EasyTransactionTeach.Core.Models.Users;
using EasyTransactionTeach.Core.Models.Users.Exceptions;

namespace EasyTransactionTeach.Core.Services.Foundations.Users
{
    internal partial class UserService
    {
        private void ValidateUserOnAdd(User user)
        {
            ValidateUserNotNull(user);

            Validate((Rule: IsInvalid(user.Id), Parameter: nameof(User.Id)),
                     (Rule: IsInvalid(user.Firstname), Parameter: nameof(User.Firstname)),
                     (Rule: IsInvalid(user.Lastname), Parameter: nameof(User.Lastname)),
                     (Rule: IsInvalid(user.Nationality), Parameter: nameof(User.Nationality)),
                     (Rule: IsInvalid(user.BirthDate), Parameter: nameof(User.BirthDate)),
                     (Rule: IsAgeLess12(user.BirthDate), Parameter: nameof(User.BirthDate)),
                     (Rule: IsInvalid(user.Email), Parameter: nameof(User.Email)));

            Validate((Rule: IsInvalidEmail(user.Email), Parameter: nameof(User.Email)));
        }

        private static void ValidateUserNotNull(User user)
        {
            if (user == null)
            {
                throw new NullUserException();
            }
        }

        private dynamic IsInvalid(Guid id) => new
        {
            Condition = id == default,
            Message = "Id is required"
        };

        private dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private dynamic IsInvalidEmail(string email) => new
        {
            Condition = !Regex.IsMatch(email, @"^(.+)@(.+)$"),
            Message = "Email is invalid"
        };

        private dynamic IsAgeLess12(DateTimeOffset date) => new
        {
            Condition = IsAgeLessThan12(date),
            Message = "Age is less than 12"
        };

        private bool IsAgeLessThan12(DateTimeOffset date)
        {
            DateTimeOffset now = this.dateTimeBroker.GetCurrentDateTimeOffset();
            int age = (now - date).Days / 365;

            return age < 12;
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidUserException = new InvalidUserException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidUserException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidUserException.ThrowIfContainsErrors();
        }
    }
}
