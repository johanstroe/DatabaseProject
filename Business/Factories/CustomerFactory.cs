

using Business.Dtos;
using Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Factories;

public static class CustomerFactory
{
    public static CustomerEntity Create (string firstName, string lastName, string email)
    {
        return new CustomerEntity
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            
        };
    }
}


