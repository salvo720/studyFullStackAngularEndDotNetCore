using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NuGet.ContentModel;
using salutiWebApi.Controllers;
using salutiWebApi.Dtos;
using salutiWebApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsalutiWebApi
{
  public class ArticoliControllerTest
  {
    // includiamo il file con la stringa di connessione e il parametro IConfiguration _configuration 
    private IConfiguration _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

    // string errore di default
    string errorString = "\" Non e stato trovato alcun articolo con il {0} '{1}' \"";




     [Fact]
    public async Task TestSelArticoloByDescrizione()
    {
      string Descrizione = "ACQUA ROCCHETTA";

      //Arrange block , Fase Arrange Block e quella parte che crea un nuovo dbcontext e poi instanzia e crea un nuovo controller passando l'articoli repository
      // che a sua volta avra il dbContext come parametro
      var dbContext = DbContextMocker.alphaShopDbContex(_configuration);

      var controller = new ArticoliController(new ArticoliRepository(dbContext));

      // Act , Fase Act dopo aver instaziato il nostro controller ci sara la fase di act ovvero azione
      // dove otteniamo una risposta dal nostro controller che pero dovra essere convertita in un tipo Dto
      var response = await controller.GetArticoliByDesc(Descrizione) as ObjectResult;
      var value = response.Value as ICollection<ArticoliDto>;

      dbContext.Dispose(); // svuota il dbcontext , perche abbiamo gia ottenuto i dati


      //Asset
      Assert.Equal(200, response.StatusCode);
      Assert.NotNull(value);
      Assert.Equal(3, value.Count); // gli articoli sono 3
      Assert.Equal("002001201", value.FirstOrDefault().CodArt); // il primo articolo sara il "002001201"
    }

    [Fact]
    public async Task TestErrSelArticoliByDescrizione()
    {
      string descrizione = "Pippo";

      //Arrange
      var dbContext = DbContextMocker.alphaShopDbContex(_configuration);

      var controller = new ArticoliController(new ArticoliRepository(dbContext));

      //Act
      var response = await controller.GetArticoliByDesc(descrizione) as ObjectResult;
      var value = response.Value as ICollection<ArticoliDto>;

      dbContext.Dispose(); // svuoto il DbContext

      //Assert
      Assert.Equal(404, response.StatusCode);
      Assert.Null(value);
      Assert.Equal(string.Format(errorString , nameof(descrizione) , descrizione ), response.Value);

    }

    [Fact] // indica che e un test
    public async Task TestSetArticoliByCode() // usiamo la notazione asycn e Task perche il metodo nella saluti web api e asincrono
    {
      string CodArt = "000992601";

      //Arrange block , Fase Arrange Block e quella parte che crea un nuovo dbcontext e poi instanzia e crea un nuovo controller passando l'articoli repository
      // che a sua volta avra il dbContext come parametro
      var dbContext = DbContextMocker.alphaShopDbContex(_configuration);
      var controller = new ArticoliController(new ArticoliRepository(dbContext));


            // Add your test code here

      // Act , Fase Act dopo aver instaziato il nostro controller ci sara la fase di act ovvero azione
      // dove otteniamo una risposta dal nostro controller che pero dovra essere convertita in un tipo Dto
      var response = await controller.GetArticoliByCodice(CodArt) as ObjectResult;
      var value = response.Value as ArticoliDto;

      dbContext.Dispose(); // svuota il dbcontext , perche abbiamo gia ottenuto i dati


      // Asset , Fase di asserzione
      Assert.Equal(200, response.StatusCode); // indica che il nostro controller ci ha risposto e non ci sono stati errori , perche lo status code e 200
      Assert.NotNull(value); // verifichiamo che il valore non sia null
      Assert.Equal(CodArt, value.CodArt); // verifichiamo che il nostro codice articolo sia uguale a quello dentro la risposta di articoliController

    }

    [Fact]
    public async Task TestErrSetArticolOByCode()
    {
      string codArt = "0009926010";

      //Arrange block , Fase Arrange Block e quella parte che crea un nuovo dbcontext e poi instanzia e crea un nuovo controller passando l'articoli repository
      // che a sua volta avra il dbContext come parametro
      var dbContext = DbContextMocker.alphaShopDbContex(_configuration);

      var controller = new ArticoliController(new ArticoliRepository(dbContext));

      // Act , Fase Act dopo aver instaziato il nostro controller ci sara la fase di act ovvero azione
      // dove otteniamo una risposta dal nostro controller che pero dovra essere convertita in un tipo Dto
      var response = await controller.GetArticoliByCodice(codArt) as ObjectResult;
      var value = response.Value as ArticoliDto; // se la conversione dalla risposta all'alrticoliDto non avviene la risposta sara Null
      // inoltre noi non verichiamo la risposta ma il response.value ovvero la risposta finale
      dbContext.Dispose(); // svuota il dbcontext , perche abbiamo gia ottenuto i dati


      // Asset , Fase di asserzione
      Assert.Equal(404, response.StatusCode); // indica che il nostro controller ci ha risposto e non ci sono stati errori , perche lo status code e 200
      Assert.Null(value); // verifichiamo che il valore sia null
      Assert.Equal(string.Format(errorString, nameof(codArt) , codArt), response.Value); // verifichiamo che il nostro codice articolo sia uguale a quello dentro la risposta di articoliController

    }



    [Fact]
    public async Task TestSelArticoliByBarcode()
    {
      string barcode = "8076809504676";

      //Arrange
      var dbContext = DbContextMocker.alphaShopDbContex(_configuration);
      var controller = new ArticoliController(new ArticoliRepository(dbContext));

      //Act
      var response = await controller.GetArticoloByEan(barcode) as ObjectResult;
      var value = response.Value as ArticoliDto;

      dbContext.Dispose(); // svuoto il DbContext

      //Assert
      Assert.Equal(200, response.StatusCode);
      Assert.NotNull(value);
      Assert.Equal(barcode, value.BarcodeDto.FirstOrDefault().Barcode);

    }

    [Fact]
    public async Task TestErrSelArticoliByBarcode()
    {
      string barcode = "80582533A";

      //Arrange
      var dbContext = DbContextMocker.alphaShopDbContex(_configuration);

      var controller = new ArticoliController(new ArticoliRepository(dbContext));

      //Act
      var response = await controller.GetArticoloByEan(barcode) as ObjectResult;
      var value = response.Value as ArticoliDto;

      dbContext.Dispose(); // svuoto il DbContext

      //Assert
      Assert.Equal(404, response.StatusCode);
      Assert.Null(value);
      Assert.Equal(string.Format(errorString , nameof(barcode) ,barcode ), response.Value);

    }
  }
}
