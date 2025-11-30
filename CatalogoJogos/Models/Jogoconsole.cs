using System;
using System.Collections.Generic;

namespace CatalogoJogos.Models;

public partial class Jogoconsole
{
    public int IdJogoconsole { get; set; }

    public int IdJogo { get; set; }

    public string ConsoleEspecifico { get; set; } = null!;

    public bool SuporteMultiplayer { get; set; }

    public virtual Jogo IdJogoNavigation { get; set; } = null!;
}
