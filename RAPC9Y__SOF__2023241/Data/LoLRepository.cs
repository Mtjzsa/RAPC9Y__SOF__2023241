using RAPC9Y__SOF__2023241.Data;
using RAPC9Y_SOF_2023241.MVC.Models;

namespace RAPC9Y_SOF_2023241.MVC.Data
{
    public class LoLRepository : ILoLRepository
    {
        LoLDbContext ctx;

        public LoLRepository(LoLDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(Champion item)
        {
            var championName = ctx.Champions.FirstOrDefault(t => t.Name == item.Name);
            if (championName != null)
            {
                throw new ArgumentException("Champion already exists");
            }
            ctx.Champions.Add(item);
            ctx.SaveChanges();
        }

        public IEnumerable<Champion> ReadAll()
        {
            return ctx.Champions;
        }

        public Champion? Read(string id)
        {
            return ctx.Champions.FirstOrDefault(t => t.Id == id);
        }

        public Champion? ReadByName(string name)
        {
            return ctx.Champions.FirstOrDefault(t => t.Name == name);
        }

        public void Delete(string id)
        {
            ctx.Set<Champion>().Remove(Read(id));
            ctx.SaveChanges();
        }

        public void Update(Champion item)
        {
            var old = ReadByName(item.Name);
            old.Name = item.Name;
            old.Gender = item.Gender;
            old.Species = item.Species;
            old.Resources = item.Resources;
            old.RegionId = item.RegionId;
            old.Release = item.Release;
            old.Data = item.Data;
            old.ContentType = item.ContentType;
            ctx.SaveChanges();

        }

    }
}
