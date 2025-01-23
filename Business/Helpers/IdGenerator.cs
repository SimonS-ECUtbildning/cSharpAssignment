namespace Business.Helpers;

public class IdGenerator
{
    public static string GenerateId() => Guid.NewGuid().ToString();
}