using System;
using System.ComponentModel.DataAnnotations;
using Asoode.Main.Data.Models.Base;

namespace Asoode.Main.Data.Models
{
    public class BlogCategory : BaseEntity
    {
        public Guid BlogId { get; set; }
        [Required][MaxLength(2)]public string Culture { get; set; }
        [Required][MaxLength(250)]public string Title { get; set; }
        [Required][MaxLength(1000)]public string NormalizedTitle { get; set; }
        [Required][MaxLength(1000)]public string Description { get; set; }
    }
}