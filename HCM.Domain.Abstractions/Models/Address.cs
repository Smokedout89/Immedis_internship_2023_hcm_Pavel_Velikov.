﻿namespace HCM.Domain.Abstractions.Models;

public class Address : Model
{
    public string TownId { get; set; } = string.Empty;
    public string StreetName { get; set; } = string.Empty;
    public int StreetNumber { get; set; }
}