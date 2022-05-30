using Business.Main.Base;
using Domain.Main.Wraper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Business.Main.ManagersFacturacion
{
    public class SINSingManager : BaseManager
    {
        public ResponseObject<string> FirmarDocumentoXML(string xmlContent, string fileRSAKey, string fileX509)
        {
            ResponseObject<string> responseObject = new ResponseObject<string>();
            try
            {
                string rsaPEM = File.ReadAllText(fileRSAKey);
                string x059PEM = File.ReadAllText(fileX509);
                var rsa = RSA.Create();
                rsa.ImportFromPem(rsaPEM.ToCharArray());
                var x509Certificate = X509Certificate2.CreateFromPem(x059PEM); 
                SignXmlFile(xmlContent, @"C:\tempdev\docfirmado.xml", rsa, x509Certificate);
            }
            catch (Exception ex)
            {
                ProcessError(ex, responseObject);
            }
            return responseObject;
        }

        private void SignXmlFile(string content, string SignedFileName, RSA Key, X509Certificate x509Certificate)
        {
            // Create a new XML document.
            XmlDocument doc = new XmlDocument();

            // Load the passed XML file using its name.
            doc.LoadXml(content);

            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml(doc);

            // Add the key to the SignedXml document. 
            signedXml.SigningKey = Key;

            // Create a reference to be signed.
            Reference reference = new Reference();
            reference.Uri = "";

            // Add an enveloped transformation to the reference.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);

            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new KeyInfoX509Data(x509Certificate));
            signedXml.KeyInfo = keyInfo;

            // Compute the signature.
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Append the element to the XML document.
            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));

            if (doc.FirstChild is XmlDeclaration)
            {
                doc.RemoveChild(doc.FirstChild);
            }

            // Save the signed XML document to a file specified
            // using the passed string.
            XmlTextWriter xmltw = new XmlTextWriter(SignedFileName, new UTF8Encoding(false));
            doc.WriteTo(xmltw);
            xmltw.Close();
        }
    }
}
