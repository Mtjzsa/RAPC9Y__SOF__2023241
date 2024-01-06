using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using RAPC9Y_SOF_2023241.MVC.Helper;
using Microsoft.AspNetCore.Mvc;

namespace RAPC9Y_SOF_2023241.MVC.Models
{
    [ModelBinder(binderType: typeof(ChampionModelBinder))]
    public class Champion
    {
        [Key]
        public string Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        public string Resources { get; set; }

        [ForeignKey(nameof(Region))]
        [Required]
        public int RegionId { get; set; }

        [JsonIgnore]
        [NotMapped]
        [ValidateNever]
        public virtual Region Region { get; set; }
        [Required]
        public int Release { get; set; }

        public string? ContentType { get; set; }

        public byte[]? Data { get; set; }

        public Champion()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
