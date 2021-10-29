#nullable enable
using System;

namespace Core.Domain
{
    public class Diagnose
    {
        public int Id { get; set; }
        public Int16? DiagnoseCode { get; set; }
        public string? BodyLocation { get; set; }
        public string? Pathology { get; set; }
    }
}