using EvictionCaseFilingAPI.Services;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace EvictionCaseFilingAPI.Security
{
    public class SOAPSignatureHandler : IClientMessageInspector
    {
        private readonly IX509CertificateProvider _certificateProvider;

        public SOAPSignatureHandler(IX509CertificateProvider certificateProvider)
        {
            _certificateProvider = certificateProvider;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            // Implementation of response message validation logic can be added here
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            // Convert the request message to a XmlDocument
            var document = new XmlDocument { PreserveWhitespace = true };
            using (var reader = request.GetReaderAtBodyContents())
            {
                document.Load(reader);
            }

            // Create a SignedXml object and assign a new RSA key to it
            SignedXml signedXml = new SignedXml(document)
            {
                SigningKey = _certificateProvider.GetCertificate().GetRSAPrivateKey()
            };

            // Create a reference to be signed
            Reference reference = new Reference
            {
                Uri = ""
            };

            // Add an enveloped transformation to the reference
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            signedXml.AddReference(reference);

            // Add the key information
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new KeyInfoX509Data(_certificateProvider.GetCertificate()));
            signedXml.KeyInfo = keyInfo;

            // Compute the signature
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save it to an XmlElement object
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Add the signature as a SOAP header to the outgoing request
            MessageHeader signatureHeader = MessageHeader.CreateHeader("Signature", "", xmlDigitalSignature);
            request.Headers.Add(signatureHeader);

            return null;
        }
    }
}