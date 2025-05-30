﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VVGames.Domain.Entities.Product
{
    public class DBGames
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Articul")]
        public string Articul { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Жанр")]
        public GameGenre Genres { get; set; }

        [Required]
        [Display(Name = "Цена")]
        [Range(0, 100000)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Изображение (URL)")]
        public string ImageUrl { get; set; }

        [Display(Name = "Краткое описание")]
        [StringLength(300)]
        public string ShortDescription { get; set; }

        [StringLength(1500)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата релиза")]
        public DateTime ReleaseDate { get; set; }
    }
}
