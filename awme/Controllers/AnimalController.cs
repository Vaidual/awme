using awme.Data.Dto.Animal;
using awme.Data.Models;
using awme.Services.AnimalServices;
using awme.Services.AnimalTypeServices;
using awme.Services.CollarServices;
using awme.Services.UserServices;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace awme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;
        private readonly IUserService _userService;
        private readonly IAnimalTypeService _animalTypeService;
        private readonly ICollarService _collarService;

        public AnimalController(
            IAnimalService animalService, 
            IUserService userService, 
            IAnimalTypeService animalTypeService,
            ICollarService collarService)
        {
            _animalService = animalService;
            _userService = userService;
            _animalTypeService = animalTypeService;
            this._collarService = collarService;
        }

        [HttpGet()]
        public async Task<ActionResult<List<Animal>>> GetAnimals()
        {
            List<Animal> animals = await _animalService.GetAnimals();
            return Ok(animals);
        }

        [HttpGet("user-animals/{userId}")]
        public async Task<ActionResult<List<Animal?>>> GetUserAnimals(int userId)
        {
            if (!await _userService.CheckIfUserExistsById(userId))
            {
                return NotFound("User does not exist.");
            }
            List<Animal> animals = await _animalService.GetUserAnimals(userId);
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
            Animal? animal = await _animalService.GetAnimal(id);
            if (animal == null)
            {
                return NotFound("The animal does not exist.");
            }
            return Ok(animal);
        }

        [HttpPost()]
        public async Task<ActionResult<Animal>> Add(AnimalAddRequest request)
        {
            User? user = await _userService.GetUser(request.UserId);
            if (user == null)
            {
                return NotFound("The user does not exist.");
            }
            AnimalType? type = await _animalTypeService.GetType(request.TypeId);
            if (type == null)
            {
                return NotFound("The type does not exist.");
            }
            Animal animal = new()
            {
                Name = request.Name,
                Age = request.Age,
                Type = type,
                AvatarImage = request.AvatarImage,
                User = user,
                Gender = request.Gender,
            };
            if (request.Description != null) animal.Description = request.Description;
            await _animalService.AddAnimal(animal);
            return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            if (!await _animalService.DeleteAnimal(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Animal>> Put(int id, AnimalUpdateRequest request)
        {
            Animal? animal = await _animalService.GetAnimal(id);
            if (animal == null)
            {
                return NotFound("The animal does not exist.");
            }
            await _animalService.UpdateAnimal(animal, request);
            return animal;
        }


        [HttpPatch()]
        public async Task<ActionResult<Animal>> PatchCollar(int animalId, string? collarId)
        {
            Animal? animal = await _animalService.GetAnimal(animalId);
            if (animal == null)
            {
                return NotFound("The animal does not exist.");
            }
            if (collarId != null && !await _userService.CheckIfUserHaveCollar(animal.UserId, collarId))
            {
                return BadRequest("User does not have collar");
            }
            Collar? collar = null;
            if (collarId != null)
            {
                collar = await _collarService.GetCollar(collarId);
                if (collar == null)
                {
                    return NotFound("The collar does not exist.");
                }
            }
            await _animalService.PatchCollar(animal, collar);
            return animal;
        }
    }
}
