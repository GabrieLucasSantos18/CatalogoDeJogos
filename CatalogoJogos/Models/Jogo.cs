using System;
using System.Collections.Generic;

namespace CatalogoJogos.Models;

public partial class Jogo
{
    public int IdJogo { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public decimal Preco { get; set; }

    public long Tamanho { get; set; }

    public sbyte Classificacao { get; set; }

    public string Avaliacao { get; set; } = null!;

    public DateTime DataLancamento { get; set; }

    public string Desenvolvedora { get; set; } = null!;

    public string Plataforma { get; set; } = null!;

    public virtual ICollection<Jogoconsole> Jogoconsoles { get; set; } = new List<Jogoconsole>();

    public virtual ICollection<Jogomobile> Jogomobiles { get; set; } = new List<Jogomobile>();

    public virtual ICollection<Jogopc> Jogopcs { get; set; } = new List<Jogopc>();
}
