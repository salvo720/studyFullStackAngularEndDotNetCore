using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using salutiWebApi.Controllers;


namespace TestsalutiWebApi
{
    public class SalutiControllerTest
    {
        private SalutiController salutiController;

        public SalutiControllerTest()
        {
            this.salutiController = new SalutiController();
        }

        [Fact]
        public void testGetSaluti()
        {
            string retVal = salutiController.getSaluti();
            string testVal = "\"Saluti , sono la tua prima web api\"";

            Assert.Equal(retVal, testVal);

        }

        [Fact]
        public void testGetSaluti2()
        {

            string stringa = "Test";
            string retVal = salutiController.getSaluti(stringa);
            string testVal = "\"Saluti , Test sono la tua prima web api c# 6.0 \"";

            Assert.Equal(retVal, testVal);
        }
    }
}
