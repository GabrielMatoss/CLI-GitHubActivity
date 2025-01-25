using System;
using System.Transactions;
using CLI.IA.Models;

namespace CLI.IA.SerializeClass;


public class Payload
{
    public string Action { get; set; } = null!;
    public Commit[]? Commits { get; set; }
}