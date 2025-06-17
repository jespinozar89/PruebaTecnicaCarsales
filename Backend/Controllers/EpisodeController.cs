using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.DTOs;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeServices _episodeServices;

        public EpisodeController(IEpisodeServices episodeServices)
        {
            _episodeServices = episodeServices;
        }
        
        /// <summary>
        /// Obtiene una lista de episodios de Rick and Morty con paginación.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetEpisodes([FromQuery] int page = 1)
        {
            try
            {

                var result = await _episodeServices.GetEpisodes(page);
                if (result == null) return NotFound("No se encontraron datos.");

                // Mapear los datos de la entidad a DTO
                var episodeDto = result.Select(e => new EpisodeDTO
                {
                    Id = e.Id,
                    Name = e.Name,
                    AirDate = e.AirDate,
                    EpisodeCode = e.EpisodeCode,
                    CharacterIds = e.Characters
                                    .Select(url => int.Parse(url.Split('/').Last()))
                                    .ToList()
                }).ToList();

                return Ok(episodeDto);
            }
            catch (HttpRequestException httpEx)
            {
                return StatusCode(500, $"Error al comunicarse con el servicio externo: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }
    }
}