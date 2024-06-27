using MpLib;
using System.Collections.Generic;
using System.ComponentModel;
namespace WindowsFormsApp2
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public static MpClass mpObj;
        public BindingList<Instrument> mInsList;
        public BindingList<Instrument> mConnectedInsList;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle68 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle69 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle70 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle71 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle72 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle73 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle74 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle67 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle75 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle76 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle77 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle78 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle79 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle80 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle81 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle82 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle83 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle84 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle85 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle86 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle87 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle88 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle89 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle90 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle91 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle92 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle93 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle94 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle95 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle96 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle97 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle98 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle99 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mean_process = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabcontrol_main = new System.Windows.Forms.TabControl();
            this.page_dev = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView_dev = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_dev_add = new System.Windows.Forms.Button();
            this.ConnectSA = new System.Windows.Forms.Button();
            this.btn_dev_connect = new System.Windows.Forms.Button();
            this.btn_dev_delete = new System.Windows.Forms.Button();
            this.panel_cam = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.btn_table_connect = new System.Windows.Forms.Button();
            this.btn_cam_connect = new System.Windows.Forms.Button();
            this.page_gnd = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.gnd_choose_theo = new System.Windows.Forms.Button();
            this.gnd_import = new System.Windows.Forms.Button();
            this.gnd_frame = new System.Windows.Forms.Button();
            this.label51 = new System.Windows.Forms.Label();
            this.text_gnd_mean = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.gnd_meansure = new System.Windows.Forms.Button();
            this.comboBox_gnd = new System.Windows.Forms.ComboBox();
            this.text_gnd_theo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView_gnd = new System.Windows.Forms.DataGridView();
            this.page_planeFrame = new System.Windows.Forms.TabPage();
            this.dataGridView_PF = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.text_pf_mean = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.plane_select_pointGroup = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.btn_plane = new System.Windows.Forms.Button();
            this.combox_planeFrame = new System.Windows.Forms.ComboBox();
            this.text_pf_theo = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.plane_import = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.page_radar = new System.Windows.Forms.TabPage();
            this.comboBox_sel_2 = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.comboBox_sel_1 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox_radar_devselect = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.panel_radar = new System.Windows.Forms.Panel();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.radar_z_error = new System.Windows.Forms.TextBox();
            this.radar_y_error = new System.Windows.Forms.TextBox();
            this.radar_x_error = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_radar_loc = new System.Windows.Forms.Button();
            this.page_dzz = new System.Windows.Forms.TabPage();
            this.btn_dzz_calcu_error = new System.Windows.Forms.Button();
            this.btn_import_dzz_std = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label55 = new System.Windows.Forms.Label();
            this.dzz_std = new System.Windows.Forms.ComboBox();
            this.dataGridView_dzz = new System.Windows.Forms.DataGridView();
            this.comboBox_dzz_devselect = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.dzz_target_select = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel_dzz = new System.Windows.Forms.Panel();
            this.btn_dzz_delete = new System.Windows.Forms.Button();
            this.btn_dzz_save = new System.Windows.Forms.Button();
            this.comboBox_dzz_devselected = new System.Windows.Forms.ComboBox();
            this.dzz_z_error = new System.Windows.Forms.TextBox();
            this.dzz_y_error = new System.Windows.Forms.TextBox();
            this.dzz_x_error = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_war_loc = new System.Windows.Forms.Button();
            this.btn_dzz_means = new System.Windows.Forms.Button();
            this.page_cni = new System.Windows.Forms.TabPage();
            this.cni_save = new System.Windows.Forms.Button();
            this.btn_cni_calcu_error = new System.Windows.Forms.Button();
            this.cni_std_ptsname = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.btn_import_cni_std = new System.Windows.Forms.Button();
            this.cni_means_ptsname = new System.Windows.Forms.ComboBox();
            this.dataGridView_cni = new System.Windows.Forms.DataGridView();
            this.cni_dev_select = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.cni_target_select = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel_cni = new System.Windows.Forms.Panel();
            this.btn_cni_delete = new System.Windows.Forms.Button();
            this.btn_cni_save = new System.Windows.Forms.Button();
            this.comboBox_cni_target_selected = new System.Windows.Forms.ComboBox();
            this.cni_z_error = new System.Windows.Forms.TextBox();
            this.cni_y_error = new System.Windows.Forms.TextBox();
            this.cni_x_error = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btn_cni_loc = new System.Windows.Forms.Button();
            this.btn_cni_means = new System.Windows.Forms.Button();
            this.page_px = new System.Windows.Forms.TabPage();
            this.px_save = new System.Windows.Forms.Button();
            this.panel_px = new System.Windows.Forms.Panel();
            this.btn_px_delete = new System.Windows.Forms.Button();
            this.btn_px_save = new System.Windows.Forms.Button();
            this.px_z_error = new System.Windows.Forms.TextBox();
            this.px_y_error = new System.Windows.Forms.TextBox();
            this.px_x_error = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.px_std_ptsname = new System.Windows.Forms.ComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.btn_import_px_std = new System.Windows.Forms.Button();
            this.px_means_ptsname = new System.Windows.Forms.ComboBox();
            this.dataGridView_px = new System.Windows.Forms.DataGridView();
            this.px_dev_select = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_px_test = new System.Windows.Forms.Button();
            this.btn_px_loc = new System.Windows.Forms.Button();
            this.btn_px_means = new System.Windows.Forms.Button();
            this.page_irs = new System.Windows.Forms.TabPage();
            this.irs_save = new System.Windows.Forms.Button();
            this.btn_irs_calcu_error = new System.Windows.Forms.Button();
            this.btn_import_irs_std = new System.Windows.Forms.Button();
            this.irs_means_ptsname = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.irs_std_ptsname = new System.Windows.Forms.ComboBox();
            this.dataGridView_irs = new System.Windows.Forms.DataGridView();
            this.irs_dev_select = new System.Windows.Forms.ComboBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.irs_target_select = new System.Windows.Forms.ComboBox();
            this.label61 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_irs_delete = new System.Windows.Forms.Button();
            this.btn_irs_save = new System.Windows.Forms.Button();
            this.irs_target_selected = new System.Windows.Forms.ComboBox();
            this.irs_z_error = new System.Windows.Forms.TextBox();
            this.irs_y_error = new System.Windows.Forms.TextBox();
            this.irs_x_error = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.btn_irs_loc = new System.Windows.Forms.Button();
            this.btn_irs_means = new System.Windows.Forms.Button();
            this.page_fcs = new System.Windows.Forms.TabPage();
            this.fcs_save = new System.Windows.Forms.Button();
            this.fcs_std_ptsname = new System.Windows.Forms.ComboBox();
            this.fcs_means_ptsname = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btn_import_fcs_std = new System.Windows.Forms.Button();
            this.dataGridView_fcs = new System.Windows.Forms.DataGridView();
            this.fcs_dev_select = new System.Windows.Forms.ComboBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.fcs_target_select = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.panel_fcs = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.btn_fcs_delete = new System.Windows.Forms.Button();
            this.btn_fcs_save = new System.Windows.Forms.Button();
            this.fcs_tartget_selected = new System.Windows.Forms.ComboBox();
            this.fcs_z_error = new System.Windows.Forms.TextBox();
            this.fcs_y_error = new System.Windows.Forms.TextBox();
            this.fcs_x_error = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.btn_fcs_calcu_error = new System.Windows.Forms.Button();
            this.btn_fcs_loc = new System.Windows.Forms.Button();
            this.btn_fcs_means = new System.Windows.Forms.Button();
            this.page_gd = new System.Windows.Forms.TabPage();
            this.gd_save = new System.Windows.Forms.Button();
            this.btn_import_gd_std = new System.Windows.Forms.Button();
            this.gd_std_ptsname = new System.Windows.Forms.ComboBox();
            this.gd_means_ptsname = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.dataGridView_gd = new System.Windows.Forms.DataGridView();
            this.gd_dev_select = new System.Windows.Forms.ComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.gd_target_select = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.panel_gd = new System.Windows.Forms.Panel();
            this.label35 = new System.Windows.Forms.Label();
            this.btn_gd_delete = new System.Windows.Forms.Button();
            this.btn_gd_save = new System.Windows.Forms.Button();
            this.gd_target_selected = new System.Windows.Forms.ComboBox();
            this.gd_z_error = new System.Windows.Forms.TextBox();
            this.gd_y_error = new System.Windows.Forms.TextBox();
            this.gd_x_error = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.btn_gd_calcu_error = new System.Windows.Forms.Button();
            this.btn_gd_loc = new System.Windows.Forms.Button();
            this.btn_gd_means = new System.Windows.Forms.Button();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn53 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn52 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.close_main = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.head_box = new System.Windows.Forms.PictureBox();
            this.btn_device = new System.Windows.Forms.Button();
            this.btn_ODA_radar = new System.Windows.Forms.Button();
            this.btn_FCS = new System.Windows.Forms.Button();
            this.btn_IRS = new System.Windows.Forms.Button();
            this.btn_disp_cont = new System.Windows.Forms.Button();
            this.btn_CNI = new System.Windows.Forms.Button();
            this.btn_elec_war = new System.Windows.Forms.Button();
            this.btn_radar = new System.Windows.Forms.Button();
            this.btn_plane_meansure = new System.Windows.Forms.Button();
            this.btn_gnd_meansure = new System.Windows.Forms.Button();
            this.tabcontrol_main.SuspendLayout();
            this.page_dev.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dev)).BeginInit();
            this.panel_cam.SuspendLayout();
            this.page_gnd.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_gnd)).BeginInit();
            this.page_planeFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PF)).BeginInit();
            this.panel2.SuspendLayout();
            this.page_radar.SuspendLayout();
            this.panel_radar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.page_dzz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dzz)).BeginInit();
            this.panel_dzz.SuspendLayout();
            this.page_cni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_cni)).BeginInit();
            this.panel_cni.SuspendLayout();
            this.page_px.SuspendLayout();
            this.panel_px.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_px)).BeginInit();
            this.page_irs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_irs)).BeginInit();
            this.panel1.SuspendLayout();
            this.page_fcs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_fcs)).BeginInit();
            this.panel_fcs.SuspendLayout();
            this.page_gd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_gd)).BeginInit();
            this.panel_gd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.head_box)).BeginInit();
            this.SuspendLayout();
            // 
            // mean_process
            // 
            this.mean_process.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mean_process.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.mean_process.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mean_process.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.mean_process.Location = new System.Drawing.Point(376, 676);
            this.mean_process.Name = "mean_process";
            this.mean_process.Size = new System.Drawing.Size(337, 274);
            this.mean_process.TabIndex = 14;
            this.mean_process.TabStop = false;
            this.mean_process.Text = "测量进程";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(215)))), ((int)(((byte)(245)))));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 27);
            this.label1.TabIndex = 24;
            this.label1.Text = "激光雷达全机水平测量及校靶系统";
            // 
            // tabcontrol_main
            // 
            this.tabcontrol_main.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabcontrol_main.Controls.Add(this.page_dev);
            this.tabcontrol_main.Controls.Add(this.page_gnd);
            this.tabcontrol_main.Controls.Add(this.page_planeFrame);
            this.tabcontrol_main.Controls.Add(this.tabPage1);
            this.tabcontrol_main.Controls.Add(this.page_radar);
            this.tabcontrol_main.Controls.Add(this.page_dzz);
            this.tabcontrol_main.Controls.Add(this.page_cni);
            this.tabcontrol_main.Controls.Add(this.page_px);
            this.tabcontrol_main.Controls.Add(this.page_irs);
            this.tabcontrol_main.Controls.Add(this.page_fcs);
            this.tabcontrol_main.Controls.Add(this.page_gd);
            this.tabcontrol_main.HotTrack = true;
            this.tabcontrol_main.Location = new System.Drawing.Point(753, 107);
            this.tabcontrol_main.Multiline = true;
            this.tabcontrol_main.Name = "tabcontrol_main";
            this.tabcontrol_main.SelectedIndex = 0;
            this.tabcontrol_main.ShowToolTips = true;
            this.tabcontrol_main.Size = new System.Drawing.Size(1118, 847);
            this.tabcontrol_main.TabIndex = 26;
            this.tabcontrol_main.TabStop = false;
            // 
            // page_dev
            // 
            this.page_dev.AutoScroll = true;
            this.page_dev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.page_dev.Controls.Add(this.panel4);
            this.page_dev.Controls.Add(this.panel_cam);
            this.page_dev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.page_dev.Location = new System.Drawing.Point(4, 22);
            this.page_dev.Name = "page_dev";
            this.page_dev.Padding = new System.Windows.Forms.Padding(3);
            this.page_dev.Size = new System.Drawing.Size(1110, 821);
            this.page_dev.TabIndex = 0;
            this.page_dev.Text = "设备";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView_dev);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.btn_dev_add);
            this.panel4.Controls.Add(this.ConnectSA);
            this.panel4.Controls.Add(this.btn_dev_connect);
            this.panel4.Controls.Add(this.btn_dev_delete);
            this.panel4.Location = new System.Drawing.Point(6, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(758, 459);
            this.panel4.TabIndex = 18;
            // 
            // dataGridView_dev
            // 
            this.dataGridView_dev.AllowUserToAddRows = false;
            this.dataGridView_dev.AllowUserToDeleteRows = false;
            this.dataGridView_dev.AllowUserToResizeColumns = false;
            this.dataGridView_dev.AllowUserToResizeRows = false;
            this.dataGridView_dev.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.dataGridView_dev.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_dev.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle68.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(54)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle68.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle68.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle68.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle68.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle68.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_dev.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle68;
            this.dataGridView_dev.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle69.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle69.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle69.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle69.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle69.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle69.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_dev.DefaultCellStyle = dataGridViewCellStyle69;
            this.dataGridView_dev.EnableHeadersVisualStyles = false;
            this.dataGridView_dev.Location = new System.Drawing.Point(42, 129);
            this.dataGridView_dev.Name = "dataGridView_dev";
            this.dataGridView_dev.ReadOnly = true;
            this.dataGridView_dev.RowHeadersWidth = 62;
            this.dataGridView_dev.RowTemplate.Height = 30;
            this.dataGridView_dev.Size = new System.Drawing.Size(571, 228);
            this.dataGridView_dev.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(39, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 17;
            this.label12.Text = "可用的仪器列表";
            // 
            // btn_dev_add
            // 
            this.btn_dev_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_dev_add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_dev_add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_dev_add.Location = new System.Drawing.Point(42, 378);
            this.btn_dev_add.Name = "btn_dev_add";
            this.btn_dev_add.Size = new System.Drawing.Size(163, 56);
            this.btn_dev_add.TabIndex = 10;
            this.btn_dev_add.Text = "添加仪器";
            this.btn_dev_add.UseVisualStyleBackColor = false;
            this.btn_dev_add.Click += new System.EventHandler(this.btn_dev_add_Click);
            // 
            // ConnectSA
            // 
            this.ConnectSA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.ConnectSA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ConnectSA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.ConnectSA.Location = new System.Drawing.Point(42, 28);
            this.ConnectSA.Name = "ConnectSA";
            this.ConnectSA.Size = new System.Drawing.Size(163, 41);
            this.ConnectSA.TabIndex = 16;
            this.ConnectSA.Text = "连接SA";
            this.ConnectSA.UseVisualStyleBackColor = false;
            this.ConnectSA.Click += new System.EventHandler(this.ConnectSA_Click);
            // 
            // btn_dev_connect
            // 
            this.btn_dev_connect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_dev_connect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_dev_connect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_dev_connect.Location = new System.Drawing.Point(450, 378);
            this.btn_dev_connect.Name = "btn_dev_connect";
            this.btn_dev_connect.Size = new System.Drawing.Size(163, 56);
            this.btn_dev_connect.TabIndex = 11;
            this.btn_dev_connect.Text = "连接仪器";
            this.btn_dev_connect.UseVisualStyleBackColor = false;
            this.btn_dev_connect.Click += new System.EventHandler(this.btn_dev_connect_Click);
            // 
            // btn_dev_delete
            // 
            this.btn_dev_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_dev_delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_dev_delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_dev_delete.Location = new System.Drawing.Point(248, 378);
            this.btn_dev_delete.Name = "btn_dev_delete";
            this.btn_dev_delete.Size = new System.Drawing.Size(163, 56);
            this.btn_dev_delete.TabIndex = 15;
            this.btn_dev_delete.Text = "删除仪器";
            this.btn_dev_delete.UseVisualStyleBackColor = false;
            this.btn_dev_delete.Click += new System.EventHandler(this.btn_dev_delete_Click);
            // 
            // panel_cam
            // 
            this.panel_cam.Controls.Add(this.button6);
            this.panel_cam.Controls.Add(this.btn_table_connect);
            this.panel_cam.Controls.Add(this.btn_cam_connect);
            this.panel_cam.Location = new System.Drawing.Point(6, 476);
            this.panel_cam.Name = "panel_cam";
            this.panel_cam.Size = new System.Drawing.Size(758, 333);
            this.panel_cam.TabIndex = 12;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.button6.Location = new System.Drawing.Point(42, 225);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(143, 39);
            this.button6.TabIndex = 13;
            this.button6.Text = "断开转台";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btn_table_connect
            // 
            this.btn_table_connect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_table_connect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_table_connect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_table_connect.Location = new System.Drawing.Point(41, 140);
            this.btn_table_connect.Name = "btn_table_connect";
            this.btn_table_connect.Size = new System.Drawing.Size(143, 39);
            this.btn_table_connect.TabIndex = 12;
            this.btn_table_connect.Text = "连接转台";
            this.btn_table_connect.UseVisualStyleBackColor = false;
            this.btn_table_connect.Click += new System.EventHandler(this.btn_table_connect_Click);
            // 
            // btn_cam_connect
            // 
            this.btn_cam_connect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_cam_connect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_cam_connect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_cam_connect.Location = new System.Drawing.Point(42, 49);
            this.btn_cam_connect.Name = "btn_cam_connect";
            this.btn_cam_connect.Size = new System.Drawing.Size(143, 39);
            this.btn_cam_connect.TabIndex = 11;
            this.btn_cam_connect.Text = "连接相机";
            this.btn_cam_connect.UseVisualStyleBackColor = false;
            this.btn_cam_connect.Click += new System.EventHandler(this.btn_cam_connect_Click);
            // 
            // page_gnd
            // 
            this.page_gnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.page_gnd.Controls.Add(this.panel3);
            this.page_gnd.Controls.Add(this.dataGridView_gnd);
            this.page_gnd.Location = new System.Drawing.Point(4, 22);
            this.page_gnd.Name = "page_gnd";
            this.page_gnd.Padding = new System.Windows.Forms.Padding(3);
            this.page_gnd.Size = new System.Drawing.Size(1110, 821);
            this.page_gnd.TabIndex = 13;
            this.page_gnd.Text = "地面坐标系建立";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.gnd_choose_theo);
            this.panel3.Controls.Add(this.gnd_import);
            this.panel3.Controls.Add(this.gnd_frame);
            this.panel3.Controls.Add(this.label51);
            this.panel3.Controls.Add(this.text_gnd_mean);
            this.panel3.Controls.Add(this.label47);
            this.panel3.Controls.Add(this.gnd_meansure);
            this.panel3.Controls.Add(this.comboBox_gnd);
            this.panel3.Controls.Add(this.text_gnd_theo);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Location = new System.Drawing.Point(20, 14);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(778, 295);
            this.panel3.TabIndex = 30;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("宋体", 9F);
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.button4.Location = new System.Drawing.Point(524, 43);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(188, 37);
            this.button4.TabIndex = 36;
            this.button4.Text = "设备转站";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // gnd_choose_theo
            // 
            this.gnd_choose_theo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.gnd_choose_theo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gnd_choose_theo.Font = new System.Drawing.Font("宋体", 9F);
            this.gnd_choose_theo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.gnd_choose_theo.Location = new System.Drawing.Point(524, 117);
            this.gnd_choose_theo.Name = "gnd_choose_theo";
            this.gnd_choose_theo.Size = new System.Drawing.Size(188, 37);
            this.gnd_choose_theo.TabIndex = 35;
            this.gnd_choose_theo.Text = "选择理论点组";
            this.gnd_choose_theo.UseVisualStyleBackColor = false;
            this.gnd_choose_theo.Click += new System.EventHandler(this.gnd_choose_theo_Click);
            // 
            // gnd_import
            // 
            this.gnd_import.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.gnd_import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gnd_import.Font = new System.Drawing.Font("宋体", 9F);
            this.gnd_import.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.gnd_import.Location = new System.Drawing.Point(306, 117);
            this.gnd_import.Name = "gnd_import";
            this.gnd_import.Size = new System.Drawing.Size(188, 37);
            this.gnd_import.TabIndex = 34;
            this.gnd_import.Text = "地面基准测量（首次）";
            this.gnd_import.UseVisualStyleBackColor = false;
            this.gnd_import.Click += new System.EventHandler(this.gnd_import_Click);
            // 
            // gnd_frame
            // 
            this.gnd_frame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.gnd_frame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gnd_frame.Font = new System.Drawing.Font("宋体", 9F);
            this.gnd_frame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.gnd_frame.Location = new System.Drawing.Point(524, 176);
            this.gnd_frame.Name = "gnd_frame";
            this.gnd_frame.Size = new System.Drawing.Size(188, 39);
            this.gnd_frame.TabIndex = 33;
            this.gnd_frame.Text = "地面坐标系建立";
            this.gnd_frame.UseVisualStyleBackColor = false;
            this.gnd_frame.Click += new System.EventHandler(this.gnd_frame_Click);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label51.Location = new System.Drawing.Point(17, 179);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(77, 12);
            this.label51.TabIndex = 32;
            this.label51.Text = "地面测量点组";
            // 
            // text_gnd_mean
            // 
            this.text_gnd_mean.Font = new System.Drawing.Font("宋体", 9F);
            this.text_gnd_mean.Location = new System.Drawing.Point(143, 176);
            this.text_gnd_mean.Name = "text_gnd_mean";
            this.text_gnd_mean.Size = new System.Drawing.Size(138, 21);
            this.text_gnd_mean.TabIndex = 31;
            this.text_gnd_mean.Text = "A::地面测量点";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label47.Location = new System.Drawing.Point(17, 120);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(77, 12);
            this.label47.TabIndex = 30;
            this.label47.Text = "地面参考点组";
            // 
            // gnd_meansure
            // 
            this.gnd_meansure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.gnd_meansure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gnd_meansure.Font = new System.Drawing.Font("宋体", 9F);
            this.gnd_meansure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.gnd_meansure.Location = new System.Drawing.Point(306, 176);
            this.gnd_meansure.Name = "gnd_meansure";
            this.gnd_meansure.Size = new System.Drawing.Size(188, 39);
            this.gnd_meansure.TabIndex = 26;
            this.gnd_meansure.Text = "地面靶球测量";
            this.gnd_meansure.UseVisualStyleBackColor = false;
            this.gnd_meansure.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox_gnd
            // 
            this.comboBox_gnd.Font = new System.Drawing.Font("宋体", 12F);
            this.comboBox_gnd.FormattingEnabled = true;
            this.comboBox_gnd.Location = new System.Drawing.Point(240, 43);
            this.comboBox_gnd.Name = "comboBox_gnd";
            this.comboBox_gnd.Size = new System.Drawing.Size(196, 24);
            this.comboBox_gnd.TabIndex = 22;
            this.comboBox_gnd.SelectedIndexChanged += new System.EventHandler(this.comboBox_gnd_SelectedIndexChanged);
            // 
            // text_gnd_theo
            // 
            this.text_gnd_theo.Font = new System.Drawing.Font("宋体", 9F);
            this.text_gnd_theo.Location = new System.Drawing.Point(143, 117);
            this.text_gnd_theo.Name = "text_gnd_theo";
            this.text_gnd_theo.Size = new System.Drawing.Size(138, 21);
            this.text_gnd_theo.TabIndex = 28;
            this.text_gnd_theo.Text = "A::地面基准点";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F);
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(53, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 23;
            this.label11.Text = "选择跟踪仪";
            // 
            // dataGridView_gnd
            // 
            this.dataGridView_gnd.AllowUserToAddRows = false;
            this.dataGridView_gnd.AllowUserToDeleteRows = false;
            this.dataGridView_gnd.AllowUserToResizeColumns = false;
            this.dataGridView_gnd.AllowUserToResizeRows = false;
            dataGridViewCellStyle70.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle70.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle70.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView_gnd.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle70;
            this.dataGridView_gnd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_gnd.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.dataGridView_gnd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_gnd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle71.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle71.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle71.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(195)))), ((int)(((byte)(197)))));
            dataGridViewCellStyle71.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle71.SelectionForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle71.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_gnd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle71;
            this.dataGridView_gnd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle72.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle72.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle72.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle72.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle72.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle72.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_gnd.DefaultCellStyle = dataGridViewCellStyle72;
            this.dataGridView_gnd.EnableHeadersVisualStyles = false;
            this.dataGridView_gnd.Location = new System.Drawing.Point(20, 333);
            this.dataGridView_gnd.MultiSelect = false;
            this.dataGridView_gnd.Name = "dataGridView_gnd";
            this.dataGridView_gnd.ReadOnly = true;
            dataGridViewCellStyle73.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle73.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle73.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle73.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle73.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle73.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle73.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_gnd.RowHeadersDefaultCellStyle = dataGridViewCellStyle73;
            this.dataGridView_gnd.RowHeadersVisible = false;
            this.dataGridView_gnd.RowHeadersWidth = 62;
            dataGridViewCellStyle74.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle74.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle74.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView_gnd.RowsDefaultCellStyle = dataGridViewCellStyle74;
            this.dataGridView_gnd.RowTemplate.Height = 30;
            this.dataGridView_gnd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_gnd.Size = new System.Drawing.Size(778, 454);
            this.dataGridView_gnd.TabIndex = 24;
            // 
            // page_planeFrame
            // 
            this.page_planeFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.page_planeFrame.Controls.Add(this.dataGridView_PF);
            this.page_planeFrame.Controls.Add(this.panel2);
            this.page_planeFrame.Location = new System.Drawing.Point(4, 22);
            this.page_planeFrame.Name = "page_planeFrame";
            this.page_planeFrame.Padding = new System.Windows.Forms.Padding(3);
            this.page_planeFrame.Size = new System.Drawing.Size(1110, 821);
            this.page_planeFrame.TabIndex = 1;
            this.page_planeFrame.Text = "建立飞机坐标系";
            // 
            // dataGridView_PF
            // 
            this.dataGridView_PF.AllowUserToAddRows = false;
            this.dataGridView_PF.AllowUserToDeleteRows = false;
            this.dataGridView_PF.AllowUserToResizeColumns = false;
            this.dataGridView_PF.AllowUserToResizeRows = false;
            this.dataGridView_PF.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_PF.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.dataGridView_PF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_PF.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle67.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle67.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle67.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle67.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle67.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle67.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_PF.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle67;
            this.dataGridView_PF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PF.DefaultCellStyle = dataGridViewCellStyle67;
            this.dataGridView_PF.EnableHeadersVisualStyles = false;
            this.dataGridView_PF.Location = new System.Drawing.Point(24, 298);
            this.dataGridView_PF.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_PF.Name = "dataGridView_PF";
            this.dataGridView_PF.ReadOnly = true;
            this.dataGridView_PF.RowHeadersDefaultCellStyle = dataGridViewCellStyle67;
            this.dataGridView_PF.RowHeadersVisible = false;
            this.dataGridView_PF.RowHeadersWidth = 62;
            this.dataGridView_PF.RowsDefaultCellStyle = dataGridViewCellStyle67;
            this.dataGridView_PF.RowTemplate.Height = 30;
            this.dataGridView_PF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_PF.Size = new System.Drawing.Size(774, 488);
            this.dataGridView_PF.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.text_pf_mean);
            this.panel2.Controls.Add(this.label50);
            this.panel2.Controls.Add(this.plane_select_pointGroup);
            this.panel2.Controls.Add(this.label42);
            this.panel2.Controls.Add(this.btn_plane);
            this.panel2.Controls.Add(this.combox_planeFrame);
            this.panel2.Controls.Add(this.text_pf_theo);
            this.panel2.Controls.Add(this.label66);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.plane_import);
            this.panel2.Location = new System.Drawing.Point(24, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(774, 278);
            this.panel2.TabIndex = 32;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(59, 202);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(183, 45);
            this.button7.TabIndex = 28;
            this.button7.Text = "手动对准A::TEST::A1";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("宋体", 9F);
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.button5.Location = new System.Drawing.Point(515, 31);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(185, 37);
            this.button5.TabIndex = 37;
            this.button5.Text = "设备转站";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // text_pf_mean
            // 
            this.text_pf_mean.Font = new System.Drawing.Font("宋体", 9F);
            this.text_pf_mean.Location = new System.Drawing.Point(132, 154);
            this.text_pf_mean.Name = "text_pf_mean";
            this.text_pf_mean.Size = new System.Drawing.Size(134, 21);
            this.text_pf_mean.TabIndex = 35;
            this.text_pf_mean.Text = "A::飞机测量点";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label50.Location = new System.Drawing.Point(27, 157);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(53, 12);
            this.label50.TabIndex = 34;
            this.label50.Text = "测量点组";
            // 
            // plane_select_pointGroup
            // 
            this.plane_select_pointGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.plane_select_pointGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.plane_select_pointGroup.Font = new System.Drawing.Font("宋体", 9F);
            this.plane_select_pointGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.plane_select_pointGroup.Location = new System.Drawing.Point(515, 94);
            this.plane_select_pointGroup.Name = "plane_select_pointGroup";
            this.plane_select_pointGroup.Size = new System.Drawing.Size(185, 37);
            this.plane_select_pointGroup.TabIndex = 33;
            this.plane_select_pointGroup.Text = "选择理论点组";
            this.plane_select_pointGroup.UseVisualStyleBackColor = false;
            this.plane_select_pointGroup.Click += new System.EventHandler(this.plane_select_pointGroup_Click);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label42.Location = new System.Drawing.Point(27, 97);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(53, 12);
            this.label42.TabIndex = 32;
            this.label42.Text = "理论点组";
            // 
            // btn_plane
            // 
            this.btn_plane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_plane.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_plane.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_plane.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_plane.Location = new System.Drawing.Point(307, 157);
            this.btn_plane.Name = "btn_plane";
            this.btn_plane.Size = new System.Drawing.Size(185, 36);
            this.btn_plane.TabIndex = 13;
            this.btn_plane.Text = "飞机靶点测量";
            this.btn_plane.UseVisualStyleBackColor = false;
            this.btn_plane.Click += new System.EventHandler(this.btn_plane_Click);
            // 
            // combox_planeFrame
            // 
            this.combox_planeFrame.Font = new System.Drawing.Font("宋体", 9F);
            this.combox_planeFrame.FormattingEnabled = true;
            this.combox_planeFrame.Location = new System.Drawing.Point(231, 36);
            this.combox_planeFrame.Name = "combox_planeFrame";
            this.combox_planeFrame.Size = new System.Drawing.Size(225, 20);
            this.combox_planeFrame.TabIndex = 20;
            this.combox_planeFrame.SelectedIndexChanged += new System.EventHandler(this.combSelTracker_SelectedIndexChanged);
            // 
            // text_pf_theo
            // 
            this.text_pf_theo.Font = new System.Drawing.Font("宋体", 9F);
            this.text_pf_theo.Location = new System.Drawing.Point(132, 94);
            this.text_pf_theo.Name = "text_pf_theo";
            this.text_pf_theo.Size = new System.Drawing.Size(134, 21);
            this.text_pf_theo.TabIndex = 30;
            this.text_pf_theo.Text = "A::飞机基准点";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("宋体", 12F);
            this.label66.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label66.Location = new System.Drawing.Point(65, 39);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(87, 16);
            this.label66.TabIndex = 21;
            this.label66.Text = "选择跟踪仪";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 9F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.button1.Location = new System.Drawing.Point(515, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 36);
            this.button1.TabIndex = 23;
            this.button1.Text = "建立飞机坐标系";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // plane_import
            // 
            this.plane_import.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.plane_import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.plane_import.Font = new System.Drawing.Font("宋体", 9F);
            this.plane_import.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.plane_import.Location = new System.Drawing.Point(307, 94);
            this.plane_import.Name = "plane_import";
            this.plane_import.Size = new System.Drawing.Size(185, 37);
            this.plane_import.TabIndex = 22;
            this.plane_import.Text = "导入基准点数据";
            this.plane_import.UseVisualStyleBackColor = false;
            this.plane_import.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1110, 821);
            this.tabPage1.TabIndex = 14;
            this.tabPage1.Text = "全机水平测量";
            // 
            // page_radar
            // 
            this.page_radar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.page_radar.Controls.Add(this.comboBox_sel_2);
            this.page_radar.Controls.Add(this.label36);
            this.page_radar.Controls.Add(this.comboBox_sel_1);
            this.page_radar.Controls.Add(this.label13);
            this.page_radar.Controls.Add(this.button3);
            this.page_radar.Controls.Add(this.button2);
            this.page_radar.Controls.Add(this.comboBox_radar_devselect);
            this.page_radar.Controls.Add(this.label43);
            this.page_radar.Controls.Add(this.panel_radar);
            this.page_radar.Controls.Add(this.btn_radar_loc);
            this.page_radar.Location = new System.Drawing.Point(4, 22);
            this.page_radar.Name = "page_radar";
            this.page_radar.Padding = new System.Windows.Forms.Padding(3);
            this.page_radar.Size = new System.Drawing.Size(1110, 821);
            this.page_radar.TabIndex = 3;
            this.page_radar.Text = "雷达";
            // 
            // comboBox_sel_2
            // 
            this.comboBox_sel_2.FormattingEnabled = true;
            this.comboBox_sel_2.Items.AddRange(new object[] {
            ""});
            this.comboBox_sel_2.Location = new System.Drawing.Point(158, 111);
            this.comboBox_sel_2.Name = "comboBox_sel_2";
            this.comboBox_sel_2.Size = new System.Drawing.Size(230, 20);
            this.comboBox_sel_2.TabIndex = 3;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label36.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label36.Location = new System.Drawing.Point(41, 111);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(103, 16);
            this.label36.TabIndex = 32;
            this.label36.Text = "选择待测设备";
            // 
            // comboBox_sel_1
            // 
            this.comboBox_sel_1.FormattingEnabled = true;
            this.comboBox_sel_1.Items.AddRange(new object[] {
            "雷达系统",
            "电子战系统",
            "CNI子系统",
            "平显系统",
            "惯性参考系统",
            "飞控系统",
            "光电分布式孔径雷达"});
            this.comboBox_sel_1.Location = new System.Drawing.Point(158, 69);
            this.comboBox_sel_1.Name = "comboBox_sel_1";
            this.comboBox_sel_1.Size = new System.Drawing.Size(230, 20);
            this.comboBox_sel_1.TabIndex = 2;
            this.comboBox_sel_1.SelectedIndexChanged += new System.EventHandler(this.comboBox_sel_1_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.Location = new System.Drawing.Point(41, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 16);
            this.label13.TabIndex = 30;
            this.label13.Text = "选择测量项目";
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.button3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Location = new System.Drawing.Point(676, 159);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(208, 40);
            this.button3.TabIndex = 6;
            this.button3.Text = "扫描并拟合";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.button2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(434, 159);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 40);
            this.button2.TabIndex = 5;
            this.button2.Text = "选择扫描面";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // comboBox_radar_devselect
            // 
            this.comboBox_radar_devselect.FormattingEnabled = true;
            this.comboBox_radar_devselect.Items.AddRange(new object[] {
            ""});
            this.comboBox_radar_devselect.Location = new System.Drawing.Point(158, 28);
            this.comboBox_radar_devselect.Name = "comboBox_radar_devselect";
            this.comboBox_radar_devselect.Size = new System.Drawing.Size(230, 20);
            this.comboBox_radar_devselect.TabIndex = 1;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label43.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label43.Location = new System.Drawing.Point(41, 28);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(71, 16);
            this.label43.TabIndex = 22;
            this.label43.Text = "设备选择";
            // 
            // panel_radar
            // 
            this.panel_radar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_radar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.panel_radar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_radar.Controls.Add(this.trackBar3);
            this.panel_radar.Controls.Add(this.pictureBox4);
            this.panel_radar.Controls.Add(this.trackBar2);
            this.panel_radar.Controls.Add(this.pictureBox3);
            this.panel_radar.Controls.Add(this.trackBar1);
            this.panel_radar.Controls.Add(this.pictureBox2);
            this.panel_radar.Controls.Add(this.radar_z_error);
            this.panel_radar.Controls.Add(this.radar_y_error);
            this.panel_radar.Controls.Add(this.radar_x_error);
            this.panel_radar.Controls.Add(this.label6);
            this.panel_radar.Controls.Add(this.label5);
            this.panel_radar.Controls.Add(this.label4);
            this.panel_radar.Controls.Add(this.label3);
            this.panel_radar.Location = new System.Drawing.Point(195, 224);
            this.panel_radar.Name = "panel_radar";
            this.panel_radar.Size = new System.Drawing.Size(593, 493);
            this.panel_radar.TabIndex = 5;
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(211, 336);
            this.trackBar3.Maximum = 2000;
            this.trackBar3.Minimum = -2000;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(228, 45);
            this.trackBar3.TabIndex = 12;
            this.trackBar3.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(211, 387);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(228, 33);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(211, 200);
            this.trackBar2.Maximum = 2000;
            this.trackBar2.Minimum = -2000;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(228, 45);
            this.trackBar2.TabIndex = 10;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(211, 251);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(228, 33);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(211, 62);
            this.trackBar1.Maximum = 2000;
            this.trackBar1.Minimum = -2000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(228, 45);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(211, 113);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(228, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // radar_z_error
            // 
            this.radar_z_error.BackColor = System.Drawing.SystemColors.Window;
            this.radar_z_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.radar_z_error.Location = new System.Drawing.Point(48, 368);
            this.radar_z_error.Name = "radar_z_error";
            this.radar_z_error.Size = new System.Drawing.Size(106, 21);
            this.radar_z_error.TabIndex = 6;
            this.radar_z_error.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.radar_z_error.TextChanged += new System.EventHandler(this.radar_z_error_TextChanged);
            // 
            // radar_y_error
            // 
            this.radar_y_error.BackColor = System.Drawing.SystemColors.Window;
            this.radar_y_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.radar_y_error.Location = new System.Drawing.Point(48, 244);
            this.radar_y_error.Name = "radar_y_error";
            this.radar_y_error.Size = new System.Drawing.Size(106, 21);
            this.radar_y_error.TabIndex = 5;
            this.radar_y_error.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.radar_y_error.TextChanged += new System.EventHandler(this.radar_y_error_TextChanged);
            // 
            // radar_x_error
            // 
            this.radar_x_error.BackColor = System.Drawing.SystemColors.Window;
            this.radar_x_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.radar_x_error.Location = new System.Drawing.Point(48, 113);
            this.radar_x_error.Name = "radar_x_error";
            this.radar_x_error.Size = new System.Drawing.Size(106, 21);
            this.radar_x_error.TabIndex = 4;
            this.radar_x_error.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.radar_x_error.TextChanged += new System.EventHandler(this.radar_x_error_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("宋体", 12F);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(63, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "X向偏差";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(63, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Y向偏差";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(63, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Z向偏差";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(26, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "角度偏差";
            // 
            // btn_radar_loc
            // 
            this.btn_radar_loc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_radar_loc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_radar_loc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_radar_loc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_radar_loc.Location = new System.Drawing.Point(193, 159);
            this.btn_radar_loc.Name = "btn_radar_loc";
            this.btn_radar_loc.Size = new System.Drawing.Size(200, 40);
            this.btn_radar_loc.TabIndex = 4;
            this.btn_radar_loc.Text = "设备转站";
            this.btn_radar_loc.UseVisualStyleBackColor = false;
            this.btn_radar_loc.Click += new System.EventHandler(this.btn_radar_loc_Click);
            // 
            // page_dzz
            // 
            this.page_dzz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.page_dzz.Controls.Add(this.btn_dzz_calcu_error);
            this.page_dzz.Controls.Add(this.btn_import_dzz_std);
            this.page_dzz.Controls.Add(this.comboBox2);
            this.page_dzz.Controls.Add(this.label55);
            this.page_dzz.Controls.Add(this.dzz_std);
            this.page_dzz.Controls.Add(this.dataGridView_dzz);
            this.page_dzz.Controls.Add(this.comboBox_dzz_devselect);
            this.page_dzz.Controls.Add(this.label44);
            this.page_dzz.Controls.Add(this.label37);
            this.page_dzz.Controls.Add(this.dzz_target_select);
            this.page_dzz.Controls.Add(this.label15);
            this.page_dzz.Controls.Add(this.panel_dzz);
            this.page_dzz.Controls.Add(this.btn_war_loc);
            this.page_dzz.Controls.Add(this.btn_dzz_means);
            this.page_dzz.Location = new System.Drawing.Point(4, 22);
            this.page_dzz.Name = "page_dzz";
            this.page_dzz.Padding = new System.Windows.Forms.Padding(3);
            this.page_dzz.Size = new System.Drawing.Size(1110, 821);
            this.page_dzz.TabIndex = 4;
            this.page_dzz.Text = "电子战";
            // 
            // btn_dzz_calcu_error
            // 
            this.btn_dzz_calcu_error.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_dzz_calcu_error.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_dzz_calcu_error.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_dzz_calcu_error.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_dzz_calcu_error.Location = new System.Drawing.Point(423, 463);
            this.btn_dzz_calcu_error.Name = "btn_dzz_calcu_error";
            this.btn_dzz_calcu_error.Size = new System.Drawing.Size(200, 40);
            this.btn_dzz_calcu_error.TabIndex = 29;
            this.btn_dzz_calcu_error.Text = "计算测量误差";
            this.btn_dzz_calcu_error.UseVisualStyleBackColor = false;
            // 
            // btn_import_dzz_std
            // 
            this.btn_import_dzz_std.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_import_dzz_std.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_import_dzz_std.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_import_dzz_std.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_import_dzz_std.Location = new System.Drawing.Point(413, 74);
            this.btn_import_dzz_std.Name = "btn_import_dzz_std";
            this.btn_import_dzz_std.Size = new System.Drawing.Size(187, 38);
            this.btn_import_dzz_std.TabIndex = 28;
            this.btn_import_dzz_std.Text = "导入理论值";
            this.btn_import_dzz_std.UseVisualStyleBackColor = false;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            ""});
            this.comboBox2.Location = new System.Drawing.Point(252, 186);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(230, 20);
            this.comboBox2.TabIndex = 27;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label55.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label55.Location = new System.Drawing.Point(25, 190);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(103, 16);
            this.label55.TabIndex = 26;
            this.label55.Text = "天线测量点集";
            // 
            // dzz_std
            // 
            this.dzz_std.FormattingEnabled = true;
            this.dzz_std.Items.AddRange(new object[] {
            ""});
            this.dzz_std.Location = new System.Drawing.Point(252, 153);
            this.dzz_std.Name = "dzz_std";
            this.dzz_std.Size = new System.Drawing.Size(230, 20);
            this.dzz_std.TabIndex = 25;
            // 
            // dataGridView_dzz
            // 
            this.dataGridView_dzz.AllowUserToAddRows = false;
            this.dataGridView_dzz.AllowUserToDeleteRows = false;
            this.dataGridView_dzz.AllowUserToResizeColumns = false;
            this.dataGridView_dzz.AllowUserToResizeRows = false;
            this.dataGridView_dzz.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.dataGridView_dzz.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_dzz.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle75.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle75.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle75.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(195)))), ((int)(((byte)(197)))));
            dataGridViewCellStyle75.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle75.SelectionForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle75.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_dzz.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle75;
            this.dataGridView_dzz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle76.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle76.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle76.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle76.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle76.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle76.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_dzz.DefaultCellStyle = dataGridViewCellStyle76;
            this.dataGridView_dzz.EnableHeadersVisualStyles = false;
            this.dataGridView_dzz.Location = new System.Drawing.Point(19, 218);
            this.dataGridView_dzz.Name = "dataGridView_dzz";
            this.dataGridView_dzz.ReadOnly = true;
            dataGridViewCellStyle77.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle77.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle77.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle77.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle77.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle77.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle77.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_dzz.RowHeadersDefaultCellStyle = dataGridViewCellStyle77;
            this.dataGridView_dzz.RowHeadersVisible = false;
            this.dataGridView_dzz.RowHeadersWidth = 62;
            dataGridViewCellStyle78.BackColor = System.Drawing.Color.Transparent;
            this.dataGridView_dzz.RowsDefaultCellStyle = dataGridViewCellStyle78;
            this.dataGridView_dzz.RowTemplate.Height = 30;
            this.dataGridView_dzz.Size = new System.Drawing.Size(709, 224);
            this.dataGridView_dzz.TabIndex = 24;
            // 
            // comboBox_dzz_devselect
            // 
            this.comboBox_dzz_devselect.FormattingEnabled = true;
            this.comboBox_dzz_devselect.Items.AddRange(new object[] {
            ""});
            this.comboBox_dzz_devselect.Location = new System.Drawing.Point(252, 20);
            this.comboBox_dzz_devselect.Name = "comboBox_dzz_devselect";
            this.comboBox_dzz_devselect.Size = new System.Drawing.Size(230, 20);
            this.comboBox_dzz_devselect.TabIndex = 23;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label44.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label44.Location = new System.Drawing.Point(24, 22);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(71, 16);
            this.label44.TabIndex = 22;
            this.label44.Text = "设备选择";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label37.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label37.Location = new System.Drawing.Point(25, 157);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(103, 16);
            this.label37.TabIndex = 18;
            this.label37.Text = "天线标准点集";
            // 
            // dzz_target_select
            // 
            this.dzz_target_select.FormattingEnabled = true;
            this.dzz_target_select.Items.AddRange(new object[] {
            "前向ESM天线",
            "前向ECM天线",
            "后向ESM天线",
            "后向ECM天线",
            "俯仰天线"});
            this.dzz_target_select.Location = new System.Drawing.Point(252, 122);
            this.dzz_target_select.Name = "dzz_target_select";
            this.dzz_target_select.Size = new System.Drawing.Size(230, 20);
            this.dzz_target_select.TabIndex = 13;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.Location = new System.Drawing.Point(24, 126);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 16);
            this.label15.TabIndex = 12;
            this.label15.Text = "选择测量的天线";
            // 
            // panel_dzz
            // 
            this.panel_dzz.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_dzz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.panel_dzz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_dzz.Controls.Add(this.btn_dzz_delete);
            this.panel_dzz.Controls.Add(this.btn_dzz_save);
            this.panel_dzz.Controls.Add(this.comboBox_dzz_devselected);
            this.panel_dzz.Controls.Add(this.dzz_z_error);
            this.panel_dzz.Controls.Add(this.dzz_y_error);
            this.panel_dzz.Controls.Add(this.dzz_x_error);
            this.panel_dzz.Controls.Add(this.label7);
            this.panel_dzz.Controls.Add(this.label8);
            this.panel_dzz.Controls.Add(this.label9);
            this.panel_dzz.Controls.Add(this.label10);
            this.panel_dzz.Location = new System.Drawing.Point(189, 522);
            this.panel_dzz.Name = "panel_dzz";
            this.panel_dzz.Size = new System.Drawing.Size(593, 256);
            this.panel_dzz.TabIndex = 11;
            // 
            // btn_dzz_delete
            // 
            this.btn_dzz_delete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_dzz_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_dzz_delete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_dzz_delete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_dzz_delete.Location = new System.Drawing.Point(294, 184);
            this.btn_dzz_delete.Name = "btn_dzz_delete";
            this.btn_dzz_delete.Size = new System.Drawing.Size(200, 40);
            this.btn_dzz_delete.TabIndex = 16;
            this.btn_dzz_delete.Text = "删除测量结果";
            this.btn_dzz_delete.UseVisualStyleBackColor = false;
            // 
            // btn_dzz_save
            // 
            this.btn_dzz_save.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_dzz_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_dzz_save.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_dzz_save.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_dzz_save.Location = new System.Drawing.Point(57, 184);
            this.btn_dzz_save.Name = "btn_dzz_save";
            this.btn_dzz_save.Size = new System.Drawing.Size(200, 40);
            this.btn_dzz_save.TabIndex = 15;
            this.btn_dzz_save.Text = "保存测量结果";
            this.btn_dzz_save.UseVisualStyleBackColor = false;
            // 
            // comboBox_dzz_devselected
            // 
            this.comboBox_dzz_devselected.FormattingEnabled = true;
            this.comboBox_dzz_devselected.Items.AddRange(new object[] {
            "前向ESM天线",
            "前向ECM天线",
            "后向ESM天线",
            "后向ECM天线",
            "俯仰天线"});
            this.comboBox_dzz_devselected.Location = new System.Drawing.Point(222, 21);
            this.comboBox_dzz_devselected.Name = "comboBox_dzz_devselected";
            this.comboBox_dzz_devselected.Size = new System.Drawing.Size(230, 20);
            this.comboBox_dzz_devselected.TabIndex = 14;
            // 
            // dzz_z_error
            // 
            this.dzz_z_error.BackColor = System.Drawing.SystemColors.Window;
            this.dzz_z_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dzz_z_error.Location = new System.Drawing.Point(388, 124);
            this.dzz_z_error.Name = "dzz_z_error";
            this.dzz_z_error.Size = new System.Drawing.Size(106, 21);
            this.dzz_z_error.TabIndex = 6;
            // 
            // dzz_y_error
            // 
            this.dzz_y_error.BackColor = System.Drawing.SystemColors.Window;
            this.dzz_y_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dzz_y_error.Location = new System.Drawing.Point(222, 124);
            this.dzz_y_error.Name = "dzz_y_error";
            this.dzz_y_error.Size = new System.Drawing.Size(107, 21);
            this.dzz_y_error.TabIndex = 5;
            // 
            // dzz_x_error
            // 
            this.dzz_x_error.BackColor = System.Drawing.SystemColors.Window;
            this.dzz_x_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dzz_x_error.Location = new System.Drawing.Point(57, 124);
            this.dzz_x_error.Name = "dzz_x_error";
            this.dzz_x_error.Size = new System.Drawing.Size(110, 21);
            this.dzz_x_error.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(63, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "X向偏差";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(228, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Y向偏差";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("宋体", 12F);
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(394, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Z向偏差";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F);
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label10.Location = new System.Drawing.Point(92, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "测量部位";
            // 
            // btn_war_loc
            // 
            this.btn_war_loc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_war_loc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_war_loc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_war_loc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_war_loc.Location = new System.Drawing.Point(174, 74);
            this.btn_war_loc.Name = "btn_war_loc";
            this.btn_war_loc.Size = new System.Drawing.Size(201, 38);
            this.btn_war_loc.TabIndex = 8;
            this.btn_war_loc.Text = "仪器定位";
            this.btn_war_loc.UseVisualStyleBackColor = false;
            // 
            // btn_dzz_means
            // 
            this.btn_dzz_means.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_dzz_means.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_dzz_means.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_dzz_means.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_dzz_means.Location = new System.Drawing.Point(189, 463);
            this.btn_dzz_means.Name = "btn_dzz_means";
            this.btn_dzz_means.Size = new System.Drawing.Size(200, 40);
            this.btn_dzz_means.TabIndex = 7;
            this.btn_dzz_means.Text = "天线靶点测量";
            this.btn_dzz_means.UseVisualStyleBackColor = false;
            // 
            // page_cni
            // 
            this.page_cni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.page_cni.Controls.Add(this.cni_save);
            this.page_cni.Controls.Add(this.btn_cni_calcu_error);
            this.page_cni.Controls.Add(this.cni_std_ptsname);
            this.page_cni.Controls.Add(this.label56);
            this.page_cni.Controls.Add(this.btn_import_cni_std);
            this.page_cni.Controls.Add(this.cni_means_ptsname);
            this.page_cni.Controls.Add(this.dataGridView_cni);
            this.page_cni.Controls.Add(this.cni_dev_select);
            this.page_cni.Controls.Add(this.label45);
            this.page_cni.Controls.Add(this.label38);
            this.page_cni.Controls.Add(this.cni_target_select);
            this.page_cni.Controls.Add(this.label16);
            this.page_cni.Controls.Add(this.panel_cni);
            this.page_cni.Controls.Add(this.btn_cni_loc);
            this.page_cni.Controls.Add(this.btn_cni_means);
            this.page_cni.Location = new System.Drawing.Point(4, 22);
            this.page_cni.Name = "page_cni";
            this.page_cni.Padding = new System.Windows.Forms.Padding(3);
            this.page_cni.Size = new System.Drawing.Size(1110, 821);
            this.page_cni.TabIndex = 5;
            this.page_cni.Text = "CNI";
            // 
            // cni_save
            // 
            this.cni_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.cni_save.Font = new System.Drawing.Font("宋体", 12F);
            this.cni_save.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cni_save.Location = new System.Drawing.Point(497, 466);
            this.cni_save.Name = "cni_save";
            this.cni_save.Size = new System.Drawing.Size(200, 40);
            this.cni_save.TabIndex = 32;
            this.cni_save.Text = "完成测量";
            this.cni_save.UseVisualStyleBackColor = false;
            // 
            // btn_cni_calcu_error
            // 
            this.btn_cni_calcu_error.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_cni_calcu_error.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_cni_calcu_error.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_cni_calcu_error.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_cni_calcu_error.Location = new System.Drawing.Point(291, 466);
            this.btn_cni_calcu_error.Name = "btn_cni_calcu_error";
            this.btn_cni_calcu_error.Size = new System.Drawing.Size(200, 40);
            this.btn_cni_calcu_error.TabIndex = 31;
            this.btn_cni_calcu_error.Text = "计算测量误差";
            this.btn_cni_calcu_error.UseVisualStyleBackColor = false;
            // 
            // cni_std_ptsname
            // 
            this.cni_std_ptsname.FormattingEnabled = true;
            this.cni_std_ptsname.Items.AddRange(new object[] {
            ""});
            this.cni_std_ptsname.Location = new System.Drawing.Point(253, 154);
            this.cni_std_ptsname.Name = "cni_std_ptsname";
            this.cni_std_ptsname.Size = new System.Drawing.Size(230, 20);
            this.cni_std_ptsname.TabIndex = 30;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label56.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label56.Location = new System.Drawing.Point(26, 158);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(95, 16);
            this.label56.TabIndex = 29;
            this.label56.Text = "CNI标准点集";
            // 
            // btn_import_cni_std
            // 
            this.btn_import_cni_std.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_import_cni_std.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_import_cni_std.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_import_cni_std.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_import_cni_std.Location = new System.Drawing.Point(269, 65);
            this.btn_import_cni_std.Name = "btn_import_cni_std";
            this.btn_import_cni_std.Size = new System.Drawing.Size(201, 38);
            this.btn_import_cni_std.TabIndex = 28;
            this.btn_import_cni_std.Text = "导入理论值";
            this.btn_import_cni_std.UseVisualStyleBackColor = false;
            // 
            // cni_means_ptsname
            // 
            this.cni_means_ptsname.FormattingEnabled = true;
            this.cni_means_ptsname.Items.AddRange(new object[] {
            ""});
            this.cni_means_ptsname.Location = new System.Drawing.Point(253, 186);
            this.cni_means_ptsname.Name = "cni_means_ptsname";
            this.cni_means_ptsname.Size = new System.Drawing.Size(230, 20);
            this.cni_means_ptsname.TabIndex = 27;
            // 
            // dataGridView_cni
            // 
            this.dataGridView_cni.AllowUserToAddRows = false;
            this.dataGridView_cni.AllowUserToDeleteRows = false;
            this.dataGridView_cni.AllowUserToResizeColumns = false;
            this.dataGridView_cni.AllowUserToResizeRows = false;
            this.dataGridView_cni.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.dataGridView_cni.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_cni.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle79.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle79.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle79.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(195)))), ((int)(((byte)(197)))));
            dataGridViewCellStyle79.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle79.SelectionForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle79.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_cni.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle79;
            this.dataGridView_cni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle80.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle80.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle80.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle80.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle80.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle80.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_cni.DefaultCellStyle = dataGridViewCellStyle80;
            this.dataGridView_cni.EnableHeadersVisualStyles = false;
            this.dataGridView_cni.Location = new System.Drawing.Point(19, 218);
            this.dataGridView_cni.Name = "dataGridView_cni";
            this.dataGridView_cni.ReadOnly = true;
            dataGridViewCellStyle81.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle81.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle81.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle81.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle81.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle81.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle81.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_cni.RowHeadersDefaultCellStyle = dataGridViewCellStyle81;
            this.dataGridView_cni.RowHeadersVisible = false;
            this.dataGridView_cni.RowHeadersWidth = 62;
            dataGridViewCellStyle82.BackColor = System.Drawing.Color.Transparent;
            this.dataGridView_cni.RowsDefaultCellStyle = dataGridViewCellStyle82;
            this.dataGridView_cni.RowTemplate.Height = 30;
            this.dataGridView_cni.Size = new System.Drawing.Size(717, 227);
            this.dataGridView_cni.TabIndex = 26;
            // 
            // cni_dev_select
            // 
            this.cni_dev_select.FormattingEnabled = true;
            this.cni_dev_select.Items.AddRange(new object[] {
            ""});
            this.cni_dev_select.Location = new System.Drawing.Point(253, 27);
            this.cni_dev_select.Name = "cni_dev_select";
            this.cni_dev_select.Size = new System.Drawing.Size(230, 20);
            this.cni_dev_select.TabIndex = 25;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label45.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label45.Location = new System.Drawing.Point(26, 31);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(71, 16);
            this.label45.TabIndex = 24;
            this.label45.Text = "设备选择";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label38.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label38.Location = new System.Drawing.Point(26, 190);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(95, 16);
            this.label38.TabIndex = 22;
            this.label38.Text = "CNI测量点集";
            // 
            // cni_target_select
            // 
            this.cni_target_select.FormattingEnabled = true;
            this.cni_target_select.Items.AddRange(new object[] {
            "IFDL天线1（前左下）",
            "IFDL天线2（前右下）",
            "IFDL天线3（后左前）",
            "IFDL天线4（后左后）",
            "IFDL天线5（后右前）",
            "IFDL天线6（后右后）",
            "卫星通讯天线"});
            this.cni_target_select.Location = new System.Drawing.Point(253, 121);
            this.cni_target_select.Name = "cni_target_select";
            this.cni_target_select.Size = new System.Drawing.Size(230, 20);
            this.cni_target_select.TabIndex = 20;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label16.Location = new System.Drawing.Point(25, 121);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(119, 16);
            this.label16.TabIndex = 19;
            this.label16.Text = "选择测量的天线";
            // 
            // panel_cni
            // 
            this.panel_cni.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_cni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.panel_cni.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_cni.Controls.Add(this.btn_cni_delete);
            this.panel_cni.Controls.Add(this.btn_cni_save);
            this.panel_cni.Controls.Add(this.comboBox_cni_target_selected);
            this.panel_cni.Controls.Add(this.cni_z_error);
            this.panel_cni.Controls.Add(this.cni_y_error);
            this.panel_cni.Controls.Add(this.cni_x_error);
            this.panel_cni.Controls.Add(this.label17);
            this.panel_cni.Controls.Add(this.label18);
            this.panel_cni.Controls.Add(this.label19);
            this.panel_cni.Controls.Add(this.label20);
            this.panel_cni.Location = new System.Drawing.Point(19, 521);
            this.panel_cni.Name = "panel_cni";
            this.panel_cni.Size = new System.Drawing.Size(717, 256);
            this.panel_cni.TabIndex = 18;
            // 
            // btn_cni_delete
            // 
            this.btn_cni_delete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_cni_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_cni_delete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_cni_delete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_cni_delete.Location = new System.Drawing.Point(356, 184);
            this.btn_cni_delete.Name = "btn_cni_delete";
            this.btn_cni_delete.Size = new System.Drawing.Size(200, 40);
            this.btn_cni_delete.TabIndex = 16;
            this.btn_cni_delete.Text = "删除测量结果";
            this.btn_cni_delete.UseVisualStyleBackColor = false;
            // 
            // btn_cni_save
            // 
            this.btn_cni_save.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_cni_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_cni_save.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_cni_save.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_cni_save.Location = new System.Drawing.Point(119, 184);
            this.btn_cni_save.Name = "btn_cni_save";
            this.btn_cni_save.Size = new System.Drawing.Size(200, 40);
            this.btn_cni_save.TabIndex = 15;
            this.btn_cni_save.Text = "保存测量结果";
            this.btn_cni_save.UseVisualStyleBackColor = false;
            // 
            // comboBox_cni_target_selected
            // 
            this.comboBox_cni_target_selected.FormattingEnabled = true;
            this.comboBox_cni_target_selected.Items.AddRange(new object[] {
            "IFDL天线1（前左下）",
            "IFDL天线2（前右下）",
            "IFDL天线3（后左前）",
            "IFDL天线4（后左后）",
            "IFDL天线5（后右前）",
            "IFDL天线6（后右后）",
            "卫星通讯天线"});
            this.comboBox_cni_target_selected.Location = new System.Drawing.Point(222, 21);
            this.comboBox_cni_target_selected.Name = "comboBox_cni_target_selected";
            this.comboBox_cni_target_selected.Size = new System.Drawing.Size(230, 20);
            this.comboBox_cni_target_selected.TabIndex = 14;
            // 
            // cni_z_error
            // 
            this.cni_z_error.BackColor = System.Drawing.SystemColors.Window;
            this.cni_z_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cni_z_error.Location = new System.Drawing.Point(388, 124);
            this.cni_z_error.Name = "cni_z_error";
            this.cni_z_error.Size = new System.Drawing.Size(106, 21);
            this.cni_z_error.TabIndex = 6;
            // 
            // cni_y_error
            // 
            this.cni_y_error.BackColor = System.Drawing.SystemColors.Window;
            this.cni_y_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cni_y_error.Location = new System.Drawing.Point(222, 124);
            this.cni_y_error.Name = "cni_y_error";
            this.cni_y_error.Size = new System.Drawing.Size(107, 21);
            this.cni_y_error.TabIndex = 5;
            // 
            // cni_x_error
            // 
            this.cni_x_error.BackColor = System.Drawing.SystemColors.Window;
            this.cni_x_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cni_x_error.Location = new System.Drawing.Point(57, 124);
            this.cni_x_error.Name = "cni_x_error";
            this.cni_x_error.Size = new System.Drawing.Size(110, 21);
            this.cni_x_error.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("宋体", 12F);
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label17.Location = new System.Drawing.Point(63, 71);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 16);
            this.label17.TabIndex = 3;
            this.label17.Text = "X向偏差";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label18.Font = new System.Drawing.Font("宋体", 12F);
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label18.Location = new System.Drawing.Point(228, 71);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 16);
            this.label18.TabIndex = 2;
            this.label18.Text = "Y向偏差";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19.Font = new System.Drawing.Font("宋体", 12F);
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label19.Location = new System.Drawing.Point(394, 71);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 16);
            this.label19.TabIndex = 1;
            this.label19.Text = "Z向偏差";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 12F);
            this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label20.Location = new System.Drawing.Point(53, 23);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 16);
            this.label20.TabIndex = 0;
            this.label20.Text = "测量部位";
            // 
            // btn_cni_loc
            // 
            this.btn_cni_loc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_cni_loc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_cni_loc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_cni_loc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_cni_loc.Location = new System.Drawing.Point(46, 65);
            this.btn_cni_loc.Name = "btn_cni_loc";
            this.btn_cni_loc.Size = new System.Drawing.Size(201, 38);
            this.btn_cni_loc.TabIndex = 16;
            this.btn_cni_loc.Text = "仪器定位";
            this.btn_cni_loc.UseVisualStyleBackColor = false;
            // 
            // btn_cni_means
            // 
            this.btn_cni_means.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_cni_means.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_cni_means.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_cni_means.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_cni_means.Location = new System.Drawing.Point(82, 466);
            this.btn_cni_means.Name = "btn_cni_means";
            this.btn_cni_means.Size = new System.Drawing.Size(200, 40);
            this.btn_cni_means.TabIndex = 15;
            this.btn_cni_means.Text = "天线靶点测量";
            this.btn_cni_means.UseVisualStyleBackColor = false;
            // 
            // page_px
            // 
            this.page_px.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.page_px.Controls.Add(this.px_save);
            this.page_px.Controls.Add(this.panel_px);
            this.page_px.Controls.Add(this.px_std_ptsname);
            this.page_px.Controls.Add(this.label57);
            this.page_px.Controls.Add(this.btn_import_px_std);
            this.page_px.Controls.Add(this.px_means_ptsname);
            this.page_px.Controls.Add(this.dataGridView_px);
            this.page_px.Controls.Add(this.px_dev_select);
            this.page_px.Controls.Add(this.label46);
            this.page_px.Controls.Add(this.label14);
            this.page_px.Controls.Add(this.btn_px_test);
            this.page_px.Controls.Add(this.btn_px_loc);
            this.page_px.Controls.Add(this.btn_px_means);
            this.page_px.Location = new System.Drawing.Point(4, 22);
            this.page_px.Name = "page_px";
            this.page_px.Padding = new System.Windows.Forms.Padding(3);
            this.page_px.Size = new System.Drawing.Size(1110, 821);
            this.page_px.TabIndex = 6;
            this.page_px.Text = "平显";
            // 
            // px_save
            // 
            this.px_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.px_save.Font = new System.Drawing.Font("宋体", 12F);
            this.px_save.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.px_save.Location = new System.Drawing.Point(479, 509);
            this.px_save.Name = "px_save";
            this.px_save.Size = new System.Drawing.Size(200, 40);
            this.px_save.TabIndex = 34;
            this.px_save.Text = "完成测量";
            this.px_save.UseVisualStyleBackColor = false;
            // 
            // panel_px
            // 
            this.panel_px.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_px.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.panel_px.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_px.Controls.Add(this.btn_px_delete);
            this.panel_px.Controls.Add(this.btn_px_save);
            this.panel_px.Controls.Add(this.px_z_error);
            this.panel_px.Controls.Add(this.px_y_error);
            this.panel_px.Controls.Add(this.px_x_error);
            this.panel_px.Controls.Add(this.label22);
            this.panel_px.Controls.Add(this.label23);
            this.panel_px.Controls.Add(this.label24);
            this.panel_px.Location = new System.Drawing.Point(30, 555);
            this.panel_px.Name = "panel_px";
            this.panel_px.Size = new System.Drawing.Size(703, 246);
            this.panel_px.TabIndex = 33;
            // 
            // btn_px_delete
            // 
            this.btn_px_delete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_px_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_px_delete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_px_delete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_px_delete.Location = new System.Drawing.Point(366, 163);
            this.btn_px_delete.Name = "btn_px_delete";
            this.btn_px_delete.Size = new System.Drawing.Size(200, 40);
            this.btn_px_delete.TabIndex = 16;
            this.btn_px_delete.Text = "删除测量结果";
            this.btn_px_delete.UseVisualStyleBackColor = false;
            // 
            // btn_px_save
            // 
            this.btn_px_save.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_px_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_px_save.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_px_save.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_px_save.Location = new System.Drawing.Point(129, 163);
            this.btn_px_save.Name = "btn_px_save";
            this.btn_px_save.Size = new System.Drawing.Size(200, 40);
            this.btn_px_save.TabIndex = 15;
            this.btn_px_save.Text = "保存测量结果";
            this.btn_px_save.UseVisualStyleBackColor = false;
            // 
            // px_z_error
            // 
            this.px_z_error.BackColor = System.Drawing.SystemColors.Window;
            this.px_z_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.px_z_error.Location = new System.Drawing.Point(405, 108);
            this.px_z_error.Name = "px_z_error";
            this.px_z_error.Size = new System.Drawing.Size(106, 21);
            this.px_z_error.TabIndex = 6;
            // 
            // px_y_error
            // 
            this.px_y_error.BackColor = System.Drawing.SystemColors.Window;
            this.px_y_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.px_y_error.Location = new System.Drawing.Point(239, 108);
            this.px_y_error.Name = "px_y_error";
            this.px_y_error.Size = new System.Drawing.Size(107, 21);
            this.px_y_error.TabIndex = 5;
            // 
            // px_x_error
            // 
            this.px_x_error.BackColor = System.Drawing.SystemColors.Window;
            this.px_x_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.px_x_error.Location = new System.Drawing.Point(74, 108);
            this.px_x_error.Name = "px_x_error";
            this.px_x_error.Size = new System.Drawing.Size(110, 21);
            this.px_x_error.TabIndex = 4;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label22.Font = new System.Drawing.Font("宋体", 12F);
            this.label22.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label22.Location = new System.Drawing.Point(80, 55);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(63, 16);
            this.label22.TabIndex = 3;
            this.label22.Text = "X向偏差";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label23.Font = new System.Drawing.Font("宋体", 12F);
            this.label23.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label23.Location = new System.Drawing.Point(245, 55);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(63, 16);
            this.label23.TabIndex = 2;
            this.label23.Text = "Y向偏差";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label24.Font = new System.Drawing.Font("宋体", 12F);
            this.label24.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label24.Location = new System.Drawing.Point(411, 55);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 16);
            this.label24.TabIndex = 1;
            this.label24.Text = "Z向偏差";
            // 
            // px_std_ptsname
            // 
            this.px_std_ptsname.FormattingEnabled = true;
            this.px_std_ptsname.Items.AddRange(new object[] {
            ""});
            this.px_std_ptsname.Location = new System.Drawing.Point(282, 143);
            this.px_std_ptsname.Name = "px_std_ptsname";
            this.px_std_ptsname.Size = new System.Drawing.Size(230, 20);
            this.px_std_ptsname.TabIndex = 32;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label57.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label57.Location = new System.Drawing.Point(27, 147);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(103, 16);
            this.label57.TabIndex = 31;
            this.label57.Text = "平显标准点集";
            // 
            // btn_import_px_std
            // 
            this.btn_import_px_std.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_import_px_std.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_import_px_std.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_import_px_std.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_import_px_std.Location = new System.Drawing.Point(282, 75);
            this.btn_import_px_std.Name = "btn_import_px_std";
            this.btn_import_px_std.Size = new System.Drawing.Size(200, 40);
            this.btn_import_px_std.TabIndex = 30;
            this.btn_import_px_std.Text = "导入理论值";
            this.btn_import_px_std.UseVisualStyleBackColor = false;
            // 
            // px_means_ptsname
            // 
            this.px_means_ptsname.FormattingEnabled = true;
            this.px_means_ptsname.Items.AddRange(new object[] {
            ""});
            this.px_means_ptsname.Location = new System.Drawing.Point(282, 178);
            this.px_means_ptsname.Name = "px_means_ptsname";
            this.px_means_ptsname.Size = new System.Drawing.Size(230, 20);
            this.px_means_ptsname.TabIndex = 29;
            // 
            // dataGridView_px
            // 
            this.dataGridView_px.AllowUserToAddRows = false;
            this.dataGridView_px.AllowUserToDeleteRows = false;
            this.dataGridView_px.AllowUserToResizeColumns = false;
            this.dataGridView_px.AllowUserToResizeRows = false;
            this.dataGridView_px.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.dataGridView_px.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_px.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle83.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle83.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle83.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(195)))), ((int)(((byte)(197)))));
            dataGridViewCellStyle83.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle83.SelectionForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle83.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_px.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle83;
            this.dataGridView_px.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle84.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle84.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle84.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle84.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle84.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle84.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle84.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_px.DefaultCellStyle = dataGridViewCellStyle84;
            this.dataGridView_px.EnableHeadersVisualStyles = false;
            this.dataGridView_px.Location = new System.Drawing.Point(30, 224);
            this.dataGridView_px.Name = "dataGridView_px";
            this.dataGridView_px.ReadOnly = true;
            dataGridViewCellStyle85.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle85.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle85.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle85.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle85.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle85.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle85.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_px.RowHeadersDefaultCellStyle = dataGridViewCellStyle85;
            this.dataGridView_px.RowHeadersVisible = false;
            this.dataGridView_px.RowHeadersWidth = 62;
            dataGridViewCellStyle86.BackColor = System.Drawing.Color.Transparent;
            this.dataGridView_px.RowsDefaultCellStyle = dataGridViewCellStyle86;
            this.dataGridView_px.RowTemplate.Height = 30;
            this.dataGridView_px.Size = new System.Drawing.Size(703, 261);
            this.dataGridView_px.TabIndex = 28;
            // 
            // px_dev_select
            // 
            this.px_dev_select.FormattingEnabled = true;
            this.px_dev_select.Items.AddRange(new object[] {
            ""});
            this.px_dev_select.Location = new System.Drawing.Point(281, 33);
            this.px_dev_select.Name = "px_dev_select";
            this.px_dev_select.Size = new System.Drawing.Size(230, 20);
            this.px_dev_select.TabIndex = 27;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label46.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label46.Location = new System.Drawing.Point(26, 35);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(71, 16);
            this.label46.TabIndex = 26;
            this.label46.Text = "设备选择";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label14.Location = new System.Drawing.Point(27, 182);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 16);
            this.label14.TabIndex = 24;
            this.label14.Text = "平显测量点集";
            // 
            // btn_px_test
            // 
            this.btn_px_test.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_px_test.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_px_test.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_px_test.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_px_test.Location = new System.Drawing.Point(273, 509);
            this.btn_px_test.Name = "btn_px_test";
            this.btn_px_test.Size = new System.Drawing.Size(200, 40);
            this.btn_px_test.TabIndex = 9;
            this.btn_px_test.Text = "安装误差计算";
            this.btn_px_test.UseVisualStyleBackColor = false;
            // 
            // btn_px_loc
            // 
            this.btn_px_loc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_px_loc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_px_loc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_px_loc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_px_loc.Location = new System.Drawing.Point(29, 75);
            this.btn_px_loc.Name = "btn_px_loc";
            this.btn_px_loc.Size = new System.Drawing.Size(200, 40);
            this.btn_px_loc.TabIndex = 8;
            this.btn_px_loc.Text = "仪器定位";
            this.btn_px_loc.UseVisualStyleBackColor = false;
            // 
            // btn_px_means
            // 
            this.btn_px_means.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_px_means.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_px_means.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_px_means.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_px_means.Location = new System.Drawing.Point(56, 509);
            this.btn_px_means.Name = "btn_px_means";
            this.btn_px_means.Size = new System.Drawing.Size(200, 40);
            this.btn_px_means.TabIndex = 7;
            this.btn_px_means.Text = "平显靶点测量";
            this.btn_px_means.UseVisualStyleBackColor = false;
            // 
            // page_irs
            // 
            this.page_irs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.page_irs.Controls.Add(this.irs_save);
            this.page_irs.Controls.Add(this.btn_irs_calcu_error);
            this.page_irs.Controls.Add(this.btn_import_irs_std);
            this.page_irs.Controls.Add(this.irs_means_ptsname);
            this.page_irs.Controls.Add(this.label2);
            this.page_irs.Controls.Add(this.irs_std_ptsname);
            this.page_irs.Controls.Add(this.dataGridView_irs);
            this.page_irs.Controls.Add(this.irs_dev_select);
            this.page_irs.Controls.Add(this.label59);
            this.page_irs.Controls.Add(this.label60);
            this.page_irs.Controls.Add(this.irs_target_select);
            this.page_irs.Controls.Add(this.label61);
            this.page_irs.Controls.Add(this.panel1);
            this.page_irs.Controls.Add(this.btn_irs_loc);
            this.page_irs.Controls.Add(this.btn_irs_means);
            this.page_irs.Location = new System.Drawing.Point(4, 22);
            this.page_irs.Name = "page_irs";
            this.page_irs.Padding = new System.Windows.Forms.Padding(3);
            this.page_irs.Size = new System.Drawing.Size(1110, 821);
            this.page_irs.TabIndex = 12;
            this.page_irs.Text = "惯性";
            // 
            // irs_save
            // 
            this.irs_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.irs_save.Font = new System.Drawing.Font("宋体", 12F);
            this.irs_save.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.irs_save.Location = new System.Drawing.Point(461, 461);
            this.irs_save.Name = "irs_save";
            this.irs_save.Size = new System.Drawing.Size(200, 40);
            this.irs_save.TabIndex = 44;
            this.irs_save.Text = "完成测量";
            this.irs_save.UseVisualStyleBackColor = false;
            // 
            // btn_irs_calcu_error
            // 
            this.btn_irs_calcu_error.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_irs_calcu_error.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_irs_calcu_error.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_irs_calcu_error.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_irs_calcu_error.Location = new System.Drawing.Point(268, 461);
            this.btn_irs_calcu_error.Name = "btn_irs_calcu_error";
            this.btn_irs_calcu_error.Size = new System.Drawing.Size(187, 39);
            this.btn_irs_calcu_error.TabIndex = 43;
            this.btn_irs_calcu_error.Text = "计算测量误差";
            this.btn_irs_calcu_error.UseVisualStyleBackColor = false;
            // 
            // btn_import_irs_std
            // 
            this.btn_import_irs_std.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_import_irs_std.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_import_irs_std.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_import_irs_std.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_import_irs_std.Location = new System.Drawing.Point(271, 70);
            this.btn_import_irs_std.Name = "btn_import_irs_std";
            this.btn_import_irs_std.Size = new System.Drawing.Size(187, 38);
            this.btn_import_irs_std.TabIndex = 42;
            this.btn_import_irs_std.Text = "导入理论值";
            this.btn_import_irs_std.UseVisualStyleBackColor = false;
            // 
            // irs_means_ptsname
            // 
            this.irs_means_ptsname.FormattingEnabled = true;
            this.irs_means_ptsname.Items.AddRange(new object[] {
            ""});
            this.irs_means_ptsname.Location = new System.Drawing.Point(271, 197);
            this.irs_means_ptsname.Name = "irs_means_ptsname";
            this.irs_means_ptsname.Size = new System.Drawing.Size(230, 20);
            this.irs_means_ptsname.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(44, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 40;
            this.label2.Text = "系统测量点集";
            // 
            // irs_std_ptsname
            // 
            this.irs_std_ptsname.FormattingEnabled = true;
            this.irs_std_ptsname.Items.AddRange(new object[] {
            ""});
            this.irs_std_ptsname.Location = new System.Drawing.Point(271, 164);
            this.irs_std_ptsname.Name = "irs_std_ptsname";
            this.irs_std_ptsname.Size = new System.Drawing.Size(230, 20);
            this.irs_std_ptsname.TabIndex = 39;
            // 
            // dataGridView_irs
            // 
            this.dataGridView_irs.AllowUserToAddRows = false;
            this.dataGridView_irs.AllowUserToDeleteRows = false;
            this.dataGridView_irs.AllowUserToResizeColumns = false;
            this.dataGridView_irs.AllowUserToResizeRows = false;
            this.dataGridView_irs.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.dataGridView_irs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_irs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle87.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle87.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle87.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(195)))), ((int)(((byte)(197)))));
            dataGridViewCellStyle87.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle87.SelectionForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle87.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_irs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle87;
            this.dataGridView_irs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle88.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle88.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle88.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle88.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle88.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle88.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_irs.DefaultCellStyle = dataGridViewCellStyle88;
            this.dataGridView_irs.EnableHeadersVisualStyles = false;
            this.dataGridView_irs.Location = new System.Drawing.Point(38, 229);
            this.dataGridView_irs.Name = "dataGridView_irs";
            this.dataGridView_irs.ReadOnly = true;
            dataGridViewCellStyle89.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle89.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle89.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle89.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle89.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle89.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle89.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_irs.RowHeadersDefaultCellStyle = dataGridViewCellStyle89;
            this.dataGridView_irs.RowHeadersVisible = false;
            this.dataGridView_irs.RowHeadersWidth = 62;
            dataGridViewCellStyle90.BackColor = System.Drawing.Color.Transparent;
            this.dataGridView_irs.RowsDefaultCellStyle = dataGridViewCellStyle90;
            this.dataGridView_irs.RowTemplate.Height = 30;
            this.dataGridView_irs.Size = new System.Drawing.Size(709, 224);
            this.dataGridView_irs.TabIndex = 38;
            // 
            // irs_dev_select
            // 
            this.irs_dev_select.FormattingEnabled = true;
            this.irs_dev_select.Items.AddRange(new object[] {
            ""});
            this.irs_dev_select.Location = new System.Drawing.Point(271, 31);
            this.irs_dev_select.Name = "irs_dev_select";
            this.irs_dev_select.Size = new System.Drawing.Size(230, 20);
            this.irs_dev_select.TabIndex = 37;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label59.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label59.Location = new System.Drawing.Point(43, 33);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(71, 16);
            this.label59.TabIndex = 36;
            this.label59.Text = "设备选择";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label60.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label60.Location = new System.Drawing.Point(44, 168);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(103, 16);
            this.label60.TabIndex = 35;
            this.label60.Text = "系统标准点集";
            // 
            // irs_target_select
            // 
            this.irs_target_select.FormattingEnabled = true;
            this.irs_target_select.Items.AddRange(new object[] {
            "前向ESM天线",
            "前向ECM天线",
            "后向ESM天线",
            "后向ECM天线",
            "俯仰天线"});
            this.irs_target_select.Location = new System.Drawing.Point(271, 133);
            this.irs_target_select.Name = "irs_target_select";
            this.irs_target_select.Size = new System.Drawing.Size(230, 20);
            this.irs_target_select.TabIndex = 34;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label61.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label61.Location = new System.Drawing.Point(43, 137);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(119, 16);
            this.label61.TabIndex = 33;
            this.label61.Text = "选择测量的系统";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btn_irs_delete);
            this.panel1.Controls.Add(this.btn_irs_save);
            this.panel1.Controls.Add(this.irs_target_selected);
            this.panel1.Controls.Add(this.irs_z_error);
            this.panel1.Controls.Add(this.irs_y_error);
            this.panel1.Controls.Add(this.irs_x_error);
            this.panel1.Controls.Add(this.label62);
            this.panel1.Controls.Add(this.label63);
            this.panel1.Controls.Add(this.label64);
            this.panel1.Controls.Add(this.label65);
            this.panel1.Location = new System.Drawing.Point(38, 519);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(709, 256);
            this.panel1.TabIndex = 32;
            // 
            // btn_irs_delete
            // 
            this.btn_irs_delete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_irs_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_irs_delete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_irs_delete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_irs_delete.Location = new System.Drawing.Point(352, 184);
            this.btn_irs_delete.Name = "btn_irs_delete";
            this.btn_irs_delete.Size = new System.Drawing.Size(200, 40);
            this.btn_irs_delete.TabIndex = 16;
            this.btn_irs_delete.Text = "删除测量结果";
            this.btn_irs_delete.UseVisualStyleBackColor = false;
            // 
            // btn_irs_save
            // 
            this.btn_irs_save.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_irs_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_irs_save.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_irs_save.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_irs_save.Location = new System.Drawing.Point(115, 184);
            this.btn_irs_save.Name = "btn_irs_save";
            this.btn_irs_save.Size = new System.Drawing.Size(200, 40);
            this.btn_irs_save.TabIndex = 15;
            this.btn_irs_save.Text = "保存测量结果";
            this.btn_irs_save.UseVisualStyleBackColor = false;
            // 
            // irs_target_selected
            // 
            this.irs_target_selected.FormattingEnabled = true;
            this.irs_target_selected.Items.AddRange(new object[] {
            "前向ESM天线",
            "前向ECM天线",
            "后向ESM天线",
            "后向ECM天线",
            "俯仰天线"});
            this.irs_target_selected.Location = new System.Drawing.Point(222, 21);
            this.irs_target_selected.Name = "irs_target_selected";
            this.irs_target_selected.Size = new System.Drawing.Size(230, 20);
            this.irs_target_selected.TabIndex = 14;
            // 
            // irs_z_error
            // 
            this.irs_z_error.BackColor = System.Drawing.SystemColors.Window;
            this.irs_z_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.irs_z_error.Location = new System.Drawing.Point(388, 124);
            this.irs_z_error.Name = "irs_z_error";
            this.irs_z_error.Size = new System.Drawing.Size(106, 21);
            this.irs_z_error.TabIndex = 6;
            // 
            // irs_y_error
            // 
            this.irs_y_error.BackColor = System.Drawing.SystemColors.Window;
            this.irs_y_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.irs_y_error.Location = new System.Drawing.Point(222, 124);
            this.irs_y_error.Name = "irs_y_error";
            this.irs_y_error.Size = new System.Drawing.Size(107, 21);
            this.irs_y_error.TabIndex = 5;
            // 
            // irs_x_error
            // 
            this.irs_x_error.BackColor = System.Drawing.SystemColors.Window;
            this.irs_x_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.irs_x_error.Location = new System.Drawing.Point(57, 124);
            this.irs_x_error.Name = "irs_x_error";
            this.irs_x_error.Size = new System.Drawing.Size(110, 21);
            this.irs_x_error.TabIndex = 4;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.BackColor = System.Drawing.Color.Transparent;
            this.label62.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label62.Font = new System.Drawing.Font("宋体", 12F);
            this.label62.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label62.Location = new System.Drawing.Point(63, 71);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(63, 16);
            this.label62.TabIndex = 3;
            this.label62.Text = "X向偏差";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.BackColor = System.Drawing.Color.Transparent;
            this.label63.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label63.Font = new System.Drawing.Font("宋体", 12F);
            this.label63.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label63.Location = new System.Drawing.Point(228, 71);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(63, 16);
            this.label63.TabIndex = 2;
            this.label63.Text = "Y向偏差";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.BackColor = System.Drawing.Color.Transparent;
            this.label64.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label64.Font = new System.Drawing.Font("宋体", 12F);
            this.label64.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label64.Location = new System.Drawing.Point(394, 71);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(63, 16);
            this.label64.TabIndex = 1;
            this.label64.Text = "Z向偏差";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("宋体", 12F);
            this.label65.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label65.Location = new System.Drawing.Point(92, 23);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(71, 16);
            this.label65.TabIndex = 0;
            this.label65.Text = "测量部位";
            // 
            // btn_irs_loc
            // 
            this.btn_irs_loc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_irs_loc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_irs_loc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_irs_loc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_irs_loc.Location = new System.Drawing.Point(47, 70);
            this.btn_irs_loc.Name = "btn_irs_loc";
            this.btn_irs_loc.Size = new System.Drawing.Size(201, 38);
            this.btn_irs_loc.TabIndex = 31;
            this.btn_irs_loc.Text = "仪器定位";
            this.btn_irs_loc.UseVisualStyleBackColor = false;
            // 
            // btn_irs_means
            // 
            this.btn_irs_means.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_irs_means.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_irs_means.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_irs_means.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_irs_means.Location = new System.Drawing.Point(60, 460);
            this.btn_irs_means.Name = "btn_irs_means";
            this.btn_irs_means.Size = new System.Drawing.Size(200, 40);
            this.btn_irs_means.TabIndex = 30;
            this.btn_irs_means.Text = "靶点测量";
            this.btn_irs_means.UseVisualStyleBackColor = false;
            // 
            // page_fcs
            // 
            this.page_fcs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.page_fcs.Controls.Add(this.fcs_save);
            this.page_fcs.Controls.Add(this.fcs_std_ptsname);
            this.page_fcs.Controls.Add(this.fcs_means_ptsname);
            this.page_fcs.Controls.Add(this.label21);
            this.page_fcs.Controls.Add(this.btn_import_fcs_std);
            this.page_fcs.Controls.Add(this.dataGridView_fcs);
            this.page_fcs.Controls.Add(this.fcs_dev_select);
            this.page_fcs.Controls.Add(this.label48);
            this.page_fcs.Controls.Add(this.label40);
            this.page_fcs.Controls.Add(this.fcs_target_select);
            this.page_fcs.Controls.Add(this.label26);
            this.page_fcs.Controls.Add(this.panel_fcs);
            this.page_fcs.Controls.Add(this.btn_fcs_calcu_error);
            this.page_fcs.Controls.Add(this.btn_fcs_loc);
            this.page_fcs.Controls.Add(this.btn_fcs_means);
            this.page_fcs.Location = new System.Drawing.Point(4, 22);
            this.page_fcs.Name = "page_fcs";
            this.page_fcs.Padding = new System.Windows.Forms.Padding(3);
            this.page_fcs.Size = new System.Drawing.Size(1110, 821);
            this.page_fcs.TabIndex = 8;
            this.page_fcs.Text = "飞控";
            // 
            // fcs_save
            // 
            this.fcs_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.fcs_save.Font = new System.Drawing.Font("宋体", 12F);
            this.fcs_save.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.fcs_save.Location = new System.Drawing.Point(479, 460);
            this.fcs_save.Name = "fcs_save";
            this.fcs_save.Size = new System.Drawing.Size(200, 40);
            this.fcs_save.TabIndex = 45;
            this.fcs_save.Text = "完成测量";
            this.fcs_save.UseVisualStyleBackColor = false;
            // 
            // fcs_std_ptsname
            // 
            this.fcs_std_ptsname.FormattingEnabled = true;
            this.fcs_std_ptsname.Items.AddRange(new object[] {
            ""});
            this.fcs_std_ptsname.Location = new System.Drawing.Point(249, 151);
            this.fcs_std_ptsname.Name = "fcs_std_ptsname";
            this.fcs_std_ptsname.Size = new System.Drawing.Size(230, 20);
            this.fcs_std_ptsname.TabIndex = 44;
            // 
            // fcs_means_ptsname
            // 
            this.fcs_means_ptsname.FormattingEnabled = true;
            this.fcs_means_ptsname.Items.AddRange(new object[] {
            ""});
            this.fcs_means_ptsname.Location = new System.Drawing.Point(249, 186);
            this.fcs_means_ptsname.Name = "fcs_means_ptsname";
            this.fcs_means_ptsname.Size = new System.Drawing.Size(230, 20);
            this.fcs_means_ptsname.TabIndex = 43;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label21.Location = new System.Drawing.Point(36, 190);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(103, 16);
            this.label21.TabIndex = 42;
            this.label21.Text = "飞控测量点集";
            // 
            // btn_import_fcs_std
            // 
            this.btn_import_fcs_std.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_import_fcs_std.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_import_fcs_std.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_import_fcs_std.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_import_fcs_std.Location = new System.Drawing.Point(247, 58);
            this.btn_import_fcs_std.Name = "btn_import_fcs_std";
            this.btn_import_fcs_std.Size = new System.Drawing.Size(201, 38);
            this.btn_import_fcs_std.TabIndex = 41;
            this.btn_import_fcs_std.Text = "导入理论值";
            this.btn_import_fcs_std.UseVisualStyleBackColor = false;
            // 
            // dataGridView_fcs
            // 
            this.dataGridView_fcs.AllowUserToAddRows = false;
            this.dataGridView_fcs.AllowUserToDeleteRows = false;
            this.dataGridView_fcs.AllowUserToResizeColumns = false;
            this.dataGridView_fcs.AllowUserToResizeRows = false;
            this.dataGridView_fcs.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.dataGridView_fcs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_fcs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle91.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle91.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle91.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(195)))), ((int)(((byte)(197)))));
            dataGridViewCellStyle91.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle91.SelectionForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle91.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_fcs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle91;
            this.dataGridView_fcs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle92.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle92.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle92.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle92.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle92.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle92.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_fcs.DefaultCellStyle = dataGridViewCellStyle92;
            this.dataGridView_fcs.EnableHeadersVisualStyles = false;
            this.dataGridView_fcs.Location = new System.Drawing.Point(38, 225);
            this.dataGridView_fcs.Name = "dataGridView_fcs";
            this.dataGridView_fcs.ReadOnly = true;
            dataGridViewCellStyle93.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle93.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle93.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle93.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle93.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle93.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle93.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_fcs.RowHeadersDefaultCellStyle = dataGridViewCellStyle93;
            this.dataGridView_fcs.RowHeadersVisible = false;
            this.dataGridView_fcs.RowHeadersWidth = 62;
            dataGridViewCellStyle94.BackColor = System.Drawing.Color.Transparent;
            this.dataGridView_fcs.RowsDefaultCellStyle = dataGridViewCellStyle94;
            this.dataGridView_fcs.RowTemplate.Height = 30;
            this.dataGridView_fcs.Size = new System.Drawing.Size(710, 227);
            this.dataGridView_fcs.TabIndex = 40;
            // 
            // fcs_dev_select
            // 
            this.fcs_dev_select.FormattingEnabled = true;
            this.fcs_dev_select.Items.AddRange(new object[] {
            ""});
            this.fcs_dev_select.Location = new System.Drawing.Point(249, 22);
            this.fcs_dev_select.Name = "fcs_dev_select";
            this.fcs_dev_select.Size = new System.Drawing.Size(230, 20);
            this.fcs_dev_select.TabIndex = 39;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label48.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label48.Location = new System.Drawing.Point(35, 24);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(71, 16);
            this.label48.TabIndex = 38;
            this.label48.Text = "设备选择";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label40.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label40.Location = new System.Drawing.Point(35, 150);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(103, 16);
            this.label40.TabIndex = 36;
            this.label40.Text = "飞控标准点集";
            // 
            // fcs_target_select
            // 
            this.fcs_target_select.FormattingEnabled = true;
            this.fcs_target_select.Items.AddRange(new object[] {
            "左速率陀螺传感器安装支架",
            "右速率陀螺传感器安装支架",
            "加速度传感器组件"});
            this.fcs_target_select.Location = new System.Drawing.Point(249, 111);
            this.fcs_target_select.Name = "fcs_target_select";
            this.fcs_target_select.Size = new System.Drawing.Size(230, 20);
            this.fcs_target_select.TabIndex = 34;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label26.Location = new System.Drawing.Point(35, 110);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(119, 16);
            this.label26.TabIndex = 33;
            this.label26.Text = "选择测量的设备";
            // 
            // panel_fcs
            // 
            this.panel_fcs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_fcs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.panel_fcs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_fcs.Controls.Add(this.label30);
            this.panel_fcs.Controls.Add(this.btn_fcs_delete);
            this.panel_fcs.Controls.Add(this.btn_fcs_save);
            this.panel_fcs.Controls.Add(this.fcs_tartget_selected);
            this.panel_fcs.Controls.Add(this.fcs_z_error);
            this.panel_fcs.Controls.Add(this.fcs_y_error);
            this.panel_fcs.Controls.Add(this.fcs_x_error);
            this.panel_fcs.Controls.Add(this.label27);
            this.panel_fcs.Controls.Add(this.label28);
            this.panel_fcs.Controls.Add(this.label29);
            this.panel_fcs.Location = new System.Drawing.Point(39, 528);
            this.panel_fcs.Name = "panel_fcs";
            this.panel_fcs.Size = new System.Drawing.Size(709, 256);
            this.panel_fcs.TabIndex = 32;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 12F);
            this.label30.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label30.Location = new System.Drawing.Point(140, 22);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(71, 16);
            this.label30.TabIndex = 17;
            this.label30.Text = "测量部位";
            // 
            // btn_fcs_delete
            // 
            this.btn_fcs_delete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_fcs_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_fcs_delete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_fcs_delete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_fcs_delete.Location = new System.Drawing.Point(352, 184);
            this.btn_fcs_delete.Name = "btn_fcs_delete";
            this.btn_fcs_delete.Size = new System.Drawing.Size(200, 40);
            this.btn_fcs_delete.TabIndex = 16;
            this.btn_fcs_delete.Text = "删除测量结果";
            this.btn_fcs_delete.UseVisualStyleBackColor = false;
            // 
            // btn_fcs_save
            // 
            this.btn_fcs_save.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_fcs_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_fcs_save.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_fcs_save.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_fcs_save.Location = new System.Drawing.Point(115, 184);
            this.btn_fcs_save.Name = "btn_fcs_save";
            this.btn_fcs_save.Size = new System.Drawing.Size(200, 40);
            this.btn_fcs_save.TabIndex = 15;
            this.btn_fcs_save.Text = "保存测量结果";
            this.btn_fcs_save.UseVisualStyleBackColor = false;
            // 
            // fcs_tartget_selected
            // 
            this.fcs_tartget_selected.FormattingEnabled = true;
            this.fcs_tartget_selected.Items.AddRange(new object[] {
            "左速率陀螺传感器安装支架",
            "右速率陀螺传感器安装支架",
            "加速度传感器组件"});
            this.fcs_tartget_selected.Location = new System.Drawing.Point(280, 20);
            this.fcs_tartget_selected.Name = "fcs_tartget_selected";
            this.fcs_tartget_selected.Size = new System.Drawing.Size(230, 20);
            this.fcs_tartget_selected.TabIndex = 14;
            // 
            // fcs_z_error
            // 
            this.fcs_z_error.BackColor = System.Drawing.SystemColors.Window;
            this.fcs_z_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.fcs_z_error.Location = new System.Drawing.Point(446, 123);
            this.fcs_z_error.Name = "fcs_z_error";
            this.fcs_z_error.Size = new System.Drawing.Size(106, 21);
            this.fcs_z_error.TabIndex = 6;
            // 
            // fcs_y_error
            // 
            this.fcs_y_error.BackColor = System.Drawing.SystemColors.Window;
            this.fcs_y_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.fcs_y_error.Location = new System.Drawing.Point(280, 123);
            this.fcs_y_error.Name = "fcs_y_error";
            this.fcs_y_error.Size = new System.Drawing.Size(107, 21);
            this.fcs_y_error.TabIndex = 5;
            // 
            // fcs_x_error
            // 
            this.fcs_x_error.BackColor = System.Drawing.SystemColors.Window;
            this.fcs_x_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.fcs_x_error.Location = new System.Drawing.Point(115, 123);
            this.fcs_x_error.Name = "fcs_x_error";
            this.fcs_x_error.Size = new System.Drawing.Size(110, 21);
            this.fcs_x_error.TabIndex = 4;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label27.Font = new System.Drawing.Font("宋体", 12F);
            this.label27.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label27.Location = new System.Drawing.Point(121, 70);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(63, 16);
            this.label27.TabIndex = 3;
            this.label27.Text = "X向偏差";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label28.Font = new System.Drawing.Font("宋体", 12F);
            this.label28.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label28.Location = new System.Drawing.Point(286, 70);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(63, 16);
            this.label28.TabIndex = 2;
            this.label28.Text = "Y向偏差";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label29.Font = new System.Drawing.Font("宋体", 12F);
            this.label29.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label29.Location = new System.Drawing.Point(452, 70);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 16);
            this.label29.TabIndex = 1;
            this.label29.Text = "Z向偏差";
            // 
            // btn_fcs_calcu_error
            // 
            this.btn_fcs_calcu_error.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_fcs_calcu_error.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_fcs_calcu_error.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_fcs_calcu_error.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_fcs_calcu_error.Location = new System.Drawing.Point(261, 460);
            this.btn_fcs_calcu_error.Name = "btn_fcs_calcu_error";
            this.btn_fcs_calcu_error.Size = new System.Drawing.Size(200, 40);
            this.btn_fcs_calcu_error.TabIndex = 31;
            this.btn_fcs_calcu_error.Text = "安装误差计算";
            this.btn_fcs_calcu_error.UseVisualStyleBackColor = false;
            // 
            // btn_fcs_loc
            // 
            this.btn_fcs_loc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_fcs_loc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_fcs_loc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_fcs_loc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_fcs_loc.Location = new System.Drawing.Point(38, 58);
            this.btn_fcs_loc.Name = "btn_fcs_loc";
            this.btn_fcs_loc.Size = new System.Drawing.Size(201, 38);
            this.btn_fcs_loc.TabIndex = 30;
            this.btn_fcs_loc.Text = "仪器定位";
            this.btn_fcs_loc.UseVisualStyleBackColor = false;
            // 
            // btn_fcs_means
            // 
            this.btn_fcs_means.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_fcs_means.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_fcs_means.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_fcs_means.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_fcs_means.Location = new System.Drawing.Point(39, 460);
            this.btn_fcs_means.Name = "btn_fcs_means";
            this.btn_fcs_means.Size = new System.Drawing.Size(200, 40);
            this.btn_fcs_means.TabIndex = 29;
            this.btn_fcs_means.Text = "靶点测量";
            this.btn_fcs_means.UseVisualStyleBackColor = false;
            // 
            // page_gd
            // 
            this.page_gd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.page_gd.Controls.Add(this.gd_save);
            this.page_gd.Controls.Add(this.btn_import_gd_std);
            this.page_gd.Controls.Add(this.gd_std_ptsname);
            this.page_gd.Controls.Add(this.gd_means_ptsname);
            this.page_gd.Controls.Add(this.label25);
            this.page_gd.Controls.Add(this.label39);
            this.page_gd.Controls.Add(this.dataGridView_gd);
            this.page_gd.Controls.Add(this.gd_dev_select);
            this.page_gd.Controls.Add(this.label49);
            this.page_gd.Controls.Add(this.gd_target_select);
            this.page_gd.Controls.Add(this.label31);
            this.page_gd.Controls.Add(this.panel_gd);
            this.page_gd.Controls.Add(this.btn_gd_calcu_error);
            this.page_gd.Controls.Add(this.btn_gd_loc);
            this.page_gd.Controls.Add(this.btn_gd_means);
            this.page_gd.Location = new System.Drawing.Point(4, 22);
            this.page_gd.Name = "page_gd";
            this.page_gd.Padding = new System.Windows.Forms.Padding(3);
            this.page_gd.Size = new System.Drawing.Size(1110, 821);
            this.page_gd.TabIndex = 9;
            this.page_gd.Text = "光电";
            // 
            // gd_save
            // 
            this.gd_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.gd_save.Font = new System.Drawing.Font("宋体", 12F);
            this.gd_save.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gd_save.Location = new System.Drawing.Point(474, 465);
            this.gd_save.Name = "gd_save";
            this.gd_save.Size = new System.Drawing.Size(200, 40);
            this.gd_save.TabIndex = 53;
            this.gd_save.Text = "完成测量";
            this.gd_save.UseVisualStyleBackColor = false;
            // 
            // btn_import_gd_std
            // 
            this.btn_import_gd_std.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_import_gd_std.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_import_gd_std.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_import_gd_std.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_import_gd_std.Location = new System.Drawing.Point(255, 57);
            this.btn_import_gd_std.Name = "btn_import_gd_std";
            this.btn_import_gd_std.Size = new System.Drawing.Size(201, 38);
            this.btn_import_gd_std.TabIndex = 52;
            this.btn_import_gd_std.Text = "导入理论值";
            this.btn_import_gd_std.UseVisualStyleBackColor = false;
            // 
            // gd_std_ptsname
            // 
            this.gd_std_ptsname.FormattingEnabled = true;
            this.gd_std_ptsname.Items.AddRange(new object[] {
            ""});
            this.gd_std_ptsname.Location = new System.Drawing.Point(244, 152);
            this.gd_std_ptsname.Name = "gd_std_ptsname";
            this.gd_std_ptsname.Size = new System.Drawing.Size(230, 20);
            this.gd_std_ptsname.TabIndex = 51;
            // 
            // gd_means_ptsname
            // 
            this.gd_means_ptsname.FormattingEnabled = true;
            this.gd_means_ptsname.Items.AddRange(new object[] {
            ""});
            this.gd_means_ptsname.Location = new System.Drawing.Point(244, 187);
            this.gd_means_ptsname.Name = "gd_means_ptsname";
            this.gd_means_ptsname.Size = new System.Drawing.Size(230, 20);
            this.gd_means_ptsname.TabIndex = 50;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label25.Location = new System.Drawing.Point(33, 191);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(103, 16);
            this.label25.TabIndex = 49;
            this.label25.Text = "光雷测量点集";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label39.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label39.Location = new System.Drawing.Point(31, 156);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(103, 16);
            this.label39.TabIndex = 48;
            this.label39.Text = "光雷标准点集";
            // 
            // dataGridView_gd
            // 
            this.dataGridView_gd.AllowUserToAddRows = false;
            this.dataGridView_gd.AllowUserToDeleteRows = false;
            this.dataGridView_gd.AllowUserToResizeColumns = false;
            this.dataGridView_gd.AllowUserToResizeRows = false;
            this.dataGridView_gd.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.dataGridView_gd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_gd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle95.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle95.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle95.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle95.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(195)))), ((int)(((byte)(197)))));
            dataGridViewCellStyle95.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle95.SelectionForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle95.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_gd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle95;
            this.dataGridView_gd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle96.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle96.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle96.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle96.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle96.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle96.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle96.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_gd.DefaultCellStyle = dataGridViewCellStyle96;
            this.dataGridView_gd.EnableHeadersVisualStyles = false;
            this.dataGridView_gd.Location = new System.Drawing.Point(34, 225);
            this.dataGridView_gd.Name = "dataGridView_gd";
            this.dataGridView_gd.ReadOnly = true;
            dataGridViewCellStyle97.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle97.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle97.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle97.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle97.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle97.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle97.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_gd.RowHeadersDefaultCellStyle = dataGridViewCellStyle97;
            this.dataGridView_gd.RowHeadersVisible = false;
            this.dataGridView_gd.RowHeadersWidth = 62;
            dataGridViewCellStyle98.BackColor = System.Drawing.Color.Transparent;
            this.dataGridView_gd.RowsDefaultCellStyle = dataGridViewCellStyle98;
            this.dataGridView_gd.RowTemplate.Height = 30;
            this.dataGridView_gd.Size = new System.Drawing.Size(710, 227);
            this.dataGridView_gd.TabIndex = 47;
            // 
            // gd_dev_select
            // 
            this.gd_dev_select.FormattingEnabled = true;
            this.gd_dev_select.Items.AddRange(new object[] {
            ""});
            this.gd_dev_select.Location = new System.Drawing.Point(244, 16);
            this.gd_dev_select.Name = "gd_dev_select";
            this.gd_dev_select.Size = new System.Drawing.Size(230, 20);
            this.gd_dev_select.TabIndex = 46;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label49.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label49.Location = new System.Drawing.Point(31, 18);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(71, 16);
            this.label49.TabIndex = 45;
            this.label49.Text = "设备选择";
            // 
            // gd_target_select
            // 
            this.gd_target_select.FormattingEnabled = true;
            this.gd_target_select.Items.AddRange(new object[] {
            "光电分布式孔径雷达",
            "DAS系统（前下-左）",
            "DAS系统（前下-右）",
            "DAS系统（前上）",
            "DAS系统（后上）",
            "DAS系统（后下-前）",
            "DAS系统（后下-后）"});
            this.gd_target_select.Location = new System.Drawing.Point(244, 117);
            this.gd_target_select.Name = "gd_target_select";
            this.gd_target_select.Size = new System.Drawing.Size(230, 20);
            this.gd_target_select.TabIndex = 41;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label31.Location = new System.Drawing.Point(31, 119);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(119, 16);
            this.label31.TabIndex = 40;
            this.label31.Text = "选择测量的设备";
            // 
            // panel_gd
            // 
            this.panel_gd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_gd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.panel_gd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_gd.Controls.Add(this.label35);
            this.panel_gd.Controls.Add(this.btn_gd_delete);
            this.panel_gd.Controls.Add(this.btn_gd_save);
            this.panel_gd.Controls.Add(this.gd_target_selected);
            this.panel_gd.Controls.Add(this.gd_z_error);
            this.panel_gd.Controls.Add(this.gd_y_error);
            this.panel_gd.Controls.Add(this.gd_x_error);
            this.panel_gd.Controls.Add(this.label32);
            this.panel_gd.Controls.Add(this.label33);
            this.panel_gd.Controls.Add(this.label34);
            this.panel_gd.Location = new System.Drawing.Point(35, 530);
            this.panel_gd.Name = "panel_gd";
            this.panel_gd.Size = new System.Drawing.Size(709, 256);
            this.panel_gd.TabIndex = 39;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("宋体", 12F);
            this.label35.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label35.Location = new System.Drawing.Point(139, 25);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(71, 16);
            this.label35.TabIndex = 17;
            this.label35.Text = "测量部位";
            // 
            // btn_gd_delete
            // 
            this.btn_gd_delete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_gd_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_gd_delete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_gd_delete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_gd_delete.Location = new System.Drawing.Point(352, 184);
            this.btn_gd_delete.Name = "btn_gd_delete";
            this.btn_gd_delete.Size = new System.Drawing.Size(200, 40);
            this.btn_gd_delete.TabIndex = 16;
            this.btn_gd_delete.Text = "删除测量结果";
            this.btn_gd_delete.UseVisualStyleBackColor = false;
            // 
            // btn_gd_save
            // 
            this.btn_gd_save.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_gd_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_gd_save.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_gd_save.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_gd_save.Location = new System.Drawing.Point(115, 184);
            this.btn_gd_save.Name = "btn_gd_save";
            this.btn_gd_save.Size = new System.Drawing.Size(200, 40);
            this.btn_gd_save.TabIndex = 15;
            this.btn_gd_save.Text = "保存测量结果";
            this.btn_gd_save.UseVisualStyleBackColor = false;
            // 
            // gd_target_selected
            // 
            this.gd_target_selected.FormattingEnabled = true;
            this.gd_target_selected.Items.AddRange(new object[] {
            "光电分布式孔径雷达",
            "DAS系统（前下-左）",
            "DAS系统（前下-右）",
            "DAS系统（前上）",
            "DAS系统（后上）",
            "DAS系统（后下-前）",
            "DAS系统（后下-后）"});
            this.gd_target_selected.Location = new System.Drawing.Point(280, 23);
            this.gd_target_selected.Name = "gd_target_selected";
            this.gd_target_selected.Size = new System.Drawing.Size(230, 20);
            this.gd_target_selected.TabIndex = 14;
            // 
            // gd_z_error
            // 
            this.gd_z_error.BackColor = System.Drawing.SystemColors.Window;
            this.gd_z_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gd_z_error.Location = new System.Drawing.Point(446, 126);
            this.gd_z_error.Name = "gd_z_error";
            this.gd_z_error.Size = new System.Drawing.Size(106, 21);
            this.gd_z_error.TabIndex = 6;
            // 
            // gd_y_error
            // 
            this.gd_y_error.BackColor = System.Drawing.SystemColors.Window;
            this.gd_y_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gd_y_error.Location = new System.Drawing.Point(280, 126);
            this.gd_y_error.Name = "gd_y_error";
            this.gd_y_error.Size = new System.Drawing.Size(107, 21);
            this.gd_y_error.TabIndex = 5;
            // 
            // gd_x_error
            // 
            this.gd_x_error.BackColor = System.Drawing.SystemColors.Window;
            this.gd_x_error.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gd_x_error.Location = new System.Drawing.Point(115, 126);
            this.gd_x_error.Name = "gd_x_error";
            this.gd_x_error.Size = new System.Drawing.Size(110, 21);
            this.gd_x_error.TabIndex = 4;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label32.Font = new System.Drawing.Font("宋体", 12F);
            this.label32.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label32.Location = new System.Drawing.Point(121, 73);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(63, 16);
            this.label32.TabIndex = 3;
            this.label32.Text = "X向偏差";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label33.Font = new System.Drawing.Font("宋体", 12F);
            this.label33.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label33.Location = new System.Drawing.Point(286, 73);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(63, 16);
            this.label33.TabIndex = 2;
            this.label33.Text = "Y向偏差";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label34.Font = new System.Drawing.Font("宋体", 12F);
            this.label34.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label34.Location = new System.Drawing.Point(452, 73);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(63, 16);
            this.label34.TabIndex = 1;
            this.label34.Text = "Z向偏差";
            // 
            // btn_gd_calcu_error
            // 
            this.btn_gd_calcu_error.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_gd_calcu_error.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_gd_calcu_error.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_gd_calcu_error.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_gd_calcu_error.Location = new System.Drawing.Point(253, 465);
            this.btn_gd_calcu_error.Name = "btn_gd_calcu_error";
            this.btn_gd_calcu_error.Size = new System.Drawing.Size(200, 40);
            this.btn_gd_calcu_error.TabIndex = 38;
            this.btn_gd_calcu_error.Text = "安装误差计算";
            this.btn_gd_calcu_error.UseVisualStyleBackColor = false;
            // 
            // btn_gd_loc
            // 
            this.btn_gd_loc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_gd_loc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_gd_loc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_gd_loc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_gd_loc.Location = new System.Drawing.Point(36, 57);
            this.btn_gd_loc.Name = "btn_gd_loc";
            this.btn_gd_loc.Size = new System.Drawing.Size(201, 38);
            this.btn_gd_loc.TabIndex = 37;
            this.btn_gd_loc.Text = "仪器定位";
            this.btn_gd_loc.UseVisualStyleBackColor = false;
            // 
            // btn_gd_means
            // 
            this.btn_gd_means.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_gd_means.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_gd_means.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_gd_means.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_gd_means.Location = new System.Drawing.Point(35, 465);
            this.btn_gd_means.Name = "btn_gd_means";
            this.btn_gd_means.Size = new System.Drawing.Size(200, 40);
            this.btn_gd_means.TabIndex = 36;
            this.btn_gd_means.Text = "靶点测量";
            this.btn_gd_means.UseVisualStyleBackColor = false;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "操作";
            this.dataGridViewButtonColumn1.MinimumWidth = 8;
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "删除";
            this.dataGridViewButtonColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn53
            // 
            this.dataGridViewTextBoxColumn53.HeaderText = "Z";
            this.dataGridViewTextBoxColumn53.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn53.Name = "dataGridViewTextBoxColumn53";
            this.dataGridViewTextBoxColumn53.Width = 120;
            // 
            // dataGridViewTextBoxColumn52
            // 
            this.dataGridViewTextBoxColumn52.HeaderText = "Y";
            this.dataGridViewTextBoxColumn52.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn52.Name = "dataGridViewTextBoxColumn52";
            this.dataGridViewTextBoxColumn52.Width = 120;
            // 
            // dataGridViewTextBoxColumn51
            // 
            this.dataGridViewTextBoxColumn51.HeaderText = "X";
            this.dataGridViewTextBoxColumn51.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn51.Name = "dataGridViewTextBoxColumn51";
            this.dataGridViewTextBoxColumn51.Width = 120;
            // 
            // dataGridViewTextBoxColumn50
            // 
            this.dataGridViewTextBoxColumn50.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle99.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle99.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle99.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(195)))), ((int)(((byte)(197)))));
            dataGridViewCellStyle99.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn50.DefaultCellStyle = dataGridViewCellStyle99;
            this.dataGridViewTextBoxColumn50.HeaderText = "测量点";
            this.dataGridViewTextBoxColumn50.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn50.Name = "dataGridViewTextBoxColumn50";
            this.dataGridViewTextBoxColumn50.ReadOnly = true;
            // 
            // close_main
            // 
            this.close_main.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.close_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.close_main.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.close_main.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.close_main.Location = new System.Drawing.Point(1686, 969);
            this.close_main.Name = "close_main";
            this.close_main.Size = new System.Drawing.Size(163, 56);
            this.close_main.TabIndex = 13;
            this.close_main.Text = "退出";
            this.close_main.UseVisualStyleBackColor = false;
            this.close_main.Click += new System.EventHandler(this.close_main_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.Location = new System.Drawing.Point(376, 120);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(337, 480);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // head_box
            // 
            this.head_box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.head_box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.head_box.Image = ((System.Drawing.Image)(resources.GetObject("head_box.Image")));
            this.head_box.Location = new System.Drawing.Point(12, 12);
            this.head_box.Name = "head_box";
            this.head_box.Size = new System.Drawing.Size(1530, 66);
            this.head_box.TabIndex = 23;
            this.head_box.TabStop = false;
            // 
            // btn_device
            // 
            this.btn_device.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_device.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.btn_device.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_device.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_device.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_device.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_device.Image = ((System.Drawing.Image)(resources.GetObject("btn_device.Image")));
            this.btn_device.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_device.Location = new System.Drawing.Point(84, 133);
            this.btn_device.Name = "btn_device";
            this.btn_device.Size = new System.Drawing.Size(236, 61);
            this.btn_device.TabIndex = 1;
            this.btn_device.Text = "设备连接";
            this.btn_device.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_device.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_device.UseVisualStyleBackColor = false;
            this.btn_device.Click += new System.EventHandler(this.button17_Click);
            // 
            // btn_ODA_radar
            // 
            this.btn_ODA_radar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_ODA_radar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.btn_ODA_radar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ODA_radar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ODA_radar.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ODA_radar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_ODA_radar.Image = ((System.Drawing.Image)(resources.GetObject("btn_ODA_radar.Image")));
            this.btn_ODA_radar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ODA_radar.Location = new System.Drawing.Point(84, 893);
            this.btn_ODA_radar.Name = "btn_ODA_radar";
            this.btn_ODA_radar.Size = new System.Drawing.Size(236, 61);
            this.btn_ODA_radar.TabIndex = 10;
            this.btn_ODA_radar.Text = "光电分布式孔径雷达";
            this.btn_ODA_radar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ODA_radar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_ODA_radar.UseVisualStyleBackColor = false;
            this.btn_ODA_radar.Click += new System.EventHandler(this.btn_ODA_radar_Click);
            // 
            // btn_FCS
            // 
            this.btn_FCS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_FCS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.btn_FCS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_FCS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FCS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_FCS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_FCS.Image = ((System.Drawing.Image)(resources.GetObject("btn_FCS.Image")));
            this.btn_FCS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_FCS.Location = new System.Drawing.Point(84, 808);
            this.btn_FCS.Name = "btn_FCS";
            this.btn_FCS.Size = new System.Drawing.Size(236, 61);
            this.btn_FCS.TabIndex = 9;
            this.btn_FCS.Text = "飞控系统";
            this.btn_FCS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_FCS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_FCS.UseVisualStyleBackColor = false;
            this.btn_FCS.Click += new System.EventHandler(this.btn_FCS_Click);
            // 
            // btn_IRS
            // 
            this.btn_IRS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_IRS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.btn_IRS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_IRS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IRS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_IRS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_IRS.Image = ((System.Drawing.Image)(resources.GetObject("btn_IRS.Image")));
            this.btn_IRS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_IRS.Location = new System.Drawing.Point(84, 723);
            this.btn_IRS.Name = "btn_IRS";
            this.btn_IRS.Size = new System.Drawing.Size(236, 61);
            this.btn_IRS.TabIndex = 8;
            this.btn_IRS.Text = "惯性参考子系统";
            this.btn_IRS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_IRS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_IRS.UseVisualStyleBackColor = false;
            this.btn_IRS.Click += new System.EventHandler(this.btn_IRS_Click);
            // 
            // btn_disp_cont
            // 
            this.btn_disp_cont.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_disp_cont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.btn_disp_cont.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_disp_cont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_disp_cont.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_disp_cont.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_disp_cont.Image = ((System.Drawing.Image)(resources.GetObject("btn_disp_cont.Image")));
            this.btn_disp_cont.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_disp_cont.Location = new System.Drawing.Point(84, 638);
            this.btn_disp_cont.Name = "btn_disp_cont";
            this.btn_disp_cont.Size = new System.Drawing.Size(236, 61);
            this.btn_disp_cont.TabIndex = 7;
            this.btn_disp_cont.Text = "座舱显示与控制系统";
            this.btn_disp_cont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_disp_cont.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_disp_cont.UseVisualStyleBackColor = false;
            this.btn_disp_cont.Click += new System.EventHandler(this.btn_disp_cont_Click);
            // 
            // btn_CNI
            // 
            this.btn_CNI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_CNI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.btn_CNI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_CNI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CNI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CNI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_CNI.Image = ((System.Drawing.Image)(resources.GetObject("btn_CNI.Image")));
            this.btn_CNI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CNI.Location = new System.Drawing.Point(84, 553);
            this.btn_CNI.Name = "btn_CNI";
            this.btn_CNI.Size = new System.Drawing.Size(236, 61);
            this.btn_CNI.TabIndex = 6;
            this.btn_CNI.Text = "CNI子系统";
            this.btn_CNI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CNI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_CNI.UseVisualStyleBackColor = false;
            this.btn_CNI.Click += new System.EventHandler(this.btn_CNI_Click);
            // 
            // btn_elec_war
            // 
            this.btn_elec_war.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_elec_war.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.btn_elec_war.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_elec_war.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_elec_war.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_elec_war.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_elec_war.Image = ((System.Drawing.Image)(resources.GetObject("btn_elec_war.Image")));
            this.btn_elec_war.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_elec_war.Location = new System.Drawing.Point(84, 468);
            this.btn_elec_war.Name = "btn_elec_war";
            this.btn_elec_war.Size = new System.Drawing.Size(236, 61);
            this.btn_elec_war.TabIndex = 5;
            this.btn_elec_war.Text = "电子战系统";
            this.btn_elec_war.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_elec_war.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_elec_war.UseVisualStyleBackColor = false;
            this.btn_elec_war.Click += new System.EventHandler(this.btn_elec_war_Click);
            // 
            // btn_radar
            // 
            this.btn_radar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_radar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.btn_radar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_radar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_radar.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_radar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_radar.Image = ((System.Drawing.Image)(resources.GetObject("btn_radar.Image")));
            this.btn_radar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_radar.Location = new System.Drawing.Point(84, 383);
            this.btn_radar.Name = "btn_radar";
            this.btn_radar.Size = new System.Drawing.Size(236, 61);
            this.btn_radar.TabIndex = 4;
            this.btn_radar.Text = "雷达系统";
            this.btn_radar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_radar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_radar.UseVisualStyleBackColor = false;
            this.btn_radar.Click += new System.EventHandler(this.btn_radar_Click);
            // 
            // btn_plane_meansure
            // 
            this.btn_plane_meansure.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_plane_meansure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.btn_plane_meansure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_plane_meansure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_plane_meansure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_plane_meansure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_plane_meansure.Image = ((System.Drawing.Image)(resources.GetObject("btn_plane_meansure.Image")));
            this.btn_plane_meansure.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_plane_meansure.Location = new System.Drawing.Point(84, 298);
            this.btn_plane_meansure.Name = "btn_plane_meansure";
            this.btn_plane_meansure.Size = new System.Drawing.Size(236, 61);
            this.btn_plane_meansure.TabIndex = 3;
            this.btn_plane_meansure.Text = "全机水平测量";
            this.btn_plane_meansure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_plane_meansure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_plane_meansure.UseVisualStyleBackColor = false;
            this.btn_plane_meansure.Click += new System.EventHandler(this.btn_plane_meansure_Click);
            // 
            // btn_gnd_meansure
            // 
            this.btn_gnd_meansure.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_gnd_meansure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.btn_gnd_meansure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_gnd_meansure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_gnd_meansure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_gnd_meansure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_gnd_meansure.Image = ((System.Drawing.Image)(resources.GetObject("btn_gnd_meansure.Image")));
            this.btn_gnd_meansure.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_gnd_meansure.Location = new System.Drawing.Point(84, 218);
            this.btn_gnd_meansure.Name = "btn_gnd_meansure";
            this.btn_gnd_meansure.Size = new System.Drawing.Size(236, 61);
            this.btn_gnd_meansure.TabIndex = 2;
            this.btn_gnd_meansure.Text = "仪器定位";
            this.btn_gnd_meansure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_gnd_meansure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_gnd_meansure.UseVisualStyleBackColor = false;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(1900, 1037);
            this.Controls.Add(this.close_main);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabcontrol_main);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.head_box);
            this.Controls.Add(this.mean_process);
            this.Controls.Add(this.btn_device);
            this.Controls.Add(this.btn_ODA_radar);
            this.Controls.Add(this.btn_FCS);
            this.Controls.Add(this.btn_IRS);
            this.Controls.Add(this.btn_disp_cont);
            this.Controls.Add(this.btn_CNI);
            this.Controls.Add(this.btn_elec_war);
            this.Controls.Add(this.btn_radar);
            this.Controls.Add(this.btn_plane_meansure);
            this.Controls.Add(this.btn_gnd_meansure);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Main";
            this.tabcontrol_main.ResumeLayout(false);
            this.page_dev.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dev)).EndInit();
            this.panel_cam.ResumeLayout(false);
            this.page_gnd.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_gnd)).EndInit();
            this.page_planeFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PF)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.page_radar.ResumeLayout(false);
            this.page_radar.PerformLayout();
            this.panel_radar.ResumeLayout(false);
            this.panel_radar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.page_dzz.ResumeLayout(false);
            this.page_dzz.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dzz)).EndInit();
            this.panel_dzz.ResumeLayout(false);
            this.panel_dzz.PerformLayout();
            this.page_cni.ResumeLayout(false);
            this.page_cni.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_cni)).EndInit();
            this.panel_cni.ResumeLayout(false);
            this.panel_cni.PerformLayout();
            this.page_px.ResumeLayout(false);
            this.page_px.PerformLayout();
            this.panel_px.ResumeLayout(false);
            this.panel_px.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_px)).EndInit();
            this.page_irs.ResumeLayout(false);
            this.page_irs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_irs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.page_fcs.ResumeLayout(false);
            this.page_fcs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_fcs)).EndInit();
            this.panel_fcs.ResumeLayout(false);
            this.panel_fcs.PerformLayout();
            this.page_gd.ResumeLayout(false);
            this.page_gd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_gd)).EndInit();
            this.panel_gd.ResumeLayout(false);
            this.panel_gd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.head_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_gnd_meansure;
        private System.Windows.Forms.Button btn_plane_meansure;
        private System.Windows.Forms.Button btn_radar;
        private System.Windows.Forms.Button btn_elec_war;
        private System.Windows.Forms.Button btn_CNI;
        private System.Windows.Forms.Button btn_disp_cont;
        private System.Windows.Forms.Button btn_IRS;
        private System.Windows.Forms.Button btn_FCS;
        private System.Windows.Forms.Button btn_ODA_radar;
        private System.Windows.Forms.Button btn_device;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabcontrol_main;
        private System.Windows.Forms.TabPage page_dev;
        private System.Windows.Forms.Button btn_dev_connect;
        private System.Windows.Forms.DataGridView dataGridView_dev;
        private System.Windows.Forms.Button btn_dev_add;
        private System.Windows.Forms.TabPage page_planeFrame;
        public System.Windows.Forms.RichTextBox mean_process;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage page_radar;
        private System.Windows.Forms.PictureBox head_box;
        private System.Windows.Forms.TabPage page_dzz;
        private System.Windows.Forms.TabPage page_cni;
        private System.Windows.Forms.TabPage page_px;
        private System.Windows.Forms.TabPage page_fcs;
        private System.Windows.Forms.TabPage page_gd;
        private System.Windows.Forms.Button btn_radar_loc;
        private System.Windows.Forms.Panel panel_radar;
        private System.Windows.Forms.TextBox radar_z_error;
        private System.Windows.Forms.TextBox radar_y_error;
        private System.Windows.Forms.TextBox radar_x_error;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel_dzz;
        private System.Windows.Forms.TextBox dzz_z_error;
        private System.Windows.Forms.TextBox dzz_y_error;
        private System.Windows.Forms.TextBox dzz_x_error;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_war_loc;
        private System.Windows.Forms.Button btn_dzz_means;
        private System.Windows.Forms.Button btn_px_test;
        private System.Windows.Forms.Button btn_px_loc;
        private System.Windows.Forms.Button btn_px_means;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox dzz_target_select;
        private System.Windows.Forms.Button btn_dzz_delete;
        private System.Windows.Forms.Button btn_dzz_save;
        private System.Windows.Forms.ComboBox comboBox_dzz_devselected;
        private System.Windows.Forms.ComboBox cni_target_select;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel_cni;
        private System.Windows.Forms.Button btn_cni_delete;
        private System.Windows.Forms.Button btn_cni_save;
        private System.Windows.Forms.ComboBox comboBox_cni_target_selected;
        private System.Windows.Forms.TextBox cni_z_error;
        private System.Windows.Forms.TextBox cni_y_error;
        private System.Windows.Forms.TextBox cni_x_error;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btn_cni_loc;
        private System.Windows.Forms.Button btn_cni_means;
        private System.Windows.Forms.ComboBox fcs_target_select;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel_fcs;
        private System.Windows.Forms.Button btn_fcs_delete;
        private System.Windows.Forms.Button btn_fcs_save;
        private System.Windows.Forms.ComboBox fcs_tartget_selected;
        private System.Windows.Forms.TextBox fcs_z_error;
        private System.Windows.Forms.TextBox fcs_y_error;
        private System.Windows.Forms.TextBox fcs_x_error;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btn_fcs_calcu_error;
        private System.Windows.Forms.Button btn_fcs_loc;
        private System.Windows.Forms.Button btn_fcs_means;
        private System.Windows.Forms.ComboBox gd_target_select;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Panel panel_gd;
        private System.Windows.Forms.Button btn_gd_delete;
        private System.Windows.Forms.Button btn_gd_save;
        private System.Windows.Forms.ComboBox gd_target_selected;
        private System.Windows.Forms.TextBox gd_z_error;
        private System.Windows.Forms.TextBox gd_y_error;
        private System.Windows.Forms.TextBox gd_x_error;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button btn_gd_calcu_error;
        private System.Windows.Forms.Button btn_gd_loc;
        private System.Windows.Forms.Button btn_gd_means;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox comboBox_radar_devselect;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.ComboBox comboBox_dzz_devselect;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.ComboBox cni_dev_select;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox px_dev_select;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.ComboBox fcs_dev_select;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.ComboBox gd_dev_select;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.DataGridView dataGridView_dzz;
        private System.Windows.Forms.DataGridView dataGridView_cni;
        private System.Windows.Forms.DataGridView dataGridView_px;
        private System.Windows.Forms.Button btn_plane;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn53;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn52;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn51;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn50;
        private System.Windows.Forms.DataGridView dataGridView_fcs;
        private System.Windows.Forms.DataGridView dataGridView_gd;
        private System.Windows.Forms.Panel panel_cam;
        private System.Windows.Forms.Button btn_table_connect;
        private System.Windows.Forms.Button btn_cam_connect;
        private System.Windows.Forms.ComboBox dzz_std;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.ComboBox cni_means_ptsname;
        private System.Windows.Forms.ComboBox px_means_ptsname;
        private System.Windows.Forms.Button btn_import_dzz_std;
        private System.Windows.Forms.Button btn_dzz_calcu_error;
        private System.Windows.Forms.ComboBox cni_std_ptsname;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Button btn_import_cni_std;
        private System.Windows.Forms.Button btn_cni_calcu_error;
        private System.Windows.Forms.Button btn_import_px_std;
        private System.Windows.Forms.ComboBox px_std_ptsname;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Button btn_import_fcs_std;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox fcs_std_ptsname;
        private System.Windows.Forms.ComboBox fcs_means_ptsname;
        private System.Windows.Forms.Panel panel_px;
        private System.Windows.Forms.Button btn_px_delete;
        private System.Windows.Forms.Button btn_px_save;
        private System.Windows.Forms.TextBox px_z_error;
        private System.Windows.Forms.TextBox px_y_error;
        private System.Windows.Forms.TextBox px_x_error;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox gd_std_ptsname;
        private System.Windows.Forms.ComboBox gd_means_ptsname;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Button btn_import_gd_std;
        private System.Windows.Forms.TabPage page_irs;
        private System.Windows.Forms.Button btn_irs_calcu_error;
        private System.Windows.Forms.Button btn_import_irs_std;
        private System.Windows.Forms.ComboBox irs_means_ptsname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox irs_std_ptsname;
        private System.Windows.Forms.DataGridView dataGridView_irs;
        private System.Windows.Forms.ComboBox irs_dev_select;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.ComboBox irs_target_select;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_irs_delete;
        private System.Windows.Forms.Button btn_irs_save;
        private System.Windows.Forms.ComboBox irs_target_selected;
        private System.Windows.Forms.TextBox irs_z_error;
        private System.Windows.Forms.TextBox irs_y_error;
        private System.Windows.Forms.TextBox irs_x_error;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Button btn_irs_loc;
        private System.Windows.Forms.Button btn_irs_means;
        private System.Windows.Forms.Button close_main;
        private System.Windows.Forms.Button cni_save;
        private System.Windows.Forms.Button px_save;
        private System.Windows.Forms.Button irs_save;
        private System.Windows.Forms.Button fcs_save;
        private System.Windows.Forms.Button gd_save;
        private System.Windows.Forms.Button ConnectSA;
        private System.Windows.Forms.Button btn_dev_delete;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.ComboBox combox_planeFrame;
        private System.Windows.Forms.Button plane_import;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage page_gnd;
        private System.Windows.Forms.TextBox text_pf_theo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Button plane_select_pointGroup;
        private System.Windows.Forms.TextBox text_pf_mean;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ComboBox comboBox_sel_2;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.ComboBox comboBox_sel_1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView_PF;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button gnd_choose_theo;
        private System.Windows.Forms.Button gnd_import;
        private System.Windows.Forms.Button gnd_frame;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox text_gnd_mean;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Button gnd_meansure;
        private System.Windows.Forms.ComboBox comboBox_gnd;
        private System.Windows.Forms.TextBox text_gnd_theo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridView_gnd;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}