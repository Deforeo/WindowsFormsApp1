using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private SqlConnection connection;
        private BindingSource bsRequired = new BindingSource();
        private BindingSource bsStock = new BindingSource();
        private BindingSource bsToOrder = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            InitializeTestData();
            LoadRecipes();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitializeTestData()
        {

            string connectionString = @"Data Source=ELMIRAVNUKO5E3C\SQLEXPRESS;Initial Catalog=Pekarnya;Integrated Security=True";
            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Произошла ошиька подключения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    

       

        private void LoadRecipes()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT Id, Name FROM Recipes", connection))
            {
                adapter.Fill(dt);
            }
            comboBoxRecipes.DisplayMember = "Name";
            comboBoxRecipes.ValueMember = "Id";
            comboBoxRecipes.DataSource = dt;
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

                int recipeId = (int)comboBoxRecipes.SelectedValue;
                string recipeName = comboBoxRecipes.Text;

                using (SqlCommand cmd = new SqlCommand("SELECT StockQuantity FROM Products WHERE Name=@name", connection))
                {
                    cmd.Parameters.AddWithValue("@name", recipeName);
                    object res = cmd.ExecuteScalar();
                    double productStock = (res == null) ? 0 : Convert.ToDouble(res);
                    lblProductStock.Text = $"На складе: {productStock} шт.";
                }

                // --- 2) Получаем рецепт (ингредиенты на 1 шт) ---
                DataTable recipeTable = new DataTable();
                string sqlRecipe = @"
            SELECT i.Name, ri.Amount, i.Unit, i.StockQuantity
            FROM RecipeIngredients ri
            JOIN Ingredients i ON ri.IngredientId = i.Id
            WHERE ri.RecipeId = @rid";
                using (SqlDataAdapter da = new SqlDataAdapter(sqlRecipe, connection))
                {
                    da.SelectCommand.Parameters.AddWithValue("@rid", recipeId);
                    da.Fill(recipeTable);
                }

                // --- 3) Считаем требуемое, остатки и к заказу ---
                DataTable requiredTable = new DataTable();
                requiredTable.Columns.Add("Ингредиент");
                requiredTable.Columns.Add("Требуется", typeof(double));
                requiredTable.Columns.Add("Единица");

                DataTable stockTable = new DataTable();
                stockTable.Columns.Add("Ингредиент");
                stockTable.Columns.Add("На складе", typeof(double));
                stockTable.Columns.Add("Единица");

                DataTable toOrderTable = new DataTable();
                toOrderTable.Columns.Add("Ингредиент");
                toOrderTable.Columns.Add("Заказать", typeof(double));
                toOrderTable.Columns.Add("Единица");

                foreach (DataRow row in recipeTable.Rows)
                {
                    string name = row["Name"].ToString();
                    double amountPerOne = Convert.ToDouble(row["Amount"]);
                    string unit = row["Unit"].ToString();
                    double stock = Convert.ToDouble(row["StockQuantity"]);

                    double required = amountPerOne * quantity;
                    double needToOrder = required - stock;
                    if (needToOrder < 0) needToOrder = 0;

                    requiredTable.Rows.Add(name, required, unit);
                    stockTable.Rows.Add(name, stock, unit);
                    toOrderTable.Rows.Add(name, needToOrder, unit);
                }

                // Привязываем таблицы к DataGridView
                dgvRequired.DataSource = requiredTable;
                dgvStock.DataSource = stockTable;
                dgvToOrder.DataSource = toOrderTable;
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            connection?.Close();
            base.OnFormClosed(e);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

    
    /*public class Recipe
    {
        public string Name;
        public Dictionary<string, (double Amount, string Unit)> Ingredients { get; set; }

        public Recipe(string name, Dictionary<string, (double Amount, string Unit)> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }
    }*/
    
}
