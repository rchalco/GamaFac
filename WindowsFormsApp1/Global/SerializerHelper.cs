using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsFormsApp1.ProofRegister;

namespace WindowsFormsApp1.Global
{
    public class SerializerHelper
    {
        public static string pFormatoDate = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff";

        /// <summary>
        /// dede aqui
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        public void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        public byte[] Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    //msi.CopyTo(gs);
                    CopyTo(msi, gs);
                }

                return mso.ToArray();
            }
        }

        public string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }

        }

        public string sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        /// <summary>
        /// Serializa el objeto a XML
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
        public string calculaDigitoMod11(string cadena, int numDig, int limMult, bool x10)
        {
            int mult, suma, i, n, dig;
            if (!x10) numDig = 1;

            for (n = 1; n <= numDig; n++)
            {
                suma = 0;
                mult = 2;
                for (i = cadena.Length - 1; i >= 0; i--)
                {
                    suma += (mult * int.Parse(cadena.Substring(i, 1)));

                    if (++mult > limMult) mult = 2;
                }

                if (x10)
                {
                    dig = ((suma * 10) % 11) % 10;
                }
                else
                {
                    dig = suma % 11;
                }

                if (dig == 10)
                {
                    cadena += "1";
                }

                if (dig == 11)
                {
                    cadena += "0";
                }

                if (dig < 10)
                {
                    cadena += dig.ToString();
                }
            }

            return cadena.Substring(cadena.Length - numDig, numDig);

        }
        public string ConvertirBase16(string CodigoPrevio)
        {
            var bigNumber = System.Numerics.BigInteger.Parse(CodigoPrevio);
            string vR = bigNumber.ToString("X");
            return vR;
        }
        public string ObtieneNumCerosIzq(long Numero, int TamCampo)
        {
            string vTamañoCampo = "D" + TamCampo.ToString();
            return Numero.ToString(vTamañoCampo);
        }
        public void CrearArchivoXML(string pXML, string path)
        {
            using (FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(pXML);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
        }
        public byte[] ConvertirArchivoAByte(string path)
        {
            return System.IO.File.ReadAllBytes(path);
        }

        /// <summary>
        /// crea archivos empaquetaos tar.gz
        /// </summary>
        /// <param name="tgzFilename"> ubicacion y nombre de archivo que se creara Ejemplo: C://FacturaSINTar//Paquete.tar.gz      </param>
        /// <param name="sourceDirectory"> ubicacion dela carpeta a comprimir  Ejemplo : C://FaturasSIN//Paquete1</param>
        public void CrearTarGZ(string tgzFilename, string sourceDirectory)
        {
            Stream outStream = File.Create(tgzFilename);
            Stream gzoStream = new GZipOutputStream(outStream);
            TarArchive tarArchive = TarArchive.CreateOutputTarArchive(gzoStream);

            // Note that the RootPath is currently case sensitive and must be forward slashes e.g. "c:/temp"
            // and must not end with a slash, otherwise cuts off first char of filename
            // This is scheduled for fix in next release
            tarArchive.RootPath = sourceDirectory.Replace('\\', '/');
            if (tarArchive.RootPath.EndsWith("/"))
                tarArchive.RootPath = tarArchive.RootPath.Remove(tarArchive.RootPath.Length - 1);

            AddDirectoryFilesToTar(tarArchive, sourceDirectory, true, true);

            tarArchive.Close();


        }

        private void AddDirectoryFilesToTar(TarArchive tarArchive, string sourceDirectory, bool recurse, bool isRoot)
        {

            // Optionally, write an entry for the directory itself.
            // Specify false for recursion here if we will add the directory's files individually.
            //
            TarEntry tarEntry;

            if (!isRoot)
            {
                tarEntry = TarEntry.CreateEntryFromFile(sourceDirectory);
                tarArchive.WriteEntry(tarEntry, false);
            }

            // Write each file to the tar.
            //
            string[] filenames = Directory.GetFiles(sourceDirectory);
            foreach (string filename in filenames)
            {
                tarEntry = TarEntry.CreateEntryFromFile(filename);
                Console.WriteLine(tarEntry.Name);
                tarArchive.WriteEntry(tarEntry, true);
            }

            if (recurse)
            {
                string[] directories = Directory.GetDirectories(sourceDirectory);
                foreach (string directory in directories)
                    AddDirectoryFilesToTar(tarArchive, directory, recurse, false);
            }
        }

        private string GeneradorXML(DateTime vDateRegister, facturaElectronicaEntidadFinanciera ObjFactura)
        {
            string vTimestamp = vDateRegister.ToString(FacturaHelper.pFormatoDate); //DateTimeOffset.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff");

            ObjFactura.cabecera.fechaEmision = vTimestamp;
            string vXml = SerializarToXml(ObjFactura);
            return vXml;
        }

        public string DatetimeToTimeStampSIN(DateTime date)
        {
            string vTimestamp = date.ToString(pFormatoDate); //DateTimeOffset.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff");
            return vTimestamp;
        }
    }
}
