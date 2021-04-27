
namespace homework8
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button_ImportOrder = new System.Windows.Forms.Button();
            this.button_ExportOrder = new System.Windows.Forms.Button();
            this.button_DeleteOrder = new System.Windows.Forms.Button();
            this.button_ModifyOrder = new System.Windows.Forms.Button();
            this.button_AddOrder = new System.Windows.Forms.Button();
            this.button_Search = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.odnumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.odpriDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.odnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDetailsBindingSourse = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderBindingSourse = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDetailsBindingSourse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderBindingSourse)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(1, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 433);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.customerDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.OrderBindingSourse;
            this.dataGridView1.Location = new System.Drawing.Point(1, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(484, 429);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(524, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(474, 433);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.odnumDataGridViewTextBoxColumn,
            this.odpriDataGridViewTextBoxColumn,
            this.odnameDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.OrderDetailsBindingSourse;
            this.dataGridView2.Location = new System.Drawing.Point(495, 99);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(493, 430);
            this.dataGridView2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.button_ImportOrder);
            this.panel3.Controls.Add(this.button_ExportOrder);
            this.panel3.Controls.Add(this.button_DeleteOrder);
            this.panel3.Controls.Add(this.button_ModifyOrder);
            this.panel3.Controls.Add(this.button_AddOrder);
            this.panel3.Controls.Add(this.button_Search);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(988, 93);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "输入订单号查询订单";
            // 
            // button_ImportOrder
            // 
            this.button_ImportOrder.Location = new System.Drawing.Point(481, 53);
            this.button_ImportOrder.Name = "button_ImportOrder";
            this.button_ImportOrder.Size = new System.Drawing.Size(88, 30);
            this.button_ImportOrder.TabIndex = 7;
            this.button_ImportOrder.Text = "导入订单";
            this.button_ImportOrder.UseVisualStyleBackColor = true;
            this.button_ImportOrder.Click += new System.EventHandler(this.button_ImportOrder_Click);
            // 
            // button_ExportOrder
            // 
            this.button_ExportOrder.Location = new System.Drawing.Point(361, 53);
            this.button_ExportOrder.Name = "button_ExportOrder";
            this.button_ExportOrder.Size = new System.Drawing.Size(89, 30);
            this.button_ExportOrder.TabIndex = 6;
            this.button_ExportOrder.Text = "导出订单";
            this.button_ExportOrder.UseVisualStyleBackColor = true;
            this.button_ExportOrder.Click += new System.EventHandler(this.button_ExportOrder_Click);
            // 
            // button_DeleteOrder
            // 
            this.button_DeleteOrder.Location = new System.Drawing.Point(127, 53);
            this.button_DeleteOrder.Name = "button_DeleteOrder";
            this.button_DeleteOrder.Size = new System.Drawing.Size(90, 30);
            this.button_DeleteOrder.TabIndex = 5;
            this.button_DeleteOrder.Text = "删除订单";
            this.button_DeleteOrder.UseVisualStyleBackColor = true;
            this.button_DeleteOrder.Click += new System.EventHandler(this.button_DeleteOrder_Click);
            // 
            // button_ModifyOrder
            // 
            this.button_ModifyOrder.Location = new System.Drawing.Point(247, 53);
            this.button_ModifyOrder.Name = "button_ModifyOrder";
            this.button_ModifyOrder.Size = new System.Drawing.Size(86, 30);
            this.button_ModifyOrder.TabIndex = 4;
            this.button_ModifyOrder.Text = "修改订单";
            this.button_ModifyOrder.UseVisualStyleBackColor = true;
            this.button_ModifyOrder.Click += new System.EventHandler(this.button_ModifyOrder_Click);
            // 
            // button_AddOrder
            // 
            this.button_AddOrder.Location = new System.Drawing.Point(12, 53);
            this.button_AddOrder.Name = "button_AddOrder";
            this.button_AddOrder.Size = new System.Drawing.Size(89, 30);
            this.button_AddOrder.TabIndex = 3;
            this.button_AddOrder.Text = "添加订单";
            this.button_AddOrder.UseVisualStyleBackColor = true;
            this.button_AddOrder.Click += new System.EventHandler(this.button_AddOrder_Click);
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(470, 8);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(99, 25);
            this.button_Search.TabIndex = 2;
            this.button_Search.Text = "查询";
            this.button_Search.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(160, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 25);
            this.textBox1.TabIndex = 1;
            // 
            // odnumDataGridViewTextBoxColumn
            // 
            this.odnumDataGridViewTextBoxColumn.DataPropertyName = "odnum";
            this.odnumDataGridViewTextBoxColumn.HeaderText = "odnum";
            this.odnumDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.odnumDataGridViewTextBoxColumn.Name = "odnumDataGridViewTextBoxColumn";
            this.odnumDataGridViewTextBoxColumn.Width = 125;
            // 
            // odpriDataGridViewTextBoxColumn
            // 
            this.odpriDataGridViewTextBoxColumn.DataPropertyName = "odpri";
            this.odpriDataGridViewTextBoxColumn.HeaderText = "odpri";
            this.odpriDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.odpriDataGridViewTextBoxColumn.Name = "odpriDataGridViewTextBoxColumn";
            this.odpriDataGridViewTextBoxColumn.Width = 125;
            // 
            // odnameDataGridViewTextBoxColumn
            // 
            this.odnameDataGridViewTextBoxColumn.DataPropertyName = "odname";
            this.odnameDataGridViewTextBoxColumn.HeaderText = "odname";
            this.odnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.odnameDataGridViewTextBoxColumn.Name = "odnameDataGridViewTextBoxColumn";
            this.odnameDataGridViewTextBoxColumn.Width = 125;
            // 
            // OrderDetailsBindingSourse
            // 
            this.OrderDetailsBindingSourse.DataSource = typeof(homework8.OrderDetails);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // customerDataGridViewTextBoxColumn
            // 
            this.customerDataGridViewTextBoxColumn.DataPropertyName = "customer";
            this.customerDataGridViewTextBoxColumn.HeaderText = "customer";
            this.customerDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.customerDataGridViewTextBoxColumn.Name = "customerDataGridViewTextBoxColumn";
            this.customerDataGridViewTextBoxColumn.Width = 125;
            // 
            // OrderBindingSourse
            // 
            this.OrderBindingSourse.DataSource = typeof(homework8.Order);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 531);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDetailsBindingSourse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderBindingSourse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_ImportOrder;
        private System.Windows.Forms.Button button_ExportOrder;
        private System.Windows.Forms.Button button_DeleteOrder;
        private System.Windows.Forms.Button button_ModifyOrder;
        private System.Windows.Forms.Button button_AddOrder;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource OrderBindingSourse;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource OrderDetailsBindingSourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn odnumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn odpriDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn odnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
    }
}

