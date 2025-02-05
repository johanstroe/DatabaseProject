using Business.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Factories
{
    public static class UserFactory
    {
        public static UserEntity Create (string firstName, string lastName, string email)
        {
            return new UserEntity
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };
        }
    }
}
