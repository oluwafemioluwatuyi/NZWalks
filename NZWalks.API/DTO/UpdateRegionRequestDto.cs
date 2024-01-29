﻿using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.DTO
{
    public class UpdateRegionRequestDto
    {
        //model validation

        [Required]
        [MinLength(3, ErrorMessage = "code has to be a minium of 3 characters")]
        [MaxLength(3, ErrorMessage = "code has to be a minium of 3 characters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "code has to be a minium of 3 characters")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
