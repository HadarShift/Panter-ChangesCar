namespace PanterToBookkeeping
{
    partial class Frm_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridView_employees = new ADGV.AdvancedDataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.cbo_search_result = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.date_start_changes2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.date_start_changes1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DataGridView_History = new ADGV.AdvancedDataGridView();
            this.btn_show = new System.Windows.Forms.Button();
            this.cbo_search = new System.Windows.Forms.ComboBox();
            this.date_start2 = new System.Windows.Forms.DateTimePicker();
            this.label24 = new System.Windows.Forms.Label();
            this.date_start1 = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_show = new System.Windows.Forms.Label();
            this.cb_ShowActive = new System.Windows.Forms.CheckBox();
            this.lbl_print = new System.Windows.Forms.Button();
            this.MakeExcellRepBTN = new System.Windows.Forms.Button();
            this.btn_printhistory = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_employees)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_History)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView_employees
            // 
            this.DataGridView_employees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_employees.AutoGenerateContextFilters = true;
            this.DataGridView_employees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView_employees.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DataGridView_employees.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_employees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridView_employees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_employees.DateWithTime = false;
            this.DataGridView_employees.Location = new System.Drawing.Point(3, 68);
            this.DataGridView_employees.Name = "DataGridView_employees";
            this.DataGridView_employees.ReadOnly = true;
            this.DataGridView_employees.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DataGridView_employees.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridView_employees.Size = new System.Drawing.Size(1434, 488);
            this.DataGridView_employees.TabIndex = 1;
            this.DataGridView_employees.TimeFilter = false;
            this.DataGridView_employees.SortStringChanged += new System.EventHandler(this.DataGridView_employees_SortStringChanged);
            this.DataGridView_employees.FilterStringChanged += new System.EventHandler(this.DataGridView_employees_FilterStringChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button1.Location = new System.Drawing.Point(663, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 369;
            this.button1.Text = "בטל חיפוש";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbo_search_result
            // 
            this.cbo_search_result.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_search_result.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbo_search_result.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_search_result.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cbo_search_result.FormattingEnabled = true;
            this.cbo_search_result.Location = new System.Drawing.Point(827, 21);
            this.cbo_search_result.Name = "cbo_search_result";
            this.cbo_search_result.Size = new System.Drawing.Size(212, 29);
            this.cbo_search_result.TabIndex = 366;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label12.Location = new System.Drawing.Point(1353, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 23);
            this.label12.TabIndex = 364;
            this.label12.Text = "חיפוש";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tabControl1.Location = new System.Drawing.Point(32, 95);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1454, 585);
            this.tabControl1.TabIndex = 370;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.date_start_changes2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.date_start_changes1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.lbl_print);
            this.tabPage1.Controls.Add(this.DataGridView_employees);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1446, 552);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "שינויי רכב";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button2.Location = new System.Drawing.Point(775, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 23);
            this.button2.TabIndex = 382;
            this.button2.Text = "הצג";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // date_start_changes2
            // 
            this.date_start_changes2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.date_start_changes2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.date_start_changes2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_start_changes2.Location = new System.Drawing.Point(846, 28);
            this.date_start_changes2.Name = "date_start_changes2";
            this.date_start_changes2.Size = new System.Drawing.Size(98, 22);
            this.date_start_changes2.TabIndex = 378;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(950, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 23);
            this.label2.TabIndex = 381;
            this.label2.Text = "עד תאריך ";
            // 
            // date_start_changes1
            // 
            this.date_start_changes1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.date_start_changes1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.date_start_changes1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_start_changes1.Location = new System.Drawing.Point(1141, 27);
            this.date_start_changes1.Name = "date_start_changes1";
            this.date_start_changes1.Size = new System.Drawing.Size(99, 22);
            this.date_start_changes1.TabIndex = 379;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(1246, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 23);
            this.label3.TabIndex = 380;
            this.label3.Text = "מתאריך התחלה";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.MakeExcellRepBTN);
            this.tabPage2.Controls.Add(this.cb_ShowActive);
            this.tabPage2.Controls.Add(this.btn_printhistory);
            this.tabPage2.Controls.Add(this.DataGridView_History);
            this.tabPage2.Controls.Add(this.btn_show);
            this.tabPage2.Controls.Add(this.cbo_search);
            this.tabPage2.Controls.Add(this.date_start2);
            this.tabPage2.Controls.Add(this.cbo_search_result);
            this.tabPage2.Controls.Add(this.label24);
            this.tabPage2.Controls.Add(this.btn_search);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.date_start1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1446, 552);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "היסטוריה";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DataGridView_History
            // 
            this.DataGridView_History.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_History.AutoGenerateContextFilters = true;
            this.DataGridView_History.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView_History.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DataGridView_History.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_History.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DataGridView_History.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_History.DateWithTime = false;
            this.DataGridView_History.Location = new System.Drawing.Point(6, 97);
            this.DataGridView_History.Name = "DataGridView_History";
            this.DataGridView_History.ReadOnly = true;
            this.DataGridView_History.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DataGridView_History.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DataGridView_History.Size = new System.Drawing.Size(1434, 449);
            this.DataGridView_History.TabIndex = 2;
            this.DataGridView_History.TimeFilter = false;
            this.DataGridView_History.SortStringChanged += new System.EventHandler(this.DataGridView_History_SortStringChanged);
            this.DataGridView_History.FilterStringChanged += new System.EventHandler(this.DataGridView_History_FilterStringChanged);
            // 
            // btn_show
            // 
            this.btn_show.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_show.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_show.Location = new System.Drawing.Point(690, 67);
            this.btn_show.Name = "btn_show";
            this.btn_show.Size = new System.Drawing.Size(51, 23);
            this.btn_show.TabIndex = 376;
            this.btn_show.Text = "הצג";
            this.btn_show.UseVisualStyleBackColor = true;
            this.btn_show.Click += new System.EventHandler(this.btn_show_Click);
            // 
            // cbo_search
            // 
            this.cbo_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_search.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_search.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cbo_search.FormattingEnabled = true;
            this.cbo_search.Location = new System.Drawing.Point(1067, 21);
            this.cbo_search.Name = "cbo_search";
            this.cbo_search.Size = new System.Drawing.Size(265, 30);
            this.cbo_search.TabIndex = 371;
            this.cbo_search.SelectedIndexChanged += new System.EventHandler(this.cbo_search_SelectedIndexChanged);
            // 
            // date_start2
            // 
            this.date_start2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.date_start2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.date_start2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_start2.Location = new System.Drawing.Point(761, 69);
            this.date_start2.Name = "date_start2";
            this.date_start2.Size = new System.Drawing.Size(98, 22);
            this.date_start2.TabIndex = 372;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label24.Location = new System.Drawing.Point(865, 67);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(111, 23);
            this.label24.TabIndex = 375;
            this.label24.Text = "עד תאריך ";
            // 
            // date_start1
            // 
            this.date_start1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.date_start1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.date_start1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_start1.Location = new System.Drawing.Point(1056, 68);
            this.date_start1.Name = "date_start1";
            this.date_start1.Size = new System.Drawing.Size(99, 22);
            this.date_start1.TabIndex = 373;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label13.Location = new System.Drawing.Point(1161, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(165, 23);
            this.label13.TabIndex = 374;
            this.label13.Text = "מתאריך התחלה";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(712, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 32);
            this.label1.TabIndex = 371;
            this.label1.Text = "שינויי רכבים  ";
            // 
            // lbl_show
            // 
            this.lbl_show.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_show.AutoSize = true;
            this.lbl_show.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_show.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_show.Location = new System.Drawing.Point(620, 52);
            this.lbl_show.Name = "lbl_show";
            this.lbl_show.Size = new System.Drawing.Size(191, 32);
            this.lbl_show.TabIndex = 372;
            this.lbl_show.Text = "****************";
            // 
            // cb_ShowActive
            // 
            this.cb_ShowActive.AutoSize = true;
            this.cb_ShowActive.Font = new System.Drawing.Font("Tahoma", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cb_ShowActive.Location = new System.Drawing.Point(6, 63);
            this.cb_ShowActive.Name = "cb_ShowActive";
            this.cb_ShowActive.Size = new System.Drawing.Size(207, 27);
            this.cb_ShowActive.TabIndex = 379;
            this.cb_ShowActive.Text = "הצג רכבים פעילים";
            this.cb_ShowActive.UseVisualStyleBackColor = true;
            this.cb_ShowActive.CheckedChanged += new System.EventHandler(this.cb_ShowActive_CheckedChanged);
            // 
            // lbl_print
            // 
            this.lbl_print.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbl_print.BackgroundImage = global::PanterToBookkeeping.Properties.Resources.print_icon;
            this.lbl_print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_print.Location = new System.Drawing.Point(27, 16);
            this.lbl_print.Name = "lbl_print";
            this.lbl_print.Size = new System.Drawing.Size(63, 46);
            this.lbl_print.TabIndex = 377;
            this.lbl_print.UseVisualStyleBackColor = false;
            this.lbl_print.Click += new System.EventHandler(this.lbl_print_Click);
            // 
            // MakeExcellRepBTN
            // 
            this.MakeExcellRepBTN.BackColor = System.Drawing.Color.LightGreen;
            this.MakeExcellRepBTN.BackgroundImage = global::PanterToBookkeeping.Properties.Resources.Excel_Icon;
            this.MakeExcellRepBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MakeExcellRepBTN.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MakeExcellRepBTN.Location = new System.Drawing.Point(6, 3);
            this.MakeExcellRepBTN.Name = "MakeExcellRepBTN";
            this.MakeExcellRepBTN.Size = new System.Drawing.Size(66, 45);
            this.MakeExcellRepBTN.TabIndex = 380;
            this.MakeExcellRepBTN.UseVisualStyleBackColor = false;
            this.MakeExcellRepBTN.Click += new System.EventHandler(this.MakeExcellRepBTN_Click);
            // 
            // btn_printhistory
            // 
            this.btn_printhistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_printhistory.BackgroundImage = global::PanterToBookkeeping.Properties.Resources.print_icon;
            this.btn_printhistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_printhistory.Location = new System.Drawing.Point(90, 3);
            this.btn_printhistory.Name = "btn_printhistory";
            this.btn_printhistory.Size = new System.Drawing.Size(63, 46);
            this.btn_printhistory.TabIndex = 378;
            this.btn_printhistory.UseVisualStyleBackColor = false;
            this.btn_printhistory.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_search
            // 
            this.btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search.BackColor = System.Drawing.Color.Transparent;
            this.btn_search.BackgroundImage = global::PanterToBookkeeping.Properties.Resources.search_icon;
            this.btn_search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_search.Enabled = false;
            this.btn_search.Location = new System.Drawing.Point(773, 21);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(48, 33);
            this.btn_search.TabIndex = 368;
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1498, 703);
            this.Controls.Add(this.lbl_show);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "מאגר רכבים";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Main_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_employees)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_History)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ADGV.AdvancedDataGridView DataGridView_employees;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.ComboBox cbo_search_result;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ADGV.AdvancedDataGridView DataGridView_History;
        private System.Windows.Forms.ComboBox cbo_search;
        private System.Windows.Forms.Button btn_show;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker date_start1;
        private System.Windows.Forms.DateTimePicker date_start2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_show;
        private System.Windows.Forms.Button lbl_print;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker date_start_changes2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker date_start_changes1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_printhistory;
        private System.Windows.Forms.CheckBox cb_ShowActive;
        private System.Windows.Forms.Button MakeExcellRepBTN;
    }
}

