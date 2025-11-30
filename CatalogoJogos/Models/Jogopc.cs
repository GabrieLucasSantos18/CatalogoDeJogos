using System;
using System.Collections.Generic;

namespace CatalogoJogos.Models;

public partial class Jogopc
{
    public int IdJogopc { get; set; }

    public int IdJogo { get; set; }

    public string RequisitosMinimos { get; set; } = null!;

    public string RequisitosRecomendados { get; set; } = null!;

    public virtual Jogo IdJogoNavigation { get; set; } = null!;
}
