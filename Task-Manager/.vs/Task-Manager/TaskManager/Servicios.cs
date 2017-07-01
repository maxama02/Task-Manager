using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Diagnostics;

namespace TaskManager
{
    public partial class Servicios : Form
    {
        //de esta manera inicia en procesos
        //public Process[] listaProc;
        public ServiceController[] listaServ;//se utiliza la referenci System.ServiceProcess de la libreria System.ServiceProcess.dll
        BindingSource source;
        ServiciosClass serviciosClass;
        int espera;
        TimeSpan tiempoFuera ;

        //variables necesarias


        public Servicios()
        {
            InitializeComponent();
            //se adopta el mismo periodo de refrescamiento que en procesos

            //se inicia tiempo de espera para cambio estado proceso
            espera = 5000;
            tiempoFuera = TimeSpan.FromMilliseconds(espera);

            //listaServ;// cargo los servicios en el inicio de la creacion del form
            iniciaListas();
            refrescarToolStripMenuItem_Click(null, null);//accesa al event handler e inicia el grid view
            Timer cronometro = new Timer();
            cronometro.Interval = 200000;//dos minutos de refrescamiento
            cronometro.Tick += refrescarToolStripMenuItem_Click; //refresca el grid view
            cronometro.Start();

        }

        private void formServicios_Load(object sender, EventArgs e)
        {
            //se llama el proceso de carga
            CargarServicios();
        }
        public void iniciaListas()
        {
            //llama al controlador de servicios y se asigna a las variables
            listaServ = (ServiceController[])ServiceController.GetServices();
            lblCorriendo.Text = listaServ.Where(x => x.Status == ServiceControllerStatus.Running).ToList().Count.ToString();
        }

