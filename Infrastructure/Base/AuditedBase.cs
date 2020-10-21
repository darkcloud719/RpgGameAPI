using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RpgGameApi.Infrastructure.Base
{
    public abstract class AuditedBase
    {
        public virtual int Id { get; set; }

        [Column("CreateData", TypeName = "datetime")]
        public DateTime CreateionTime { get; set; }

        [Required]
        [MaxLength(100)]
        public string CreateUser { get; set; }

        [Column("ModifyDate", TypeName = "datetime")]
        public DateTime? LastModificationTime { get; set; }

        [MaxLength(100)]
        public string ModifyUser { get; set; }

        [Column("DeleteDate", TypeName = "datetime")]
        public DateTime? DeletionTime { get; set; }

        [MaxLength(100)]
        public string DeleteUser { get; set; }

        [Column("DeleteFlag")]
        public bool IsDeleted { get; set; }
    }
}