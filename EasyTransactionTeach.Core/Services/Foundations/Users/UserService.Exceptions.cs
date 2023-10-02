//==========================
// Copyright (c) Tarteeb LLC
// Manage Your Money Easy
//==========================

using EasyTransactionTeach.Core.Models.Users;
using System.Threading.Tasks;
using System;
using Xeptions;
using EFxceptions.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using EasyTransactionTeach.Core.Models.Users.Exceptions;

namespace EasyTransactionTeach.Core.Services.Foundations.Users
{
    internal partial class UserService
    {
        private delegate Task<User> ReturningUserFunction();
        private Task<User> TryCatch(ReturningUserFunction returningUserFunction)
        {
            try
            {
                return returningUserFunction();
            }
            catch (NullUserException nullUserException)
            {
                throw CreateValidationException(nullUserException);
            }
            catch (InvalidUserException invalidUserException)
            {
                throw CreateValidationException(invalidUserException);
            }
            catch(DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsUserException =
                    new AlreadyExistsUserException(duplicateKeyException);

                throw CreateDependencyValidationException(alreadyExistsUserException);
            }
            catch(DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                LockedUserException lockedUserException =
                    new LockedUserException(dbUpdateConcurrencyException);

                throw CreateDependencyException(lockedUserException);
            }
            catch(DbUpdateException dbUpdateException)
            {
                FailedStorageException failedStorageException =
                    new FailedStorageException(dbUpdateException);

                throw CreateDependencyException(failedStorageException);
            }
            catch(Exception exception)
            {
                FailedUserException failedUserException =
                    new FailedUserException(exception);

                throw CreateServiceException(failedUserException);
            }
        }

        private UserServiceException CreateServiceException(Xeption exception)
        {
            UserServiceException userServiceException = new UserServiceException(exception);

            return userServiceException;
        }

        private UserDependencyException CreateDependencyException(Xeption exception)
        {
            var userDependencyException = new UserDependencyException(exception);

            return userDependencyException;
        }

        private UserDependencyValidationException CreateDependencyValidationException(Xeption exception)
        {
            var userDependencyValidationException = new UserDependencyValidationException(exception);

            return userDependencyValidationException;
        }

        private UserValidationException CreateValidationException(Xeption exception)
        {
            var userValidationException = new UserValidationException(exception);

            return userValidationException;
        }
    }
}
