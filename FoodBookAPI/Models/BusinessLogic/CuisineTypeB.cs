using FoodBookAPI.Data;
using FoodBookAPI.Helpers;
using FoodBookAPI.Models.FoodBook;
using FoodBookAPI.Models.Media;
using FoodBookAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace FoodBookAPI.Models.BusinessLogic
{
    public class CuisineTypeB
    {
        public static async Task ConvertCuisineTypeForViewToCuisineAndSave(CuisineTypeForView cuisine, FoodBookContext _context)
        {
            var cuisineTypeToAdd = new CuisineType().CopyProperties(cuisine);
            cuisineTypeToAdd.IsActive= true;
            //Adding new image if null
            if (cuisineTypeToAdd.IdImage == null)
            {
                Images img = new Images
                {
                    Image = cuisine.ImageURL,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Title = cuisine.ImageTitle
                };
                _context.Images.Add(img);
                await _context.SaveChangesAsync();
                cuisineTypeToAdd.IdImage = img.Id;
            }
            _context.CuisineType.Add(cuisineTypeToAdd);
            await _context.SaveChangesAsync();
        }
        public static async Task EditConvertDishTypeForViewToDishAndSave(CuisineType cuisineToModify, CuisineTypeForView cuisineType, FoodBookContext _context)
        {
            cuisineToModify.CopyProperties(cuisineType);
            cuisineToModify.IsActive= true;
            //Modifying image
            if (cuisineToModify.Image.Image != cuisineType.ImageURL)
            {
                var imageToModify = await _context.Images.FindAsync(cuisineToModify.IdImage);

                imageToModify.Image = cuisineType.ImageURL;
                imageToModify.IsActive = true;
                imageToModify.Title = cuisineType.ImageTitle;

                _context.Entry(imageToModify).State = EntityState.Modified;
            }
            _context.Entry(cuisineToModify).State = EntityState.Modified;
        }
    }
}
