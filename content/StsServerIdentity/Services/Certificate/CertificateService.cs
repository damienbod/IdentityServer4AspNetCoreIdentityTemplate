using System.Security.Cryptography.X509Certificates;

namespace StsServerIdentity.Services.Certificate
{
    public static class CertificateService
    {
        public static (X509Certificate2, X509Certificate2) GetCertificates(CertificateConfiguration certificateConfiguration)
        {
            (X509Certificate2, X509Certificate2) certs = (null, null);

            if (certificateConfiguration.UseLocalCertStore)
            {
                using X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadOnly);
                var storeCerts = store.Certificates.Find(X509FindType.FindByThumbprint, certificateConfiguration.CertificateThumbprint, false);
                certs.Item1 = storeCerts[0];
                store.Close();
            }
            else
            {
                if (!string.IsNullOrEmpty(certificateConfiguration.KeyVaultEndpoint))
                {
                    var keyVaultCertificateService = new KeyVaultCertificateService(
                            certificateConfiguration.KeyVaultEndpoint, 
                            certificateConfiguration.CertificateNameKeyVault);

                    certs = keyVaultCertificateService.GetCertificatesFromKeyVault();
                }  
            }
            
            // search for local PFX with password, usually local dev
            if(certs.Item1 == null)
            {
                certs.Item1 = new X509Certificate2(
                    certificateConfiguration.DevelopmentCertificatePfx,
                    certificateConfiguration.DevelopmentCertificatePassword);
            }

            return certs;
        }
    }
}
