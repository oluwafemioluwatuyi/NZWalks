using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.DTO
{
    public class AddWalkRequestDto
    {
        //model validation

        [Required]
        [MaxLength(1000)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(1000)]
        public double LengthInkm { get; set; }
        public string? WalkImageUrl { get; set; }

        [Required]
      
        public Guid DifficultyId { get; set; }
        [Required]
       
        public Guid RegionId { get; set; }
    }
}
