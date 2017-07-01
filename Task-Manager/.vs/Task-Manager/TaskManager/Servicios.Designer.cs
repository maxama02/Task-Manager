namespace TaskManager
{
    partial class Servicios
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Servicios));
            this.contextMenuServicios = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemIniciar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPausar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDetener = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvServicios = new System.Windows.Forms.DataGridView();
            this.statusStripServicios = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCorriendo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnActualizarServicios = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCPU = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuServicios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            this.statusStripServicios.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuServicios
            // 
            this.contextMenuServicios.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemIniciar,
            this.toolStripMenuItemPausar,
            this.toolStripMenuItemDetener});
            this.contextMenuServicios.Name = "contextMenuServicios";
            this.contextMenuServicios.Size = new System.Drawing.Size(160, 70);
            // 
            // toolStripMenuItemIniciar
            // 
            this.toolStripMenuItemIniciar.Name = "toolStripMenuItemIniciar";
            this.toolStripMenuItemIniciar.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItemIniciar.Text = "Iniciar Servicio";
            this.toolStripMenuItemIniciar.Click += new System.EventHandler(this.toolStripMenuItemIniciar_Click);
            // 
            // toolStripMenuItemPausar
            // 
            this.toolStripMenuItemPausar.Name = "toolStripMenuItemPausar";
            this.toolStripMenuItemPausar.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItemPausar.Text = "Pausar Servicio";
            this.toolStripMenuItemPausar.Click += new System.EventHandler(this.toolStripMenuItemPausar_Click);
            // 
            // toolStripMenuItemDetener
            // 
            this.toolStripMenuItemDetener.Name = "toolStripMenuItemDetener";
            this.toolStripMenuItemDetener.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItemDetener.Text = "Detener Servicio";
            this.toolStripMenuItemDetener.Click += new System.EventHandler(this.toolStripMenuItemDetener_Click);
            // 
            // dgvServicios
            // 
            this.dgvServicios.AllowUserToAddRows = false;
            this.dgvServicios.AllowUserToDeleteRows = false;
            this.dgvServicios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServicios.Location = new System.Drawing.Point(0, 0);
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.ReadOnly = true;
            this.dgvServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServicios.Size = new System.Drawing.Size(589, 405);
            this.dgvServicios.TabIndex = 1;
            this.dgvServicios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellContentClick);
            this.dgvServicios.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvServicios_CellMouseDown);
            // 
            // statusStripServicios
            // 
            this.statusStripServicios.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblCorriendo,
            this.toolStripStatusLabel2,
            this.lblCPU,
            this.toolStripDropDownButton1});
            this.statusStripServicios.Location = new System.Drawing.Point(0, 383);
            this.statusStripServicios.Name = "statusStripServicios";
            this.statusStripServicios.Size = new System.Drawing.Size(589, 22);
            this.statusStripServicios.TabIndex = 4;
            this.statusStripServicios.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(179, 17);
            this.toolStripStatusLabel1.Text = "Cantidad de servicios corriendo: ";
            // 
            // lblCorriendo
            // 
            this.lblCorriendo.Name = "lblCorriendo";
            this.lblCorriendo.Size = new System.Drawing.Size(60, 17);
            this.lblCorriendo.Text = "Corriendo";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnActualizarServicios});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // btnActualizarServicios
            // 
            this.btnActualizarServicios.Name = "btnActualizarServicios";
            this.btnActualizarServicios.Size = new System.Drawing.Size(152, 22);
            this.btnActualizarServicios.Text = "Actualizar";
            this.btnActualizarServicios.Click += new System.EventHandler(this.btnActualizarServicios_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(64, 17);
            this.toolStripStatusLabel2.Text = "Carga CPU";
            // 
            // lblCPU
            // 
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(27, 17);
            this.lblCPU.Text = "%%";
            // 
            // Servicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 405);
            this.Controls.Add(this.statusStripServicios);
            this.Controls.Add(this.dgvServicios);
            this.Name = "Servicios";
            this.Text = "Servicios Ejecutandose";
            this.contextMenuServicios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            this.statusStripServicios.ResumeLayout(false);
            this.statusStripServicios.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuServicios;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPausar;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDetener;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIniciar;
        private System.Windows.Forms.DataGridView dgvServicios;
        private System.Windows.Forms.StatusStrip statusStripServicios;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblCorriendo;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnActualizarServicios;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblCPU;
    }
}