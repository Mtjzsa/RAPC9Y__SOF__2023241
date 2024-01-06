using Microsoft.AspNetCore.Mvc.ModelBinding;
using RAPC9Y_SOF_2023241.MVC.Models;

namespace RAPC9Y_SOF_2023241.MVC.Helper
{
    public class ChampionModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentException(nameof(bindingContext));
            }

            Champion champ = new Champion();
            //Name
            if (bindingContext.ValueProvider.GetValue("name").FirstValue == null)
                champ.Name = (bindingContext.ValueProvider.GetValue("champ.name").FirstValue);
            else
                champ.Name = bindingContext.ValueProvider.GetValue("name").FirstValue;

            //Gender
            if (bindingContext.ValueProvider.GetValue("gender").FirstValue == null)
                champ.Gender = (bindingContext.ValueProvider.GetValue("champ.gender").FirstValue);
            else
                champ.Gender = bindingContext.ValueProvider.GetValue("gender").FirstValue;

            //Species
            if (bindingContext.ValueProvider.GetValue("species").FirstValue == null)
                champ.Species = (bindingContext.ValueProvider.GetValue("champ.species").FirstValue);
            else
                champ.Species = bindingContext.ValueProvider.GetValue("species").FirstValue;

            //Resources
            if (bindingContext.ValueProvider.GetValue("resources").FirstValue == null)
                champ.Resources = bindingContext.ValueProvider.GetValue("champ.resources").FirstValue;
            else
                champ.Resources = bindingContext.ValueProvider.GetValue("resources").FirstValue;
            
            //RegionId
            if (bindingContext.ValueProvider.GetValue("regionid").FirstValue == null)
                champ.RegionId = int.Parse(bindingContext.ValueProvider.GetValue("champ.regionid").FirstValue);
            else
                champ.RegionId = int.Parse(bindingContext.ValueProvider.GetValue("regionid").FirstValue);

            //Release
            if (bindingContext.ValueProvider.GetValue("release").FirstValue == null)
                champ.Release = int.Parse(bindingContext.ValueProvider.GetValue("champ.release").FirstValue);
            else
                champ.Release = int.Parse(bindingContext.ValueProvider.GetValue("release").FirstValue);

            if (bindingContext.HttpContext.Request.Form.Files.Count > 0)
            {
                var file = bindingContext.HttpContext.Request.Form.Files[0];
                using (var stream = file.OpenReadStream())
                {
                    byte[] buffer = new byte[file.Length];
                    stream.Read(buffer, 0, (int)file.Length);
                    string filename = champ.Id + "." + file.FileName.Split('.')[1];
                    champ.Data = buffer;
                    champ.ContentType = file.ContentType;
                }
            }
           
            bindingContext.Result = ModelBindingResult.Success(champ);
            return Task.CompletedTask;
        }
    }
}
