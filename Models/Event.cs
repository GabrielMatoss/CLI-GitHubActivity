using System;
using CLI.IA.SerializeClass;

namespace CLI.IA.Models;

public class Event
{
    public string Type { get; set; } = null!;
    public Payload Payload { get; set; } = null!;
    public Repo Repo { get; set; } = null!;
}
