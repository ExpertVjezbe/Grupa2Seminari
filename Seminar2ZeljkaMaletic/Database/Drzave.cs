using System;
using System.Collections.Generic;

namespace Seminar2ZeljkaMaletic.Database;

public partial class Drzave
{
    public int Id { get; set; }

    public string Naziv { get; set; } = null!;

    public string Kratica { get; set; } = null!;

    public string? Opis { get; set; }

    public virtual ICollection<Gradovi> Gradovis { get; } = new List<Gradovi>();
}
