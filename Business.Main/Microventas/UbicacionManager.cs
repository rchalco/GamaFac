using Business.Main.Base;
using CoreAccesLayer.Implement.SQLServer;
using Domain.Main.MicroVentas.SP;
using Domain.Main.MicroVentas.Ubicacion;
using Domain.Main.Wraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Main.Microventas
{
    public class UbicacionManager : BaseManager
    {
        public ResponseQuery<UbicacionDTO> ObtenerUbicaciones(RequestParametrosGral requestGral)
        {

            ResponseQuery<UbicacionDTO> response = new ResponseQuery<UbicacionDTO> { Message = "Datos Obtenidos", State = ResponseType.Success };
            try
            {
                long id = 0;
                ParamOut poRespuesta = new ParamOut(false);
                ParamOut poLogRespuesta = new ParamOut("");
               

                poLogRespuesta.Size = 100;


                response.ListEntities = repositoryMicroventas.GetDataByProcedure<UbicacionDTO>("shParqueos.spObtParqueos", requestGral.ParametroLong1, poRespuesta, poLogRespuesta);


                if ((bool)poRespuesta.Valor)
                {
                    response.Message = poLogRespuesta.Valor.ToString();
                    response.State = ResponseType.Error;
                    return response;
                }


            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }

        public ResponseObject<UbicacionDTO> GrabarUbicacion(UbicacionDTO ubicacionDTO)
        {

            ResponseObject<UbicacionDTO> response = new ResponseObject<UbicacionDTO> { Message = "Usuario Grabado", State = ResponseType.Success };
            try
            {
                long id = 0;
                ParamOut poRespuesta = new ParamOut(false);
                ParamOut poLogRespuesta = new ParamOut("");

                poLogRespuesta.Size = 100;

                repositoryMicroventas.CallProcedure<Response>("shParqueos.spAddUbicacion",
                    ubicacionDTO.idSesion,
                    ubicacionDTO.idUbicacion,
                    ubicacionDTO.nombreParqueo,
                    ubicacionDTO.capacidad,
                    ubicacionDTO.latitud,
                    ubicacionDTO.longitud,
                    ubicacionDTO.activo,
                    poRespuesta,
                    poLogRespuesta
                    );
                repositoryMicroventas.Commit();

            }
            catch (Exception ex)
            {
                response.State = ResponseType.Error;
                response.Message = ex.Message;
                repositoryMicroventas.Rollback();
                ProcessError(ex, response);
            }
            return response;
        }

    }
}
