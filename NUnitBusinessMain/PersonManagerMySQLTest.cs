
using Business.Main.Microventas;
using Business.Main.ModuloSample;
using Domain.Main.MicroVentas.SP;
using Domain.Main.Wraper;
using NUnit.Framework;

namespace NUnitBusinessMain
{
    public class PersonManagerMySQLTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PersonRegisterTest()
        {
            //PersonManager personManager = new PersonManager();
            //Person person = new Person { Idperson = 0, Name = "Dario", Lastname = "Chalco" };
            //var resul = personManager.RegisterPerson(person);
            //Assert.AreEqual(resul.State, ResponseType.Success);
        }

        [Test]
        public void PersonRemoveTest()
        {
            //PersonManager personManager = new PersonManager();  
            //Person person = new Person { Idperson = 2};
            //var resul = personManager.DeletePerson(person);
            //Assert.AreEqual(resul.State, ResponseType.Success);
        }

        [Test]
        public void GetPersonsTest()
        {
            //PersonManager personManager = new PersonManager();
            //var resul = personManager.GetPersons("ruben");
            //Assert.AreEqual(resul.State, ResponseType.Success);
        }


        [Test]
        public void Login()
        {
            StockManger stockManger = new StockManger();
            var rsul = stockManger.LoginUsuario(new Domain.Main.MicroVentas.Usuarios.RequestLogin
            {
                idEmpresa = 1,
                password = "123",
                usuario = "rchalco"
            });
        }


        [Test]
        public void RegistrarVentasTest()
        {
            VentaManager stockManger = new VentaManager();
            RequestRegistroVenta requestRegistroVenta = new RequestRegistroVenta
            {
                idSesion = 1,
                idOperacionDiariaCaja = 1,
                detalleVentas = new System.Collections.Generic.List<DetalleVenta>()
            };

            requestRegistroVenta.detalleVentas.Add(new DetalleVenta
            {
                cantidad = 2,
                idProducto = 1,
                precioCaja = 55,
                PrecioUnitario = 5,
                UnidadePorCaja = 11
            });
            var resul = stockManger.RegistrarVentas(requestRegistroVenta);

        }

    }
}