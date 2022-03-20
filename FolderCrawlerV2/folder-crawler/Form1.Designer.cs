namespace folder_crawler
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gViewer1 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.lbl_title = new System.Windows.Forms.Label();
            this.folderbrowse_startingpoint = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_choosefolder = new System.Windows.Forms.Button();
            this.lbl_startingfolder = new System.Windows.Forms.Label();
            this.lbl_selectedstartfolder = new System.Windows.Forms.Label();
            this.lbl_selecteddetail = new System.Windows.Forms.Label();
            this.tbox_filename = new System.Windows.Forms.TextBox();
            this.lbl_filename_title = new System.Windows.Forms.Label();
            this.cbox_alloccurence = new System.Windows.Forms.CheckBox();
            this.lbl_method = new System.Windows.Forms.Label();
            this.method_panel_group = new System.Windows.Forms.Panel();
            this.radio_dfs = new System.Windows.Forms.RadioButton();
            this.radio_bfs = new System.Windows.Forms.RadioButton();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_interrupt = new System.Windows.Forms.Button();
            this.bg_searching = new System.ComponentModel.BackgroundWorker();
            this.pnl_folderloc = new System.Windows.Forms.Panel();
            this.lbl_time_elapsed = new System.Windows.Forms.Label();
            this.lbl_time_elapsed_detail = new System.Windows.Forms.Label();
            this.method_panel_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // gViewer1
            // 
            this.gViewer1.ArrowheadLength = 10D;
            this.gViewer1.AsyncLayout = false;
            this.gViewer1.AutoScroll = true;
            this.gViewer1.BackwardEnabled = false;
            this.gViewer1.BuildHitTree = true;
            this.gViewer1.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.gViewer1.EdgeInsertButtonVisible = true;
            this.gViewer1.FileName = "";
            this.gViewer1.ForwardEnabled = false;
            this.gViewer1.Graph = null;
            this.gViewer1.InsertingEdge = false;
            this.gViewer1.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewer1.LayoutEditingEnabled = true;
            this.gViewer1.Location = new System.Drawing.Point(441, 27);
            this.gViewer1.LooseOffsetForRouting = 0.25D;
            this.gViewer1.MouseHitDistance = 0.05D;
            this.gViewer1.Name = "gViewer1";
            this.gViewer1.NavigationVisible = true;
            this.gViewer1.NeedToCalculateLayout = true;
            this.gViewer1.OffsetForRelaxingInRouting = 0.6D;
            this.gViewer1.PaddingForEdgeRouting = 8D;
            this.gViewer1.PanButtonPressed = false;
            this.gViewer1.SaveAsImageEnabled = true;
            this.gViewer1.SaveAsMsaglEnabled = true;
            this.gViewer1.SaveButtonVisible = true;
            this.gViewer1.SaveGraphButtonVisible = true;
            this.gViewer1.SaveInVectorFormatEnabled = true;
            this.gViewer1.Size = new System.Drawing.Size(789, 394);
            this.gViewer1.TabIndex = 0;
            this.gViewer1.TightOffsetForRouting = 0.125D;
            this.gViewer1.ToolBarIsVisible = true;
            this.gViewer1.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("gViewer1.Transform")));
            this.gViewer1.UndoRedoButtonsVisible = true;
            this.gViewer1.WindowZoomButtonPressed = false;
            this.gViewer1.ZoomF = 1D;
            this.gViewer1.ZoomWindowThreshold = 0.05D;
            this.gViewer1.Load += new System.EventHandler(this.gViewer1_Load);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 673);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(3, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 673);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(6, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 673);
            this.splitter3.TabIndex = 5;
            this.splitter3.TabStop = false;
            // 
            // splitter4
            // 
            this.splitter4.Location = new System.Drawing.Point(9, 0);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(3, 673);
            this.splitter4.TabIndex = 6;
            this.splitter4.TabStop = false;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.lbl_title.Font = new System.Drawing.Font("Consolas", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(150)))));
            this.lbl_title.Location = new System.Drawing.Point(45, 27);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(143, 36);
            this.lbl_title.TabIndex = 7;
            this.lbl_title.Text = "SETTINGS";
            this.lbl_title.Enter += new System.EventHandler(this.tbox_filename_clicked);
            this.lbl_title.Leave += new System.EventHandler(this.tbox_filename_clicked);
            // 
            // btn_choosefolder
            // 
            this.btn_choosefolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.btn_choosefolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_choosefolder.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_choosefolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(150)))));
            this.btn_choosefolder.Location = new System.Drawing.Point(53, 133);
            this.btn_choosefolder.Name = "btn_choosefolder";
            this.btn_choosefolder.Size = new System.Drawing.Size(207, 45);
            this.btn_choosefolder.TabIndex = 8;
            this.btn_choosefolder.Text = "Choose Folder...";
            this.btn_choosefolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_choosefolder.UseVisualStyleBackColor = false;
            this.btn_choosefolder.Click += new System.EventHandler(this.btn_choosefolder_Click);
            // 
            // lbl_startingfolder
            // 
            this.lbl_startingfolder.AutoSize = true;
            this.lbl_startingfolder.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_startingfolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(150)))));
            this.lbl_startingfolder.Location = new System.Drawing.Point(49, 93);
            this.lbl_startingfolder.Name = "lbl_startingfolder";
            this.lbl_startingfolder.Size = new System.Drawing.Size(230, 22);
            this.lbl_startingfolder.TabIndex = 9;
            this.lbl_startingfolder.Text = "SELECT STARTING FOLDER";
            // 
            // lbl_selectedstartfolder
            // 
            this.lbl_selectedstartfolder.AutoSize = true;
            this.lbl_selectedstartfolder.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_selectedstartfolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(150)))));
            this.lbl_selectedstartfolder.Location = new System.Drawing.Point(50, 194);
            this.lbl_selectedstartfolder.Name = "lbl_selectedstartfolder";
            this.lbl_selectedstartfolder.Size = new System.Drawing.Size(136, 17);
            this.lbl_selectedstartfolder.TabIndex = 10;
            this.lbl_selectedstartfolder.Text = "SELECTED FOLDER:";
            // 
            // lbl_selecteddetail
            // 
            this.lbl_selecteddetail.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_selecteddetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(150)))));
            this.lbl_selecteddetail.Location = new System.Drawing.Point(53, 214);
            this.lbl_selecteddetail.Name = "lbl_selecteddetail";
            this.lbl_selecteddetail.Size = new System.Drawing.Size(294, 55);
            this.lbl_selecteddetail.TabIndex = 11;
            this.lbl_selecteddetail.Text = "None";
            // 
            // tbox_filename
            // 
            this.tbox_filename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.tbox_filename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbox_filename.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_filename.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(150)))));
            this.tbox_filename.Location = new System.Drawing.Point(53, 309);
            this.tbox_filename.Name = "tbox_filename";
            this.tbox_filename.Size = new System.Drawing.Size(294, 26);
            this.tbox_filename.TabIndex = 12;
            this.tbox_filename.Enter += new System.EventHandler(this.tbox_filename_clicked);
            this.tbox_filename.Leave += new System.EventHandler(this.tbox_filename_clicked);
            // 
            // lbl_filename_title
            // 
            this.lbl_filename_title.AutoSize = true;
            this.lbl_filename_title.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_filename_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(150)))));
            this.lbl_filename_title.Location = new System.Drawing.Point(49, 269);
            this.lbl_filename_title.Name = "lbl_filename_title";
            this.lbl_filename_title.Size = new System.Drawing.Size(150, 22);
            this.lbl_filename_title.TabIndex = 13;
            this.lbl_filename_title.Text = "ENTER FILENAME";
            // 
            // cbox_alloccurence
            // 
            this.cbox_alloccurence.AutoSize = true;
            this.cbox_alloccurence.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_alloccurence.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(150)))));
            this.cbox_alloccurence.Location = new System.Drawing.Point(53, 346);
            this.cbox_alloccurence.Name = "cbox_alloccurence";
            this.cbox_alloccurence.Size = new System.Drawing.Size(179, 21);
            this.cbox_alloccurence.TabIndex = 15;
            this.cbox_alloccurence.Text = "Find All Occurences";
            this.cbox_alloccurence.UseVisualStyleBackColor = true;
            // 
            // lbl_method
            // 
            this.lbl_method.AutoSize = true;
            this.lbl_method.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_method.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(150)))));
            this.lbl_method.Location = new System.Drawing.Point(49, 406);
            this.lbl_method.Name = "lbl_method";
            this.lbl_method.Size = new System.Drawing.Size(70, 22);
            this.lbl_method.TabIndex = 16;
            this.lbl_method.Text = "METHOD";
            // 
            // method_panel_group
            // 
            this.method_panel_group.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.method_panel_group.Controls.Add(this.radio_dfs);
            this.method_panel_group.Controls.Add(this.radio_bfs);
            this.method_panel_group.Cursor = System.Windows.Forms.Cursors.Default;
            this.method_panel_group.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(150)))));
            this.method_panel_group.Location = new System.Drawing.Point(54, 436);
            this.method_panel_group.Name = "method_panel_group";
            this.method_panel_group.Size = new System.Drawing.Size(68, 60);
            this.method_panel_group.TabIndex = 17;
            // 
            // radio_dfs
            // 
            this.radio_dfs.AutoSize = true;
            this.radio_dfs.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_dfs.Location = new System.Drawing.Point(3, 33);
            this.radio_dfs.Name = "radio_dfs";
            this.radio_dfs.Size = new System.Drawing.Size(50, 21);
            this.radio_dfs.TabIndex = 1;
            this.radio_dfs.TabStop = true;
            this.radio_dfs.Text = "DFS";
            this.radio_dfs.UseVisualStyleBackColor = true;
            // 
            // radio_bfs
            // 
            this.radio_bfs.AutoSize = true;
            this.radio_bfs.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_bfs.Location = new System.Drawing.Point(3, 3);
            this.radio_bfs.Name = "radio_bfs";
            this.radio_bfs.Size = new System.Drawing.Size(50, 21);
            this.radio_bfs.TabIndex = 0;
            this.radio_bfs.TabStop = true;
            this.radio_bfs.Text = "BFS";
            this.radio_bfs.UseVisualStyleBackColor = true;
            // 
            // btn_search
            // 
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(150)))));
            this.btn_search.Location = new System.Drawing.Point(53, 545);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(167, 56);
            this.btn_search.TabIndex = 18;
            this.btn_search.Text = "Search File";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_interrupt
            // 
            this.btn_interrupt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_interrupt.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_interrupt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(150)))));
            this.btn_interrupt.Location = new System.Drawing.Point(242, 545);
            this.btn_interrupt.Name = "btn_interrupt";
            this.btn_interrupt.Size = new System.Drawing.Size(167, 56);
            this.btn_interrupt.TabIndex = 19;
            this.btn_interrupt.Text = "Cancel Search";
            this.btn_interrupt.UseVisualStyleBackColor = true;
            this.btn_interrupt.Click += new System.EventHandler(this.btn_interrupt_Click);
            // 
            // bg_searching
            // 
            this.bg_searching.WorkerReportsProgress = true;
            this.bg_searching.WorkerSupportsCancellation = true;
            this.bg_searching.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_searching_DoWork);
            this.bg_searching.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bg_searching_ProgressChanged);
            this.bg_searching.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_searching_RunWorkerCompleted);
            // 
            // pnl_folderloc
            // 
            this.pnl_folderloc.AutoScroll = true;
            this.pnl_folderloc.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl_folderloc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(150)))));
            this.pnl_folderloc.Location = new System.Drawing.Point(470, 439);
            this.pnl_folderloc.Name = "pnl_folderloc";
            this.pnl_folderloc.Size = new System.Drawing.Size(633, 162);
            this.pnl_folderloc.TabIndex = 20;
            // 
            // lbl_time_elapsed
            // 
            this.lbl_time_elapsed.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time_elapsed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(159)))));
            this.lbl_time_elapsed.Location = new System.Drawing.Point(1125, 440);
            this.lbl_time_elapsed.Name = "lbl_time_elapsed";
            this.lbl_time_elapsed.Size = new System.Drawing.Size(125, 56);
            this.lbl_time_elapsed.TabIndex = 21;
            this.lbl_time_elapsed.Text = "Time Elapsed:";
            // 
            // lbl_time_elapsed_detail
            // 
            this.lbl_time_elapsed_detail.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time_elapsed_detail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(159)))));
            this.lbl_time_elapsed_detail.Location = new System.Drawing.Point(1125, 496);
            this.lbl_time_elapsed_detail.Name = "lbl_time_elapsed_detail";
            this.lbl_time_elapsed_detail.Size = new System.Drawing.Size(125, 56);
            this.lbl_time_elapsed_detail.TabIndex = 22;
            this.lbl_time_elapsed_detail.Text = "None";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.lbl_time_elapsed_detail);
            this.Controls.Add(this.lbl_time_elapsed);
            this.Controls.Add(this.pnl_folderloc);
            this.Controls.Add(this.btn_interrupt);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.method_panel_group);
            this.Controls.Add(this.lbl_method);
            this.Controls.Add(this.cbox_alloccurence);
            this.Controls.Add(this.lbl_filename_title);
            this.Controls.Add(this.tbox_filename);
            this.Controls.Add(this.lbl_selecteddetail);
            this.Controls.Add(this.lbl_selectedstartfolder);
            this.Controls.Add(this.lbl_startingfolder);
            this.Controls.Add(this.btn_choosefolder);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.splitter4);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.gViewer1);
            this.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Folder Crawler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.method_panel_group.ResumeLayout(false);
            this.method_panel_group.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.FolderBrowserDialog folderbrowse_startingpoint;
        private System.Windows.Forms.Button btn_choosefolder;
        private System.Windows.Forms.Label lbl_startingfolder;
        private System.Windows.Forms.Label lbl_selectedstartfolder;
        private System.Windows.Forms.Label lbl_selecteddetail;
        private System.Windows.Forms.TextBox tbox_filename;
        private System.Windows.Forms.Label lbl_filename_title;
        private System.Windows.Forms.CheckBox cbox_alloccurence;
        private System.Windows.Forms.Label lbl_method;
        private System.Windows.Forms.Panel method_panel_group;
        private System.Windows.Forms.RadioButton radio_dfs;
        private System.Windows.Forms.RadioButton radio_bfs;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_interrupt;
        private System.ComponentModel.BackgroundWorker bg_searching;
        private System.Windows.Forms.Panel pnl_folderloc;
        private System.Windows.Forms.Label lbl_time_elapsed;
        private System.Windows.Forms.Label lbl_time_elapsed_detail;
    }
}

