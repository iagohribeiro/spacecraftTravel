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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(s));
            this.spacecraft_ComboBox = new System.Windows.Forms.ComboBox();
            this.capacity_ComboBox = new System.Windows.Forms.ComboBox();
            this.spacecraf_label = new System.Windows.Forms.Label();
            this.capacity_label = new System.Windows.Forms.Label();
            this.destination_listBox = new System.Windows.Forms.ListBox();
            this.destination_list_label = new System.Windows.Forms.Label();
            this.route_label = new System.Windows.Forms.Label();
            this.destination_selector_label = new System.Windows.Forms.Label();
            this.destination_comboBox = new System.Windows.Forms.ComboBox();
            this.createRoute_button = new System.Windows.Forms.Button();
            this.load_route_button = new System.Windows.Forms.Button();
            this.save_route_button = new System.Windows.Forms.Button();
            this.route_textBox = new System.Windows.Forms.TextBox();
            this.logo_pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.logo_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.spacecraf_label.Size = new System.Drawing.Size(115, 25);
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
            this.destination_listBox.Location = new System.Drawing.Point(183, 540);
            this.destination_listBox.Name = "destination_listBox";
            this.destination_listBox.Size = new System.Drawing.Size(521, 404);
            this.destination_listBox.TabIndex = 4;
            this.destination_listBox.SelectedIndexChanged += new System.EventHandler(this.destination_listBox_SelectedIndexChanged);
            // 
            // destination_list_label
            // 
            this.destination_list_label.AutoSize = true;
            this.destination_list_label.Location = new System.Drawing.Point(345, 486);
            this.destination_list_label.Name = "destination_list_label";
            this.destination_list_label.Size = new System.Drawing.Size(160, 25);
            this.destination_list_label.TabIndex = 5;
            this.destination_list_label.Text = "Destination List";
            // 
            // route_label
            // 
            this.route_label.AutoSize = true;
            this.route_label.Location = new System.Drawing.Point(1086, 486);
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
            this.createRoute_button.Location = new System.Drawing.Point(730, 592);
            this.createRoute_button.Name = "createRoute_button";
            this.createRoute_button.Size = new System.Drawing.Size(97, 74);
            this.createRoute_button.TabIndex = 10;
            this.createRoute_button.Text = "Create Route";
            this.createRoute_button.UseVisualStyleBackColor = true;
            this.createRoute_button.Click += new System.EventHandler(this.createRoute_button_Click);
            // 
            // load_route_button
            // 
            this.load_route_button.Location = new System.Drawing.Point(730, 699);
            this.load_route_button.Name = "load_route_button";
            this.load_route_button.Size = new System.Drawing.Size(97, 74);
            this.load_route_button.TabIndex = 11;
            this.load_route_button.Text = "Load Route";
            this.load_route_button.UseVisualStyleBackColor = true;
            this.load_route_button.Click += new System.EventHandler(this.load_route_button_Click);
            // 
            // save_route_button
            // 
            this.save_route_button.Location = new System.Drawing.Point(730, 812);
            this.save_route_button.Name = "save_route_button";
            this.save_route_button.Size = new System.Drawing.Size(97, 74);
            this.save_route_button.TabIndex = 12;
            this.save_route_button.Text = "Save Route";
            this.save_route_button.UseVisualStyleBackColor = true;
            this.save_route_button.Click += new System.EventHandler(this.save_route_button_Click);
            // 
            // route_textBox
            // 
            this.route_textBox.Location = new System.Drawing.Point(861, 540);
            this.route_textBox.Multiline = true;
            this.route_textBox.Name = "route_textBox";
            this.route_textBox.Size = new System.Drawing.Size(521, 404);
            this.route_textBox.TabIndex = 13;
            // 
            // logo_pictureBox
            // 
            this.logo_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logo_pictureBox.Image")));
            this.logo_pictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("logo_pictureBox.InitialImage")));
            this.logo_pictureBox.Location = new System.Drawing.Point(1101, 92);
            this.logo_pictureBox.Name = "logo_pictureBox";
            this.logo_pictureBox.Size = new System.Drawing.Size(333, 336);
            this.logo_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo_pictureBox.TabIndex = 14;
            this.logo_pictureBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(509, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(566, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // s
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1502, 978);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.logo_pictureBox);
            this.Controls.Add(this.route_textBox);
            this.Controls.Add(this.save_route_button);
            this.Controls.Add(this.load_route_button);
            this.Controls.Add(this.createRoute_button);
            this.Controls.Add(this.destination_comboBox);
            this.Controls.Add(this.destination_selector_label);
            this.Controls.Add(this.route_label);
            this.Controls.Add(this.destination_list_label);
            this.Controls.Add(this.destination_listBox);
            this.Controls.Add(this.capacity_label);
            this.Controls.Add(this.spacecraf_label);
            this.Controls.Add(this.capacity_ComboBox);
            this.Controls.Add(this.spacecraft_ComboBox);
            this.Name = "s";
            this.Text = "Isar Assignment";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logo_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label route_label;
        private System.Windows.Forms.Label destination_selector_label;
        private System.Windows.Forms.ComboBox destination_comboBox;
        private System.Windows.Forms.Button createRoute_button;
        private System.Windows.Forms.Button load_route_button;
        private System.Windows.Forms.Button save_route_button;
        private System.Windows.Forms.TextBox route_textBox;
        private System.Windows.Forms.PictureBox logo_pictureBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

