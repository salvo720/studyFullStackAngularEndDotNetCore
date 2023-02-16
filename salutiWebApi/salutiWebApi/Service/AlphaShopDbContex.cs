using Microsoft.EntityFrameworkCore;
using salutiWebApi.Models;

namespace salutiWebApi.Service
{
  public class AlphaShopDbContex : DbContext
  {
    protected readonly IConfiguration _configuration;
    public AlphaShopDbContex(DbContextOptions<AlphaShopDbContex> options , IConfiguration configuration) : base(options) {
      _configuration= configuration;
    }

    // la seguente notazione indica una tabella del database ,
    //va mappatto DbSet con la classe del model , e poi con il nome della tabella del db 
    public virtual DbSet<Articoli> Articoli => Set<Articoli>();
    public virtual DbSet<Ean> BarCode => Set<Ean>();
    public virtual DbSet<FamAssort> FamAssort => Set<FamAssort>();
    public virtual DbSet<Ingredienti> Ingredienti => Set<Ingredienti>();
    public virtual DbSet<Iva> Iva => Set<Iva>();



    //metodo OnConfiguring con connessione al db
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      var connectionString = _configuration.GetConnectionString("alphashopDbConnString");
      options.UseSqlServer(connectionString);
    }

    // qui dentro si fa la configurazione fluente
    // andiamo a indicare quli sono le chiavi primarie delle tabelle , le relazione 
    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Articoli>()
        .HasKey(key => new { key.CodArt });

      //relazione one to many (uno a molti ) fra articoli e barcode 

      modelBuilder.Entity<Ean>()
        .HasOne<Articoli>( s => s.articolo)
        .WithMany( g => g.Barcode)
        .HasForeignKey( s => s.CodArt );

      // relazione 1 a uno tra articoli e ingredienti
      modelBuilder.Entity<Articoli>()
        .HasOne<Ingredienti>(s => s.ingrediente)
        .WithOne(g => g.articolo)
        .HasForeignKey<Ingredienti>(s => s.CodArt);

      //relazione one to many iva e articoli
      modelBuilder.Entity<Articoli>()
        .HasOne<Iva>(s => s.iva)
        .WithMany(g => g.articoli)
        .HasForeignKey(s => s.IdIva);

      // relazione one to many fra FamAssort e Articoli
      modelBuilder.Entity<Articoli>()
        .HasOne<FamAssort>(s => s.famAssort)
        .WithMany(g => g.articoli)
        .HasForeignKey(s => s.IdFamAss);

    }
  }
}
