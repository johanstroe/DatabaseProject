using Business.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Factories
{
    public static class EmployeeFactory
    {
        public static EmployeeEntity Create (string firstName, string lastName, string email)
        {
            return new EmployeeEntity
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };
        }
    }
}
