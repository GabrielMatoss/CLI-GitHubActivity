using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.VisualBasic;

namespace CLI.IA.Utils;

public static class FormatJson
{
    public static readonly JsonSerializerOptions options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };
}
