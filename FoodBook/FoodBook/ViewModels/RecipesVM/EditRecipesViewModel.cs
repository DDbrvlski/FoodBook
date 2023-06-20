using FoodBook.Service.Reference;
using FoodBook.Services;
using FoodBook.ViewModels.Abstract;
using FoodBook.ViewModels.RecipesVM.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodBook.ViewModels.RecipesVM
{
    public class EditRecipesViewModel : AEditViewModel<RecipeForView>
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
        public EditRecipesViewModel() : base()
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
        public override void LoadProperties(RecipeForView item)
        {
            Title = item.Title;
            CreateDate = item.CreatedDate;
            ModifiedDate = item.ModifiedDate;
            MakingTime = item.MakingTime;
            CuisineTypeTitle = item.CuisineTypeTitle;
            DifficultyName = item.DifficultyName;
            DishTypeTitle = item.DishTypeTitle;
            ImageURL = item.ImageURL;
            ImageTitle = item.ImageTitle;

            //Getting index of id
            IdCuisineType = CuisineTypesList.IndexOf(CuisineTypesList.FirstOrDefault(x => x.Id == item.IdCuisineType));
            IdDifficulty = DifficultyList.IndexOf(DifficultyList.FirstOrDefault(x => x.Id == item.IdDifficulty));
            IdDishType = DishTypesList.IndexOf(DishTypesList.FirstOrDefault(x => x.Id == item.IdDishType));

            //Setting steps and ingredients for recipe in collections for listview
            AddStep(new ObservableCollection<RecipeStepsForView>(item.RecipeStepsView));
            AddIngredient(new ObservableCollection<IngredientsForRecipeForView>(item.IngredientsView));
        }
        public override async Task<RecipeForView> SetItem()
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
            foreach (var element in IngredientsInRecipeTemp)
            {
                var elemenetToAdd = new IngredientsForRecipeForView
                {
                    AmountOfUnit = element.Amount,
                    IdIngredient = element.IngredientsInRecipeList[element.IdIngredient].Id
                };
                IngredientsInRecipe.Add(elemenetToAdd);
            }
            RecipeForView item = await DataStore.GetItemAsync(ItemId);
            item.Title = item.Title;
            item.ModifiedDate = DateTime.Now;
            item.MakingTime = this.MakingTime;
            item.IdCuisineType = CuisineTypesList[(int)this.IdCuisineType].Id;
            item.IdDifficulty = DifficultyList[(int)this.IdDifficulty].Id;
            item.IdDishType = DishTypesList[(int)this.IdDishType].Id;
            item.ImageURL = ImageURL;
            item.ImageTitle = ImageTitle;
            item.CuisineTypeTitle = "";
            item.DifficultyName = "";
            item.DishTypeTitle = "";
            item.RecipeStepsView = RecipeStepsInRecipe;
            item.IngredientsView = IngredientsInRecipe;
            return item;
        }
        #region Functions for listview
        //Getting every step from recipe and adding it into listview
        private void AddStep(ObservableCollection<RecipeStepsForView> recipeStepsView)
        {
            foreach (var element in recipeStepsView)
            {
                var temp = new RecipeStep(RecipeSteps);
                temp.Description = element.Description;
                temp.Title = element.Title;
                temp.Position = element.Position;
                RecipeSteps.Add(temp);
            }
        }
        //Button command function to add new step
        private void AddStep()
        {
            var temp = new RecipeStep(RecipeSteps);
            RecipeSteps.Add(temp);
        }
        //Getting every ingredient from recipe and adding it into listview
        private void AddIngredient(ObservableCollection<IngredientsForRecipeForView> ingredientsView)
        {
            foreach (var element in ingredientsView)
            {
                var temp = new RecipeIngredient(IngredientsInRecipeTemp);
                temp.IngredientsInRecipeList = IngredientsList;
                temp.Amount = (float)element.AmountOfUnit;
                temp.IdIngredient = ingredientsList.IndexOf(ingredientsList.FirstOrDefault(x => x.Id == element.IdIngredient));
                IngredientsInRecipeTemp.Add(temp);
            }
        }
        //Button command function to add new ingredient
        private void AddIngredient()
        {
            var temp = new RecipeIngredient(IngredientsInRecipeTemp);
            temp.IngredientsInRecipeList = IngredientsList;
            IngredientsInRecipeTemp.Add(temp);
        }
        #endregion
        public override bool ValidateSave()
        {
            return true;
        }
    }
}
