using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RAPC9Y_SOF_2023241.MVC.Models
{
    public class Region
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string RegionName { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Champion> ChampionsByRegions { get; set; }

        public Region()
        {
            this.ChampionsByRegions = new HashSet<Champion>();
        }
    }
}
