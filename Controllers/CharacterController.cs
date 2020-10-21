using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RpgGameApi.Dtos.Character;
using RpgGameApi.Models;
using RpgGameApi.Servies.CharacterService;

namespace RpgGameApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : Controller
    {
        private readonly ICharacterService _service;
        private readonly IMapper _mapper;

        public CharacterController(ICharacterService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("GetAll", Name = "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            ServiceResponse<List<CharacterReadDto>> serviceResponse = await _service.GetAllCharacters();
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }

            return Ok(serviceResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            ServiceResponse<CharacterReadDto> serviceResponse = await _service.GetCharacterById(id);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(CharacterAddDto newCharacter)
        {
            ServiceResponse<List<CharacterReadDto>> serviceResponse = new ServiceResponse<List<CharacterReadDto>>();

            var validator = new CharacterAddDtoValidator();
            var result = validator.Validate(newCharacter);
            if (!result.IsValid)
            {
                serviceResponse.Success = false;

                foreach (var failure in result.Errors)
                {
                    serviceResponse.Message += failure.ErrorMessage;
                }
                //return BadRequest(result.Errors);
            }
            else
            {
                serviceResponse = await _service.AddCharacter(newCharacter);
            }


            //ServiceResponse<List<CharacterReadDto>> serviceResponse = await _service.AddCharacter(newCharacter);
            if (serviceResponse.Success == false)
            {
                return BadRequest(serviceResponse);
            }

            return CreatedAtRoute(nameof(GetAll), new { Id = serviceResponse.Data[0].IdForRead }, serviceResponse);


        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(CharacterUpdateDto updateCharacter)
        {
            ServiceResponse<CharacterReadDto> serviceResponse = new ServiceResponse<CharacterReadDto>();

            var validator = new CharacterUpdateDtoValidator();
            var result = validator.Validate(updateCharacter);
            if (!result.IsValid)
            {
                serviceResponse.Success = false;

                foreach (var failure in result.Errors)
                {
                    serviceResponse.Message += failure;
                }
            }
            else
            {
                serviceResponse = await _service.UpdateCharacter(updateCharacter);
            }

            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            ServiceResponse<List<CharacterReadDto>> serviceResponse = await _service.DeleteCharacter(id);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialCharacterUpdate(int id, JsonPatchDocument<CharacterUpdateDto> patchDoc)
        {
            // 要用AsNotracking
            ServiceResponse<CharacterReadDto> serviceResponse = await _service.GetCharacterById(id);
            if (serviceResponse.Success == false)
            {
                return NotFound();
            }

            var characterModelFromRepo = serviceResponse.Data;

            var characterToPatch = _mapper.Map<CharacterUpdateDto>(characterModelFromRepo);

            patchDoc.ApplyTo(characterToPatch, ModelState);

            if (!TryValidateModel(characterToPatch))
            {
                return ValidationProblem(ModelState);
            }

            serviceResponse = await _service.UpdateCharacter(characterToPatch);

            if (serviceResponse.Success == false)
            {
                return NotFound();
            }

            return Ok(serviceResponse);
        }
    }
}