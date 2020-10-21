using FluentValidation;
using RpgGameApi.Models;

namespace RpgGameApi.Dtos.Character
{

    public class CharacterAddDtoValidator : AbstractValidator<CharacterAddDto>
    {
        public CharacterAddDtoValidator()
        {
            RuleFor(x => x.NameForAdd).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(x => x.HitPointsForAdd).NotNull().NotEmpty().GreaterThan(0).WithMessage("{HitPoints} 必須大於 0");
            RuleFor(x => x.StrengthForAdd).NotNull().NotEmpty().GreaterThan(0).WithMessage("{Strength} 必須大於 0");
            RuleFor(x => x.DefenseForAdd).NotNull().NotEmpty().GreaterThan(0).WithMessage("{Defense} 必須大於 0");
            RuleFor(x => x.IntelligenceForAdd).NotNull().NotEmpty().GreaterThan(0).WithMessage("{Intelligence 必須大於 0}");
            RuleFor(x => x.RpgClassForAdd).NotNull().NotEmpty();
        }
    }

    public class CharacterAddDto
    {
        public string NameForAdd { get; set; }

        public int HitPointsForAdd { get; set; }

        public int StrengthForAdd { get; set; }

        public int DefenseForAdd { get; set; }

        public int IntelligenceForAdd { get; set; }

        public RpgClass RpgClassForAdd { get; set; }
    }

    public class CharacterReadDto
    {
        public int IdForRead { get; set; }

        public string NameForRead { get; set; }

        public int HitPointsForRead { get; set; }

        public int StrengthForRead { get; set; }

        public int DefenseForRead { get; set; }

        public int IntelligenceForRead { get; set; }

        public RpgClass RpgClassForRead { get; set; }
    }

    public class CharacterUpdateDtoValidator : AbstractValidator<CharacterUpdateDto>
    {
        public CharacterUpdateDtoValidator()
        {
            RuleFor(x => x.IdForUpdate).NotNull().NotEmpty();
            RuleFor(x => x.HitPointsForUpdate).NotNull().NotEmpty().GreaterThan(0).WithMessage("HitPoints 必須大於 0");
            RuleFor(x => x.StrengthForUpdate).NotNull().NotEmpty().GreaterThan(0).WithMessage("Strength 必須大於 0");
            RuleFor(x => x.DefenseForUpdate).NotNull().NotEmpty().GreaterThan(0).WithMessage("Defense 必須大於 0");
            RuleFor(x => x.IntelligenceForUpdate).NotNull().NotEmpty().GreaterThan(0).WithMessage("Intelligence 必須大於 0");
            RuleFor(x => x.RpgClassForUpdate).NotNull().NotEmpty();
        }
    }
    public class CharacterUpdateDto
    {
        public int IdForUpdate { get; set; }

        public string NameForUpdate { get; set; }

        public int HitPointsForUpdate { get; set; }

        public int StrengthForUpdate { get; set; }

        public int DefenseForUpdate { get; set; }

        public int IntelligenceForUpdate { get; set; }

        public RpgClass RpgClassForUpdate { get; set; }
    }
}