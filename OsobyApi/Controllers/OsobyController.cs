using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OsobyApi.App_Start;
using OsobyApi.Data;
using OsobyApi.Models;

namespace OsobyApi.Controllers
{
    /// <summary>
    /// Controller for the route api/Osoby/{id}.
    /// 
    /// (Requests where {id} doesn't match "^$|^\d+$" are routed to "Error404" route.)
    /// 
    /// Has actions for GET and POST requests.
    /// </summary>
    public class OsobyController : ApiController
    {
        private readonly IOsobyApiContext db = new OsobyApiContext();

        private readonly IMapper mapper = AutoMapperConfig.MapperConfig.CreateMapper();

        public OsobyController() { }

        public OsobyController(IOsobyApiContext context)
        {
            db = context;
        }

        /// <summary>
        /// Returns the person with the given integer <c>id</c>
        /// </summary>
        /// <response code="200">The person with the given <c>id</c> is found</response>
        /// <response code="404">The person with the given <c>id</c> is not found</response>
        [ResponseType(typeof(OsobaDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IHttpActionResult> GetOsoba(int id)
        {
            if (!OsobaExists(id))
                return NotFound();

            List<Osoba> osoby = await db.Osoby
                .Where(o => o.Id == id)
                .Include(o => o.Bydliste)
                .Include(o => o.Kontakty)
                .ToListAsync();

            OsobaDto osobaDto = mapper.Map<OsobaDto>(osoby.First());

            return Ok(osobaDto);
        }

        /// <summary>
        /// Creates a person from the given data
        /// </summary>
        /// <param name="osobaDto"></param>
        /// <remarks>
        /// Values supplied for Stat, Narodnost, and TypKontaktu are checked against existing codebooks.
        /// RodneCislo is checked for validity.
        /// DatumNarozeni is correlated with RodneCislo.
        /// </remarks>
        /// <response code="201">A person is created from the given data</response>
        /// <response code="400">The given data structure or data content is not valid</response>
        [ResponseType(typeof(OsobaDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IHttpActionResult> PostOsoba(OsobaDto osobaDto)
        {
            // Errors found in model validation based on attributes
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (db.Narodnosti.Count(n => n.Nazev == osobaDto.Narodnost) == 0)
                ModelState.AddModelError("osobaDto.Narodnost", $"Hodnota pole Narodnost (\"{osobaDto.Narodnost}\") neexistuje v číselníku.");

            if (db.Staty.Count(s => s.Nazev == osobaDto.Bydliste.Stat) == 0)
                ModelState.AddModelError("osobaDto.Bydliste.Stat", $"Hodnota pole Stat (\"{osobaDto.Bydliste.Stat}\") neexistuje v číselníku.");

            foreach (KontaktDto k in osobaDto.Kontakty)
            {
                if (db.TypyKontaktu.Count(t => t.Typ == k.TypKontaktu) == 0)
                {
                    ModelState.AddModelError("osobaDto.Kontakty", $"Hodnota pole TypKontaktu (\"{k.TypKontaktu}\") neexistuje v číselníku.");
                }
            }

            (bool result, DateTime birthDate) rodneCisloValidationResult = RodneCislo.IsValid(osobaDto.RodneCislo);
            if (!rodneCisloValidationResult.result)
                ModelState.AddModelError("osobaDto.RodneCislo", $"Hodnota pole RodneCislo (\"{osobaDto.RodneCislo}\") není platným rodným číslem.");
            else if (rodneCisloValidationResult.birthDate != osobaDto.DatumNarozeni)
                ModelState.AddModelError("osobaDto.RodneCislo, osobaDto.DatumNarozeni", $"Hodnoty polí RodneCislo (\"{osobaDto.RodneCislo}\") a DatumNarozeni (\"{osobaDto.DatumNarozeni:yyyy-MM-dd}\") si neodpovídají.");

            // Errors found in the above factual validation
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Osoba osoba = mapper.Map<Osoba>(osobaDto);

            db.Osoby.Add(osoba);
            await db.SaveChangesAsync();

            osobaDto = mapper.Map<OsobaDto>(osoba);

            return CreatedAtRoute("DefaultApi", new { id = osoba.Id }, osobaDto);
        }

        private bool OsobaExists(int id)
        {
            return db.Osoby.Count(e => e.Id == id) > 0;
        }
    }
}