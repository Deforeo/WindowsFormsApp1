using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private Dictionary<string, Recipe> recipes;
        private Dictionary<string, double> stockIngredients; 
        private Dictionary<string, double> stockProducts;    

        public Form1()
        {
            InitializeComponent();
            InitializeTestData();
            FillRecipeComboBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitializeTestData()
        {
            
            recipes = new Dictionary<string, Recipe>
            {
                {
                    "Хлеб белый",
                    new Recipe("Хлеб белый", new Dictionary<string, (double Amount, string Unit)>
                    {
                        ["Мука"] = (500, "г"),
                        ["Дрожжи"] = (10, "г"),
                        ["Соль"] = (5, "г"),
                        ["Вода"] = (300, "мл")
                    })
                },
                {
                    "Кекс",
                    new Recipe("Кекс", new Dictionary<string, (double Amount, string Unit)>
                    {
                        ["Мука"] = (200, "г"),
                        ["Сахар"] = (150, "г"),
                        ["Масло"] = (100, "г"),
                        ["Яйца"] = (2, "шт")
                    })
                }
            };

            
            stockIngredients = new Dictionary<string, double>
            {
                ["Мука"] = 2000,
                ["Дрожжи"] = 50,
                ["Соль"] = 100,
                ["Вода"] = 1000,
                ["Сахар"] = 500,
                ["Масло"] = 200,
                ["Яйца"] = 10
            };

            
            stockProducts = new Dictionary<string, double>
            {
                ["Хлеб белый"] = 5,
                ["Кекс"] = 2
            };
        }

        private void FillRecipeComboBox()
        {
            comboBoxRecipes.Items.Clear();
            foreach (var recipe in recipes.Keys)
            {
                comboBoxRecipes.Items.Add(recipe);
            }
            if (comboBoxRecipes.Items.Count > 0)
                comboBoxRecipes.SelectedIndex = 0;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCalculate_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                if (comboBoxRecipes.SelectedItem == null)
                {
                    MessageBox.Show("Выберите рецепт.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                int quantity;
                if (!int.TryParse(txtQuantity.Text, out quantity) || quantity <= 0)
                {
                    MessageBox.Show("Введите корректное положительное количество.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string recipeName = comboBoxRecipes.SelectedItem.ToString();
                Recipe selectedRecipe = recipes[recipeName];

               
                double productInStock = stockProducts.ContainsKey(recipeName) ? stockProducts[recipeName] : 0;
                lblProductStock.Text = $"На складе: {productInStock} шт.";

                
                var requiredIngredients = new Dictionary<string, (double Amount, string Unit)>();
                foreach (var ing in selectedRecipe.Ingredients)
                {
                    double requiredAmount = ing.Value.Amount * quantity;
                    requiredIngredients[ing.Key] = (requiredAmount, ing.Value.Unit);
                }

                
                var toOrder = new Dictionary<string, (double Amount, string Unit)>();

                
                listRequired.Items.Clear();
                foreach (var ing in requiredIngredients)
                {
                    listRequired.Items.Add($"{ing.Key}: {ing.Value.Amount} {ing.Value.Unit}");
                }

                
                listStock.Items.Clear();
                foreach (var ing in stockIngredients)
                {
                    
                    if (requiredIngredients.ContainsKey(ing.Key))
                    {
                        listStock.Items.Add($"{ing.Key}: {ing.Value} {requiredIngredients[ing.Key].Unit}");
                    }
                    else
                    {
                        listStock.Items.Add($"{ing.Key}: {ing.Value} (не используется в рецепте)");
                    }
                }

                
                listToOrder.Items.Clear();
                foreach (var required in requiredIngredients)
                {
                    string ingredientName = required.Key;
                    double requiredAmount = required.Value.Amount;
                    string unit = required.Value.Unit;

                    double stockAmount = stockIngredients.ContainsKey(ingredientName) ? stockIngredients[ingredientName] : 0;
                    double needToOrder = requiredAmount - stockAmount;
                    if (needToOrder > 0)
                    {
                        listToOrder.Items.Add($"{ingredientName}: {needToOrder} {unit}");
                    }
                    else
                    {
                        listToOrder.Items.Add($"{ingredientName}: 0 (достаточно)");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    
    public class Recipe
    {
        public string Name;
        public Dictionary<string, (double Amount, string Unit)> Ingredients { get; set; }

        public Recipe(string name, Dictionary<string, (double Amount, string Unit)> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }
    }
    
}
