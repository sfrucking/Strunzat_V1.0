using Microsoft.AspNetCore.Mvc;
using PrototypePrjEntityFramework.Models;
using PrototypePrjEntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PrototypePrjEntityFramework.Controllers
{
    [Route("[Controller]")]
    public class RistorantiController : Controller
    {
        private readonly IService<Ristorante> _service;

        public RistorantiController(IService<Ristorante> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(_service.Elenco());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Json(_service.Rimuovi(id));
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            return Json(_service.Cerca(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody]Ristorante rs)
        {
            return Json(_service.Aggiungi(rs));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Ristorante rs, [FromRoute]int id)
        {
            return Json(_service.Aggiorna(id, rs));
        }

    }
}
