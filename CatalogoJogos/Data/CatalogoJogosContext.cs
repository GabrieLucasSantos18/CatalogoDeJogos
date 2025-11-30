using System;
using System.Collections.Generic;
using CatalogoJogos.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace CatalogoJogos.Data;

public partial class CatalogoJogosContext : DbContext
{
    public CatalogoJogosContext()
    {
    }

    public CatalogoJogosContext(DbContextOptions<CatalogoJogosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Jogo> Jogos { get; set; }

    public virtual DbSet<Jogoconsole> Jogoconsoles { get; set; }

    public virtual DbSet<Jogomobile> Jogomobiles { get; set; }

    public virtual DbSet<Jogopc> Jogopcs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;user=root;database=catalogo_jogos", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Jogo>(entity =>
        {
            entity.HasKey(e => e.IdJogo).HasName("PRIMARY");

            entity.ToTable("jogo");

            entity.Property(e => e.IdJogo)
                .HasColumnType("int(11)")
                .HasColumnName("ID_jogo");
            entity.Property(e => e.Avaliacao)
                .HasMaxLength(10)
                .HasColumnName("avaliacao");
            entity.Property(e => e.Classificacao)
                .HasColumnType("tinyint(2)")
                .HasColumnName("classificacao");
            entity.Property(e => e.DataLancamento)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("data_lancamento");
            entity.Property(e => e.Descricao)
                .HasColumnType("text")
                .HasColumnName("descricao");
            entity.Property(e => e.Desenvolvedora)
                .HasMaxLength(35)
                .HasColumnName("desenvolvedora");
            entity.Property(e => e.Genero)
                .HasMaxLength(40)
                .HasColumnName("genero");
            entity.Property(e => e.Plataforma)
                .HasColumnType("text")
                .HasColumnName("plataforma");
            entity.Property(e => e.Preco)
                .HasPrecision(4, 2)
                .HasColumnName("preco");
            entity.Property(e => e.Tamanho)
                .HasColumnType("bigint(20)")
                .HasColumnName("tamanho");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Jogoconsole>(entity =>
        {
            entity.HasKey(e => e.IdJogoconsole).HasName("PRIMARY");

            entity.ToTable("jogoconsole");

            entity.HasIndex(e => e.IdJogo, "fkconsole_ID_jogo");

            entity.Property(e => e.IdJogoconsole)
                .HasColumnType("int(11)")
                .HasColumnName("ID_jogoconsole");
            entity.Property(e => e.ConsoleEspecifico)
                .HasMaxLength(15)
                .HasColumnName("console_especifico");
            entity.Property(e => e.IdJogo)
                .HasColumnType("int(11)")
                .HasColumnName("ID_jogo");
            entity.Property(e => e.SuporteMultiplayer).HasColumnName("suporte_multiplayer");

            entity.HasOne(d => d.IdJogoNavigation).WithMany(p => p.Jogoconsoles)
                .HasForeignKey(d => d.IdJogo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkconsole_ID_jogo");
        });

        modelBuilder.Entity<Jogomobile>(entity =>
        {
            entity.HasKey(e => e.IdJogomobile).HasName("PRIMARY");

            entity.ToTable("jogomobile");

            entity.HasIndex(e => e.IdJogo, "fkmobile_ID_jogo");

            entity.Property(e => e.IdJogomobile)
                .HasColumnType("int(11)")
                .HasColumnName("ID_jogomobile");
            entity.Property(e => e.IdJogo)
                .HasColumnType("int(11)")
                .HasColumnName("ID_jogo");
            entity.Property(e => e.PrecisaConexao).HasColumnName("precisa_conexao");

            entity.HasOne(d => d.IdJogoNavigation).WithMany(p => p.Jogomobiles)
                .HasForeignKey(d => d.IdJogo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkmobile_ID_jogo");
        });

        modelBuilder.Entity<Jogopc>(entity =>
        {
            entity.HasKey(e => e.IdJogopc).HasName("PRIMARY");

            entity.ToTable("jogopc");

            entity.HasIndex(e => e.IdJogo, "fkpc_ID_jogo");

            entity.Property(e => e.IdJogopc)
                .HasColumnType("int(11)")
                .HasColumnName("ID_jogopc");
            entity.Property(e => e.IdJogo)
                .HasColumnType("int(11)")
                .HasColumnName("ID_jogo");
            entity.Property(e => e.RequisitosMinimos)
                .HasColumnType("text")
                .HasColumnName("requisitos_minimos");
            entity.Property(e => e.RequisitosRecomendados)
                .HasColumnType("text")
                .HasColumnName("requisitos_recomendados");

            entity.HasOne(d => d.IdJogoNavigation).WithMany(p => p.Jogopcs)
                .HasForeignKey(d => d.IdJogo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkpc_ID_jogo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
