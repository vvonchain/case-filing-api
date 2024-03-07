using EvictionCaseFilingAPI.Services;
using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;
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
            // TODO: Implement response message validation logic
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var document = new XmlDocument();
            document.LoadXml(request.ToString());

            var signedXml = new SignedXml(document);
            signedXml.SigningKey = _certificateProvider.GetCertificate().PrivateKey;

            var reference = new Reference();
            reference.Uri = "";
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            signedXml.AddReference(reference);

            signedXml.ComputeSignature();
            var xmlDigitalSignature = signedXml.GetXml();
            var header = new MessageHeader<XmlElement>(xmlDigitalSignature);
            request.Headers.Add(header);

            return null;
        }
    }
}