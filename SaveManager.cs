using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using UnityEngine;

[System.Serializable]
public class SaveManager
{

    private static readonly byte[] EncryptionKey = new byte[]
    {
        0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF,
        0xFE, 0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x10
    };

    public static void SaveData(PlayersData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        MemoryStream memoryStream = new MemoryStream();

        formatter.Serialize(memoryStream, data);

        byte[] encryptedData = EncryptData(memoryStream.ToArray());

        FileStream fs = new FileStream(GetPath(), FileMode.Create);
        fs.Write(encryptedData, 0, encryptedData.Length);
        fs.Close();
    }

    public static PlayersData LoadData()
    {
        if (!File.Exists(GetPath()))
        {
            PlayersData empty = new PlayersData();
            SaveData(empty);
            return empty;
        }

        byte[] encryptedData = File.ReadAllBytes(GetPath());

        byte[] decryptedData = DecryptData(encryptedData);

        BinaryFormatter formatter = new BinaryFormatter();
        MemoryStream memoryStream = new MemoryStream(decryptedData);

        PlayersData data = formatter.Deserialize(memoryStream) as PlayersData;

        return data;
    }

    //public static void DeleteData()
    //{
    //    File.Delete(GetPath());
    //}

    private static string GetPath()
    {
        return Application.persistentDataPath + "/GetOut.Amr";
    }

    private static byte[] EncryptData(byte[] data)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = EncryptionKey;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Write(aes.IV, 0, aes.IV.Length);
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(data, 0, data.Length);
                    cryptoStream.FlushFinalBlock();
                }

                return memoryStream.ToArray();
            }
        }
    }

    private static byte[] DecryptData(byte[] data)
    {
        using (Aes aes = Aes.Create())
        {
            byte[] iv = new byte[aes.IV.Length];
            Array.Copy(data, iv, iv.Length);

            aes.Key = EncryptionKey;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream(data, iv.Length, data.Length - iv.Length))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    byte[] decryptedData = new byte[data.Length - iv.Length];
                    int bytesRead = cryptoStream.Read(decryptedData, 0, decryptedData.Length);

                    return decryptedData;
                }
            }
        }
    }
    public static player currentPlayer;

}
