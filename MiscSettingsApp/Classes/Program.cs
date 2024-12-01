using System.Runtime.CompilerServices;
using Spectre.Console.Json;

// ReSharper disable once CheckNamespace
namespace MiscSettingsApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

    private static void PresentJson(string json)
    {
        AnsiConsole.Write(
            new JsonText(json)
                .BracesColor(Color.Red)
                .BracketColor(Color.Green)
                .ColonColor(Color.White)
                .CommaColor(Color.Cyan1)
                .StringColor(Color.White)
                .NumberColor(Color.White)
                .BooleanColor(Color.Red)
                .MemberColor(Color.Yellow)
                .NullColor(Color.Green));
    }
}
