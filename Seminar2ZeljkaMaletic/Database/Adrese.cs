using System;
using System.Collections.Generic;

namespace Seminar2ZeljkaMaletic.Database;

public partial class Adrese
{
    public int Id { get; set; }

    public string NazivUlice { get; set; } = null!;

    public string Kat { get; set; } = null!;

    public string KucniBroj { get; set; } = null!;

    public int IdGradovi { get; set; }

    public virtual Gradovi IdGradoviNavigation { get; set; } = null!;
}
