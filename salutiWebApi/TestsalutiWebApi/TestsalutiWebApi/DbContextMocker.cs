using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using salutiWebApi.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsalutiWebApi
{
  internal class DbContextMocker
  {
    public static AlphaShopDbContex alphaShopDbContex(IConfiguration configuration)
    {
  
      // Configure the DbContext to use the connection string from appsettings.json
      var options = new DbContextOptionsBuilder<AlphaShopDbContex>()
          .UseSqlServer(configuration.GetConnectionString("alphashopDbConnString"))
          .Options;

      // Create a new instance of MyDbContext using the options
      var DbContex = new AlphaShopDbContex(options, configuration);


      return DbContex;
    }


  }
}
