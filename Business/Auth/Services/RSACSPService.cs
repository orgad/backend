using System;
using System.Security.Cryptography;
using System.Text;

namespace dotnet_wms_ef.Auth.Services
{
    public class RSACSPService
    {
        private static string xmlPublicKey;
        private static RSAParameters PublicParam;
        private static string xmlPrivateKey;
        private static RSAParameters PrivateParam;
             

        private static RSACryptoServiceProvider RSA;

        private static void Initial()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                RSA = rsa;
                
                PublicParam = rsa.ExportParameters(false); //公钥加密
                xmlPublicKey = rsa.ToXmlString(false);
                
                PrivateParam = rsa.ExportParameters(true);  //私钥解密
                xmlPrivateKey = rsa.ToXmlString(true);
            }
        }

        public static string RSAEncrypt(string plainText)
        {
            if(RSA==null) Initial();

            var bytes = Encoding.UTF8.GetBytes(plainText);
            var rSAKeyInfo = PrivateParam;
            var encryptBytes = RSAEncrypt(bytes, rSAKeyInfo, false);
            return Convert.ToBase64String(encryptBytes);
        }

        public static string RSADecrypt(string cipherText)
        {
            if(RSA==null) Initial();
            
            var bytes = Convert.FromBase64String(cipherText);
            var rSAKeyInfo = PublicParam;
            var decryptBytes = RSAEncrypt(bytes, rSAKeyInfo, false);
            return Encoding.UTF8.GetString(decryptBytes);
        }
        public static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                //using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                //{
                    //Import the RSA Key information. This only needs
                    //toinclude the public key information.
                    RSA.ImportParameters(RSAKeyInfo);
                    //Encrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                //}
                return encryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                //using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                //{
                    //Import the RSA Key information. This needs
                    //to include the private key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Decrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                //}
                return decryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static RSAParameters GenerateKey()
        {
            //输出2048位置的私钥
            using (var key = new RSACryptoServiceProvider(2048))
            {
                return key.ExportParameters(true);
            }
        }
        private void Demo()
        {
            try
            {
                //Create a UnicodeEncoder to convert between byte array and string.
                UnicodeEncoding ByteConverter = new UnicodeEncoding();

                //Create byte arrays to hold original, encrypted, and decrypted data.
                byte[] dataToEncrypt = ByteConverter.GetBytes("Data to Encrypt");
                byte[] encryptedData;
                byte[] decryptedData;

                //Create a new instance of RSACryptoServiceProvider to generate
                //public and private key data.
                using (RSA = new RSACryptoServiceProvider())
                {
                    //Pass the data to ENCRYPT, the public key information 
                    //(using RSACryptoServiceProvider.ExportParameters(false),
                    //and a boolean flag specifying no OAEP padding.
                    encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);

                    //Pass the data to DECRYPT, the private key information 
                    //(using RSACryptoServiceProvider.ExportParameters(true),
                    //and a boolean flag specifying no OAEP padding.
                    decryptedData = RSADecrypt(encryptedData, RSA.ExportParameters(true), false);

                    //Display the decrypted plaintext to the console. 
                    Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData));
                }
            }
            catch (ArgumentNullException)
            {
                //Catch this exception in case the encryption did
                //not succeed.
                Console.WriteLine("Encryption failed.");
            }
        }
    }
}