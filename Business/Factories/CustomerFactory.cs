


using Data.Entities;


namespace Business.Factories;

public static class CustomerFactory
{
    public static CustomerEntity Create (string Name)
    {
        return new CustomerEntity
        {
            Name = Name,
            
            
        };
    }
}


