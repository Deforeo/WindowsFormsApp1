
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxRecipes = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblProductStock = new System.Windows.Forms.Label();
            this.listRequired = new System.Windows.Forms.ListBox();
            this.listStock = new System.Windows.Forms.ListBox();
            this.listToOrder = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxRecipes
            // 
            this.comboBoxRecipes.FormattingEnabled = true;
            this.comboBoxRecipes.Location = new System.Drawing.Point(271, 228);
            this.comboBoxRecipes.Name = "comboBoxRecipes";
            this.comboBoxRecipes.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRecipes.TabIndex = 0;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(271, 282);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(41, 20);
            this.txtQuantity.TabIndex = 1;
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.SpringGreen;
            this.btnCalculate.Font = new System.Drawing.Font("Arial Black", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(208, 328);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(238, 78);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "жми";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click_1);
            // 
            // lblProductStock
            // 
            this.lblProductStock.AutoSize = true;
            this.lblProductStock.Font = new System.Drawing.Font("Arial Black", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProductStock.Location = new System.Drawing.Point(12, 143);
            this.lblProductStock.Name = "lblProductStock";
            this.lblProductStock.Size = new System.Drawing.Size(253, 90);
            this.lblProductStock.TabIndex = 3;
            this.lblProductStock.Text = "label1";
            // 
            // listRequired
            // 
            this.listRequired.BackColor = System.Drawing.Color.Maroon;
            this.listRequired.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listRequired.ForeColor = System.Drawing.Color.Cyan;
            this.listRequired.FormattingEnabled = true;
            this.listRequired.Location = new System.Drawing.Point(158, 45);
            this.listRequired.Name = "listRequired";
            this.listRequired.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listRequired.Size = new System.Drawing.Size(207, 91);
            this.listRequired.TabIndex = 4;
            // 
            // listStock
            // 
            this.listStock.BackColor = System.Drawing.Color.Maroon;
            this.listStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listStock.ForeColor = System.Drawing.Color.Aqua;
            this.listStock.FormattingEnabled = true;
            this.listStock.Location = new System.Drawing.Point(390, 45);
            this.listStock.Name = "listStock";
            this.listStock.Size = new System.Drawing.Size(253, 93);
            this.listStock.TabIndex = 5;
            // 
            // listToOrder
            // 
            this.listToOrder.BackColor = System.Drawing.Color.Maroon;
            this.listToOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listToOrder.ForeColor = System.Drawing.Color.Cyan;
            this.listToOrder.FormattingEnabled = true;
            this.listToOrder.Location = new System.Drawing.Point(12, 45);
            this.listToOrder.Name = "listToOrder";
            this.listToOrder.Size = new System.Drawing.Size(116, 93);
            this.listToOrder.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "На заказ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(154, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Сколько требуется";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(386, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "На слакде";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Кол-во";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(665, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listToOrder);
            this.Controls.Add(this.listStock);
            this.Controls.Add(this.listRequired);
            this.Controls.Add(this.lblProductStock);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.comboBoxRecipes);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxRecipes;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblProductStock;
        private System.Windows.Forms.ListBox listRequired;
        private System.Windows.Forms.ListBox listStock;
        private System.Windows.Forms.ListBox listToOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

