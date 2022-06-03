using Business.Main.Base;
using Business.Main.DataMappingFacturacion;
using Domain.Main.Wraper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Business.Main.ManagersFacturacion
{
    public class SINOficinaManager : BaseManager
    {
        public static string apiKey = "TokenApi eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJHYW1hdGVrIiwiY29kaWdvU2lzdGVtYSI6IjcyMDEzMjZGMDdFRDlGNENFMEU3RDJGIiwibml0IjoiSDRzSUFBQUFBQUFBQURNeE1EU3dzTFF3TURRQkFMbmxvdjhLQUFBQSIsImlkIjozMDE0NDg0LCJleHAiOjE2NjcyNjA4MDAsImlhdCI6MTY1MjgwMzIwMywibml0RGVsZWdhZG8iOjQwMTA4OTgwMTQsInN1YnNpc3RlbWEiOiJTRkUifQ.O9DltacO2LFpEXrBFq_JyZGH1X7AWA_AhqVjltQNxTA9oU08rcs2x3dUyI97kHDuRaKp3TktmhXgie-O5PAq8g";
        public Response ConsutaPuntosVenta(int _nit)
        {
            Response responseObject = new Response();
            try
            {
                using (SINOperaciones.ServicioFacturacionOperacionesClient client = new SINOperaciones.ServicioFacturacionOperacionesClient())
                using (var scope = new OperationContextScope(client.InnerChannel))
                {

                    HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                    requestMessage.Headers["Apikey"] = apiKey;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                    var resulService = client.consultaPuntoVenta(new SINOperaciones.consultaPuntoVenta
                    {
                        SolicitudConsultaPuntoVenta = new SINOperaciones.solicitudConsultaPuntoVenta
                        {
                            codigoAmbiente = 2,
                            codigoSistema = "7201326F07ED9F4CE0E7D2F",
                            codigoSucursal = 0,
                            cuis = "75979D1D",
                            nit = _nit
                        }

                    });

                }
            }
            catch (Exception ex)
            {
                ProcessError(ex, responseObject);
            }
            return responseObject;
        }

        public Response CrearPuntosVenta(Office _office)
        {
            Response responseObject = new Response();
            try
            {
                using (SINOperaciones.ServicioFacturacionOperacionesClient client = new SINOperaciones.ServicioFacturacionOperacionesClient())
                using (var scope = new OperationContextScope(client.InnerChannel))
                {

                    HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                    requestMessage.Headers["Apikey"] = apiKey;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                    var resulService = client.registroPuntoVenta(new SINOperaciones.registroPuntoVenta
                    {
                        SolicitudRegistroPuntoVenta = new SINOperaciones.solicitudRegistroPuntoVenta
                        {
                            codigoAmbiente = 2,
                            codigoModalidad = 2,
                            codigoSistema = "7201326F07ED9F4CE0E7D2F",
                            codigoSucursal = 0,
                            codigoTipoPuntoVenta = Convert.ToInt32(_office.CodigoTipoPuntoVenta),
                            cuis = "75979D1D",
                            descripcion = _office.Descripcion,
                            nit = Convert.ToInt32(_office.Nit),
                            nombrePuntoVenta = _office.Name
                        }
                    });


                }
            }
            catch (Exception ex)
            {
                ProcessError(ex, responseObject);
            }
            return responseObject;
        }
    }
}
