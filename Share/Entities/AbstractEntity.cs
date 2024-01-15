﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Share.Entities
{
    public abstract class AbstractEntity
    {
        [Key]
        [Column("ID", TypeName = "varchar"), MaxLength(36)]
        public string Id { get; set; }

        [Required]
        [Column("ENABLE")]
        public bool Enable { get; set; }

        [Column("CREATED_AT")]
        public DateTime CreatedAt { get; set; }

        [Column("UPDATED_AT")]
        public DateTime UpdatedAt { get; set; }

        [Column("STATUS_ID")]
        public string StatusId { get; set; }

        [ForeignKey("STATUS_ID")]
        public Status Status { get; set; } = null!;
    }
}
