using System.Security.Cryptography.X509Certificates;

namespace EvictionCaseFilingAPI.Services
{
    public interface IX509CertificateProvider
    {
        X509Certificate2 GetCertificate();
    }

    public class X509CertificateProvider : IX509CertificateProvider
    {
        public X509Certificate2 GetCertificate()
        {
            // TODO: Implement logic to load and return the X.509 certificate
            return new X509Certificate2();
        }
    }
}