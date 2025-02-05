

using Business.Dtos;
using Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Factories;

public static class CustomerFactory
{
    public static UserEntity Create (UserRegistrationForm form)
    {
        return new UserEntity
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
           
        };
    }
}


