
namespace Business.Interfaces;

public interface IResult
{
   public bool Success { get; }

    public int StatusCode { get; }

   public string? ErrorMessage { get; }

}
