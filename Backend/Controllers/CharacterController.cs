using Backend.Models.DTOs;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly IRickAndMortyService _rickAndMortyService;

        public CharacterController(IRickAndMortyService rickAndMortyService)
        {
            _rickAndMortyService = rickAndMortyService;
        }

        /// <summary>
        /// Obtiene una lista de personajes de Rick and Morty con paginación.
        /// Si no se especifica la página, se devuelve la primera página.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCharacters([FromQuery] int page = 1)
        {
            try
            {

                var result = await _rickAndMortyService.GetCharactersAsync(page);
                if (result == null) return NotFound("No se encontraron datos.");

                // Mapear los datos de la entidad a DTO
                var characterDto = result.Select(c => new CharacterDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Status = c.Status,
                    Species = c.Species,
                    Type = c.Type,
                    Gender = c.Gender,
                    OriginName = c.Origin?.Name ?? string.Empty,
                    LocationName = c.Location?.Name ?? string.Empty,
                    Image = c.Image,
                    Created = c.Created

                }
                ).ToList();

                return Ok(characterDto);
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

        /// <summary>
        /// Obtiene un personaje específico de Rick and Morty por su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCharacterById(int id = 1)
        {
            try
            {
                if (id <= 0) return BadRequest("El ID debe ser un número positivo.");

                var character = await _rickAndMortyService.GetCharacterByIdAsync(id);
                if (character == null) return NotFound($"Personaje con ID {id} no encontrado.");

                // Mapear los datos de la entidad a DTO
                var characterDto = new CharacterDTO
                {
                    Id = character.Id,
                    Name = character.Name,
                    Status = character.Status,
                    Species = character.Species,
                    Type = character.Type,
                    Gender = character.Gender,
                    OriginName = character.Origin?.Name ?? string.Empty,
                    LocationName = character.Location?.Name ?? string.Empty,
                    Image = character.Image,
                    Created = character.Created

                };

                return Ok(characterDto);
            }
            catch (HttpRequestException httpEx)
            {
                return StatusCode(500, $"Error al comunicarse con el servicio externo: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar el ID: {ex.Message}");
            }

        }
    }
}