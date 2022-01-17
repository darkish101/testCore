using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace testCore.Data
{
    public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TKey Id { get; set; }

        [Column(Order = 1001)]
        [DefaultValue("GETDATE()")]
        public DateTime? Created_On { get; set; }

        [Column(Order = 1002)]
        public DateTime? LastUpdatedDate { get; set; }
    }
}