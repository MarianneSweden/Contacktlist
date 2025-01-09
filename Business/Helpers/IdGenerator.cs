using System.Reflection.Metadata;

namespace Business.Helpers;

public static class IdGenerator
{

    //Genererar GUID till en sträng
    public static string GenerateUniqueId() => Guid.NewGuid().ToString();


}
