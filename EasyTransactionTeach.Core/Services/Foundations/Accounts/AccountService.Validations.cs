//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using EasyTransactionTeach.Core.Models.Accounts.Exceptions;
using EasyTransactionTeach.Core.Models.Accounts;
using System.Text.RegularExpressions;
using System;

namespace EasyTransactionTeach.Core.Services.Foundations.Accounts
{
    internal partial class AccountService
    {
        private void ValidateAccountOnAdd(Account account)
        {
            ValidateAccountNotNull(account);

            Validate(
                (Rule: IsInvalid(account.Id), Parameter: nameof(Account.Id)),
                (Rule: IsInvalid(account.AccountNumber), Parameter: nameof(Account.AccountNumber)),
                (Rule: IsInvalid(account.Login), Parameter: nameof(Account.Login)),
                (Rule: IsInvalid(account.Password), Parameter: nameof(Account.Password)),
                (Rule: IsInvalidPassword(account.Password), Parameter: nameof(Account.Password)),
                (Rule: IsInvalidBalance(account.Balance), Parameter: nameof(Account.Balance)));
        }

        private static void ValidateAccountNotNull(Account account)
        {
            if (account is null)
                throw new NullAccountException();
        }

        private dynamic IsInvalid(Guid Id) => new
        {
            Condition = Id == default,
            Message = "Id is required"
        };

        private dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private dynamic IsInvalidBalance(decimal balance) => new
        {
            Condition = balance < 0,
            Message = "Balance cannot be negative"
        };

        private dynamic IsInvalidPassword(string password) => new
        {
            Condition = !Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{5,}$"),
            Message = "Password must contain at least one lowercase letter, " +
            "one uppercase letter and a number"
        };

        private void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidAccountException = new InvalidAccountException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidAccountException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidAccountException.ThrowIfContainsErrors();
        }
    }
}
