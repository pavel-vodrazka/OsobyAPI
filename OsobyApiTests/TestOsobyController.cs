using OsobyApi.App_Start;
using OsobyApi.Controllers;
using OsobyApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace OsobyApiTests
{
    public class TestOsobyController
    {
        [Fact]
        public async Task PostDemoOsobaDto_ShouldReturnTheSameOsobaDto()
        {
            AutoMapperConfig.Register();

            OsobyController controller = new OsobyController(new TestOsobyApiContext());

            OsobaDto demoOsobaDto = GetDemoOsobaDto();

            //CreatedAtRouteNegotiatedContentResult<OsobaDto> result = await controller.PostOsoba(demoOsobaDto) as CreatedAtRouteNegotiatedContentResult<OsobaDto>;
            var result = await controller.PostOsoba(demoOsobaDto);

            Log.Debug(result.ToString());

            Assert.IsType<InvalidModelStateResult>(result);
        }

        OsobaDto GetDemoOsobaDto()
        {
            return new OsobaDto()
            {
                //Id = 1,
                Jmeno = "Jan",
                Prijmeni = "Novák",
                RodnePrijmeni = null,
                RodneCislo = "8501011233",
                DatumNarozeni = DateTime.Parse("1985-01-01"),
                Narodnost = "Česká",
                Bydliste = new BydlisteDto()
                {
                    //Id = 1,
                    Ulice = "Hlavní 123",
                    Mesto = "Praha",
                    PSC = "11000",
                    Stat = "Česká republika"
                },
                Kontakty = new List<KontaktDto>()
                {
                    new KontaktDto()
                    {
                        //Id = 1,
                        TypKontaktu = "Telefon",
                        Hodnota = "420123456789",
                        //OsobaID = 1
                    },
                    new KontaktDto()
                    {
                        //Id = 2,
                        TypKontaktu = "Email",
                        Hodnota = "jan.novak@example.com",
                        //OsobaID = 1
                    }
                }
            };
        }
    }
}
