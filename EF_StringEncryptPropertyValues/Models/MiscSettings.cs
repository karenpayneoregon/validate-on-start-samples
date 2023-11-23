using EnumLibrary;

namespace EF_StringEncryptPropertyValues.Models;

public class MiscSettings
{
    
    public string Name { get; set; }
    public TheEnum TheEnum { get; set; }
    public override string ToString() => Name;
}




