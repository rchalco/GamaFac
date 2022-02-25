using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

using WindowsFormsApp1.FacturacionOperaciones;
using WindowsFormsApp1.Managers;
using WindowsFormsApp1.ProofRegister;
using WindowsFormsApp1.ServiceReference1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ServiceReference1.ServicioFacturacionSincronizacionClient clientService;
        static string token_impuestos = "TokenApi " + ConfigurationManager.AppSettings["token_impuestos"];
        static string CuisCode = string.Empty;
        static string CuisCode2 = string.Empty;
        //public DateTime vDateRegister;
        string vTimestamp = string.Empty;

        SIN_BDEntities2 contextDB = new SIN_BDEntities2();
        cabeceraFactura Objcabecera = new cabeceraFactura();
        cabeceraFacturaCV ObjcabeceraCV = new cabeceraFacturaCV();
        cabeceraFacturaCM ObjcabeceraCM = new cabeceraFacturaCM();



        private int pcodigoDocumentoSector = 15; // porque?
        private long pSucursal = 0;
        private long pPuntoVenta = 0;
        private string pCodigoSistema = "6D0B0AA5777B0605D651E3E";
        private int pModalidad = 1;
        private long pNumeroFactura = 101;
        private int pTipoFactura = 1; // 1 = Factura Compra Venta 2 = Recibo de Alquiler de Bienes Inmuebles //24 = Nota Crédito - Débito
        private int pTipoEmision = 1; // porque?
        private int pTipoEmisionP = 2; // emision offline
        public DateTime vDateRegister;
        private long pEmisor = 1029837028;

        string CuisValido = string.Empty;



        public Form1()
        {
            InitializeComponent();

            clientService = new ServiceReference1.ServicioFacturacionSincronizacionClient();

            //OPCION 1
            //codigoAmbiente = 2, // pruebas 2, produccion 1
            //codigoModalidad = 1, // 1 facturación electronica en linea 2. computarizada
            //codigoPuntoVenta = 0, // punto de venta 0 y 1, se puede crear más pero  solo se contabilizan 0 y 1
            //codigoPuntoVentaSpecified = true; // false, hace referencia al código 0
            //codigoSistema = "6D0B0AA5777B0605D651E3E"; // específico de Prodem, figura en contrato
            //codigoSucursal = 0
            //cuis = CuisCode2 // generar un CUIS para punto de venta 0 y para punto de venta 1
            //nit = 1029837028 //paarticular de Prodem.
            // OPCION 2
            //codigoAmbiente = 2, // 
            //codigoModalidad = 1, // 
            //codigoPuntoVenta = 1, //**** 
            //codigoPuntoVentaSpecified = true; // ***
            //codigoSistema = "6D0B0AA5777B0605D651E3E"; // específico de Prodem, figura en contrato
            //codigoSucursal = 0
            //nit = 1029837028 //paarticular de Prodem.


            txtAmbiente.Text = "2";
            txtModalidad.Text = "1";
            txtPuntoDeVenta.Text = "0";
            chkPuntoDeVentaEspecificado.Checked = true;
            txtCodigoDeSistema.Text = "6D0B0AA5777B0605D651E3E";
            txtCosSucursal.Text = "0";
            txtNit.Text = "1029837028";

            //



            //ServiceReference1.ServicioFacturacionSincronizacionClient services1 = new ServiceReference1.ServicioFacturacionSincronizacionClient();
            //solicitudSincronizacion uuu = new solicitudSincronizacion();
            //uuu.codigoAmbiente = 2;
            //uuu.codigoPuntoVenta = 0;
            //uuu.codigoPuntoVentaSpecified
            //uuu.codigoSistema = "5555";
            //uuu.codigoSucursal = 1;
            //uuu.cuis = "465465";
            //uuu.nit = 5968439;

            //services1.sincronizarActividades(uuu);
            //respuestaListaActividades ra = new respuestaListaActividades();

            //services1.sincronizarFechaHora(uuu);  ///********** TODO ****
            //respuestaFechaHora rf = new respuestaFechaHora();

            //services1.sincronizarListaActividadesDocumentoSector(uuu);
            //respuestaListaActividadesDocumentoSector ead = new respuestaListaActividadesDocumentoSector();

            //services1.sincronizarListaLeyendasFactura(uuu);
            //respuestaListaParametricasLeyendas rlp = new respuestaListaParametricasLeyendas();

            //services1.sincronizarListaMensajesServicios(uuu);
            //respuestaListaParametricas rp = new respuestaListaParametricas();

            //services1.sincronizarListaProductosServicios(uuu);
            //respuestaListaProductos rlpro = new respuestaListaProductos();

            //services1.sincronizarParametricaEventosSignificativos(uuu);
            //respuestaListaParametricas rpara = new respuestaListaParametricas();

            //services1.sincronizarParametricaMotivoAnulacion(uuu);
            //respuestaListaParametricas rparanu = new respuestaListaParametricas();

            //services1.sincronizarParametricaPaisOrigen(uuu);
            //respuestaListaParametricas rlis = new respuestaListaParametricas();

            //services1.sincronizarParametricaTipoDocumentoIdentidad(uuu);
            //respuestaListaParametricas rdoc = new respuestaListaParametricas();

            //services1.sincronizarParametricaTipoDocumentoSector(uuu);
            //respuestaListaParametricas rtdoc = new respuestaListaParametricas();

            //services1.sincronizarParametricaTipoEmision(uuu);
            //respuestaListaParametricas rpaemision = new respuestaListaParametricas();

            //services1.sincronizarParametricaTipoHabitacion(uuu);
            //respuestaListaParametricas rparamhab = new respuestaListaParametricas();

            //services1.sincronizarParametricaTipoMetodoPago(uuu);
            //respuestaListaParametricas rtipoMet = new respuestaListaParametricas();

            //services1.sincronizarParametricaTipoMoneda(uuu);
            //respuestaListaParametricas rtipMoneda = new respuestaListaParametricas();

            //services1.sincronizarParametricaTipoPuntoVenta(uuu);
            //respuestaListaParametricas rtiPuntoV = new respuestaListaParametricas();

            //services1.sincronizarParametricaTiposFactura(uuu);
            //respuestaListaParametricas rtipofac = new respuestaListaParametricas();

            //services1.sincronizarParametricaUnidadMedida(uuu);
            //respuestaListaParametricas rparamUni = new respuestaListaParametricas();

            //services1.verificarComunicacion();
            //respuestaComunicacion resp = new respuestaComunicacion();

            //FacturacionCodigos
            //FacturacionOperaciones.
            //ServiceReference1.
            
        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                if (clientService.State != CommunicationState.Opened)
                    clientService.Open();

                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                //ServiceReference1.ServicioFacturacionSincronizacionClient cliente = new ServiceReference1.ServicioFacturacionSincronizacionClient();
               // clientService.verificarComunicacion();

                var result= clientService.verificarComunicacion();

                //ServiceReference1.verificarComunicacion ver = new ServiceReference1.verificarComunicacion {

                //};


                //FacturacionOperaciones.consultaPuntoVenta resp = null;
                //resp = FacturacionOperaciones.(new  ); //.verificarComunicacion();
                Console.WriteLine("******");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //clientService.InnerChannel.Close();
                //clientService.Close();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            FacturacionCodigos.ServicioFacturacionCodigosClient clienteCodigos = new FacturacionCodigos.ServicioFacturacionCodigosClient("ServicioFacturacionCodigosPort");
            try
            {

                OperationContextScope contextScope = new OperationContextScope(clienteCodigos.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Authorization"] = token_impuestos;
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                FacturacionCodigos.solicitudCuis _solicitudCuis = new FacturacionCodigos.solicitudCuis
                {
                    codigoAmbiente = 2, // pruebas 2, produccion 1
                    codigoModalidad = 1, // 1 facturación electronica en linea 2. computarizada
                    codigoPuntoVenta = 0, // punto de venta 0 y 1, se puede crear más pero  solo se contabilizan 0 y 1
                    codigoPuntoVentaSpecified = false,
                    codigoSistema = "6D0B0AA5777B0605D651E3E",
                    codigoSucursal = 0,
                    nit = 1029837028,

                };
                var resp = clienteCodigos.cuis(_solicitudCuis);
                CuisCode = resp.codigo;
                //Console.WriteLine("******");
                lblCuiCode.Text = CuisCode;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //clienteCodigos.InnerChannel.Close();
            }

            ///TODO llamando al Manager
            ConfiguracionManager configuracionManager=new ConfiguracionManager();
            var resulCuis = configuracionManager.GetCUIS();
            lblCuiCode.Text = resulCuis;


        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                //Console.WriteLine(clientService.InnerChannel.State);

                //if (clientService.InnerChannel.State!= CommunicationState.Created || clientService.InnerChannel.State != CommunicationState.Opened)
                //    clientService.InnerChannel.Open();

                //if (clientService.State != CommunicationState.Opened)
                //    clientService.Open();

                if (string.IsNullOrEmpty(CuisCode))
                {
                    MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 0;
                objSend.codigoPuntoVentaSpecified = false;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode;
                objSend.nit = 1029837028;

                respuestaListaActividades resp = null;
                resp = clientService.sincronizarActividades(objSend);
                //Console.WriteLine("******");
                gridActivities.DataSource = resp.listaActividades;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //clientService.Close();
                //clientService.InnerChannel.Close();
                //clientService.InnerChannel.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 0;
                objSend.codigoPuntoVentaSpecified = false;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode;
                objSend.nit = 1029837028;

                respuestaListaActividadesDocumentoSector resp = null;
                resp = clientService.sincronizarListaActividadesDocumentoSector(objSend);
                //Console.WriteLine("******");
                gridDocumentsSector.DataSource = resp.listaActividadesDocumentoSector;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 1;
                objSend.codigoPuntoVentaSpecified = false;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode;
                objSend.nit = 1029837028;

                respuestaListaParametricasLeyendas resp = null;
                resp = clientService.sincronizarListaLeyendasFactura(objSend);
                //Console.WriteLine("******");
                gridLeyend.DataSource = resp.listaLeyendas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 0;
                objSend.codigoPuntoVentaSpecified = false;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp = null;
                resp = clientService.sincronizarListaMensajesServicios(objSend);
                //Console.WriteLine("******");
                gridMsgServices.DataSource = resp.listaCodigos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 0;
                objSend.codigoPuntoVentaSpecified = false;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode;
                objSend.nit = 1029837028;

                respuestaListaProductos resp = null;
                resp = clientService.sincronizarListaProductosServicios(objSend);
                //Console.WriteLine("******");
                gridProdServices.DataSource = resp.listaCodigos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 0;
                objSend.codigoPuntoVentaSpecified = false;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp = null;
                resp = clientService.sincronizarParametricaEventosSignificativos(objSend);
                //Console.WriteLine("******");
                gridEventsSing.DataSource = resp.listaCodigos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 0;
                objSend.codigoPuntoVentaSpecified = false;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp = null;
                resp = clientService.sincronizarParametricaTipoMoneda(objSend);
                //Console.WriteLine("******");
                gridMoney.DataSource = resp.listaCodigos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 0;
                objSend.codigoPuntoVentaSpecified = false;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp = null;
                resp = clientService.sincronizarParametricaMotivoAnulacion(objSend);
                //Console.WriteLine("******");
                gridAvoidMotives.DataSource = resp.listaCodigos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 0;
                objSend.codigoPuntoVentaSpecified = false;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp = null;
                resp = clientService.sincronizarParametricaPaisOrigen(objSend);
                //Console.WriteLine("******");
                gridOriginCountries.DataSource = resp.listaCodigos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 0;
                objSend.codigoPuntoVentaSpecified = false;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp = null;
                resp = clientService.sincronizarParametricaTipoDocumentoIdentidad(objSend);
                //Console.WriteLine("******");
                gridDocuTypeIdentity.DataSource = resp.listaCodigos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 0;
                objSend.codigoPuntoVentaSpecified = false;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp = null;
                resp = clientService.sincronizarParametricaTipoDocumentoSector(objSend);
                //Console.WriteLine("******");
                gridDocTypeSector.DataSource = resp.listaCodigos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 0;
                objSend.codigoPuntoVentaSpecified = false;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp = null;
                resp = clientService.sincronizarParametricaTipoEmision(objSend);
                //Console.WriteLine("******");
                gridEmisionType.DataSource = resp.listaCodigos;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 0;
                objSend.codigoPuntoVentaSpecified = false;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp = null;
                resp = clientService.sincronizarParametricaTipoHabitacion(objSend);
                //Console.WriteLine("******");
                gridRoomType.DataSource = resp.listaCodigos;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 0;
                objSend.codigoPuntoVentaSpecified = false;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp = null;
                resp = clientService.sincronizarParametricaTipoMetodoPago(objSend);
                //Console.WriteLine("******");
                gridPaymentMethod.DataSource = resp.listaCodigos;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 0;
                objSend.codigoPuntoVentaSpecified = false;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp = null;
                resp = clientService.sincronizarParametricaTipoPuntoVenta(objSend);
                //Console.WriteLine("******");
                gridSalePoint.DataSource = resp.listaCodigos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 0;
                objSend.codigoPuntoVentaSpecified = false;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp = null;
                resp = clientService.sincronizarParametricaTiposFactura(objSend);
                //Console.WriteLine("******");
                gridInvoiceType.DataSource = resp.listaCodigos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 1;
                objSend.codigoPuntoVentaSpecified = true;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp = null;
                resp = clientService.sincronizarParametricaUnidadMedida(objSend);
                gridUnitMeasurement.DataSource = resp.listaCodigos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCuis2_Click(object sender, EventArgs e)
        {
            FacturacionCodigos.ServicioFacturacionCodigosClient clienteCodigos = new FacturacionCodigos.ServicioFacturacionCodigosClient("ServicioFacturacionCodigosPort");
            try
            {

                OperationContextScope contextScope = new OperationContextScope(clienteCodigos.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Authorization"] = token_impuestos;
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                FacturacionCodigos.solicitudCuis _solicitudCuis = new FacturacionCodigos.solicitudCuis
                {
                    codigoAmbiente = 2, // pruebas 2, produccion 1
                    codigoModalidad = 1, // 1 facturación electronica en linea 2. computarizada
                    codigoSucursal = 0,
                    codigoPuntoVenta = 1,
                    codigoPuntoVentaSpecified = true,
                    codigoSistema = "6D0B0AA5777B0605D651E3E",
                    nit = 1029837028,

                };

                var resp = clienteCodigos.cuis(_solicitudCuis);
                CuisCode2 = resp.codigo;

                lblCuis2.Text = CuisCode2;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //clienteCodigos.InnerChannel.Close();
            }
        }

        private void btnObtActividadesCUIS2_Click(object sender, EventArgs e)
        {

            try
            {

                if (string.IsNullOrEmpty(CuisCode2))
                {
                    MessageBox.Show("Solicite el código CUIS 2", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);
                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;


                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 1;
                objSend.codigoPuntoVentaSpecified = true;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode2;
                objSend.nit = 1029837028;

                respuestaListaActividades resp = null;
                resp = clientService.sincronizarActividades(objSend);
                gridActivities.DataSource = resp.listaActividades;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        private void btnGetFechaCuis1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(CuisCode2))
            {
                MessageBox.Show("Solicite el código CUIS 222", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string strCuis = "";
                var checkedButton2 = panel3.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                if (checkedButton2.Text == "Cuis 1")
                    strCuis = CuisCode;
                else
                    strCuis = CuisCode2;

                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);
                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = int.Parse(txtAmbiente.Text);
                objSend.codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text);
                objSend.codigoPuntoVentaSpecified = Convert.ToBoolean(chkPuntoDeVentaEspecificado.CheckState);
                objSend.codigoSistema = txtCodigoDeSistema.Text;
                objSend.codigoSucursal = int.Parse(txtCosSucursal.Text);
                objSend.cuis = strCuis;
                objSend.nit = Int64.Parse(txtNit.Text);

                var checkedButton1 = grpServicios.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                string strServicio = checkedButton1.Text;

                Type clientType = Type.GetType("WindowsFormsApp1.ServiceReference1.ServicioFacturacionSincronizacionClient");
                MethodInfo magicMethod = clientType.GetMethod(strServicio);
                object valueServices = magicMethod.Invoke(clientService, new object[] { objSend });


                //respuestaFechaHora resp = null;
                //resp = clientService.sincronizarFechaHora(objSend);
                //MessageBox.Show("Fecha SIN", resp.fechaHora.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                //
                ///TODO llamando al Manager
                ///
                var checkedButton = grpServicios.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                string strParametroServicio = checkedButton.Text;
                ConfiguracionManager configuracionManager = new ConfiguracionManager();
                var resultParametros = configuracionManager.GetParametrosServcio(strParametroServicio, CuisValido);
 

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void btnObtenerDocumentosCUIS2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode2))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 1;
                objSend.codigoPuntoVentaSpecified = true;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode2;
                objSend.nit = 1029837028;

                respuestaListaActividadesDocumentoSector resp2 = null;
                resp2 = clientService.sincronizarListaActividadesDocumentoSector(objSend);
                gridDocumentsSector.DataSource = resp2.listaActividadesDocumentoSector;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 1;
                objSend.codigoPuntoVentaSpecified = true;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode2;
                objSend.nit = 1029837028;

                respuestaListaParametricasLeyendas resp2 = null;
                resp2 = clientService.sincronizarListaLeyendasFactura(objSend);
                //Console.WriteLine("******");
                gridLeyend.DataSource = resp2.listaLeyendas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode2))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 1;
                objSend.codigoPuntoVentaSpecified = true;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode2;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp = null;
                resp = clientService.sincronizarListaMensajesServicios(objSend);
                //Console.WriteLine("******");
                gridMsgServices.DataSource = resp.listaCodigos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode2))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 1;
                objSend.codigoPuntoVentaSpecified = true;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode2;
                objSend.nit = 1029837028;

                respuestaListaProductos resp2 = null;
                resp2 = clientService.sincronizarListaProductosServicios(objSend);
                gridProdServices.DataSource = resp2.listaCodigos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode2))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 1;
                objSend.codigoPuntoVentaSpecified = true;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode2;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp2 = null;
                resp2 = clientService.sincronizarParametricaEventosSignificativos(objSend);
                //Console.WriteLine("******");
                gridEventsSing.DataSource = resp2.listaCodigos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode2))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 0;
                objSend.codigoPuntoVentaSpecified = true;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode2;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp2 = null;
                resp2 = clientService.sincronizarParametricaTipoMoneda(objSend);
                //Console.WriteLine("******");
                gridMoney.DataSource = resp2.listaCodigos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode2))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 1;
                objSend.codigoPuntoVentaSpecified = true;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode2;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp2 = null;
                resp2 = clientService.sincronizarParametricaMotivoAnulacion(objSend);
                //Console.WriteLine("******");
                gridAvoidMotives.DataSource = resp2.listaCodigos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode2))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 1;
                objSend.codigoPuntoVentaSpecified = true;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode2;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp2 = null;
                resp2 = clientService.sincronizarParametricaPaisOrigen(objSend);
                //Console.WriteLine("******");
                gridOriginCountries.DataSource = resp2.listaCodigos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode2))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 1;
                objSend.codigoPuntoVentaSpecified = true;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode2;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp2 = null;
                resp2 = clientService.sincronizarParametricaTipoDocumentoIdentidad(objSend);
                gridDocuTypeIdentity.DataSource = resp2.listaCodigos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode2))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 1;
                objSend.codigoPuntoVentaSpecified = true;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode2;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp2 = null;
                resp2 = clientService.sincronizarParametricaTipoDocumentoSector(objSend);
                gridDocTypeSector.DataSource = resp2.listaCodigos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode2))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                solicitudSincronizacion objSend = new solicitudSincronizacion();
                objSend.codigoAmbiente = 2;
                objSend.codigoPuntoVenta = 1;
                objSend.codigoPuntoVentaSpecified = true;
                objSend.codigoSistema = "6D0B0AA5777B0605D651E3E";
                objSend.codigoSucursal = 0;
                objSend.cuis = CuisCode2;
                objSend.nit = 1029837028;

                respuestaListaParametricas resp2 = null;
                resp2 = clientService.sincronizarParametricaTipoEmision(objSend);
                //Console.WriteLine("******");
                gridEmisionType.DataSource = resp2.listaCodigos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FacturacionCodigos.ServicioFacturacionCodigosClient clienteCodigos = new FacturacionCodigos.ServicioFacturacionCodigosClient("ServicioFacturacionCodigosPort");
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clienteCodigos.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Authorization"] = token_impuestos;
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                FacturacionCodigos.solicitudCufd vobj = new FacturacionCodigos.solicitudCufd
                {
                    cuis = CuisCode,
                    codigoAmbiente = 2, // pruebas 2, produccion 1
                    codigoModalidad = 1, // 1 facturación electronica en linea 2. computarizada
                    codigoPuntoVenta = 0, // punto de venta 0 y 1, se puede crear más pero  solo se contabilizan 0 y 1
                    codigoPuntoVentaSpecified = false,
                    codigoSistema = "6D0B0AA5777B0605D651E3E",
                    codigoSucursal = 0,
                    nit = 1029837028
                };
                FacturacionCodigos.respuestaCufd resp = clienteCodigos.cufd(vobj);
                lblCufd0CodControl.Text = resp.codigoControl;
                lblCufd1.Text = resp.codigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ///TODO llamando al Manager
            ///

            ConfiguracionManager configuracionManager = new ConfiguracionManager();
            var resultCUFD = configuracionManager.GetCUFD(CuisValido);


        }




        private void btnCufd2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CuisCode2))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FacturacionCodigos.ServicioFacturacionCodigosClient clienteCodigos = new FacturacionCodigos.ServicioFacturacionCodigosClient("ServicioFacturacionCodigosPort");
            try
            {
                OperationContextScope contextScope = new OperationContextScope(clienteCodigos.InnerChannel);

                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Authorization"] = token_impuestos;
                requestMessage.Headers["Apikey"] = token_impuestos;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                FacturacionCodigos.solicitudCufd vobj = new FacturacionCodigos.solicitudCufd
                {
                    cuis = CuisCode2,
                    codigoAmbiente = 2,
                    codigoModalidad = 1,
                    codigoPuntoVenta = 1, //**
                    codigoPuntoVentaSpecified = true,
                    codigoSistema = "6D0B0AA5777B0605D651E3E",
                    codigoSucursal = 0,
                    nit = 1029837028
                };
                FacturacionCodigos.respuestaCufd resp = clienteCodigos.cufd(vobj);
                lblCufd20CodControl.Text = resp.codigoControl;
                lblCufd21.Text = resp.codigo;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string SerializarToXml(object obj)
        {
            try
            {
                StringWriter strWriter = new StringWriter();
                XmlSerializer serializer = new XmlSerializer(obj.GetType());

                serializer.Serialize(strWriter, obj);
                string resultXml = strWriter.ToString();
                strWriter.Close();

                return resultXml;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private FacturacionCodigos.respuestaCufd vCUFD;
        private FacturacionCodigos.respuestaCufd vCUFD2;

        private string InsertaFirmaDigital(string vXML)
        {
            string vResultado = "";
            string vTipoCertificado = "/opt/config_sin/ConfigCerticate";
            FirmaDigital.SignDocumentClient clienteFirmaDigital = new FirmaDigital.SignDocumentClient();
            FirmaDigital.resulSign vresult = clienteFirmaDigital.GetDocumentSign(vTipoCertificado, vXML);
            string vCabecera = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone =\"yes\" ?>";
            vResultado = vCabecera + " " + vresult.resul;
            //FacturacionCodigos.ServicioFacturacionCodigosClient clienteCodigos = new FacturacionCodigos.ServicioFacturacionCodigosClient("ServicioFacturacionCodigosPort");
            return vResultado;
        }


        private void button21_Click(object sender, EventArgs e)
        {
            vDateRegister = DateTime.Now;
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string vXML = GeneradorXML();
                vXML = vXML.Replace("utf-16", "UTF-8");
                vXML = vXML.Replace("?>", " standalone=\"yes\"?>");
                vXML = InsertaFirmaDigital(vXML);
                byte[] bXML = FacturaHelper.Zip(vXML);//Encoding.ASCII.GetBytes(vXML);
                string XMLSHA256 = FacturaHelper.sha256_hash(vXML);
                // var unixTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();

                string vTimestamp = vDateRegister.ToString(FacturaHelper.pFormatoDate); //DateTimeOffset.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff");
                FacturacionEntidadFinanciera.ServicioFacturacionClient ObjrecepcionFactura = new FacturacionEntidadFinanciera.ServicioFacturacionClient("ServicioFacturacionPort");
                //FacturacionCodigos.ServicioFacturacionCodigosClient clienteCodigos = new ServicioFacturacion.ServicioFacturacionClient("ServicioFacturacionCodigosPort");
                try
                {
                    OperationContextScope contextScope = new OperationContextScope(ObjrecepcionFactura.InnerChannel);
                    HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                    requestMessage.Headers["Authorization"] = token_impuestos;
                    requestMessage.Headers["Apikey"] = token_impuestos;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                    FacturacionEntidadFinanciera.solicitudRecepcionFactura vobj = new FacturacionEntidadFinanciera.solicitudRecepcionFactura
                    {
                        codigoAmbiente = 2, // pruebas 2, produccion 1
                        codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text), // punto de venta 0 y 1, se puede crear más pero  solo se contabilizan 0 y 1
                        codigoSistema = txtPuntoDeVenta.Text,
                        codigoSucursal = int.Parse(txtCosSucursal.Text),
                        nit = int.Parse(txtNit.Text),
                        codigoDocumentoSector = 15,//
                        codigoEmision = 1,
                        codigoModalidad = int.Parse(txtModalidad.Text), // 1 facturación electronica en linea 2. computarizada
                        cufd = vCUFD.codigo,
                        cuis = CuisCode,
                        tipoFacturaDocumento = int.Parse(txtTipoFactura.Text),
                        archivo = bXML,
                        fechaEnvio = vTimestamp,
                        hashArchivo = XMLSHA256
                        //codigoPuntoVentaSpecified = false,

                    };
                    var resp = ObjrecepcionFactura.recepcionFactura(vobj);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    //clienteCodigos.InnerChannel.Close();
                }
            }

        }
        private FacturacionCodigos.respuestaCufd GeneradorCUFD(bool IsCodeControl)
        {
            string vRes = "";
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FacturacionCodigos.ServicioFacturacionCodigosClient clienteCodigos = new FacturacionCodigos.ServicioFacturacionCodigosClient("ServicioFacturacionCodigosPort");
                try
                {
                    OperationContextScope contextScope = new OperationContextScope(clienteCodigos.InnerChannel);

                    HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                    requestMessage.Headers["Authorization"] = token_impuestos;
                    requestMessage.Headers["Apikey"] = token_impuestos;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                    FacturacionCodigos.solicitudCufd vobj = new FacturacionCodigos.solicitudCufd
                    {
                        cuis = CuisValido,
                        codigoAmbiente = int.Parse(txtAmbiente.Text), // pruebas 2, produccion 1
                        codigoModalidad = int.Parse(txtModalidad.Text), // 1 facturación electronica en linea 2. computarizada
                        codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text),// punto de venta 0 y 1, se puede crear más pero  solo se contabilizan 0 y 1
                        codigoPuntoVentaSpecified = true,
                        codigoSistema = txtCodigoDeSistema.Text,
                        codigoSucursal = int.Parse(txtCosSucursal.Text),
                        nit = Int64.Parse(txtNit.Text)
                    };
                    string vCUFD = "";
                    FacturacionCodigos.respuestaCufd resp = clienteCodigos.cufd(vobj);
                    if (IsCodeControl)
                        vCUFD = resp.codigoControl;
                    else
                        vCUFD = resp.codigo;

                    //Console.WriteLine("******");
                    //txtTipoFactura.Text = CuisCode;
                    vRes = CuisCode;

                    return resp;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    //clienteCodigos.InnerChannel.Close();
                }
            }
            return null;
        }
        private string GeneradorCUF(string CUFD)
        {
            string vTimestamp = vDateRegister.ToString(FacturaHelper.pFormatoDate); //DateTimeOffset.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff");

            ParametrosCUF ObjParam = new ParametrosCUF();
            ObjParam.NIT = Int64.Parse(txtNit.Text);
            ObjParam.FechaHora = Convert.ToInt64(vDateRegister.ToString("yyyyMMddHHmmssfff"));  //Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            ObjParam.Sucursal = int.Parse(txtCosSucursal.Text); //////// comun
            ObjParam.Modalidad = int.Parse(txtModalidad.Text);
            ObjParam.TipoEmision = pTipoEmision;
            ObjParam.TipoFactura = int.Parse(txtTipoFactura.Text); //////// comun
            ObjParam.TipoDocumentoSector = int.Parse(txtSector.Text);  //////// comun
            ObjParam.NumeroFactura = pNumeroFactura; //////// comun
            ObjParam.PuntoVenta = int.Parse(txtPuntoDeVenta.Text); //////// comun 

            ///La cadena de entrada al algoritmo es la concatenación del nit, sucursal, fecha, modalidad, tipo emisión, tipo documento, número factura.
            //string vCadena = ObjParam.NIT.ToString() +
            //                 ObjParam.Sucursal.ToString() +
            //                 ObjParam.FechaHora.ToString() +
            //                 ObjParam.Modalidad.ToString() +
            //                 ObjParam.TipoEmision.ToString() +
            //                 ObjParam.TipoDocumentoSector.ToString() +
            //                 ObjParam.NumeroFactura;
            //string vDigito = FacturaHelper.calculaDigitoMod11ER(vCadena, 1, 9, false);
            //string vDigito2 = FacturaHelper.calculaDigitoMod11GOF(vCadena, 1, 9, false);

            string vCadena = FacturaHelper.ObtieneNumCerosIzq(ObjParam.NIT, 13) +
                                 FacturaHelper.ObtieneNumCerosIzq(ObjParam.FechaHora, 17) +
                                 FacturaHelper.ObtieneNumCerosIzq(ObjParam.Sucursal, 4) +
                                 FacturaHelper.ObtieneNumCerosIzq(ObjParam.Modalidad, 1) +
                                 FacturaHelper.ObtieneNumCerosIzq(ObjParam.TipoEmision, 1) +
                                 FacturaHelper.ObtieneNumCerosIzq(ObjParam.TipoFactura, 1) +
                                 FacturaHelper.ObtieneNumCerosIzq(ObjParam.TipoDocumentoSector, 2) +
                                 FacturaHelper.ObtieneNumCerosIzq(ObjParam.NumeroFactura, 10) +
                                 FacturaHelper.ObtieneNumCerosIzq(ObjParam.PuntoVenta, 4);
            string vDigito2 = FacturaHelper.calculaDigitoMod11GOF(vCadena, 1, 9, false);
            ObjParam.CodigoAutoverificador = Convert.ToInt16(vDigito2);


            ///SE obtiene codigo previo 
            string CodigoPrevio = FacturaHelper.ObtieneNumCerosIzq(ObjParam.NIT, 13) +
                                  FacturaHelper.ObtieneNumCerosIzq(ObjParam.FechaHora, 17) +
                                  FacturaHelper.ObtieneNumCerosIzq(ObjParam.Sucursal, 4) +
                                  FacturaHelper.ObtieneNumCerosIzq(ObjParam.Modalidad, 1) +
                                  FacturaHelper.ObtieneNumCerosIzq(ObjParam.TipoEmision, 1) +
                                  FacturaHelper.ObtieneNumCerosIzq(ObjParam.TipoFactura, 1) +
                                  FacturaHelper.ObtieneNumCerosIzq(ObjParam.TipoDocumentoSector, 2) +
                                  FacturaHelper.ObtieneNumCerosIzq(ObjParam.NumeroFactura, 10) +
                                  FacturaHelper.ObtieneNumCerosIzq(ObjParam.PuntoVenta, 4) +
                                  FacturaHelper.ObtieneNumCerosIzq(ObjParam.CodigoAutoverificador, 1);

            //CodigoPrevio = "000012345678920190113163721231000011101000000000100001";
            string vR = FacturaHelper.ConvertirBase16(CodigoPrevio);
            //vR = vR.TrimStart('0');
            vR = vR + CUFD;
            return vR;
        }
        private string GeneradorXML()
        {
            string vTimestamp = vDateRegister.ToString(FacturaHelper.pFormatoDate); //DateTimeOffset.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff");

            vCUFD = GeneradorCUFD(false);
            string vCUF = GeneradorCUF(vCUFD.codigoControl);

            facturaElectronicaEntidadFinanciera ObjFactura = new facturaElectronicaEntidadFinanciera();
            Objcabecera = new cabeceraFactura();

            Objcabecera.nitEmisor = 1029837028;
            Objcabecera.razonSocialEmisor = "PRUEBA";
            Objcabecera.municipio = "La Paz";
            Objcabecera.telefono = "2846005";
            Objcabecera.numeroFactura = pNumeroFactura; //////// comun
            Objcabecera.cuf = vCUF;
            Objcabecera.cufd = vCUFD.codigo;
            Objcabecera.codigoSucursal = pSucursal; //////// comun
            Objcabecera.direccion = "AV.JORGE LOPEZ #123";
            Objcabecera.codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text); //////// comun
            Objcabecera.fechaEmision = vTimestamp;//DateTime.Now;//2021 - 10 - 07T09: 55:45.714;
            Objcabecera.nombreRazonSocial = "Pablo Perez";
            Objcabecera.codigoTipoDocumentoIdentidad = 5;
            Objcabecera.numeroDocumento = "1020703023";
            Objcabecera.complemento = "";
            Objcabecera.codigoCliente = "51158891";
            Objcabecera.codigoMetodoPago = 1;
            Objcabecera.numeroTarjeta = null;
            Objcabecera.montoTotalArrendamientoFinanciero = null;
            Objcabecera.montoTotal = 450;
            Objcabecera.montoTotalSujetoIva = 450.0M;
            Objcabecera.codigoMoneda = 1;
            Objcabecera.tipoCambio = 1;
            Objcabecera.montoTotalMoneda = 450;
            Objcabecera.descuentoAdicional = null;
            Objcabecera.codigoExcepcion = null;
            Objcabecera.cafc = null;
            Objcabecera.leyenda = "Ley N° 453: El proveedor debe exhibir certificaciones de habilitación o documentos que acrediten lascapacidades u ofertas de servicios especializados.";
            Objcabecera.usuario = "VSilva";
            Objcabecera.codigoDocumentoSector = int.Parse(txtSector.Text); //////// comun

            ObjFactura.cabecera = Objcabecera;

            detalleFactura Objdetalle = new detalleFactura();
            Objdetalle.actividadEconomica = "641900";
            Objdetalle.codigoProductoSin = 71200;
            Objdetalle.codigoProducto = "PM - 3123 - BS";
            Objdetalle.descripcion = "Pago prima de mes de enero";
            Objdetalle.cantidad = 1;
            Objdetalle.unidadMedida = 58;
            Objdetalle.precioUnitario = 450;
            Objdetalle.montoDescuento = null;
            Objdetalle.subTotal = 450;
            ObjFactura.detalle = Objdetalle;

            string vXml = SerializarToXml(ObjFactura);
            return vXml;
        }
        private string GeneradorXMLCV()
        {
            string vTimestamp = vDateRegister.ToString(FacturaHelper.pFormatoDate); //DateTimeOffset.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff");

            vCUFD = GeneradorCUFD(false);
            string vCUF = GeneradorCUF(vCUFD.codigoControl);

            facturaElectronicaCompraVenta ObjFactura = new facturaElectronicaCompraVenta();
            ObjcabeceraCV = new cabeceraFacturaCV();

            ObjcabeceraCV.nitEmisor = 1029837028;
            ObjcabeceraCV.razonSocialEmisor = "PRUEBA";
            ObjcabeceraCV.municipio = "La Paz";
            ObjcabeceraCV.telefono = "2846005";
            ObjcabeceraCV.numeroFactura = pNumeroFactura; //////// comun
            ObjcabeceraCV.cuf = vCUF;
            ObjcabeceraCV.cufd = vCUFD.codigo;
            ObjcabeceraCV.codigoSucursal = pSucursal; //////// comun
            ObjcabeceraCV.direccion = "AV.JORGE LOPEZ #123";
            ObjcabeceraCV.codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text); //////// comun
            ObjcabeceraCV.fechaEmision = vTimestamp;//DateTime.Now;//2021 - 10 - 07T09: 55:45.714;
            ObjcabeceraCV.nombreRazonSocial = "Pablo Perez";
            ObjcabeceraCV.codigoTipoDocumentoIdentidad = 5;
            ObjcabeceraCV.numeroDocumento = "1020703023";
            ObjcabeceraCV.complemento = "";
            ObjcabeceraCV.codigoCliente = "51158891";
            ObjcabeceraCV.codigoMetodoPago = 1;
            ObjcabeceraCV.numeroTarjeta = null;
            //ObjcabeceraCV.montoTotalArrendamientoFinanciero = null;
            ObjcabeceraCV.montoTotal = 450;
            ObjcabeceraCV.montoTotalSujetoIva = 450.0M;
            ObjcabeceraCV.codigoMoneda = 1;
            ObjcabeceraCV.tipoCambio = 1;
            ObjcabeceraCV.montoTotalMoneda = 450;
            //ObjcabeceraCV.descuentoAdicional = null;
            //ObjcabeceraCV.codigoExcepcion = null;
            //ObjcabeceraCV.cafc = null;
            ObjcabeceraCV.leyenda = "Ley N° 453: El proveedor debe exhibir certificaciones de habilitación o documentos que acrediten lascapacidades u ofertas de servicios especializados.";
            ObjcabeceraCV.usuario = "VSilva";
            ObjcabeceraCV.codigoDocumentoSector = int.Parse(txtSector.Text);
            ObjcabeceraCV.montoGiftCard = null;
            ObjcabeceraCV.descuentoAdicional = null;
            ObjcabeceraCV.codigoExcepcion = null;
            ObjcabeceraCV.cafc = null;
            ObjFactura.cabecera = ObjcabeceraCV;

            detalleFacturaCV Objdetalle = new detalleFacturaCV();
            Objdetalle.actividadEconomica = "641900";
            Objdetalle.codigoProductoSin = 71200;
            Objdetalle.codigoProducto = "PM - 3123 - BS";
            Objdetalle.descripcion = "Pago prima de mes de enero";
            Objdetalle.cantidad = 1;
            Objdetalle.unidadMedida = 58;
            Objdetalle.precioUnitario = 450;
            Objdetalle.montoDescuento = null;
            Objdetalle.subTotal = 450;
            Objdetalle.numeroSerie = null;
            Objdetalle.numeroImei = null;
            ObjFactura.detalle = Objdetalle;


            string vXml = SerializarToXml(ObjFactura);
            return vXml;
        }
        private string GeneradorXMLCM()
        {
            string vTimestamp = vDateRegister.ToString(FacturaHelper.pFormatoDate); //DateTimeOffset.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff");

            vCUFD = GeneradorCUFD(false);
            string vCUF = GeneradorCUF(vCUFD.codigoControl);

            facturaElectronicaMonedaExtranjera ObjFactura = new facturaElectronicaMonedaExtranjera();
            ObjcabeceraCM = new cabeceraFacturaCM();

            ObjcabeceraCM.nitEmisor = 1029837028;
            ObjcabeceraCM.razonSocialEmisor = "PRUEBA";
            ObjcabeceraCM.municipio = "La Paz";
            ObjcabeceraCM.telefono = "2846005";
            ObjcabeceraCM.numeroFactura = pNumeroFactura; //////// comun
            ObjcabeceraCM.cuf = vCUF;
            ObjcabeceraCM.cufd = vCUFD.codigo;
            ObjcabeceraCM.codigoSucursal = pSucursal; //////// comun
            ObjcabeceraCM.direccion = "AV.JORGE LOPEZ #123";
            ObjcabeceraCM.codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text); //////// comun
            ObjcabeceraCM.fechaEmision = vTimestamp;//DateTime.Now;//2021 - 10 - 07T09: 55:45.714;
            ObjcabeceraCM.nombreRazonSocial = "Pablo Perez";
            ObjcabeceraCM.codigoTipoDocumentoIdentidad = 5;
            ObjcabeceraCM.numeroDocumento = "1020703023";
            ObjcabeceraCM.complemento = "";
            ObjcabeceraCM.codigoCliente = "51158891";
            ObjcabeceraCM.codigoMetodoPago = 1;
            ObjcabeceraCM.numeroTarjeta = null;
            ObjcabeceraCM.montoTotal = 64.56m;
            //ObjcabeceraCM.montoTotalSujetoIva = 450.0M;
            ObjcabeceraCM.codigoMoneda = 1;
            ObjcabeceraCM.tipoCambio = 1;
            ObjcabeceraCM.montoTotalMoneda = 9.26m;
            ObjcabeceraCM.ingresoDiferenciaCambio = 0.01m;
            ObjcabeceraCM.tipoCambio = 6.97m;
            ObjcabeceraCM.leyenda = "Ley N° 453: El proveedor debe exhibir certificaciones de habilitación o documentos que acrediten lascapacidades u ofertas de servicios especializados.";
            ObjcabeceraCM.usuario = "VSilva";
            ObjcabeceraCM.tipoCambioOficial = 6.96m;
            ObjcabeceraCM.montoTotalSujetoIva = 0.00m;
            ObjcabeceraCM.codigoDocumentoSector = int.Parse(txtSector.Text);
            ObjcabeceraCM.codigoTipoOperacion = 2;/// ojo

            //ObjcabeceraCM.montoGiftCard = null;
            //ObjcabeceraCM.descuentoAdicional = null;
            //ObjcabeceraCM.codigoExcepcion = null;
            //ObjcabeceraCM.cafc = null;
            ObjFactura.cabecera = ObjcabeceraCM;

            detalleFacturaCM Objdetalle = new detalleFacturaCM();
            Objdetalle.actividadEconomica = "641900";
            Objdetalle.codigoProductoSin = 71200;
            Objdetalle.codigoProducto = "PM - 3123 - BS";
            Objdetalle.descripcion = "Pago prima de mes de enero";
            Objdetalle.cantidad = 1;
            Objdetalle.unidadMedida = 58;
            Objdetalle.precioUnitario = 64.56m;
            Objdetalle.montoDescuento = null;
            Objdetalle.subTotal = 64.56m;
            //Objdetalle.numeroSerie = null;
            //Objdetalle.numeroImei = null;
            ObjFactura.detalle = Objdetalle;


            string vXml = SerializarToXml(ObjFactura);
            return vXml;
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(txtVecesFac.Text); i++)
            {
                emitirFacrtura();
            }
            //MessageBox.Show("Proceso finalizado con exito!!!");
        }


        private void emitirFacrtura()
        {
            #region Emision de factura
            vDateRegister = DateTime.Now;
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string vXML = GeneradorXML();
                vXML = vXML.Replace("utf-16", "UTF-8");
                vXML = vXML.Replace("?>", " standalone=\"yes\"?>");
                vXML = InsertaFirmaDigital(vXML);
                byte[] bXML = FacturaHelper.Zip(vXML);//Encoding.ASCII.GetBytes(vXML);
                string XMLSHA256 = FacturaHelper.sha256_hash(vXML);
                // var unixTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();

                string vTimestamp = vDateRegister.ToString(FacturaHelper.pFormatoDate); //DateTimeOffset.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff");
                FacturacionEntidadFinanciera.ServicioFacturacionClient ObjrecepcionFactura = new FacturacionEntidadFinanciera.ServicioFacturacionClient("ServicioFacturacionPort");
                //FacturacionElectronica.ServicioFacturacionClient ObjrecepcionFactura = new FacturacionElectronica.ServicioFacturacionClient("ServicioFacturacionPort1");
                //FacturacionCompraVenta.ServicioFacturacionClient ObjrecepcionFactura = new FacturacionCompraVenta.ServicioFacturacionClient("ServicioFacturacionPort2");
                try
                {
                    OperationContextScope contextScope = new OperationContextScope(ObjrecepcionFactura.InnerChannel);
                    HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                    requestMessage.Headers["Authorization"] = token_impuestos;
                    requestMessage.Headers["Apikey"] = token_impuestos;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
                    FacturacionEntidadFinanciera.solicitudRecepcionFactura vobj = new FacturacionEntidadFinanciera.solicitudRecepcionFactura
                    //FacturacionElectronica.solicitudRecepcionFactura vobj = new FacturacionElectronica.solicitudRecepcionFactura
                    //FacturacionCompraVenta.solicitudRecepcionFactura vobj = new FacturacionCompraVenta.solicitudRecepcionFactura
                    {
                        codigoAmbiente = 2, // pruebas 2, produccion 1
                        codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text), // punto de venta 0 y 1, se puede crear más pero  solo se contabilizan 0 y 1
                        codigoSistema = txtCodigoDeSistema.Text,
                        codigoSucursal = int.Parse(txtCosSucursal.Text),
                        nit = pEmisor,
                        codigoDocumentoSector = int.Parse(txtSector.Text),
                        codigoEmision = pTipoEmision,
                        codigoModalidad = pModalidad, // 1 facturación electronica en linea 2. computarizada
                        cufd = vCUFD.codigo,
                        cuis = CuisValido,
                        tipoFacturaDocumento = int.Parse(txtTipoFactura.Text),
                        archivo = bXML,
                        fechaEnvio = vTimestamp,
                        hashArchivo = XMLSHA256,
                        codigoPuntoVentaSpecified = true,


                    };
                    var resp = ObjrecepcionFactura.recepcionFactura(vobj);

                    ///persistir
                    ///

                    CabeceraFac2 cabecera = new CabeceraFac2
                    {
                        codigoCliente = "0",
                        request = SerializarToXml(vobj),
                        response = SerializarToXml(resp),
                        fechaEmision = DateTime.Now,
                        archivoXML = vXML,
                        Cuf = Objcabecera.cuf

                    };

                    contextDB.CabeceraFac2.Add(cabecera);
                    contextDB.SaveChanges();

                    /*Data.DetalleFac detalle = new Data.DetalleFac
                    {
                        idCabeceraFac = cabecera.idCabeceraFac,
                        detalle = "dddddddddd"
                    };

                    contextDB.DetalleFac.Add(detalle);
                    contextDB.SaveChanges();*/

                }
                catch (Exception ex)
                {

                    //throw ex;
                    
                }
                finally
                {
                    //clienteCodigos.InnerChannel.Close();
                }
            }
            ///
            ///TODO.Factura
            ///


            #endregion
        }
        private void button35_Click(object sender, EventArgs e)
        {

            vCUFD = GeneradorCUFD(false);
            txtCufdIni.Text = vCUFD.codigo;
            txtHoraCufIni.Text = DateTime.Now.ToString();


        }

        private void button36_Click(object sender, EventArgs e)
        {
            vCUFD2 = GeneradorCUFD(false);

            txtCufDFin.Text = vCUFD2.codigo;
            txtHoraCufFin.Text = DateTime.Now.ToString();//vCUFD2.fechaVigencia.ToString();


            //var context = new SIN_BDEntities();
            FacturacionOperaciones.ServicioFacturacionOperacionesClient vclienteop = new FacturacionOperaciones.ServicioFacturacionOperacionesClient();

            OperationContextScope contextScope = new OperationContextScope(vclienteop.InnerChannel);
            HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
            requestMessage.Headers["Authorization"] = token_impuestos;
            requestMessage.Headers["Apikey"] = token_impuestos;
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

            FacturacionOperaciones.solicitudEventoSignificativo objevento = new FacturacionOperaciones.solicitudEventoSignificativo
            {
                codigoAmbiente = 2,
                codigoMotivoEvento = 1,
                codigoPuntoVenta = 1, //GetPuntoVenta(),
                codigoPuntoVentaSpecified = true,
                codigoSistema = "6D0B0AA5777B0605D651E3E",
                codigoSucursal = int.Parse(txtCosSucursal.Text),
                cufd = vCUFD2.codigo,
                cufdEvento = vCUFD.codigo,
                cuis = CuisValido,
                descripcion = "registro de evento significativo " + txtCosSucursal.Text,
                fechaHoraFinEvento = DateTime.Now,
                fechaHoraInicioEvento = DateTime.Now.AddMinutes(-1),
                nit = 1029837028

            };

            // string XMLRequest = Serialize(objevento);
            var resultado = vclienteop.registroEventoSignificativo(objevento);
        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            //CuisValido = lblCuiCode.Text;
            CuisValido = lblCuis2.Text;
        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            CuisValido = lblCuiCode.Text;
            //CuisValido = lblCuis2.Text;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(txtVecesFac.Text); i++)
            {
                emitirFacrturaCompraVenta();
            }
        }
        public void emitirFacrturaCompraVenta()
        {
            vDateRegister = DateTime.Now;
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string vXML = GeneradorXMLCV();
                vXML = vXML.Replace("utf-16", "UTF-8");
                vXML = vXML.Replace("?>", " standalone=\"yes\"?>");
                vXML = InsertaFirmaDigital(vXML);
                byte[] bXML = FacturaHelper.Zip(vXML);//Encoding.ASCII.GetBytes(vXML);
                string XMLSHA256 = FacturaHelper.sha256_hash(vXML);
                // var unixTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();

                string vTimestamp = vDateRegister.ToString(FacturaHelper.pFormatoDate); //DateTimeOffset.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff");
                //FacturacionEntidadFinanciera.ServicioFacturacionClient ObjrecepcionFactura = new FacturacionEntidadFinanciera.ServicioFacturacionClient("ServicioFacturacionPort");
                //FacturacionElectronica.ServicioFacturacionClient ObjrecepcionFactura = new FacturacionElectronica.ServicioFacturacionClient("ServicioFacturacionPort1");
                FacturacionCompraVenta.ServicioFacturacionClient ObjrecepcionFactura = new FacturacionCompraVenta.ServicioFacturacionClient("ServicioFacturacionPort2");
                try
                {
                    OperationContextScope contextScope = new OperationContextScope(ObjrecepcionFactura.InnerChannel);
                    HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                    requestMessage.Headers["Authorization"] = token_impuestos;
                    requestMessage.Headers["Apikey"] = token_impuestos;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
                    //FacturacionEntidadFinanciera.solicitudRecepcionFactura vobj = new FacturacionEntidadFinanciera.solicitudRecepcionFactura
                    //FacturacionElectronica.solicitudRecepcionFactura vobj = new FacturacionElectronica.solicitudRecepcionFactura
                    FacturacionCompraVenta.solicitudRecepcionFactura vobj = new FacturacionCompraVenta.solicitudRecepcionFactura
                    {
                        codigoAmbiente = 2, // pruebas 2, produccion 1
                        codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text), // punto de venta 0 y 1, se puede crear más pero  solo se contabilizan 0 y 1
                        codigoSistema = txtCodigoDeSistema.Text,
                        codigoSucursal = int.Parse(txtCosSucursal.Text),
                        nit = pEmisor,
                        codigoDocumentoSector = int.Parse(txtSector.Text),
                        codigoEmision = pTipoEmision,
                        codigoModalidad = pModalidad, // 1 facturación electronica en linea 2. computarizada
                        cufd = vCUFD.codigo,
                        cuis = CuisValido,
                        tipoFacturaDocumento = int.Parse(txtTipoFactura.Text),
                        archivo = bXML,
                        fechaEnvio = vTimestamp,
                        hashArchivo = XMLSHA256,
                        codigoPuntoVentaSpecified = true,


                    };
                    var resp = ObjrecepcionFactura.recepcionFactura(vobj);

                    ///persistir
                    ///

                    CabeceraFac2 cabecera = new CabeceraFac2
                    {
                        codigoCliente = "0",
                        request = SerializarToXml(vobj),
                        response = SerializarToXml(resp),
                        fechaEmision = DateTime.Now,
                        archivoXML = vXML,
                        Cuf = Objcabecera.cuf

                    };

                    contextDB.CabeceraFac2.Add(cabecera);
                    contextDB.SaveChanges();

                    /*Data.DetalleFac detalle = new Data.DetalleFac
                    {
                        idCabeceraFac = cabecera.idCabeceraFac,
                        detalle = "dddddddddd"
                    };

                    contextDB.DetalleFac.Add(detalle);
                    contextDB.SaveChanges();*/

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    //clienteCodigos.InnerChannel.Close();
                }
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(txtVecesFac.Text); i++)
            {
                emitirFacrturaCambioMoneda();
            }
        }
        public void emitirFacrturaCambioMoneda()
        {
            vDateRegister = DateTime.Now;
            if (string.IsNullOrEmpty(CuisCode))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string vXML = GeneradorXMLCM();
                vXML = vXML.Replace("utf-16", "UTF-8");
                vXML = vXML.Replace("?>", " standalone=\"yes\"?>");
                vXML = InsertaFirmaDigital(vXML);
                byte[] bXML = FacturaHelper.Zip(vXML);//Encoding.ASCII.GetBytes(vXML);
                string XMLSHA256 = FacturaHelper.sha256_hash(vXML);
                // var unixTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();

                string vTimestamp = vDateRegister.ToString(FacturaHelper.pFormatoDate); //DateTimeOffset.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff");
                //FacturacionEntidadFinanciera.ServicioFacturacionClient ObjrecepcionFactura = new FacturacionEntidadFinanciera.ServicioFacturacionClient("ServicioFacturacionPort"); //15 sector
                FacturacionElectronica.ServicioFacturacionClient ObjrecepcionFactura = new FacturacionElectronica.ServicioFacturacionClient("ServicioFacturacionPort1"); //sector 9
                //FacturacionCompraVenta.ServicioFacturacionClient ObjrecepcionFactura = new FacturacionCompraVenta.ServicioFacturacionClient("ServicioFacturacionPort2"); //1
                try
                {
                    OperationContextScope contextScope = new OperationContextScope(ObjrecepcionFactura.InnerChannel);
                    HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                    requestMessage.Headers["Authorization"] = token_impuestos;
                    requestMessage.Headers["Apikey"] = token_impuestos;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
                    //FacturacionEntidadFinanciera.solicitudRecepcionFactura vobj = new FacturacionEntidadFinanciera.solicitudRecepcionFactura
                    FacturacionElectronica.solicitudRecepcionFactura vobj = new FacturacionElectronica.solicitudRecepcionFactura
                    //FacturacionCompraVenta.solicitudRecepcionFactura vobj = new FacturacionCompraVenta.solicitudRecepcionFactura
                    {
                        codigoAmbiente = 2, // pruebas 2, produccion 1
                        codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text), // punto de venta 0 y 1, se puede crear más pero  solo se contabilizan 0 y 1
                        codigoSistema = txtCodigoDeSistema.Text,
                        codigoSucursal = int.Parse(txtCosSucursal.Text),
                        nit = pEmisor,
                        codigoDocumentoSector = int.Parse(txtSector.Text),
                        codigoEmision = pTipoEmision,
                        codigoModalidad = pModalidad, // 1 facturación electronica en linea 2. computarizada
                        cufd = vCUFD.codigo,
                        cuis = CuisValido,
                        tipoFacturaDocumento = int.Parse(txtTipoFactura.Text),
                        archivo = bXML,
                        fechaEnvio = vTimestamp,
                        hashArchivo = XMLSHA256,
                        codigoPuntoVentaSpecified = true,


                    };
                    var resp = ObjrecepcionFactura.recepcionFactura(vobj);

                    ///persistir
                    ///

                    CabeceraFac2 cabecera = new CabeceraFac2
                    {
                        codigoCliente = "0",
                        request = SerializarToXml(vobj),
                        response = SerializarToXml(resp),
                        fechaEmision = DateTime.Now,
                        archivoXML = vXML,
                        Cuf = Objcabecera.cuf

                    };

                    contextDB.CabeceraFac2.Add(cabecera);
                    contextDB.SaveChanges();

                    /*Data.DetalleFac detalle = new Data.DetalleFac
                    {
                        idCabeceraFac = cabecera.idCabeceraFac,
                        detalle = "dddddddddd"
                    };

                    contextDB.DetalleFac.Add(detalle);
                    contextDB.SaveChanges();*/

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    //clienteCodigos.InnerChannel.Close();
                }
            }
        }


        #region Recepcion Paquetes Offline


        private string pCUFDCodigoNuevo = "BQT5DbMOJQ0JBNkDYwNUQ2NTFFM0U=QkFreUxLWkxWVUFQwQjBBQTU3NzdCM";
        private string pCUFDCodigocontrolNuevo = "2B8DFD7809EDC74";
        private string pCUFDCodigoEvento = "BQT5DbMOJQ0JBNkDYwNUQ2NTFFM0U=QnxhdURMWkxWVUFQwQjBBQTU3NzdCM";
        private string pCUFDCodigoControlEvento = "0D18CB1909EDC74";
        private long pCodigoEvento = 64314;
        private List<PruebasEventoSignificativo> ColEventos = null;

        private void GetDataBDEventos()
        {
            SIN_BDEntities2 Context = new SIN_BDEntities2();
            int iPV = int.Parse(txtPuntoDeVenta.Text);

            ColEventos = Context.PruebasEventoSignificativo.Where(s => s.Procesado == false && s.CodPuntoVenta == iPV).ToList();

            //Context.puntoventa.Add()

            //LogMasivo ObjNew = new LogMasivo();
            ////ObjNew.Codigo = 1;
            ////ObjNew.XMLRequest = Serialize();

            //Context.LogMasivo.Add(ObjNew);
            //Context.SaveChanges();
        }
        private string GeneradorCUF1(string CUFD, int vTipoEmision, ParametrosCUF ObjParam)
        {
            string vTimestamp = vDateRegister.ToString(FacturaHelper.pFormatoDate); //DateTimeOffset.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff");

            //ParametrosCUF ObjParam = new ParametrosCUF();
            //ObjParam.NIT = pEmisor;
            //ObjParam.FechaHora = Convert.ToInt64(vDateRegister.ToString("yyyyMMddHHmmssfff"));  //Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            //ObjParam.Sucursal = pSucursal; //////// comun
            //ObjParam.Modalidad = pModalidad;
            //ObjParam.TipoEmision = vTipoEmision;
            //ObjParam.TipoFactura = pTipoFactura; //////// comun
            //ObjParam.TipoDocumentoSector = pcodigoDocumentoSector;  //////// comun
            //ObjParam.NumeroFactura = pNumeroFactura; //////// comun
            //ObjParam.PuntoVenta = pPuntoVenta; //////// comun 



            string vCadena = FacturaHelper.ObtieneNumCerosIzq(ObjParam.NIT, 13) +
                                 FacturaHelper.ObtieneNumCerosIzq(ObjParam.FechaHora, 17) +
                                 FacturaHelper.ObtieneNumCerosIzq(ObjParam.Sucursal, 4) +
                                 FacturaHelper.ObtieneNumCerosIzq(ObjParam.Modalidad, 1) +
                                 FacturaHelper.ObtieneNumCerosIzq(ObjParam.TipoEmision, 1) +
                                 FacturaHelper.ObtieneNumCerosIzq(ObjParam.TipoFactura, 1) +
                                 FacturaHelper.ObtieneNumCerosIzq(ObjParam.TipoDocumentoSector, 2) +
                                 FacturaHelper.ObtieneNumCerosIzq(ObjParam.NumeroFactura, 10) +
                                 FacturaHelper.ObtieneNumCerosIzq(ObjParam.PuntoVenta, 4);
            string vDigito2 = FacturaHelper.calculaDigitoMod11GOF(vCadena, 1, 9, false);
            ObjParam.CodigoAutoverificador = Convert.ToInt16(vDigito2);


            ///SE obtiene codigo previo 
            string CodigoPrevio = FacturaHelper.ObtieneNumCerosIzq(ObjParam.NIT, 13) +
                                  FacturaHelper.ObtieneNumCerosIzq(ObjParam.FechaHora, 17) +
                                  FacturaHelper.ObtieneNumCerosIzq(ObjParam.Sucursal, 4) +
                                  FacturaHelper.ObtieneNumCerosIzq(ObjParam.Modalidad, 1) +
                                  FacturaHelper.ObtieneNumCerosIzq(ObjParam.TipoEmision, 1) +
                                  FacturaHelper.ObtieneNumCerosIzq(ObjParam.TipoFactura, 1) +
                                  FacturaHelper.ObtieneNumCerosIzq(ObjParam.TipoDocumentoSector, 2) +
                                  FacturaHelper.ObtieneNumCerosIzq(ObjParam.NumeroFactura, 10) +
                                  FacturaHelper.ObtieneNumCerosIzq(ObjParam.PuntoVenta, 4) +
                                  FacturaHelper.ObtieneNumCerosIzq(ObjParam.CodigoAutoverificador, 1);

            //CodigoPrevio = "000012345678920190113163721231000011101000000000100001";



            string vR = FacturaHelper.ConvertirBase16(CodigoPrevio);
            //vR = vR.TrimStart('0');
            vR = vR + CUFD;
            return vR;
        }
        private byte[] GeneradorMasivoPaquetesXML(int vTipoEmision, PruebasEventoSignificativo ObjEvento)
        {
            List<string> ColXml = new List<string>();
            StringBuilder vListFacturas = new StringBuilder();
            string vXml = "", vCUF = "";
            //string vTimestamp = vDateRegister.ToString(FacturaHelper.pFormatoDate);

            #region Primera Factura

            DateTime fechaFac1 = Convert.ToDateTime(ObjEvento.FechaHoraIni).AddSeconds(10);

            pNumeroFactura = int.Parse(txtNroFact.Text) + ii;

            ParametrosCUF ObjParam = new ParametrosCUF();
            ObjParam.NIT = Int64.Parse(txtNit.Text);
            ObjParam.FechaHora = Convert.ToInt64(fechaFac1.ToString("yyyyMMddHHmmssfff"));  //Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            ObjParam.Sucursal = int.Parse(txtCosSucursal.Text); //////// comun
            ObjParam.Modalidad = int.Parse(txtModalidad.Text);
            ObjParam.TipoEmision = vTipoEmision;
            ObjParam.TipoFactura = int.Parse(txtTipoFactura.Text); //////// comun
            ObjParam.TipoDocumentoSector = int.Parse(txtSector.Text);  //////// comun
            ObjParam.NumeroFactura = pNumeroFactura; //////// comun
            ObjParam.PuntoVenta = int.Parse(txtPuntoDeVenta.Text); //////// comun 
            //vCUF = GeneradorCUF(pCUFDCodigoControlEvento, vTipoEmision, ObjParam);
            vCUF = GeneradorCUF1(ObjEvento.CodigoControlCUFDEvento, vTipoEmision, ObjParam);

            facturaElectronicaEntidadFinanciera ObjFactura1 = new facturaElectronicaEntidadFinanciera();
            cabeceraFactura Objcabecera = new cabeceraFactura();
            string vTimestamp1 = fechaFac1.ToString(FacturaHelper.pFormatoDate);

            Objcabecera.nitEmisor = 1029837028;
            Objcabecera.razonSocialEmisor = "PRUEBA";
            Objcabecera.municipio = "La Paz";
            Objcabecera.telefono = "2846005";
            Objcabecera.numeroFactura = pNumeroFactura; //////// comun
            Objcabecera.cuf = vCUF;
            Objcabecera.cufd = ObjEvento.CufdEvento;
            Objcabecera.codigoSucursal = int.Parse(txtCosSucursal.Text); ; //////// comun
            Objcabecera.direccion = "AV.JORGE LOPEZ #123";
            Objcabecera.codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text); ; //////// comun
            Objcabecera.fechaEmision = vTimestamp1;//DateTime.Now;//2021 - 10 - 07T09: 55:45.714;
            Objcabecera.nombreRazonSocial = "Pablo Perez";
            Objcabecera.codigoTipoDocumentoIdentidad = 5;
            Objcabecera.numeroDocumento = "1020703023";
            Objcabecera.complemento = "";
            Objcabecera.codigoCliente = "51158891";
            Objcabecera.codigoMetodoPago = 1;
            Objcabecera.numeroTarjeta = null;
            Objcabecera.montoTotalArrendamientoFinanciero = null;
            Objcabecera.montoTotal = 450;
            Objcabecera.montoTotalSujetoIva = 450.0M;
            Objcabecera.codigoMoneda = 1;
            Objcabecera.tipoCambio = 1;
            Objcabecera.montoTotalMoneda = 450;
            Objcabecera.descuentoAdicional = null;
            Objcabecera.codigoExcepcion = null;
            Objcabecera.cafc = null;
            Objcabecera.leyenda = "Ley N° 453: El proveedor debe exhibir certificaciones de habilitación o documentos que acrediten lascapacidades u ofertas de servicios especializados.";
            Objcabecera.usuario = "VSilva";
            Objcabecera.codigoDocumentoSector = int.Parse(txtSector.Text); ; //////// comun

            ObjFactura1.cabecera = Objcabecera;

            detalleFactura Objdetalle = new detalleFactura();
            Objdetalle.actividadEconomica = "641900";
            Objdetalle.codigoProductoSin = 71200;
            Objdetalle.codigoProducto = "PM - 3123 - BS";
            Objdetalle.descripcion = "Pago prima de mes de enero";
            Objdetalle.cantidad = 1;
            Objdetalle.unidadMedida = 58;
            Objdetalle.precioUnitario = 450;
            Objdetalle.montoDescuento = null;
            Objdetalle.subTotal = 450;
            ObjFactura1.detalle = Objdetalle;

            vXml = FacturaHelper.SerializarToXml(ObjFactura1);
            vXml = vXml.Replace("utf-16", "UTF-8");
            vXml = vXml.Replace("?>", " standalone=\"yes\"?>");
            vXml = InsertaFirmaDigital(vXml);

            ColXml.Add(vXml);
            #endregion


            for (int i = 0; i < ColXml.Count; i++)
            {
                FacturaHelper.CrearArchivoXML(ColXml[i], "C://FaturasSIN//Paquete1//Factura" + (i + 100).ToString() + ".xml");
            }

            FacturaHelper.CrearTarGZ("C://FacturaSINTar//paquete.tar.gz", "C://FaturasSIN//Paquete1");

            byte[] FileByte = FacturaHelper.ConvertirArchivoAByte("C://FacturaSINTar//paquete.tar.gz");

            return FileByte;
        }

        private byte[] GeneradorMasivoPaquetesXMLCV(int vTipoEmision, PruebasEventoSignificativo ObjEvento)
        {
            List<string> ColXml = new List<string>();
            StringBuilder vListFacturas = new StringBuilder();
            string vXml = "", vCUF = "";
            //string vTimestamp = vDateRegister.ToString(FacturaHelper.pFormatoDate);

            #region Primera Factura

            DateTime fechaFac1 = Convert.ToDateTime(ObjEvento.FechaHoraIni).AddSeconds(10);

            pNumeroFactura = int.Parse(txtNroFact.Text) + ii;

            ParametrosCUF ObjParam = new ParametrosCUF();
            ObjParam.NIT = Int64.Parse(txtNit.Text);
            ObjParam.FechaHora = Convert.ToInt64(fechaFac1.ToString("yyyyMMddHHmmssfff"));  //Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            ObjParam.Sucursal = int.Parse(txtCosSucursal.Text); //////// comun
            ObjParam.Modalidad = int.Parse(txtModalidad.Text);
            ObjParam.TipoEmision = vTipoEmision;
            ObjParam.TipoFactura = int.Parse(txtTipoFactura.Text); //////// comun
            ObjParam.TipoDocumentoSector = int.Parse(txtSector.Text);  //////// comun
            ObjParam.NumeroFactura = pNumeroFactura; //////// comun
            ObjParam.PuntoVenta = int.Parse(txtPuntoDeVenta.Text); //////// comun 
            //vCUF = GeneradorCUF(pCUFDCodigoControlEvento, vTipoEmision, ObjParam);
            vCUF = GeneradorCUF1(ObjEvento.CodigoControlCUFDEvento, vTipoEmision, ObjParam);

            facturaElectronicaCompraVenta ObjFactura1 = new facturaElectronicaCompraVenta();
            cabeceraFacturaCV Objcabecera = new cabeceraFacturaCV();
            string vTimestamp1 = fechaFac1.ToString(FacturaHelper.pFormatoDate);

            Objcabecera.nitEmisor = 1029837028;
            Objcabecera.razonSocialEmisor = "PRUEBA";
            Objcabecera.municipio = "La Paz";
            Objcabecera.telefono = "2846005";
            Objcabecera.numeroFactura = pNumeroFactura; //////// comun
            Objcabecera.cuf = vCUF;
            Objcabecera.cufd = ObjEvento.CufdEvento;
            Objcabecera.codigoSucursal = int.Parse(txtCosSucursal.Text); ; //////// comun
            Objcabecera.direccion = "AV.JORGE LOPEZ #123";
            Objcabecera.codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text); ; //////// comun
            Objcabecera.fechaEmision = vTimestamp1;//DateTime.Now;//2021 - 10 - 07T09: 55:45.714;
            Objcabecera.nombreRazonSocial = "Pablo Perez";
            Objcabecera.codigoTipoDocumentoIdentidad = 5;
            Objcabecera.numeroDocumento = "1020703023";
            Objcabecera.complemento = "";
            Objcabecera.codigoCliente = "51158891";
            Objcabecera.codigoMetodoPago = 1;
            Objcabecera.numeroTarjeta = null;
            //Objcabecera.montoTotalArrendamientoFinanciero = null;
            Objcabecera.montoTotal = 450;
            Objcabecera.montoTotalSujetoIva = 450.0M;
            Objcabecera.codigoMoneda = 1;
            Objcabecera.tipoCambio = 1;
            Objcabecera.montoTotalMoneda = 450;
            Objcabecera.descuentoAdicional = null;
            Objcabecera.codigoExcepcion = null;
            Objcabecera.cafc = cafc;
            Objcabecera.leyenda = "Ley N° 453: El proveedor debe exhibir certificaciones de habilitación o documentos que acrediten lascapacidades u ofertas de servicios especializados.";
            Objcabecera.usuario = "VSilva";
            Objcabecera.codigoDocumentoSector = int.Parse(txtSector.Text); ; //////// comun

            ObjFactura1.cabecera = Objcabecera;

            detalleFacturaCV Objdetalle = new detalleFacturaCV();
            Objdetalle.actividadEconomica = "641900";
            Objdetalle.codigoProductoSin = 71200;
            Objdetalle.codigoProducto = "PM - 3123 - BS";
            Objdetalle.descripcion = "Pago prima de mes de enero";
            Objdetalle.cantidad = 1;
            Objdetalle.unidadMedida = 58;
            Objdetalle.precioUnitario = 450;
            Objdetalle.montoDescuento = null;
            Objdetalle.subTotal = 450;
            ObjFactura1.detalle = Objdetalle;

            vXml = FacturaHelper.SerializarToXml(ObjFactura1);
            vXml = vXml.Replace("utf-16", "UTF-8");
            vXml = vXml.Replace("?>", " standalone=\"yes\"?>");
            vXml = InsertaFirmaDigital(vXml);

            ColXml.Add(vXml);
            #endregion


            for (int i = 0; i < ColXml.Count; i++)
            {
                FacturaHelper.CrearArchivoXML(ColXml[i], "C://FaturasSIN//Paquete1//Factura" + (i + 100).ToString() + ".xml");
            }

            FacturaHelper.CrearTarGZ("C://FacturaSINTar//paquete.tar.gz", "C://FaturasSIN//Paquete1");

            byte[] FileByte = FacturaHelper.ConvertirArchivoAByte("C://FacturaSINTar//paquete.tar.gz");

            return FileByte;
        }
        long cafc = 666;
        private byte[] GeneradorMasivoPaquetesXMLCM(int vTipoEmision, PruebasEventoSignificativo ObjEvento)
        {
            List<string> ColXml = new List<string>();
            StringBuilder vListFacturas = new StringBuilder();
            string vXml = "", vCUF = "";
            //string vTimestamp = vDateRegister.ToString(FacturaHelper.pFormatoDate);

            #region Primera Factura

            DateTime fechaFac1 = Convert.ToDateTime(ObjEvento.FechaHoraIni).AddSeconds(10);

            pNumeroFactura = int.Parse(txtNroFact.Text) + ii;

            ParametrosCUF ObjParam = new ParametrosCUF();
            ObjParam.NIT = Int64.Parse(txtNit.Text);
            ObjParam.FechaHora = Convert.ToInt64(fechaFac1.ToString("yyyyMMddHHmmssfff"));  //Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            ObjParam.Sucursal = int.Parse(txtCosSucursal.Text); //////// comun
            ObjParam.Modalidad = int.Parse(txtModalidad.Text);
            ObjParam.TipoEmision = vTipoEmision;
            ObjParam.TipoFactura = int.Parse(txtTipoFactura.Text); //////// comun
            ObjParam.TipoDocumentoSector = int.Parse(txtSector.Text);  //////// comun
            ObjParam.NumeroFactura = pNumeroFactura; //////// comun
            ObjParam.PuntoVenta = int.Parse(txtPuntoDeVenta.Text); //////// comun 
            //vCUF = GeneradorCUF(pCUFDCodigoControlEvento, vTipoEmision, ObjParam);
            vCUF = GeneradorCUF1(ObjEvento.CodigoControlCUFDEvento, vTipoEmision, ObjParam);

            facturaElectronicaMonedaExtranjera ObjFactura1 = new facturaElectronicaMonedaExtranjera();
            cabeceraFacturaCM Objcabecera = new cabeceraFacturaCM();
            string vTimestamp1 = fechaFac1.ToString(FacturaHelper.pFormatoDate);

            Objcabecera.nitEmisor = 1029837028;
            Objcabecera.razonSocialEmisor = "PRUEBA";
            Objcabecera.municipio = "La Paz";
            Objcabecera.telefono = "2846005";
            Objcabecera.numeroFactura = pNumeroFactura; //////// comun
            Objcabecera.cuf = vCUF;
            Objcabecera.cufd = ObjEvento.CufdEvento;
            Objcabecera.codigoSucursal = int.Parse(txtCosSucursal.Text); ; //////// comun
            Objcabecera.direccion = "AV.JORGE LOPEZ #123";
            Objcabecera.codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text); ; //////// comun
            Objcabecera.fechaEmision = vTimestamp1;//DateTime.Now;//2021 - 10 - 07T09: 55:45.714;
            Objcabecera.nombreRazonSocial = "Pablo Perez";
            Objcabecera.codigoTipoDocumentoIdentidad = 5;
            Objcabecera.numeroDocumento = "1020703023";
            Objcabecera.complemento = "";
            Objcabecera.codigoCliente = "51158891";
            Objcabecera.codigoMetodoPago = 1;
            Objcabecera.numeroTarjeta = null;
            //Objcabecera.montoTotalArrendamientoFinanciero = null;
            Objcabecera.montoTotal = 64.56m;
            Objcabecera.montoTotalSujetoIva = 0.00m;
            Objcabecera.codigoMoneda = 1;
            Objcabecera.tipoCambio = 6.97m;
            Objcabecera.montoTotalMoneda = 9.26m;
            Objcabecera.descuentoAdicional = null;
            Objcabecera.codigoExcepcion = null;
            Objcabecera.cafc = cafc;
            Objcabecera.leyenda = "Ley N° 453: El proveedor debe exhibir certificaciones de habilitación o documentos que acrediten lascapacidades u ofertas de servicios especializados.";
            Objcabecera.usuario = "VSilva";
            Objcabecera.codigoDocumentoSector = int.Parse(txtSector.Text); ; //////// comun
            Objcabecera.tipoCambioOficial = 6.96m;
            Objcabecera.ingresoDiferenciaCambio = 0.01m;
            Objcabecera.codigoTipoOperacion = 2;

            ObjFactura1.cabecera = Objcabecera;

            detalleFacturaCM Objdetalle = new detalleFacturaCM();
            Objdetalle.actividadEconomica = "641900";
            Objdetalle.codigoProductoSin = 71200;
            Objdetalle.codigoProducto = "PM - 3123 - BS";
            Objdetalle.descripcion = "Pago prima de mes de enero";
            Objdetalle.cantidad = 1;
            Objdetalle.unidadMedida = 58;
            Objdetalle.precioUnitario = 64.56m;
            Objdetalle.montoDescuento = null;
            Objdetalle.subTotal = 64.56m;
            ObjFactura1.detalle = Objdetalle;

            vXml = FacturaHelper.SerializarToXml(ObjFactura1);
            vXml = vXml.Replace("utf-16", "UTF-8");
            vXml = vXml.Replace("?>", " standalone=\"yes\"?>");
            vXml = InsertaFirmaDigital(vXml);

            ColXml.Add(vXml);
            #endregion


            for (int i = 0; i < ColXml.Count; i++)
            {
                FacturaHelper.CrearArchivoXML(ColXml[i], "C://FaturasSIN//Paquete1//Factura" + (i + 100).ToString() + ".xml");
            }

            FacturaHelper.CrearTarGZ("C://FacturaSINTar//paquete.tar.gz", "C://FaturasSIN//Paquete1");

            byte[] FileByte = FacturaHelper.ConvertirArchivoAByte("C://FacturaSINTar//paquete.tar.gz");

            return FileByte;
        }

        //CUFD currentCUFD = null;
        private void RecepcionPaquetes()
        {
            vDateRegister = DateTime.Now;

            GetDataBDEventos();

            if (string.IsNullOrEmpty(CuisValido))
            {
                MessageBox.Show("Solicite el código CUIS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                //vCUFD = GeneradorCUFD(false);
                vCUFD = GeneradorCUFD(false);


                // ObtenerCodigoRegistroEvento();

                pTipoEmision = 2;

                PruebasEventoSignificativo ObjEventoSelect = new PruebasEventoSignificativo();

                foreach (var item in ColEventos)
                {
                    //if (item.codEvento.ToString() == txtCodigoEventoSig.Text)
                    if (item.CodEventoSignificativo.ToString() == txtCodigoEventoSig.Text)
                    {
                        txtCodEventoEnviado.Text = txtCodigoEventoSig.Text;

                        ObjEventoSelect = item;


                        break;
                    }
                }
                byte[] bXML = null;
                //var resp;
                string sResponse = string.Empty;
                string sResponse2 = string.Empty;
                LogMasivo ObjNew = null;
                string sCodRecepcion = string.Empty;
                SIN_BDEntities2 Context = new SIN_BDEntities2();

                switch (txtSector.Text)
                {
                    case "15":
                        bXML = GeneradorMasivoPaquetesXML(pTipoEmision, ObjEventoSelect);
                        break;
                    case "9":
                        bXML = GeneradorMasivoPaquetesXMLCM(pTipoEmision, ObjEventoSelect);
                        break;
                    case "1":
                        bXML = GeneradorMasivoPaquetesXMLCV(pTipoEmision, ObjEventoSelect);
                        break;
                }

                // byte[] bXML = GeneradorMasivoPaquetesXML(pTipoEmision, ObjEventoSelect);
                string XMLSHA256 = FacturaHelper.ConvertArryaBytesToSha256(bXML);
                // var unixTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
                string vTimestamp = vDateRegister.ToString(FacturaHelper.pFormatoDate); //DateTimeOffset.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff");

                FacturacionEntidadFinanciera.ServicioFacturacionClient ObjrecepcionFactura = new FacturacionEntidadFinanciera.ServicioFacturacionClient("ServicioFacturacionPort");
                FacturacionElectronica.ServicioFacturacionClient ObjrecepcionFacturaCM = new FacturacionElectronica.ServicioFacturacionClient("ServicioFacturacionPort1");
                FacturacionCompraVenta.ServicioFacturacionClient ObjrecepcionFacturaCV = new FacturacionCompraVenta.ServicioFacturacionClient("ServicioFacturacionPort2");
                try
                {

                    OperationContextScope contextScope = new OperationContextScope(ObjrecepcionFactura.InnerChannel);

                    HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                    requestMessage.Headers["Authorization"] = token_impuestos;
                    requestMessage.Headers["Apikey"] = token_impuestos;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
                    switch (txtSector.Text)
                    {
                        case "15":
                            FacturacionEntidadFinanciera.solicitudRecepcionPaquete vobj = new FacturacionEntidadFinanciera.solicitudRecepcionPaquete
                            {
                                codigoAmbiente = 2, // pruebas 2, produccion 1
                                codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text), // punto de venta 0 y 1, se puede crear más pero  solo se contabilizan 0 y 1
                                codigoSistema = txtCodigoDeSistema.Text,
                                codigoSucursal = int.Parse(txtCosSucursal.Text),
                                nit = Int64.Parse(txtNit.Text),
                                codigoDocumentoSector = int.Parse(txtSector.Text),
                                codigoEmision = pTipoEmisionP,
                                codigoModalidad = pModalidad, // 1 facturación electronica en linea 2. computarizada
                                cufd = vCUFD.codigo, // pCUFDCodigoNuevo, //vCUFD.codigo,  CUFD nuevo
                                cuis = CuisValido,
                                tipoFacturaDocumento = int.Parse(txtTipoFactura.Text),
                                archivo = bXML,
                                fechaEnvio = vTimestamp,
                                hashArchivo = XMLSHA256,
                                cantidadFacturas = 1,
                                cafc = null,
                                codigoEvento = Int64.Parse(txtCodEventoEnviado.Text),
                                codigoPuntoVentaSpecified = true,
                                //codigoPuntoVentaSpecified = false,

                            };
                            var resp = ObjrecepcionFactura.recepcionPaqueteFactura(vobj);
                            sResponse = Serialize(vobj);
                            sResponse2 = Serialize(resp);

                            ObjNew = new LogMasivo()
                            {
                                Codigo = resp.codigoEstado.ToString(),
                                CodigoExcepcion = "",
                                codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text),
                                CodigoRecepcion = resp.codigoRecepcion,
                                codigoSucursal = int.Parse(txtCosSucursal.Text),
                                Descripcion = resp.codigoDescripcion,
                                Estado = true,
                                FechaProceso = DateTime.Now,
                                IdPruebaEvento = ObjEventoSelect.IdPruebaEvento,
                                CodigoEvento = Int64.Parse(txtCodEventoEnviado.Text),
                                Servicio = "recepcionPaqueteFactura",
                                TipoFactura = int.Parse(txtTipoFactura.Text),
                                XMLRequest = sResponse,
                                XMLResponse = sResponse2
                            };
                            sCodRecepcion = resp.codigoRecepcion;
                            Context.LogMasivo.Add(ObjNew);
                            Context.SaveChanges();
                            vCUFD = GeneradorCUFD(false);

                            FacturacionEntidadFinanciera.solicitudValidacionRecepcion vobjv = new FacturacionEntidadFinanciera.solicitudValidacionRecepcion
                            {
                                codigoAmbiente = 2, // pruebas 2, produccion 1
                                codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text),
                                codigoPuntoVentaSpecified = true,
                                codigoSistema = txtCodigoDeSistema.Text,
                                codigoSucursal = int.Parse(txtCosSucursal.Text),
                                nit = Int64.Parse(txtNit.Text),
                                codigoDocumentoSector = int.Parse(txtSector.Text),
                                codigoEmision = 2,//offline
                                codigoModalidad = pModalidad, // 1 facturación electronica en linea 2. computarizada
                                cufd = vCUFD.codigo,
                                cuis = CuisValido,
                                tipoFacturaDocumento = int.Parse(txtTipoFactura.Text),
                                codigoRecepcion = resp.codigoRecepcion//"08edf3f9-4ba2-11ec-9fc3-df299c636642"// "23f8da28-4b9e-11ec-be1e-c1ea96abc198"

                            };
                            var resp1 = ObjrecepcionFactura.validacionRecepcionPaqueteFactura(vobjv);
                            //txtCodigoRecepcion.Text = resp.codigoRecepcion;

                            ObjNew = new LogMasivo()
                            {
                                Codigo = resp1.codigoEstado.ToString(),
                                CodigoExcepcion = "",
                                codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text),
                                CodigoRecepcion = resp1.codigoRecepcion,
                                codigoSucursal = int.Parse(txtCosSucursal.Text),
                                Descripcion = resp1.codigoDescripcion,
                                Estado = true,
                                FechaProceso = DateTime.Now,
                                IdPruebaEvento = 0,
                                CodigoEvento = 0,
                                Servicio = "validacionRecepcionPaqueteFactura",
                                TipoFactura = int.Parse(txtTipoFactura.Text),
                                XMLRequest = Serialize(vobjv),
                                XMLResponse = Serialize(resp1)
                            };


                            Context.LogMasivo.Add(ObjNew);
                            Context.SaveChanges();

                            break;
                        case "9":
                            FacturacionElectronica.solicitudRecepcionPaquete vobjCM = new FacturacionElectronica.solicitudRecepcionPaquete
                            {
                                codigoAmbiente = 2, // pruebas 2, produccion 1
                                codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text), // punto de venta 0 y 1, se puede crear más pero  solo se contabilizan 0 y 1
                                codigoSistema = txtCodigoDeSistema.Text,
                                codigoSucursal = int.Parse(txtCosSucursal.Text),
                                nit = Int64.Parse(txtNit.Text),
                                codigoDocumentoSector = int.Parse(txtSector.Text),
                                codigoEmision = pTipoEmisionP,
                                codigoModalidad = pModalidad, // 1 facturación electronica en linea 2. computarizada
                                cufd = vCUFD.codigo, // pCUFDCodigoNuevo, //vCUFD.codigo,  CUFD nuevo
                                cuis = CuisValido,
                                tipoFacturaDocumento = int.Parse(txtTipoFactura.Text),
                                archivo = bXML,
                                fechaEnvio = vTimestamp,
                                hashArchivo = XMLSHA256,
                                cantidadFacturas = 1,
                                cafc = null,
                                codigoEvento = Int64.Parse(txtCodEventoEnviado.Text),
                                codigoPuntoVentaSpecified = true,
                                //codigoPuntoVentaSpecified = false,

                            };
                            var respCM = ObjrecepcionFacturaCM.recepcionPaqueteFactura(vobjCM);
                            sResponse = Serialize(vobjCM);
                            sResponse2 = Serialize(respCM);
                            ObjNew = new LogMasivo()
                            {
                                Codigo = respCM.codigoEstado.ToString(),
                                CodigoExcepcion = "",
                                codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text),
                                CodigoRecepcion = respCM.codigoRecepcion,
                                codigoSucursal = int.Parse(txtCosSucursal.Text),
                                Descripcion = respCM.codigoDescripcion,
                                Estado = true,
                                FechaProceso = DateTime.Now,
                                IdPruebaEvento = ObjEventoSelect.IdPruebaEvento,
                                CodigoEvento = Int64.Parse(txtCodEventoEnviado.Text),
                                Servicio = "recepcionPaqueteFactura",
                                TipoFactura = int.Parse(txtTipoFactura.Text),
                                XMLRequest = sResponse,
                                XMLResponse = sResponse2
                            };
                            sCodRecepcion = respCM.codigoRecepcion;
                            Context.LogMasivo.Add(ObjNew);
                            Context.SaveChanges();

                            vCUFD = GeneradorCUFD(false);

                            FacturacionElectronica.solicitudValidacionRecepcion vobjvCM = new FacturacionElectronica.solicitudValidacionRecepcion
                            {
                                codigoAmbiente = 2, // pruebas 2, produccion 1
                                codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text),
                                codigoPuntoVentaSpecified = true,
                                codigoSistema = txtCodigoDeSistema.Text,
                                codigoSucursal = int.Parse(txtCosSucursal.Text),
                                nit = Int64.Parse(txtNit.Text),
                                codigoDocumentoSector = int.Parse(txtSector.Text),
                                codigoEmision = 2,//offline
                                codigoModalidad = pModalidad, // 1 facturación electronica en linea 2. computarizada
                                cufd = vCUFD.codigo,
                                cuis = CuisValido,
                                tipoFacturaDocumento = int.Parse(txtTipoFactura.Text),
                                codigoRecepcion = respCM.codigoRecepcion//"08edf3f9-4ba2-11ec-9fc3-df299c636642"// "23f8da28-4b9e-11ec-be1e-c1ea96abc198"

                            };
                            var resp1CM = ObjrecepcionFacturaCM.validacionRecepcionPaqueteFactura(vobjvCM);
                            //txtCodigoRecepcion.Text = resp.codigoRecepcion;

                            ObjNew = new LogMasivo()
                            {
                                Codigo = resp1CM.codigoEstado.ToString(),
                                CodigoExcepcion = "",
                                codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text),
                                CodigoRecepcion = resp1CM.codigoRecepcion,
                                codigoSucursal = int.Parse(txtCosSucursal.Text),
                                Descripcion = resp1CM.codigoDescripcion,
                                Estado = true,
                                FechaProceso = DateTime.Now,
                                IdPruebaEvento = 0,
                                CodigoEvento = 0,
                                Servicio = "validacionRecepcionPaqueteFactura",
                                TipoFactura = int.Parse(txtTipoFactura.Text),
                                XMLRequest = Serialize(vobjvCM),
                                XMLResponse = Serialize(resp1CM)
                            };


                            Context.LogMasivo.Add(ObjNew);
                            Context.SaveChanges();

                            break;
                        case "1":
                            FacturacionCompraVenta.solicitudRecepcionPaquete vobjCV = new FacturacionCompraVenta.solicitudRecepcionPaquete
                            {
                                codigoAmbiente = 2, // pruebas 2, produccion 1
                                codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text), // punto de venta 0 y 1, se puede crear más pero  solo se contabilizan 0 y 1
                                codigoSistema = txtCodigoDeSistema.Text,
                                codigoSucursal = int.Parse(txtCosSucursal.Text),
                                nit = Int64.Parse(txtNit.Text),
                                codigoDocumentoSector = int.Parse(txtSector.Text),
                                codigoEmision = pTipoEmisionP,
                                codigoModalidad = pModalidad, // 1 facturación electronica en linea 2. computarizada
                                cufd = vCUFD.codigo, // pCUFDCodigoNuevo, //vCUFD.codigo,  CUFD nuevo
                                cuis = CuisValido,
                                tipoFacturaDocumento = int.Parse(txtTipoFactura.Text),
                                archivo = bXML,
                                fechaEnvio = vTimestamp,
                                hashArchivo = XMLSHA256,
                                cantidadFacturas = 1,
                                cafc = cafc.ToString(),
                                codigoEvento = Int64.Parse(txtCodEventoEnviado.Text),
                                codigoPuntoVentaSpecified = true,
                                //codigoPuntoVentaSpecified = false,

                            };
                            var respCV = ObjrecepcionFacturaCV.recepcionPaqueteFactura(vobjCV);
                            sResponse = Serialize(vobjCV);
                            sResponse2 = Serialize(respCV);
                            ObjNew = new LogMasivo()
                            {
                                Codigo = respCV.codigoEstado.ToString(),
                                CodigoExcepcion = "",
                                codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text),
                                CodigoRecepcion = respCV.codigoRecepcion,
                                codigoSucursal = int.Parse(txtCosSucursal.Text),
                                Descripcion = respCV.codigoDescripcion,
                                Estado = true,
                                FechaProceso = DateTime.Now,
                                IdPruebaEvento = ObjEventoSelect.IdPruebaEvento,
                                CodigoEvento = Int64.Parse(txtCodEventoEnviado.Text),
                                Servicio = "recepcionPaqueteFactura",
                                TipoFactura = int.Parse(txtTipoFactura.Text),
                                XMLRequest = sResponse,
                                XMLResponse = sResponse2
                            };
                            sCodRecepcion = respCV.codigoRecepcion;
                            Context.LogMasivo.Add(ObjNew);
                            Context.SaveChanges();

                            vCUFD = GeneradorCUFD(false);

                            // vCUFD = GeneradorCUFD(false);

                            FacturacionCompraVenta.solicitudValidacionRecepcion vobjvCV = new FacturacionCompraVenta.solicitudValidacionRecepcion
                            {
                                codigoAmbiente = 2, // pruebas 2, produccion 1
                                codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text),
                                codigoPuntoVentaSpecified = true,
                                codigoSistema = txtCodigoDeSistema.Text,
                                codigoSucursal = int.Parse(txtCosSucursal.Text),
                                nit = Int64.Parse(txtNit.Text),
                                codigoDocumentoSector = int.Parse(txtSector.Text),
                                codigoEmision = 2,//offline
                                codigoModalidad = pModalidad, // 1 facturación electronica en linea 2. computarizada
                                cufd = vCUFD.codigo,
                                cuis = CuisValido,
                                tipoFacturaDocumento = int.Parse(txtTipoFactura.Text),
                                codigoRecepcion = respCV.codigoRecepcion//"08edf3f9-4ba2-11ec-9fc3-df299c636642"// "23f8da28-4b9e-11ec-be1e-c1ea96abc198"

                            };
                            var resp1CV = ObjrecepcionFacturaCV.validacionRecepcionPaqueteFactura(vobjvCV);
                            //txtCodigoRecepcion.Text = resp.codigoRecepcion;

                            ObjNew = new LogMasivo()
                            {
                                Codigo = resp1CV.codigoEstado.ToString(),
                                CodigoExcepcion = "",
                                codigoPuntoVenta = int.Parse(txtPuntoDeVenta.Text),
                                CodigoRecepcion = resp1CV.codigoRecepcion,
                                codigoSucursal = int.Parse(txtCosSucursal.Text),
                                Descripcion = resp1CV.codigoDescripcion,
                                Estado = true,
                                FechaProceso = DateTime.Now,
                                IdPruebaEvento = 0,
                                CodigoEvento = 0,
                                Servicio = "validacionRecepcionPaqueteFactura",
                                TipoFactura = int.Parse(txtTipoFactura.Text),
                                XMLRequest = Serialize(vobjvCV),
                                XMLResponse = Serialize(resp1CV)
                            };


                            Context.LogMasivo.Add(ObjNew);
                            Context.SaveChanges();


                            break;
                    }



                    txtCodigoRecepcion.Text = sCodRecepcion;
                    //#region ValidacionPaquete

                    //#endregion

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    //throw ex;
                }
                finally
                {
                    //clienteCodigos.InnerChannel.Close();
                }
            }

        }



        public static string Serialize<T>(T dataToSerialize)
        {
            try
            {
                var stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stringwriter, dataToSerialize);
                return stringwriter.ToString();
            }
            catch
            {
                throw;
            }
        }

        public static T Deserialize<T>(string xmlText)
        {
            try
            {
                var stringReader = new System.IO.StringReader(xmlText);
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
            catch
            {
                throw;
            }
        }

        #endregion
        int ii;
        private void btnRecepPaquete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(txtVecesFac.Text); i++)
            {
                ii = i;
                RecepcionPaquetes();

            }
            MessageBox.Show("Es un capo");

        }



        public PruebasEventoSignificativo CreaEventoSignificativo(int IdTipoEvento, int codPuntoVenta)
        {
            List<string> colEventosString = new List<string>();
            colEventosString.Add("CORTE DEL SERVICIO DE INTERNET");
            colEventosString.Add("INACCESIBILIDAD AL SERVICIO WEB DE LA ADMINISTRACIÓN TRIBUTARIA");
            colEventosString.Add("INGRESO A ZONAS SIN INTERNET POR DESPLIEGUE DE PUNTO DE VENTA EN VEHICULOS AUTOMOTORES");
            colEventosString.Add("VENTA EN LUGARES SIN INTERNET");
            colEventosString.Add("CORTE DE SUMINISTRO DE ENERGIA ELECTRICA");
            colEventosString.Add("VIRUS INFORMÁTICO O FALLA DE SOFTWARE");
            colEventosString.Add("CAMBIO DE INFRAESTRUCTURA DEL SISTEMA INFORMÁTICO DE FACTURACIÓN O FALLA DE HARDWARE");
            var context = new SIN_BDEntities2();

            string CUIOP = CuisValido;

            int intentos = 1;
            int puntosVenta = 1;
            int IdsEvento = 1;


            DateTime FechaEventoIni = DateTime.Now;
            CUFD CufdEvento = registrCUFD(0, codPuntoVenta, CUIOP);
            System.Threading.Thread.Sleep(70000);
            DateTime FechaEventoFin = DateTime.Now;

            CUFD CufdActual = registrCUFD(0, codPuntoVenta, CUIOP);

            ///////asdasdasdasd
            ///


            var rEvento = RegistroEventoSignificativo(0, codPuntoVenta, IdTipoEvento, CUIOP, CufdEvento.CufdValue, CufdActual.CufdValue,
                FechaEventoIni, FechaEventoFin);
            try
            {

                PruebasEventoSignificativo objNuevaPrueba = new PruebasEventoSignificativo
                {
                    codEvento = IdTipoEvento,
                    CodEventoSignificativo = rEvento.codigoevento.ToString(),
                    CodPuntoVenta = codPuntoVenta,
                    CodSucursal = 0,
                    CufdEvento = CufdEvento.CufdValue,
                    DescripcionEvento = colEventosString[IdTipoEvento - 1],
                    FechaHoraFin = FechaEventoFin,
                    FechaHoraIni = FechaEventoIni,
                    IDCUFD = Convert.ToInt32(CufdActual.IdCUFD),
                    IDCUFDEVENTO = Convert.ToInt32(CufdEvento.IdCUFD),
                    Procesado = false,
                    XmlRequest = rEvento.XMLRequest,
                    XmlResponse = rEvento.XMLResponse,
                    IdRegistroEvento = Convert.ToInt32(rEvento.IdRegistroEvento),
                    CodigoControlCUFD = CufdActual.CodigoControl,
                    CodigoControlCUFDEvento = CufdEvento.CodigoControl
                };
                context.PruebasEventoSignificativo.Add(objNuevaPrueba);
                context.SaveChanges();
                return objNuevaPrueba;

            }
            catch (Exception ex)
            {

            }
            return null;


        }
        public RegistroEvento RegistroEventoSignificativo(int IdOffice, int IdPuntoVenta, int idevento, string CUIS, string CUFDEVENTO,
           string CUFDACTUAL, DateTime FechaHoraIni, DateTime FechahoraFin)
        {

            //if (GetCantidadCUFDOffice() >= 2)
            //{
            var context = new SIN_BDEntities2();
            FacturacionOperaciones.ServicioFacturacionOperacionesClient vclienteop = new FacturacionOperaciones.ServicioFacturacionOperacionesClient();

            OperationContextScope contextScope = new OperationContextScope(vclienteop.InnerChannel);
            HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
            requestMessage.Headers["Authorization"] = token_impuestos;
            requestMessage.Headers["Apikey"] = token_impuestos;
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;



            solicitudEventoSignificativo objevento = new solicitudEventoSignificativo
            {
                codigoAmbiente = 2,
                codigoMotivoEvento = idevento,
                codigoPuntoVenta = IdPuntoVenta,
                codigoPuntoVentaSpecified = true,
                codigoSistema = "6D0B0AA5777B0605D651E3E",
                codigoSucursal = IdOffice,
                cufd = CUFDACTUAL,
                cufdEvento = CUFDEVENTO,
                cuis = CUIS,
                descripcion = "registro de evento significativo " + IdOffice.ToString(),
                fechaHoraFinEvento = FechahoraFin,
                fechaHoraInicioEvento = FechaHoraIni,
                nit = 1029837028

            };

            string XMLRequest = Serialize(objevento);
            StringBuilder vMessage = new StringBuilder();
            vMessage.AppendLine("************XML DE OBJETO REQUEST ********");
            vMessage.AppendLine("************PUNTO DE VENTA 0********");
            vMessage.AppendLine("");
            vMessage.AppendLine("");
            vMessage.AppendLine(XMLRequest);


            var resultado = vclienteop.registroEventoSignificativo(objevento);
            vMessage.AppendLine("");
            vMessage.AppendLine("");

            vMessage.AppendLine("************XML DE OBJETO RESPONSE ********");
            vMessage.AppendLine("");
            vMessage.AppendLine("");
            vMessage.AppendLine(Serialize(resultado));
            // txtRegistroevento.Text = vMessage.ToString();
            if (resultado.mensajesList == null || resultado.mensajesList.Count() == 0)
            {
                RegistroEvento ObjREvento = new RegistroEvento
                {
                    codigoevento = resultado.codigoRecepcionEventoSignificativo,
                    CodigoMotivoEvento = idevento,
                    CodigoSucursal = IdOffice,
                    cufd = CUFDACTUAL,
                    cufdevento = CUFDEVENTO,
                    Cui = CUIS,
                    FechaHoraFin = FechahoraFin,
                    FechaHoraInicio = FechaHoraIni,
                    FechaHoraRegistro = DateTime.Now,
                    codpuntoventa = IdPuntoVenta,
                    XMLRequest = XMLRequest,
                    XMLResponse = Serialize(resultado)
                };
                context.RegistroEvento.Add(ObjREvento);
                context.SaveChanges();
                return ObjREvento;
            }
            return null;
            //}
            //else
            //    MessageBox.Show("No se tiene mas de un CUFD para el registro");
            //return null;            //}
            //else
            //    MessageBox.Show("No se tiene mas de un CUFD para el registro");
            //return null;

        }

        public CUFD registrCUFD(int IdOffice, int IdPuntoVenta, string CUIS)
        {
            FacturacionCodigos.ServicioFacturacionCodigosClient vcliente = new FacturacionCodigos.ServicioFacturacionCodigosClient();
            OperationContextScope contextScope = new OperationContextScope(vcliente.InnerChannel);

            HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
            requestMessage.Headers["Apikey"] = token_impuestos;
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
            FacturacionCodigos.solicitudCufd objSol = new FacturacionCodigos.solicitudCufd
            {
                codigoAmbiente = 2,
                codigoModalidad = 1,
                codigoPuntoVenta = IdPuntoVenta,
                codigoPuntoVentaSpecified = true,
                codigoSistema = "6D0B0AA5777B0605D651E3E",
                codigoSucursal = IdOffice,
                cuis = CUIS,
                nit = 1029837028
            };


            var respuesta = vcliente.cufd(objSol);
            string Serializado = Serialize(respuesta);

            string XMLRequest = Serialize(objSol);
            StringBuilder vMessage = new StringBuilder();
            vMessage.AppendLine("************XML DE OBJETO REQUEST ********");
            vMessage.AppendLine("************CUIS PUNTO DE VENTA 1********");
            vMessage.AppendLine("");
            vMessage.AppendLine("");
            vMessage.AppendLine(XMLRequest);


            vMessage.AppendLine("");
            vMessage.AppendLine("");

            vMessage.AppendLine("************XML DE OBJETO RESPONSE ********");
            vMessage.AppendLine("");
            vMessage.AppendLine("");
            vMessage.AppendLine(Serializado);
            //txtCufd.Text = vMessage.ToString();



            if (respuesta.codigo != null && respuesta.codigoControl != null)
            {
                CUFD objcufd = new CUFD
                {
                    CodSucursal = IdOffice,
                    CufdValue = respuesta.codigo,
                    Cuis = CUIS,
                    XMLRequest = Serializado,
                    FechaHora = DateTime.Now,
                    CodigoControl = respuesta.codigoControl,
                    CodpuntoVenta = IdPuntoVenta,
                    FechaVigenciaSIN = respuesta.fechaVigencia

                };

                var context = new SIN_BDEntities2();
                context.CUFD.Add(objcufd);
                context.SaveChanges();
                return objcufd;
            }
            return null;

        }

        private void button39_Click(object sender, EventArgs e)
        {
            ProcesaEventosAntiguos(txtCodEvento.Text);
            PruebasEventoSignificativo reg = CreaEventoSignificativo(int.Parse(txtCodEvento.Text), int.Parse(txtPuntoDeVenta.Text));
            txtCodigoEventoSig.Text = reg.CodEventoSignificativo;
            MessageBox.Show("Es un capo1");

        }

        public void ProcesaEventosAntiguos(string codevento)
        {
            var context = new SIN_BDEntities2();
            string consulta = @"update [SIN_BD].[dbo].[PruebasEventoSignificativo]
                          set procesado=1
                          where codevento= @codevento";
            var param = new SqlParameter("@codevento", codevento);
            int valor = context.Database.ExecuteSqlCommand(consulta, param);

        }

        public string registraCUIS(int idcodSucursal, int IdPuntoVenta)
        {

            var context = new SIN_BDEntities2();
            FacturacionCodigos.ServicioFacturacionCodigosClient vcliente = new FacturacionCodigos.ServicioFacturacionCodigosClient();
            OperationContextScope contextScope = new OperationContextScope(vcliente.InnerChannel);

            HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
            requestMessage.Headers["Apikey"] = token_impuestos;
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

            FacturacionCodigos.solicitudCuis objSol = new FacturacionCodigos.solicitudCuis
            {
                codigoAmbiente = 2,
                codigoModalidad = 1,
                codigoPuntoVenta = IdPuntoVenta,
                codigoPuntoVentaSpecified = true,

                //codigoPuntoVenta = 0,
                //codigoPuntoVentaSpecified = false,
                codigoSistema = "6D0B0AA5777B0605D651E3E",
                codigoSucursal = idcodSucursal,
                nit = 1029837028
            };
            var resultado = vcliente.cuis(objSol);

            return resultado.codigo;
        }


        public void ProcesarANULADAS()
        {
            var context = new SIN_BDEntities2();
            List<CabeceraFac2> colFacturas = context.CabeceraFac2.Where(s => s.Procesado != null && s.Procesado == false && s.request != "" && s.response != "" && s.response.Contains("<codigoDescripcion>VALIDADA</codigoDescripcion>")).ToList();
            foreach (var item in colFacturas)
            {


                FacturacionEntidadFinanciera.solicitudRecepcionFactura objFactura = Deserialize<FacturacionEntidadFinanciera.solicitudRecepcionFactura>(item.request);
                ///Entidad financiera
                if (objFactura.codigoDocumentoSector == 15)
                {
                    facturaElectronicaEntidadFinanciera objArchivoF = Deserialize<facturaElectronicaEntidadFinanciera>(item.archivoXML);
                    if (objArchivoF != null)
                        AnularFinanciera(item, objFactura, objArchivoF.cabecera.cuf);
                }
                ///Electronica
                else if (objFactura.codigoDocumentoSector == 9)
                {
                    facturaElectronicaMonedaExtranjera objArchivoE = Deserialize<facturaElectronicaMonedaExtranjera>(item.archivoXML);
                    if (objArchivoE != null)
                        AnularElectronica(item, objFactura, objArchivoE.cabecera.cuf);
                }
                ////Compraventa
                else if (objFactura.codigoDocumentoSector == 1)
                {
                    facturaElectronicaCompraVenta objArchivoCV = Deserialize<facturaElectronicaCompraVenta>(item.archivoXML);
                    if (objArchivoCV != null)
                        AnularCompraVenta(item, objFactura, objArchivoCV.cabecera.cuf);
                }


            }
        }


        public void AnularElectronica(CabeceraFac2 objAnular, FacturacionEntidadFinanciera.solicitudRecepcionFactura objSolicitud, string CUF)
        {
            var context = new SIN_BDEntities2();
            string CUIOP = registraCUIS(0, objSolicitud.codigoPuntoVenta);
            CUFD CufdEvento = registrCUFD(0, objSolicitud.codigoPuntoVenta, CUIOP);


            //List<CabeceraFac2> ColFacturas = context.CabeceraFac2.Where(s => s.request != "" && s.response != "").ToList();

            FacturacionElectronica.ServicioFacturacionClient vclienteop = new FacturacionElectronica.ServicioFacturacionClient();
            OperationContextScope contextScope = new OperationContextScope(vclienteop.InnerChannel);

            HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
            requestMessage.Headers["Apikey"] = token_impuestos;
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
            //vclienteop.anulacionFactura()
            FacturacionElectronica.solicitudAnulacion objAnula = new FacturacionElectronica.solicitudAnulacion
            {
                codigoAmbiente = 2,
                codigoDocumentoSector = 9,//
                codigoEmision = objSolicitud.codigoEmision,//2a1
                codigoModalidad = objSolicitud.codigoModalidad,
                codigoMotivo = 1,//BASE
                codigoPuntoVenta = objSolicitud.codigoPuntoVenta,
                codigoPuntoVentaSpecified = true,
                codigoSistema = objSolicitud.codigoSistema,
                codigoSucursal = 0,
                cuf = CUF,
                cufd = CufdEvento.CufdValue,
                cuis = CUIOP,
                nit = 1029837028,
                tipoFacturaDocumento = objSolicitud.tipoFacturaDocumento

            };
            var respuesta = vclienteop.anulacionFactura(objAnula);

            try
            {
                FacturasAnuladas objNew = new FacturasAnuladas
                {
                    codigoDescripcion = respuesta.codigoDescripcion == null ? "" : respuesta.codigoDescripcion,
                    codigoEstado = respuesta.codigoEstado,
                    codigoRecepcion = respuesta.codigoRecepcion == null ? "" : respuesta.codigoRecepcion,
                    FechaProceso = DateTime.Now,
                    IdCabeceraFac = objAnular.idCabeceraFac,
                    Procesado = true,
                    XMLRequest = Serialize(objAnula),
                    XMLResponse = Serialize(respuesta),
                    TipoFactura = "ELECTRONICA"

                };

                context.FacturasAnuladas.Add(objNew);
                context.SaveChanges();

                MarcaFacturaAnulada(objAnular.idCabeceraFac.ToString());
            }
            catch (Exception ex)
            {


            }
        }
        public void AnularFinanciera(CabeceraFac2 objAnular, FacturacionEntidadFinanciera.solicitudRecepcionFactura objSolicitud, string CUF)
        {
            var context = new SIN_BDEntities2();
            string CUIOP = registraCUIS(0, objSolicitud.codigoPuntoVenta);
            CUFD CufdEvento = registrCUFD(0, objSolicitud.codigoPuntoVenta, CUIOP);

            //List<CabeceraFac2> ColFacturas = context.CabeceraFac2.Where(s => s.request != "" && s.response != "").ToList();

            FacturacionEntidadFinanciera.ServicioFacturacionClient vclienteop = new FacturacionEntidadFinanciera.ServicioFacturacionClient();
            OperationContextScope contextScope = new OperationContextScope(vclienteop.InnerChannel);

            HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
            requestMessage.Headers["Apikey"] = token_impuestos;
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
            //vclienteop.anulacionFactura()
            FacturacionEntidadFinanciera.solicitudAnulacion objAnula = new FacturacionEntidadFinanciera.solicitudAnulacion
            {
                codigoAmbiente = 2,
                codigoDocumentoSector = 15,//
                codigoEmision = objSolicitud.codigoEmision,//2a1
                codigoModalidad = objSolicitud.codigoModalidad,
                codigoMotivo = 1,//BASE
                codigoPuntoVenta = objSolicitud.codigoPuntoVenta,
                codigoPuntoVentaSpecified = true,
                codigoSistema = objSolicitud.codigoSistema,
                codigoSucursal = 0,
                cuf = CUF,
                cufd = CufdEvento.CufdValue,
                cuis = CUIOP,
                nit = 1029837028,
                tipoFacturaDocumento = objSolicitud.tipoFacturaDocumento

            };
            var respuesta = vclienteop.anulacionFactura(objAnula);

            try
            {
                FacturasAnuladas objNew = new FacturasAnuladas
                {
                    codigoDescripcion = respuesta.codigoDescripcion == null ? "" : respuesta.codigoDescripcion,
                    codigoEstado = respuesta.codigoEstado,
                    codigoRecepcion = respuesta.codigoRecepcion == null ? "" : respuesta.codigoRecepcion,
                    FechaProceso = DateTime.Now,
                    IdCabeceraFac = objAnular.idCabeceraFac,
                    Procesado = true,
                    XMLRequest = Serialize(objAnula),
                    XMLResponse = Serialize(respuesta),
                    TipoFactura = "FINANCIERA"
                };

                context.FacturasAnuladas.Add(objNew);
                context.SaveChanges();
                MarcaFacturaAnulada(objAnular.idCabeceraFac.ToString());

            }
            catch (Exception ex)
            {


            }

        }

        public void AnularCompraVenta(CabeceraFac2 objAnular, FacturacionEntidadFinanciera.solicitudRecepcionFactura objSolicitud, string CUF)
        {
            var context = new SIN_BDEntities2();
            string CUIOP = registraCUIS(0, objSolicitud.codigoPuntoVenta);
            CUFD CufdEvento = registrCUFD(0, objSolicitud.codigoPuntoVenta, CUIOP);

            //List<CabeceraFac2> ColFacturas = context.CabeceraFac2.Where(s => s.request != "" && s.response != "").ToList();

            FacturacionCompraVenta.ServicioFacturacionClient vclienteop = new FacturacionCompraVenta.ServicioFacturacionClient();
            OperationContextScope contextScope = new OperationContextScope(vclienteop.InnerChannel);

            HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
            requestMessage.Headers["Apikey"] = token_impuestos;
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
            //vclienteop.anulacionFactura()
            FacturacionCompraVenta.solicitudAnulacion objAnula = new FacturacionCompraVenta.solicitudAnulacion
            {
                codigoAmbiente = 2,
                codigoDocumentoSector = 1,
                codigoEmision = objSolicitud.codigoEmision,//2a1
                codigoModalidad = objSolicitud.codigoModalidad,
                codigoMotivo = 1,//BASE
                codigoPuntoVenta = objSolicitud.codigoPuntoVenta,
                codigoPuntoVentaSpecified = true,
                codigoSistema = objSolicitud.codigoSistema,
                codigoSucursal = 0,
                cuf = CUF,
                cufd = CufdEvento.CufdValue,
                cuis = CUIOP,
                nit = 1029837028,
                tipoFacturaDocumento = objSolicitud.tipoFacturaDocumento

            };
            var respuesta = vclienteop.anulacionFactura(objAnula);

            try
            {
                FacturasAnuladas objNew = new FacturasAnuladas
                {
                    codigoDescripcion = respuesta.codigoDescripcion == null ? "" : respuesta.codigoDescripcion,
                    codigoEstado = respuesta.codigoEstado,
                    codigoRecepcion = respuesta.codigoRecepcion == null ? "" : respuesta.codigoRecepcion,
                    FechaProceso = DateTime.Now,
                    IdCabeceraFac = objAnular.idCabeceraFac,
                    Procesado = true,
                    XMLRequest = Serialize(objAnula),
                    XMLResponse = Serialize(respuesta),
                    TipoFactura = "COMPRA VENTA"

                };

                context.FacturasAnuladas.Add(objNew);
                context.SaveChanges();

                MarcaFacturaAnulada(objAnular.idCabeceraFac.ToString());

            }
            catch (Exception ex)
            {


            }
        }

        public void MarcaFacturaAnulada(string idfactura)
        {
            var context = new SIN_BDEntities2();
            string consulta = @"  update [dbo].[CabeceraFac2]
                              set Procesado=1
                               where idcabecerafac = @idfactura";
            var param = new SqlParameter("@idfactura", idfactura);
            int valor = context.Database.ExecuteSqlCommand(consulta, param);

        }

        private void button40_Click(object sender, EventArgs e)
        {
            ProcesarANULADAS();
        }
    }
}

