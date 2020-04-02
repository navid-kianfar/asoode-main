using System;
using System.ComponentModel.DataAnnotations;
using Asoode.Main.Data.Models.Base;

namespace Asoode.Main.Data.Models
{
    public class Post : BaseEntity
    {
        [MaxLength(500)]public string Title { get; set; }
        [MaxLength(1500)]public string Description { get; set; }
        [MaxLength(2)]public string Culture { get; set; }
        [MaxLength(500)]public string Summary { get; set; }
        [MaxLength(500)]public string Keywords { get; set; }
        [MaxLength(5000)]public string Text { get; set; }
        public Guid UserId { get; set; }
        public string LargeImage { get; set; }
        public string SmallImage { get; set; }
        public string FullImage { get; set; }
    }
}