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
            champ.Name = bindingContext.ValueProvider.GetValue("name").FirstValue;
            champ.Gender = bindingContext.ValueProvider.GetValue("gender").FirstValue;
            champ.Species = bindingContext.ValueProvider.GetValue("species").FirstValue;
            champ.Resources = bindingContext.ValueProvider.GetValue("resources").FirstValue;
            champ.RegionId = int.Parse(bindingContext.ValueProvider.GetValue("regionid").FirstValue);
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
