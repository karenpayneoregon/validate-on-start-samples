﻿using System.Text.Json;
using MiscSettingsApp.Classes;
using MiscSettingsApp.Models;
using Spectre.Console.Json;

#pragma warning disable CA1869
#pragma warning disable CA1869

namespace MiscSettingsApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        var list = await Operations.ReadMiscSettings();
        list.ToJson("data");

        MiscSettingsRoot root = new() { MiscSettings = list.ToArray()};
        var json = JsonSerializer.Serialize(root, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        PresentJson(json);

        Console.WriteLine();
        Console.WriteLine();
        json.ToJson("FinalResults");
        AnsiConsole.MarkupLine("[yellow]Done[/]");
        Console.ReadLine();
    }
}