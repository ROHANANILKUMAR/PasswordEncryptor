﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Encryptor
{
    public enum ServiceProvider { DES, TripleDES, RC2 };

    public class StringCipher
    {

        static SymmetricAlgorithm mobjCryptoService=new DESCryptoServiceProvider();
        

        private static byte[] GetLegalKey(string Key)
        {
            string sTemp;
            if (mobjCryptoService.LegalKeySizes.Length > 0)
            {
                int lessSize = 0;
                int moreSize = mobjCryptoService.LegalKeySizes[0].MinSize;

                // key sizes are in bits
                while (Key.Length * 8 > moreSize)
                {
                    lessSize = moreSize;
                    moreSize += mobjCryptoService.LegalKeySizes[0].SkipSize;
                }
                sTemp = Key.PadRight(moreSize / 8, ' ');
            }
            else
                sTemp = Key;



            // convert the secret key to byte array
            //return ASCIIEncoding.ASCII.GetBytes(sTemp);

            return UTF8Encoding.UTF8.GetBytes(sTemp);
        }

        public static string Encrypt(string contend, string key = "R0H@N")
        {
            if (mobjCryptoService != null)
            {
                byte[] contendBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(contend);
                System.IO.MemoryStream ms = new MemoryStream();

                byte[] bytKey = GetLegalKey(key);

                mobjCryptoService.Key = bytKey;
                mobjCryptoService.IV = bytKey;

                ICryptoTransform crypto = mobjCryptoService.CreateEncryptor();

                CryptoStream cs = new CryptoStream(ms, crypto, CryptoStreamMode.Write);

                cs.Write(contendBytes, 0, contendBytes.Length);
                cs.FlushFinalBlock();

                byte[] EncByte = ms.ToArray();
                return Convert.ToBase64String(EncByte);
            }
            else
            {
                throw new Exception("You have not any service providers");
            }
            
     }

        public static string Decrypt(string EncryptedData, string Key = "R0H@N")
        {
            if (mobjCryptoService != null)
            {
                byte[] EncryptdedDataBytes = Convert.FromBase64String(EncryptedData);

                MemoryStream ms = new MemoryStream(EncryptdedDataBytes, 0, EncryptdedDataBytes.Length);

                byte[] keyBytes = GetLegalKey(Key);

                mobjCryptoService.Key = keyBytes;
                mobjCryptoService.IV = keyBytes;

                ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();

                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);

                StreamReader sr = new StreamReader(cs);
                return sr.ReadToEnd();
            }
            else
            {
                throw new Exception("You have not any service providers");
            }
        }
    }
}

