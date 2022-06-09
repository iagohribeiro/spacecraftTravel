namespace isarAssignment
{
    partial class s
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.spacecraft_ComboBox = new System.Windows.Forms.ComboBox();
            this.capacity_ComboBox = new System.Windows.Forms.ComboBox();
            this.spacecraf_label = new System.Windows.Forms.Label();
            this.capacity_label = new System.Windows.Forms.Label();
            this.destination_listBox = new System.Windows.Forms.ListBox();
            this.destination_list_label = new System.Windows.Forms.Label();
            this.route_listBox = new System.Windows.Forms.ListBox();
            this.route_label = new System.Windows.Forms.Label();
            this.destination_selector_label = new System.Windows.Forms.Label();
            this.destination_comboBox = new System.Windows.Forms.ComboBox();
            this.createRoute_button = new System.Windows.Forms.Button();
            this.load_route_button = new System.Windows.Forms.Button();
            this.save_route_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // spacecraft_ComboBox
            // 
            this.spacecraft_ComboBox.FormattingEnabled = true;
            this.spacecraft_ComboBox.Location = new System.Drawing.Point(595, 162);
            this.spacecraft_ComboBox.Name = "spacecraft_ComboBox";
            this.spacecraft_ComboBox.Size = new System.Drawing.Size(414, 33);
            this.spacecraft_ComboBox.TabIndex = 0;
            this.spacecraft_ComboBox.SelectedIndexChanged += new System.EventHandler(this.spacecraft_ComboBox_SelectedIndexChanged);
            // 
            // capacity_ComboBox
            // 
            this.capacity_ComboBox.FormattingEnabled = true;
            this.capacity_ComboBox.Location = new System.Drawing.Point(595, 241);
            this.capacity_ComboBox.Name = "capacity_ComboBox";
            this.capacity_ComboBox.Size = new System.Drawing.Size(414, 33);
            this.capacity_ComboBox.TabIndex = 1;
            this.capacity_ComboBox.SelectedIndexChanged += new System.EventHandler(this.capacity_ComboBox_SelectedIndexChanged);
            // 
            // spacecraf_label
            // 
            this.spacecraf_label.AutoSize = true;
            this.spacecraf_label.Location = new System.Drawing.Point(208, 170);
            this.spacecraf_label.Name = "spacecraf_label";
            this.spacecraf_label.Size = new System.Drawing.Size(184, 40);
            this.spacecraf_label.TabIndex = 2;
            this.spacecraf_label.Text = "Spacecraft";
            // 
            // capacity_label
            // 
            this.capacity_label.AutoSize = true;
            this.capacity_label.Location = new System.Drawing.Point(208, 249);
            this.capacity_label.Name = "capacity_label";
            this.capacity_label.Size = new System.Drawing.Size(231, 25);
            this.capacity_label.TabIndex = 3;
            this.capacity_label.Text = "Number of Passengers";
            // 
            // destination_listBox
            // 
            this.destination_listBox.FormattingEnabled = true;
            this.destination_listBox.ItemHeight = 25;
            this.destination_listBox.Location = new System.Drawing.Point(183, 499);
            this.destination_listBox.Name = "destination_listBox";
            this.destination_listBox.Size = new System.Drawing.Size(521, 404);
            this.destination_listBox.TabIndex = 4;
            this.destination_listBox.SelectedIndexChanged += new System.EventHandler(this.destination_listBox_SelectedIndexChanged);
            // 
            // destination_list_label
            // 
            this.destination_list_label.AutoSize = true;
            this.destination_list_label.Location = new System.Drawing.Point(345, 445);
            this.destination_list_label.Name = "destination_list_label";
            this.destination_list_label.Size = new System.Drawing.Size(160, 25);
            this.destination_list_label.TabIndex = 5;
            this.destination_list_label.Text = "Destination List";
            // 
            // route_listBox
            // 
            this.route_listBox.FormattingEnabled = true;
            this.route_listBox.ItemHeight = 25;
            this.route_listBox.Location = new System.Drawing.Point(865, 499);
            this.route_listBox.Name = "route_listBox";
            this.route_listBox.Size = new System.Drawing.Size(521, 404);
            this.route_listBox.TabIndex = 6;
            // 
            // route_label
            // 
            this.route_label.AutoSize = true;
            this.route_label.Location = new System.Drawing.Point(1086, 445);
            this.route_label.Name = "route_label";
            this.route_label.Size = new System.Drawing.Size(69, 25);
            this.route_label.TabIndex = 7;
            this.route_label.Text = "Route";
            // 
            // destination_selector_label
            // 
            this.destination_selector_label.AutoSize = true;
            this.destination_selector_label.Location = new System.Drawing.Point(710, 339);
            this.destination_selector_label.Name = "destination_selector_label";
            this.destination_selector_label.Size = new System.Drawing.Size(186, 25);
            this.destination_selector_label.TabIndex = 8;
            this.destination_selector_label.Text = "Select Destination";
            // 
            // destination_comboBox
            // 
            this.destination_comboBox.FormattingEnabled = true;
            this.destination_comboBox.Location = new System.Drawing.Point(592, 385);
            this.destination_comboBox.Name = "destination_comboBox";
            this.destination_comboBox.Size = new System.Drawing.Size(414, 33);
            this.destination_comboBox.TabIndex = 9;
            this.destination_comboBox.SelectedIndexChanged += new System.EventHandler(this.destination_comboBox_SelectedIndexChanged);
            // 
            // createRoute_button
            // 
            this.createRoute_button.Location = new System.Drawing.Point(730, 551);
            this.createRoute_button.Name = "createRoute_button";
            this.createRoute_button.Size = new System.Drawing.Size(97, 74);
            this.createRoute_button.TabIndex = 10;
            this.createRoute_button.Text = "Create Route";
            this.createRoute_button.UseVisualStyleBackColor = true;
            // 
            // load_route_button
            // 
            this.load_route_button.Location = new System.Drawing.Point(730, 658);
            this.load_route_button.Name = "load_route_button";
            this.load_route_button.Size = new System.Drawing.Size(97, 74);
            this.load_route_button.TabIndex = 11;
            this.load_route_button.Text = "Load Route";
            this.load_route_button.UseVisualStyleBackColor = true;
            // 
            // save_route_button
            // 
            this.save_route_button.Location = new System.Drawing.Point(730, 771);
            this.save_route_button.Name = "save_route_button";
            this.save_route_button.Size = new System.Drawing.Size(97, 74);
            this.save_route_button.TabIndex = 12;
            this.save_route_button.Text = "Save Route";
            this.save_route_button.UseVisualStyleBackColor = true;
            // 
            // s
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1502, 978);
            this.Controls.Add(this.save_route_button);
            this.Controls.Add(this.load_route_button);
            this.Controls.Add(this.createRoute_button);
            this.Controls.Add(this.destination_comboBox);
            this.Controls.Add(this.destination_selector_label);
            this.Controls.Add(this.route_label);
            this.Controls.Add(this.route_listBox);
            this.Controls.Add(this.destination_list_label);
            this.Controls.Add(this.destination_listBox);
            this.Controls.Add(this.capacity_label);
            this.Controls.Add(this.spacecraf_label);
            this.Controls.Add(this.capacity_ComboBox);
            this.Controls.Add(this.spacecraft_ComboBox);
            this.Name = "s";
            this.Text = "Isar Assignment";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox spacecraft_ComboBox;
        private System.Windows.Forms.ComboBox capacity_ComboBox;
        private System.Windows.Forms.Label spacecraf_label;
        private System.Windows.Forms.Label capacity_label;
        private System.Windows.Forms.ListBox destination_listBox;
        private System.Windows.Forms.Label destination_list_label;
        private System.Windows.Forms.ListBox route_listBox;
        private System.Windows.Forms.Label route_label;
        private System.Windows.Forms.Label destination_selector_label;
        private System.Windows.Forms.ComboBox destination_comboBox;
        private System.Windows.Forms.Button createRoute_button;
        private System.Windows.Forms.Button load_route_button;
        private System.Windows.Forms.Button save_route_button;
    }
}

