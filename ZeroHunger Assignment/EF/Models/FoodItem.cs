using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger_Assignment.EF.Models
{
    public class FoodItem
    {
        [Required, Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required, ForeignKey("CollectRequest")]
        public int CollectRequestId { get; set; }

        public virtual CollectRequest CollectRequest { get; set; }
    }
}