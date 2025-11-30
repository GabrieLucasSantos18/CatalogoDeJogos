using System;
using System.Collections.Generic;

namespace CatalogoJogos.Models;

public partial class Jogomobile
{
    public int IdJogomobile { get; set; }

    public int IdJogo { get; set; }

    public bool PrecisaConexao { get; set; }

    public virtual Jogo IdJogoNavigation { get; set; } = null!;
}