        public void CargarServicios()
        {
            
            try
            {
                var tablaDatosServ = new DataTable("Ejecutandose");
                source = new BindingSource();

                //datos porcentuales de los servicios
                lblCPU.Text = getPorcentajeCPUTotal();//calcual el porcentaje de CPU utilizado
                //lblMemoria.Text = Convert.ToString(Math.Round((memoriaTotal() / 1000000), 2)) + "%";//calcula la memoria total manejada en terminos de peso porcentual en MB
                //...

                tablaDatosServ.Columns.Add("Proceso ID");
                tablaDatosServ.Columns.Add("Nombre");
                tablaDatosServ.Columns.Add("Descripcion");
                tablaDatosServ.Columns.Add("Usuario");
                tablaDatosServ.Columns.Add("Estado");


                //int i = 0;  enumeracion de los servicios, pero no es el process id, la enumeracion la puede hacer el gridview

                foreach (var ser in listaServ)
                {
                    serviciosClass = new ServiciosClass();
                    ServiciosClass servicio = obtenerServicio(ser.ServiceName.ToString());

                    serviciosClass.Id = servicio.Id;
                    serviciosClass.Nombre = ser.ServiceName.ToString();
                    serviciosClass.Desc = ser.DisplayName.ToString();
                    serviciosClass.UsuarioServicio = servicio.UsuarioServicio;
                    serviciosClass.Estado = ser.Status.ToString();

                    if (servicio.Id.Equals("0"))
                        serviciosClass.Id = string.Empty;

                    try
                    {
                        tablaDatosServ.Rows.Add(serviciosClass.Id, serviciosClass.Nombre, serviciosClass.Desc, serviciosClass.UsuarioServicio, serviciosClass.Estado);
                    }
                    catch (Exception w32)
                    {
                        MessageBox.Show(w32.Message.ToString(), "Error al Cargar la tabla interna de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //i++;

                }

                try
                {

                    tablaDatosServ.AcceptChanges();
                    source.DataSource = tablaDatosServ;//ejemplo sin utilizar data source2

                    int scroll = dgvServicios.FirstDisplayedScrollingRowIndex;
                    this.dgvServicios.DataSource = source;//ejemplo sin el data source1

                    if (scroll != -1)
                    {
                        dgvServicios.FirstDisplayedScrollingRowIndex = scroll;
                    }

                }
                catch (Exception w32)
                {
                    MessageBox.Show(w32.Message.ToString(), "Error Al Cargar el gridview", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Win32Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Error Al Cargar Vista", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refrescarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaListas();
            CargarServicios();
        }



        //funcion interna que obtiene el process ID del servicio mediante el DLL
        private ServiciosClass obtenerServicio(string nombreServicio)
        {
            ServiciosClass servicio = new ServiciosClass();

            System.Management.SelectQuery consulta = new System.Management.SelectQuery(string.Format("select processid, startname from Win32_Service where name = '{0}'", nombreServicio));
            System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher(consulta);

            foreach (System.Management.ManagementObject servicioController in searcher.Get())
            {
                try
                {
                    servicio.Id = servicioController["PROCESSID"].ToString();
                    servicio.UsuarioServicio = servicioController["STARTNAME"].ToString();
                }
                catch (Exception)
                {
                    servicio.Id = string.Empty;
                    servicio.UsuarioServicio = "Acceso Denegado";
                     
                }
            }
            return servicio;

        }

        //Evento al seleccionar con el click derecho alguna de las filas del gridview
        private void dgvServicios_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                dgvServicios.CurrentCell = dgvServicios.Rows[e.RowIndex].Cells[e.ColumnIndex];//despues de que el usuario selecciono con el click derecho del mouse una columna, la guarda en el gridview la fila seleccionada

                //determina si el servicio esta corriendo y da las opciones adecuadas
                if (servicioCorriendo(dgvServicios.Rows[dgvServicios.CurrentCellAddress.Y].Cells[1].Value.ToString()))
                    this.toolStripMenuItemIniciar.Enabled = false;
                this.toolStripMenuItemPausar.Enabled = true;
                this.toolStripMenuItemDetener.Enabled = true;

                //determina si el servicio no esta corriendo y da las opciones adecuadas
                if (!servicioCorriendo(dgvServicios.Rows[dgvServicios.CurrentCellAddress.Y].Cells[1].Value.ToString()))
                {
                    this.toolStripMenuItemIniciar.Enabled = true;
                    this.toolStripMenuItemPausar.Enabled = false;
                    this.toolStripMenuItemDetener.Enabled = false;
                }
                //hace visible el menu
                this.contextMenuServicios.Show(Cursor.Position);

            }
        }

        //Funcion que determina si el servicio esta corriendo o no
        private Boolean servicioCorriendo(string nombreServicio)
        {
            return listaServ.FirstOrDefault(x => x.ServiceName.Equals(nombreServicio)).Status == ServiceControllerStatus.Running;

        }

        private void dgvServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnActualizarServicios_Click(object sender, EventArgs e)
        {
            CargarServicios();
        }

        private void toolStripMenuItemIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                //Por medio de esta sintaxis lambda, se obtiene el servicio con el nombre seleccionado en el grid view
                ServiceController.GetServices().FirstOrDefault(x => x.ServiceName.Equals(dgvServicios.Rows[dgvServicios.CurrentCellAddress.Y].Cells[1].Value.ToString())).Start();
                ServiceController.GetServices().FirstOrDefault(x => x.ServiceName.Equals(dgvServicios.Rows[dgvServicios.CurrentCellAddress.Y].Cells[1].Value.ToString())).WaitForStatus(ServiceControllerStatus.Running, tiempoFuera);
                //Despues de finalizar el servicio se pregunta al usuario si quiere cargar la vista de nuevo
                if (MessageBox.Show("Desea actualizar la vista de servicios?", "Servicio Iniciado Exitosamente", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    iniciaListas();
                    CargarServicios();
                }
            }
            catch (Exception ex)
            {
                //Notifica al usuario de algun error al cargar el servicio
                MessageBox.Show(ex.Message.ToString(), "Error Al Cerrar el Servicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItemPausar_Click(object sender, EventArgs e)
        {
            try
            {
                //Por medio de esta sintaxis lambda, se obtiene el servicio con el nombre seleccionado en el grid view
                ServiceController.GetServices().FirstOrDefault(x => x.ServiceName.Equals(dgvServicios.Rows[dgvServicios.CurrentCellAddress.Y].Cells[1].Value.ToString())).Pause();
                ServiceController.GetServices().FirstOrDefault(x => x.ServiceName.Equals(dgvServicios.Rows[dgvServicios.CurrentCellAddress.Y].Cells[1].Value.ToString())).WaitForStatus(ServiceControllerStatus.Running, tiempoFuera);
                //Despues de finalizar el servicio se pregunta al usuario si quiere cargar la vista de nuevo
                if (MessageBox.Show("Desea actualizar la vista de servicios?", "Servicio Pausado Exitosamente", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    iniciaListas();
                    CargarServicios();
                }
            }
            catch (Exception ex)
            {
                //Notifica al usuario de algun error al cargar el servicio
                MessageBox.Show(ex.Message.ToString(), "Error Al Cerrar el Servicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItemDetener_Click(object sender, EventArgs e)
        {
            try
            {
                //Por medio de esta sintaxis lambda, se obtiene el servicio con el nombre seleccionado en el grid view
                ServiceController.GetServices().FirstOrDefault(x => x.ServiceName.Equals(dgvServicios.Rows[dgvServicios.CurrentCellAddress.Y].Cells[1].Value.ToString())).Stop();
                ServiceController.GetServices().FirstOrDefault(x => x.ServiceName.Equals(dgvServicios.Rows[dgvServicios.CurrentCellAddress.Y].Cells[1].Value.ToString())).WaitForStatus(ServiceControllerStatus.Running, tiempoFuera);

                //Despues de finalizar el proceso pregunta al usuario si quiere cargar la vista de nuevo
                if (MessageBox.Show("Desea actualizar la vista de servicios?", "Proceso Iniciado Exitosamente", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    iniciaListas();
                    CargarServicios();
                }
            }
            catch (Exception ex)
            {
                //Notifica al usuario de algun error al cargar el servicio
                MessageBox.Show(ex.Message.ToString(), "Error Al Cerrar el Servicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Funcion que calcula el porcentaje de CPU usado en todos los servicios
        public string getPorcentajeCPUTotal()
        {
            try
            {
                var contadorCPU = new PerformanceCounter("Process", "% Processor Time", "_Total", true);
                contadorCPU.NextValue();
                System.Threading.Thread.Sleep(100);
                int aux = (int)contadorCPU.NextValue();
                System.Threading.Thread.Sleep(100);
                aux = (int)contadorCPU.NextValue();
                System.Threading.Thread.Sleep(100);
                aux = (int)contadorCPU.NextValue();
                System.Threading.Thread.Sleep(100);
                aux = (int)contadorCPU.NextValue();
                System.Threading.Thread.Sleep(100);
                aux = (int)contadorCPU.NextValue();
                return aux/100 + "%";//retorna el peso porcentual del uso del procesador deacuerdo a todos los servicios
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message,"Error en porcentaje");
            }
            return "";
        }

    }
}