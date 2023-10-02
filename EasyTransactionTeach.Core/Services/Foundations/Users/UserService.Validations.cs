using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyTransactionTeach.Core.Models.Users;

namespace EasyTransactionTeach.Core.Services.Foundations.Users
{
    internal partial class UserService
    {
        private void ValidateUserOnAdd(User user)
        {
            ValidateUserNotNull(user);
        }

        private void ValidateUserNotNull(User user)
        {
            if(user  == null)
            {
                throw new ArgumentNullException("user");
            }
        }
    }
}
