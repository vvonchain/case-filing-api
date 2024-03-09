using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace EvictionCaseFilingAPI.Services
{
    public interface IX509CertificateProvider
    {
        X509Certificate2 GetCertificate();
    }

    public class X509CertificateProvider : IX509CertificateProvider
    {
        private readonly string _certificatePath;
        private readonly string _certificatePassword;

        public X509CertificateProvider(string certificatePath, string certificatePassword)
        {
            _certificatePath = certificatePath;
            _certificatePassword = certificatePassword;
        }

        public X509Certificate2 GetCertificate()
        {
            if (!File.Exists(_certificatePath))
            {
                throw new FileNotFoundException($"Certificate file not found at {_certificatePath}");
            }

            return new X509Certificate2(_certificatePath, _certificatePassword);
        }
    }
}