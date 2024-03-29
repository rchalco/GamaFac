﻿using Business.Main.DataMappingMicroVenta;
using CoreAccesLayer.Interface;
using Domain.Main.Wraper;
using PlumbingProps.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Main.Base
{
    public abstract class BaseManager
    {
        /// <summary>
        /// se genera conla siguiente linea de codigo
        /// Install-Package Microsoft.EntityFrameworkCore.Tools
        /// dotnet ef dbcontext scaffold "Data Source=140.82.15.241;Initial Catalog=GamaFac;Persist Security Info=True;User ID=sa;Password=mikyches*123;TrustServerCertificate=True" "Microsoft.EntityFrameworkCore.SqlServer" -o DataMappingMicroVenta -f 
        /// </summary>
        internal IRepository repositoryGamaFac { get; set; } = null;
        internal IRepository repositoryMicroventas { get; set; } = null;
        internal IRepository repositoryFacturacion { get; set; } = null;
        public BaseManager()
        {
            //repositoryMySql = FactoryDataInterfaz.CreateRepository<sigadContext>("mysql");
            //repositoryGamaFac = FactoryDataInterfaz.CreateRepository<sigadContext>("mysql");
            repositoryMicroventas = FactoryDataInterfaz.CreateRepository<DataMappingMicroVenta.DBTintoreriaGamaFacContext>("sqlserver");
            repositoryFacturacion = FactoryDataInterfaz.CreateRepository<DataMappingFacturacion.FacturacionBDContext>("sqlserver");
        }

        public string ProcessError(Exception ex)
        {
            ManagerException managerException = new ManagerException();
            return managerException.ProcessException(ex);
        }

        public string ProcessError(Exception ex, Response response)
        {
            ManagerException managerException = new ManagerException();
            response.State = ResponseType.Error;
            response.Message = managerException.ProcessException(ex);
            repositoryGamaFac?.Rollback();
            repositoryMicroventas?.Rollback();
            return managerException.ProcessException(ex);
        }
    }

}
