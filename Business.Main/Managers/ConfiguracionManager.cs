using PlumbingProps.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
//using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
//using WindowsFormsApp1.Global;

namespace WindowsFormsApp1.Managers
{
    public class ConfiguracionManager
    {

        //public static string NIT
        //{
        //    get
        //    {
        //        return ConfigManager.GetConfiguration()["NIT"];
        //    }
        //}
        //public static string CodigoAmbiente
        //{
        //    // pruebas 2, produccion 1
        //    get
        //    {
        //        return System.Configuration.ConfigurationManager.AppSettings["CodigoAmbiente"];
        //    }
        //}
        //public static string Modalidad
        //{
        //    // 1 facturación electronica en linea 2. computarizada
        //    get
        //    {
        //        return System.Configuration.ConfigurationManager.AppSettings["Modalidad"];
        //    }
        //}
        //public static string CodigoSistema
        //{
        //    //Generado en la solicitud de certificacion
        //    get
        //    {
        //        return System.Configuration.ConfigurationManager.AppSettings["CodigoSistema"];
        //    }
        //}
        //public static string CodigoSucursal
        //{
        //    get
        //    {
        //        return System.Configuration.ConfigurationManager.AppSettings["CodigoSucursal"];
        //    }
        //}

        //public static string PuntoDeVenta
        //{
        //    get
        //    {
        //        return System.Configuration.ConfigurationManager.AppSettings["PuntoDeVenta"];
        //    }
        //}
        //public static bool PuntoDeVentaEspecificado
        //{
        //    get
        //    {
        //        return bool.Parse(System.Configuration.ConfigurationManager.AppSettings["PuntoDeVentaEspecificado"]);
        //    }
        //}

        //public string GetCUIS()
        //{
        //    string CuisCode = string.Empty;
        //    try
        //    {
        //        FacturacionCodigos.ServicioFacturacionCodigosClient clienteCodigos = new FacturacionCodigos.ServicioFacturacionCodigosClient("ServicioFacturacionCodigosPort");

        //        OperationContextScope contextScope = new OperationContextScope(clienteCodigos.InnerChannel);

        //        HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
        //        //requestMessage.Headers["Authorization"] = CustomSettings.TokenImpuestos;
        //        requestMessage.Headers["Apikey"] = CustomSettings.TokenImpuestos;
        //        OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

        //        FacturacionCodigos.solicitudCuis _solicitudCuis = new FacturacionCodigos.solicitudCuis
        //        {
        //            nit = Int64.Parse(NIT),
        //            codigoAmbiente = int.Parse(CodigoAmbiente),
        //            codigoModalidad = int.Parse(Modalidad),
        //            codigoSistema = CodigoSistema,
        //            codigoSucursal = int.Parse(CodigoSucursal),
        //            codigoPuntoVenta = int.Parse(PuntoDeVenta), // punto de venta 0 y 1, se puede crear más pero  solo se contabilizan 0 y 1
        //            codigoPuntoVentaSpecified = PuntoDeVentaEspecificado,
        //        };
        //        var resp = clienteCodigos.cuis(_solicitudCuis);
        //        CuisCode = resp.codigo;


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        //clienteCodigos.InnerChannel.Close();
        //    }

        //    return CuisCode;
        //}

        //public string GetParametrosServcio(string strServicio, string CUIS)
        //{
        //    try
        //    {
        //        ServiceReference1.ServicioFacturacionSincronizacionClient clientService = new ServiceReference1.ServicioFacturacionSincronizacionClient();
        //        OperationContextScope contextScope = new OperationContextScope(clientService.InnerChannel);
        //        HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
        //        requestMessage.Headers["Apikey"] = CustomSettings.TokenImpuestos;
        //        OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

        //        ServiceReference1.solicitudSincronizacion objSend = new ServiceReference1.solicitudSincronizacion();
        //        objSend.nit = Int64.Parse(NIT);
        //        objSend.codigoAmbiente = int.Parse(CodigoAmbiente);
        //        objSend.codigoSistema = CodigoSistema;
        //        objSend.codigoSucursal = int.Parse(CodigoSucursal);
        //        objSend.codigoPuntoVenta = int.Parse(PuntoDeVenta);
        //        objSend.codigoPuntoVentaSpecified = PuntoDeVentaEspecificado;
        //        objSend.cuis = CUIS;



        //        Type clientType = Type.GetType("WindowsFormsApp1.ServiceReference1.ServicioFacturacionSincronizacionClient");
        //        MethodInfo magicMethod = clientType.GetMethod(strServicio);
        //        object valueServices = magicMethod.Invoke(clientService, new object[] { objSend });

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        //clienteCodigos.InnerChannel.Close();
        //    }

        //    return "";
        //}

        //public FacturacionCodigos.respuestaCufd GetCUFD(string CUIS)
        //{
        //    FacturacionCodigos.ServicioFacturacionCodigosClient clienteCodigos = new FacturacionCodigos.ServicioFacturacionCodigosClient("ServicioFacturacionCodigosPort");
        //    try
        //    {
        //        OperationContextScope contextScope = new OperationContextScope(clienteCodigos.InnerChannel);

        //        HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
        //        requestMessage.Headers["Apikey"] = CustomSettings.TokenImpuestos;
        //        OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

        //        FacturacionCodigos.solicitudCufd vobj = new FacturacionCodigos.solicitudCufd
        //        {
        //            nit = Int64.Parse(NIT),
        //            codigoAmbiente = int.Parse(CodigoAmbiente),
        //            codigoModalidad = int.Parse(Modalidad),
        //            codigoSistema = CodigoSistema,
        //            codigoSucursal = int.Parse(CodigoSucursal),
        //            codigoPuntoVenta = int.Parse(PuntoDeVenta),
        //            codigoPuntoVentaSpecified = PuntoDeVentaEspecificado,
        //            cuis = CUIS
        //        };
        //        FacturacionCodigos.respuestaCufd resp = clienteCodigos.cufd(vobj);
        //        return resp;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        //clienteCodigos.InnerChannel.Close();
        //    }
        //}


        /**/
    }
}
