using System;
using System.Security.Cryptography;
using System.Text;
namespace KiemTra_10_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Console.OutputEncoding = Encoding.Unicode;
            Console.Write("Nhập chuỗi cần mã hóa: ");
            string inputText = Console.ReadLine() ?? "";

            byte[] encryptedDataCurrentUser = EncryptData(inputText, DataProtectionScope.CurrentUser);
            Console.WriteLine("Chuỗi đã mã hóa (CurrentUser): " + Convert.ToBase64String(encryptedDataCurrentUser));

            string decryptedTextCurrentUser = DecryptData(encryptedDataCurrentUser, DataProtectionScope.CurrentUser);
            Console.WriteLine("Chuỗi đã giải mã (CurrentUser): " + decryptedTextCurrentUser);

            Console.WriteLine("".PadLeft(100,'*'));

            byte[] encryptedDataLocalMachine = EncryptData(inputText, DataProtectionScope.LocalMachine);
            Console.WriteLine("Chuỗi đã mã hóa (LocalMachine): " + Convert.ToBase64String(encryptedDataLocalMachine));

            string decryptedTextLocalMachine = DecryptData(encryptedDataLocalMachine, DataProtectionScope.LocalMachine);
            Console.WriteLine("Chuỗi đã giải mã (LocalMachine): " + decryptedTextLocalMachine);
        }

        static byte[] EncryptData(string inputText, DataProtectionScope scope)
        {
            return ProtectedData.Protect(Encoding.Unicode.GetBytes(inputText), null, scope);

        }

        static string DecryptData(byte[] encryptedData, DataProtectionScope scope)
        {
            return Encoding.Unicode.GetString(ProtectedData.Unprotect(encryptedData, null, scope));
        }
    }
}