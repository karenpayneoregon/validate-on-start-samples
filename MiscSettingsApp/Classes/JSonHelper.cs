using System.Text.Json;

namespace MiscSettingsApp.Classes;
public static class JSonHelper
{
    /// <summary>
    /// Serializes a list of objects to a JSON file.
    /// </summary>
    /// <typeparam name="T">The type of objects in the list.</typeparam>
    /// <param name="sender">The list of objects to serialize.</param>
    /// <param name="fileName">The name of the file (without extension) where the JSON will be saved.</param>
    public static void ToJson<T>(this List<T> sender, string fileName)
    {
        File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{fileName}.json"),
            JsonSerializer.Serialize(sender, SerializerOptions));
    }
    /// <summary>
    /// Serializes an array of objects to a JSON file.
    /// </summary>
    /// <typeparam name="T">The type of objects in the array.</typeparam>
    /// <param name="sender">The array of objects to serialize.</param>
    /// <param name="fileName">The name of the file (without extension) where the JSON will be saved.</param>
    public static void ToJson<T>(this T[] sender, string fileName)
    {
        File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{fileName}.json"),
            JsonSerializer.Serialize(sender, SerializerOptions));
    }

    /// <summary>
    /// Write Json string to file
    /// </summary>
    /// <param name="sender">Json string</param>
    /// <param name="fileName">Filename without extension</param>
    public static void ToJson(this string sender, string fileName)
    {
        var json = JsonSerializer.Serialize(sender, SerializerOptions);
        
        File.WriteAllText($"{fileName}.json", sender);
    }

    private static JsonSerializerOptions SerializerOptions =>
        new()
        {
            WriteIndented = true
        };

}
