using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RpgGameApi.Infrastructure.Base;

namespace RpgGameApi.Models
{
    [Table("Character")]
    public class Character : AuditedBase
    {
        [Key]
        [Column("SeqId", Order = 0)]
        public override int Id { get; set; }
        [Required]
        [Column(Order = 1)]
        public string Name { get; set; }
        [Required]
        [Column(Order = 2)]
        public int HitPoints { get; set; }
        [Required]
        [Column(Order = 3)]
        public int Strength { get; set; }
        [Required]
        [Column(Order = 4)]
        public int Defense { get; set; }
        [Required]
        [Column(Order = 5)]
        public int Intelligence { get; set; }
        [Required]
        [Column(Order = 6)]
        public RpgClass RpgClass { get; set; }
    }
}