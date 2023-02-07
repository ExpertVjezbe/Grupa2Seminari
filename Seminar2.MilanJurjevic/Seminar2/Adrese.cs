using System;
using System.Collections.Generic;

namespace Seminar2.MilanJurjevic.Seminar2;

public partial class Adrese
{
    public int Id { get; set; }

    public string Naziv { get; set; } = null!;

    public string KucniBroj { get; set; } = null!;

    public string? Kat { get; set; }

    public int? IdGrada { get; set; }

    public virtual Gradovi? IdGradaNavigation { get; set; }
}
