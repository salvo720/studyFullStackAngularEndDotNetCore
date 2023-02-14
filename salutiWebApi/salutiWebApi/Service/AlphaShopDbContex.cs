using Microsoft.EntityFrameworkCore;
using salutiWebApi.Models;

namespace salutiWebApi.Service
{
  public class AlphaShopDbContex : DbContext
  {
    public AlphaShopDbContex(DbContextOptions<AlphaShopDbContex> options) : base(options) {

    }

    // la seguente notazione indica una tabella del database ,
    //va mappatto DbSet con la classe del model , e poi con il nome della tabella del db 
    public virtual DbSet<Articoli> Articoli { get; set; }
    public virtual DbSet<Ean> BarCode { get; set; }
    public virtual DbSet<FamAssort> FamAssort { get; set; }
    public virtual DbSet<Ingredienti> Ingredienti { get; set; }
    public virtual DbSet<Iva> Iva { get; set; }


    // qui dentro si fa la configurazione fluente
    // andiamo a indicare quli sono le chiavi primarie delle tabelle , le relazione 
    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Articoli>()
        .HasKey(key => new { key.CodArt });

      //relazione one to many (uno a molti ) fra articoli e barcode 

      modelBuilder.Entity<Ean>()
        .HasOne<Articoli>( keyOne => keyOne.articolo)
        .WithMany( keyMany => keyMany.Barcode)
        .HasForeignKey( keyForeign => keyForeign.CodArt );
    }
  }
}
