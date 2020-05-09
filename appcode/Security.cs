using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace YES.appcode
{
    /// <summary>
    /// Contains all functions that belong to security and authentication processes.
    /// </summary>
    class Security
    {
        public class Cryptography
        {
            public static string Encrypt(string toEncrypt, bool useHashing, string key)
            {
                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

                System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
                // Get the key from config file

                //key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
                //string key = "Mustafa Moh Beshr";
                //System.Windows.Forms.MessageBox.Show(key);
                //If hashing use get hashcode regards to your key
                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    //Always release the resources and flush data
                    // of the Cryptographic service provide. Best Practice

                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                //set the secret key for the tripleDES algorithm
                tdes.Key = keyArray;
                //mode of operation. there are other 4 modes.
                //We choose ECB(Electronic code Book)
                tdes.Mode = CipherMode.ECB;
                //padding mode(if any extra byte added)

                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                //transform the specified region of bytes array to resultArray
                byte[] resultArray =
                  cTransform.TransformFinalBlock(toEncryptArray, 0,
                  toEncryptArray.Length);
                //Release resources held by TripleDes Encryptor
                tdes.Clear();
                //Return the encrypted data into unreadable string format
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            public static string Decrypt(string cipherString, bool useHashing, string key)
            {
                try
                {
                    byte[] keyArray;
                    //get the byte code of the string

                    byte[] toEncryptArray = Convert.FromBase64String(cipherString);

                    System.Configuration.AppSettingsReader settingsReader =
                                                        new AppSettingsReader();
                    //Get your key from config file to open the lock!
                    //key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
                    //string key = "Mustafa Moh Beshr";
                    if (useHashing)
                    {
                        //if hashing was used get the hash code with regards to your key
                        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                        //release any resource held by the MD5CryptoServiceProvider

                        hashmd5.Clear();
                    }
                    else
                    {
                        //if hashing was not implemented get the byte code of the key
                        keyArray = UTF8Encoding.UTF8.GetBytes(key);
                    }

                    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                    //set the secret key for the tripleDES algorithm
                    tdes.Key = keyArray;
                    //mode of operation. there are other 4 modes. 
                    //We choose ECB(Electronic code Book)

                    tdes.Mode = CipherMode.ECB;
                    //padding mode(if any extra byte added)
                    tdes.Padding = PaddingMode.PKCS7;

                    ICryptoTransform cTransform = tdes.CreateDecryptor();
                    byte[] resultArray = cTransform.TransformFinalBlock(
                                         toEncryptArray, 0, toEncryptArray.Length);
                    //Release resources held by TripleDes Encryptor                
                    tdes.Clear();
                    //return the Clear decrypted TEXT
                    return UTF8Encoding.UTF8.GetString(resultArray);
                }
                catch (Exception ex)
                {
                    throw new CryptographicException();

                }
            }
            public static void TextFileToBinary(string TexFilePath, string TargetFolder)
            {
                string fileContents;
                using (FileStream fileStream = new FileStream(TexFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (StreamReader sr = new StreamReader(fileStream))
                    {
                        fileContents = sr.ReadToEnd();
                    }
                }
                using (FileStream fs = new FileStream(TexFilePath.Replace("txt", "bin"), FileMode.Create))
                {
                    // Construct a BinaryFormatter and use it to serialize the data to the stream.
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, fileContents);
                }
            }
            public static void BinaryToTextFile(string BinaryFilePath)
            {
                string fileContents;
                using (FileStream fileStream = new FileStream(BinaryFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    fileContents = (string)formatter.Deserialize(fileStream);
                }
                //using (FileStream fs = new FileStream(BinaryFilePath.Replace("bin", "txt"), FileMode.Create))
                //{
                using (StreamWriter sw = new StreamWriter(BinaryFilePath.Replace("bin", "txt")))
                {
                    sw.Write(fileContents);

                }
                //}

            }
            public static void EncryptTextFile(string TexFilePath, string key, string TargetFolder)
            {
                string fileContents;
                using (FileStream fileStream = new FileStream(TexFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (StreamReader sr = new StreamReader(fileStream))
                    {
                        fileContents = sr.ReadToEnd();
                    }
                }
                fileContents = Encrypt(fileContents, true, key);
                //using (FileStream fs = new FileStream(TexFilePath.Replace("txt", "dat"), FileMode.Create))
                //{
                //string dir = Path.GetDirectoryName(TexFilePath);
                string fn = Path.GetFileName(TexFilePath);
                fn = TargetFolder + @"\" + fn;
                using (StreamWriter sw = new StreamWriter(fn))
                {
                    sw.Write(fileContents);
                }
                //}
            }
            public static void DecrypeTextFile(string TexFilePath, string key, string TargetFile)
            {
                string fileContents;
                using (FileStream fileStream = new FileStream(TexFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (StreamReader sr = new StreamReader(fileStream))
                    {
                        fileContents = sr.ReadToEnd();
                    }
                }
                fileContents = Decrypt(fileContents, true, key);
                //using (FileStream fs = new FileStream(TexFilePath.Replace("txt", "dat"), FileMode.Create))
                //{
                string dir = Path.GetDirectoryName(TexFilePath);
                string fn = Path.GetFileNameWithoutExtension(TexFilePath) + "_old.txt";
                fn = dir + @"\" + fn;
                using (StreamWriter sw = new StreamWriter(fn))
                {
                    sw.Write(fileContents);
                }
                //}
            }
            public static string DecrypeTextFile(string TexFilePath, string key)
            {
                try
                {
                    string fileContents;
                    using (FileStream fileStream = new FileStream(TexFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (StreamReader sr = new StreamReader(fileStream))
                        {
                            fileContents = sr.ReadToEnd();
                        }
                    }
                    fileContents = Decrypt(fileContents, true, key);
                    return fileContents;
                }
                catch (CryptographicException)
                {
                    throw new CryptographicException();
                }
            }
        }
    }
}
