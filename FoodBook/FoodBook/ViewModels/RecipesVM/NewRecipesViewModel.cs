using FoodBook.ViewModels.Abstract;
using FoodBook.Service.Reference;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using FoodBook.Services;
using System.Threading.Tasks;
using System.Linq;
using FoodBook.ViewModels.RecipesVM.Helpers;

namespace FoodBook.ViewModels.RecipesVM
{
    public class NewRecipesViewModel : ANewViewModel<RecipeForView>
    {

        #region Fields
        private int id;
        private string title;
        private DateTimeOffset createDate = DateTime.Now;
        private DateTimeOffset modifiedDate = DateTime.Now;
        private int _makingTime;
        private string description;
        private string position;
        private float amount;
        private string unitTitle;
        private string imageTitle;
        private string imageURL;
        private int? _idCuisineType;
        private int? _idDishType;
        private int? _idDifficulty;
        private string _cuisineTypeTitle;
        private string _difficultyName;
        private string _dishTypeTitle;
        private int? _idRecipeStep;
        private int? _idIngredient;
        private ObservableCollection<RecipeStep> _recipeSteps;
        private ObservableCollection<RecipeStepsForView> _recipeStepsInRecipe;
        private ObservableCollection<CuisineTypeForView> cuisineTypesList;
        private ObservableCollection<DishTypeForView> dishTypesList;
        private ObservableCollection<Difficulty> difficultyList;
        private ObservableCollection<IngredientsForView> ingredientsList;
        private ObservableCollection<RecipeIngredient> _ingredientsInRecipeTemp;
        private ObservableCollection<IngredientsForRecipeForView> _ingredientsInRecipe;
        private IDataStore<RecipeStepsForView> DataStore2 => DependencyService.Get<IDataStore<RecipeStepsForView>>();
        #endregion
        #region Properties
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public DateTimeOffset CreateDate
        {
            get => createDate;
            set => SetProperty(ref createDate, value);
        }
        public DateTimeOffset ModifiedDate
        {
            get => modifiedDate;
            set => SetProperty(ref modifiedDate, value);
        }
        public int MakingTime
        {
            get { return _makingTime; }
            set { SetProperty(ref _makingTime, value); }
        }
        public int? IdCuisineType
        {
            get { return _idCuisineType; }
            set { SetProperty(ref _idCuisineType, value); }
        }
        public int? IdDishType
        {
            get { return _idDishType; }
            set
            {
                if (_idDishType != value)
                {
                    _idDishType = value;
                    base.OnPropertyChanged(() => IdDishType);
                }
            }
        }
        public int? IdDifficulty
        {
            get { return _idDifficulty; }
            set
            {
                if (_idDifficulty != value)
                {
                    _idDifficulty = value;
                    base.OnPropertyChanged(() => IdDifficulty);
                }
            }
        }
        public string ImageTitle
        {
            get { return imageTitle; }
            set { SetProperty(ref imageTitle, value); }
        }
        public string ImageURL
        {
            get { return imageURL; }
            set { SetProperty(ref imageURL, value); }
        }
        public string CuisineTypeTitle
        {
            get { return _cuisineTypeTitle; }
            set { SetProperty(ref _cuisineTypeTitle, value); }
        }
        public string DifficultyName
        {
            get { return _difficultyName; }
            set { SetProperty(ref _difficultyName, value); }
        }
        public string DishTypeTitle
        {
            get { return _dishTypeTitle; }
            set { SetProperty(ref _dishTypeTitle, value); }
        }
        public int? IdRecipeStep
        {
            get { return _idRecipeStep; }
            set { SetProperty(ref _idRecipeStep, value); }
        }
        public int? IdIngredient
        {
            get { return _idIngredient; }
            set { SetProperty(ref _idIngredient, value); }
        }
        public string UnitTitle
        {
            get => unitTitle;
            set => SetProperty(ref unitTitle, value);
        }
        public float Amount
        {
            get => amount;
            set => SetProperty(ref amount, value);
        }
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public string Position
        {
            get => position;
            set => SetProperty(ref position, value);
        }
        #region Collections
        //Collection that contain steps in listview
        public ObservableCollection<RecipeStep> RecipeSteps
        {
            get { return _recipeSteps; }
            set { SetProperty(ref _recipeSteps, value); }
        }
        //Collection for steps to add to database
        public ObservableCollection<RecipeStepsForView> RecipeStepsInRecipe
        {
            get { return _recipeStepsInRecipe; }
            set { SetProperty(ref _recipeStepsInRecipe, value); }
        }
        //Collection that contain ingredients in listview
        public ObservableCollection<RecipeIngredient> IngredientsInRecipeTemp
        {
            get { return _ingredientsInRecipeTemp; }
            set { SetProperty(ref _ingredientsInRecipeTemp, value); }
        }
        //Collection for ingredients to add to database
        public ObservableCollection<IngredientsForRecipeForView> IngredientsInRecipe
        {
            get { return _ingredientsInRecipe; }
            set { SetProperty(ref _ingredientsInRecipe, value); }
        }
        //Getting ingredients list for picker
        public ObservableCollection<IngredientsForView> IngredientsList
        {
            get { return ingredientsList; }
            set { SetProperty(ref ingredientsList, value); }
        }
        public async Task<ObservableCollection<IngredientsForView>> SetIngredientsList()
        {
            Task<IEnumerable<IngredientsForView>> ingredientsTask = DependencyService.Get<IDataStore<IngredientsForView>>().GetItemsAsync(true);
            IEnumerable<IngredientsForView> ingredientsEnumerable = await ingredientsTask;
            return new ObservableCollection<IngredientsForView>(ingredientsEnumerable);
        }
        //Getting difficulty list for picker
        public ObservableCollection<Difficulty> DifficultyList
        {
            get { return difficultyList; }
            set { SetProperty(ref difficultyList, value); }
        }
        public async Task<ObservableCollection<Difficulty>> SetDifficultyList()
        {
            Task<IEnumerable<Difficulty>> difficultyTask = DependencyService.Get<IDataStore<Difficulty>>().GetItemsAsync(true);
            IEnumerable<Difficulty> difficultyEnumerable = await difficultyTask;
            return new ObservableCollection<Difficulty>(difficultyEnumerable);
        }
        //Getting dishes list for picker
        public ObservableCollection<DishTypeForView> DishTypesList
        {
            get { return dishTypesList; }
            set { SetProperty(ref dishTypesList, value); }
        }
        public async Task<ObservableCollection<DishTypeForView>> SetDishTypesList()
        {
            Task<IEnumerable<DishTypeForView>> dishTypesTask = DependencyService.Get<IDataStore<DishTypeForView>>().GetItemsAsync(true);
            IEnumerable<DishTypeForView> dishTypesEnumerable = await dishTypesTask;
            return new ObservableCollection<DishTypeForView>(dishTypesEnumerable);
        }
        //Getting cuisines list for picker
        public ObservableCollection<CuisineTypeForView> CuisineTypesList
        {
            get { return cuisineTypesList; }
            set { SetProperty(ref cuisineTypesList, value); }
        }
        public async Task<ObservableCollection<CuisineTypeForView>> SetCuisineTypesList()
        {
            return new ObservableCollection<CuisineTypeForView>(await DependencyService.Get<IDataStore<CuisineTypeForView>>().GetItemsAsync(true));
        }
        #endregion
        public Command EditItemCommand { get; }
        public Command AddStepCommand { get; set; }
        public Command AddIngredientCommand { get; set; }
        #endregion
        public NewRecipesViewModel() : base()
        {
            AddIngredientCommand = new Command(AddIngredient);
            AddStepCommand = new Command(AddStep);
            RecipeSteps = new ObservableCollection<RecipeStep>();
            RecipeStepsInRecipe = new ObservableCollection<RecipeStepsForView>();
            IngredientsInRecipeTemp = new ObservableCollection<RecipeIngredient>();
            IngredientsInRecipe = new ObservableCollection<IngredientsForRecipeForView>();
            //Adding elements to lists for picker
            SetDifficultyList().ContinueWith(task => DifficultyList = task.Result);
            SetDishTypesList().ContinueWith(task => DishTypesList = task.Result);
            SetCuisineTypesList().ContinueWith(task => CuisineTypesList = task.Result);
            SetIngredientsList().ContinueWith(task => IngredientsList = task.Result);
        }
        public override RecipeForView SetItem()
        {
            //Adding added steps to list
            foreach (var element in RecipeSteps)
            {
                var elementToAdd = new RecipeStepsForView
                {
                    Title = "",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Description = element.Description,
                    Position = element.Position
                };
                RecipeStepsInRecipe.Add(elementToAdd);

            }
            //Adding added ingredients to list 
            foreach (var item in IngredientsInRecipeTemp)
            {
                var elemenetToAdd = new IngredientsForRecipeForView
                {
                    AmountOfUnit = item.Amount,
                    IdIngredient = item.IngredientsInRecipeList[item.IdIngredient].Id
                };
                IngredientsInRecipe.Add(elemenetToAdd);
            }
            return new RecipeForView
            {
                Title = this.Title,
                CreatedDate = this.CreateDate,
                ModifiedDate = this.ModifiedDate,
                IsActive = true,
                MakingTime = this.MakingTime,
                IdCuisineType = CuisineTypesList[(int)this.IdCuisineType].Id,
                IdDifficulty = DifficultyList[(int)this.IdDifficulty].Id,
                IdDishType = DishTypesList[(int)this.IdDishType].Id,
                ImageTitle = this.ImageTitle,
                CuisineTypeTitle = "",
                DifficultyName = "",
                DishTypeTitle = "",
                ImageURL = this.ImageURL,
                RecipeStepsView = RecipeStepsInRecipe,
                IngredientsView = IngredientsInRecipe
            };
        }

        #region Functions for listview
        //Button command function to add new step
        private void AddStep()
        {
            var temp = new RecipeStep(RecipeSteps);
            RecipeSteps.Add(temp);
        }
        //Button command function to add new ingredient
        private void AddIngredient()
        {
            try
            {
                var temp = new RecipeIngredient(IngredientsInRecipeTemp);
                temp.IngredientsInRecipeList = IngredientsList;
                temp.UnitTitle = "";
                IngredientsInRecipeTemp.Add(temp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
        public override bool ValidateSave()
        {
            return true;
        }

    }
}
