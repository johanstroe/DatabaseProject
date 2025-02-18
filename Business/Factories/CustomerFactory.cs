


using Data.Entities;


namespace Business.Factories;

public static class CustomerFactory
{
    public static CustomerEntity Create (string firstName)
    {
        return new CustomerEntity
        {
            Name = firstName,
            
            
        };
    }
}


