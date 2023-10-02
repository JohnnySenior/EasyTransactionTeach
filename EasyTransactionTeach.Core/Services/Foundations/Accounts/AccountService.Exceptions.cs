//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using EasyTransactionTeach.Core.Models.Accounts;
using EasyTransactionTeach.Core.Models.Accounts.Exceptions;
using EFxceptions.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xeptions;

namespace EasyTransactionTeach.Core.Services.Foundations.Accounts
{
    internal partial class AccountService
    {
        private delegate Task<Account> ReturningAccountFunction();

        private Task<Account> TryCatch(ReturningAccountFunction returningAccountFunction)
        {
            try
            {
                return returningAccountFunction();
            }
            catch (NullAccountException nullAccountException)
            {
                throw CreateValidationException(nullAccountException);
            }
            catch (InvalidAccountException invalidAccountException)
            {
                throw CreateValidationException(invalidAccountException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsAccountException =
                    new AlreadyExistsAccountException(duplicateKeyException);

                throw CreateDependencyValidationException(alreadyExistsAccountException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedAccountException =
                    new LockedAccountException(dbUpdateConcurrencyException);

                throw CreateDependencyException(lockedAccountException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                var failedStorageAccountException =
                    new FailedStorageAccountException(dbUpdateException);

                throw CreateDependencyException(failedStorageAccountException);
            }
            catch (Exception exception)
            {
                var failedServiceAccountException =
                    new FailedServiceAccountException(exception);

                throw CreateServiceException(failedServiceAccountException);
            }
        }

        private AccountValidationException CreateValidationException(Xeption exception)
        {
            var accountValidationException =
                    new AccountValidationException(exception);

            return accountValidationException;
        }

        private AccountDependencyValidatonException CreateDependencyValidationException(Xeption exception)
        {
            var accountDependencyValidatonException =
                   new AccountDependencyValidatonException(exception);

            return accountDependencyValidatonException;
        }

        private AccountDependencyException CreateDependencyException(Xeption exception)
        {
            var accountDependencyException =
                new AccountDependencyException(exception);

            return accountDependencyException;
        }

        private AccountServiceException CreateServiceException(Xeption exception)
        {
            var accountServiceException =
                new AccountServiceException(exception);

            return accountServiceException;
        }
    }
}
