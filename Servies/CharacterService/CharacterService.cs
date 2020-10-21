using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RpgGameApi.Data;
using RpgGameApi.Dtos.Character;
using RpgGameApi.Models;

namespace RpgGameApi.Servies.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly CharacterContext _context;

        public CharacterService(IMapper mapper, CharacterContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<CharacterReadDto>>> AddCharacter(CharacterAddDto dto)
        {
            ServiceResponse<List<CharacterReadDto>> serviceResponse = new ServiceResponse<List<CharacterReadDto>>();


            try
            {
                Character character = _mapper.Map<Character>(dto);
                character.CreateUser = character.Name;
                character.CreateionTime = DateTime.Now;
                _context.Characters.Add(character);
                if (await SaveChanges())
                    serviceResponse.Data = _context.Characters.Select(c => _mapper.Map<CharacterReadDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterReadDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<CharacterReadDto>> serviceResponse = new ServiceResponse<List<CharacterReadDto>>();
            try
            {
                Character character = _context.Characters.First(c => c.Id == id);
                _context.Characters.Remove(character);
                if (await SaveChanges())
                    serviceResponse.Data = _context.Characters.Select(c => _mapper.Map<CharacterReadDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterReadDto>>> GetAllCharacters()
        {
            ServiceResponse<List<CharacterReadDto>> serviceResponse = new ServiceResponse<List<CharacterReadDto>>();

            try
            {
                serviceResponse.Data = _context.Characters.Select(c => _mapper.Map<CharacterReadDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<CharacterReadDto>> GetCharacterById(int id)
        {
            ServiceResponse<CharacterReadDto> serviceResponse = new ServiceResponse<CharacterReadDto>();

            try
            {
                serviceResponse.Data = _mapper.Map<CharacterReadDto>(_context.Characters.AsNoTracking().First(c => c.Id == id));
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<bool> SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task<ServiceResponse<CharacterReadDto>> UpdateCharacter(CharacterUpdateDto dto)
        {
            ServiceResponse<CharacterReadDto> serviceResponse = new ServiceResponse<CharacterReadDto>();

            try
            {
                Character character = _context.Characters.AsNoTracking().First(c => c.Id == dto.IdForUpdate);
                character = _mapper.Map<CharacterUpdateDto, Character>(dto, character);
                _context.Update(character);
                if (await SaveChanges())
                    serviceResponse.Data = _mapper.Map<CharacterReadDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}