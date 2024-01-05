using RAPC9Y_SOF_2023241.MVC.Models;

namespace RAPC9Y_SOF_2023241.MVC.Helper
{
    public class UpdateHelper
    {
        public Champion Champ { get; set; }

        public Region[] Regions { get; set; }

        public UpdateHelper()
        {
            Regions = new Region[]
            {
                new Region() { Id=1, RegionName="Bandle-City"},
                new Region() { Id=2, RegionName="Bilgewater"},
                new Region() { Id=3, RegionName="Demacia"},
                new Region() { Id=4, RegionName="Ionia"},
                new Region() { Id=5, RegionName="Ixtal"},
                new Region() { Id=6, RegionName="Noxus"},
                new Region() { Id=7, RegionName="Piltover"},
                new Region() { Id=8, RegionName="Runeterra"},
                new Region() { Id=9, RegionName="Shadow Isles"},
                new Region() { Id=10, RegionName="Shurima"},
                new Region() { Id=11, RegionName="Targon"},
                new Region() { Id=12, RegionName="Freljord"},
                new Region() { Id=13, RegionName="Void"},
                new Region() { Id=14, RegionName="Zaun"},
            };
        }
    }
}
