namespace EF_StringEncryptPropertyValues.Models;

/// <summary>
/// Represents a configuration section for storing database connection strings.
/// </summary>
public class ConnectionStrings
{
    /// <summary>
    /// Gets or sets the default database connection string.
    /// </summary>
    public string DefaultConnection { get; set; }
}