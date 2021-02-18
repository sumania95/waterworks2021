Imports MySql.Data.MySqlClient
Imports System.Security
Imports System.Security.Cryptography
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Text
Module ConnectionDB
    Public cn As New MySqlConnection
    Public cm As New MySqlCommand
    Public dr As MySqlDataReader
    Public tripleDes As New TripleDESCryptoServiceProvider
    Public Sub connection()
        cn = New MySqlConnection
        With cn
            '.ConnectionString = "Server=127.0.0.1;Port=3306;Database=waterworkdbbkup2020;Uid=root;Pwd=;"
            .ConnectionString = "Server=192.168.1.42;Port=3306;Database=waterworks;Uid=ayandev;Pwd=;"
        End With
    End Sub


    'Public Function EncryptData(ByVal plaintext As String) As String
    '    Dim plaintextBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(plaintext)
    '    Dim ms As New System.IO.MemoryStream
    '    Dim encStream As New CryptoStream(ms, tripleDes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write)
    '    encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
    '    encStream.FlushFinalBlock()

    '    Return Convert.ToBase64String(ms.ToArray)
    'End Function
    'Public Function DescryptData(ByVal encryptedtext As String) As String
    '    Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)
    '    Dim ms As New System.IO.MemoryStream
    '    Dim decStream As New CryptoStream(ms, tripleDes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write)
    '    decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
    '    decStream.FlushFinalBlock()

    '    Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
    'End Function
    'Public Function Encrypt(ByVal plainText As String) As String

    '    Dim passPhrase As String = "yourPassPhrase"
    '    Dim saltValue As String = "mySaltValue"
    '    Dim hashAlgorithm As String = "SHA1"

    '    Dim passwordIterations As Integer = 2
    '    Dim initVector As String = "@1B2c3D4e5F6g7H8"
    '    Dim keySize As Integer = 256

    '    Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
    '    Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)

    '    Dim plainTextBytes As Byte() = Encoding.UTF8.GetBytes(plainText)


    '    Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)

    '    Dim keyBytes As Byte() = password.GetBytes(keySize \ 8)
    '    Dim symmetricKey As New RijndaelManaged()

    '    symmetricKey.Mode = CipherMode.CBC

    '    Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)

    '    Dim memoryStream As New MemoryStream()
    '    Dim cryptoStream As New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)

    '    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
    '    cryptoStream.FlushFinalBlock()
    '    Dim cipherTextBytes As Byte() = memoryStream.ToArray()
    '    memoryStream.Close()
    '    cryptoStream.Close()
    '    Dim cipherText As String = Convert.ToBase64String(cipherTextBytes)
    '    Return cipherText
    'End Function
    'Public Function Decrypt(ByVal cipherText As String) As String
    '    Dim passPhrase As String = "yourPassPhrase"
    '    Dim saltValue As String = "mySaltValue"
    '    Dim hashAlgorithm As String = "SHA1"

    '    Dim passwordIterations As Integer = 2
    '    Dim initVector As String = "@1B2c3D4e5F6g7H8"
    '    Dim keySize As Integer = 256
    '    ' Convert strings defining encryption key characteristics into byte
    '    ' arrays. Let us assume that strings only contain ASCII codes.
    '    ' If strings include Unicode characters, use Unicode, UTF7, or UTF8
    '    ' encoding.
    '    Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
    '    Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)

    '    ' Convert our ciphertext into a byte array.
    '    Dim cipherTextBytes As Byte() = Convert.FromBase64String(cipherText)

    '    ' First, we must create a password, from which the key will be 
    '    ' derived. This password will be generated from the specified 
    '    ' passphrase and salt value. The password will be created using
    '    ' the specified hash algorithm. Password creation can be done in
    '    ' several iterations.
    '    Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)

    '    ' Use the password to generate pseudo-random bytes for the encryption
    '    ' key. Specify the size of the key in bytes (instead of bits).
    '    Dim keyBytes As Byte() = password.GetBytes(keySize \ 8)

    '    ' Create uninitialized Rijndael encryption object.
    '    Dim symmetricKey As New RijndaelManaged()

    '    ' It is reasonable to set encryption mode to Cipher Block Chaining
    '    ' (CBC). Use default options for other symmetric key parameters.
    '    symmetricKey.Mode = CipherMode.CBC

    '    ' Generate decryptor from the existing key bytes and initialization 
    '    ' vector. Key size will be defined based on the number of the key 
    '    ' bytes.
    '    Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)

    '    ' Define memory stream which will be used to hold encrypted data.
    '    Dim memoryStream As New MemoryStream(cipherTextBytes)

    '    ' Define cryptographic stream (always use Read mode for encryption).
    '    Dim cryptoStream As New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)

    '    ' Since at this point we don't know what the size of decrypted data
    '    ' will be, allocate the buffer long enough to hold ciphertext;
    '    ' plaintext is never longer than ciphertext.
    '    Dim plainTextBytes As Byte() = New Byte(cipherTextBytes.Length - 1) {}

    '    ' Start decrypting.
    '    Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)

    '    ' Close both streams.
    '    memoryStream.Close()
    '    cryptoStream.Close()

    '    ' Convert decrypted data into a string. 
    '    ' Let us assume that the original plaintext string was UTF8-encoded.
    '    Dim plainText As String = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)

    '    ' Return decrypted string.   
    '    Return plainText
    'End Function
End Module

