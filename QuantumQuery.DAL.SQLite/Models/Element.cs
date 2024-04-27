using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuantumQuery.DAL.SQLite.Models;

[Table("Element")]
public partial class Element
{
    [Key]
    public string Id { get; set; } = null!;

    public long Index { get; set; }

    public string ShortName { get; set; } = null!;

    public string ElementName { get; set; } = null!;

    public double AtomicMass { get; set; }

    [Column("CPKHexColor")]
    public string CpkhexColor { get; set; } = null!;

    public string? StandardState { get; set; }

    public string? ElectronConfiguration { get; set; }

    public string? OxidationStates { get; set; }

    public double? Electronegativity { get; set; }

    public long? AtomicRadius { get; set; }

    public double? IonizationEnergy { get; set; }

    public double? ElectronAffinity { get; set; }

    public double? MeltingPoint { get; set; }

    public double? BoilingPoint { get; set; }

    public double? Density { get; set; }

    public string GroupBlock { get; set; } = null!;

    public string? YearDiscovered { get; set; }
}
