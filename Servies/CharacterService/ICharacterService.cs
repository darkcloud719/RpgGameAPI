using System.Collections.Generic;
using System.Threading.Tasks;
using RpgGameApi.Dtos.Character;
using RpgGameApi.Models;

namespace RpgGameApi.Servies.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<CharacterReadDto>>> GetAllCharacters();

        Task<ServiceResponse<CharacterReadDto>> GetCharacterById(int id);

        Task<ServiceResponse<List<CharacterReadDto>>> AddCharacter(CharacterAddDto dto);

        Task<ServiceResponse<CharacterReadDto>> UpdateCharacter(CharacterUpdateDto dto);

        Task<ServiceResponse<List<CharacterReadDto>>> DeleteCharacter(int id);

        Task<bool> SaveChanges();
    }
}