using System;
using System.Collections.Generic;

namespace Seminar2.FraneGregov.Seminar2;

public partial class Drzave
{
    public int Id { get; set; }

    public string Naziv { get; set; } = null!;

    public string Kratica { get; set; } = null!;

    public string? NazivEngleski { get; set; }

    public string? NazivKineski { get; set; }

    public virtual ICollection<Gradovi> Gradovis { get; } = new List<Gradovi>();
}
