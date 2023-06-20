using FoodBookAPI.Data;
using FoodBookAPI.Helpers;
using FoodBookAPI.Models.FoodBook;
using FoodBookAPI.Models.Media;
using FoodBookAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace FoodBookAPI.Models.BusinessLogic
{
    public class DishTypeB
    {
        public static async Task ConvertDishTypeForViewToDishAndSave(DishTypeForView dish, FoodBookContext _context)
        {
            var dishTypeToAdd = new DishType().CopyProperties(dish);
            dishTypeToAdd.IsActive = true;
            //Adding new image
            if (dishTypeToAdd.IdImage == 0 || dishTypeToAdd.IdImage == null)
            {
                var newImage = new Images
                {
                    Image = dish.ImageURL,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Title = dish.ImageTitle,
                };
                _context.Images.Add(newImage);
                await _context.SaveChangesAsync();
                dishTypeToAdd.IdImage = newImage.Id;
            }
            _context.DishType.Add(dishTypeToAdd);
            await _context.SaveChangesAsync();
        }
        public static async Task EditConvertDishTypeForViewToDishAndSave(DishType dishToModify, DishTypeForView dishType, FoodBookContext _context)
        {
            dishToModify.CopyProperties(dishType);
            dishToModify.IsActive = true;
            //Modifying image
            if (dishToModify.Image.Image != dishType.ImageURL)
            {
                var imageToModify = await _context.Images.FindAsync(dishToModify.IdImage);

                imageToModify.Image = dishType.ImageURL;
                imageToModify.IsActive = true;
                imageToModify.Title = dishType.ImageTitle;

                _context.Entry(imageToModify).State = EntityState.Modified;
            }
            _context.Entry(dishToModify).State = EntityState.Modified;
        }
    }
}
