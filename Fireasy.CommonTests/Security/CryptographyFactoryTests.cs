using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fireasy.Common.Extensions;

namespace Fireasy.Common.Security.Tests
{
    [TestClass]
    public class CryptographyFactoryTests
    {
        private string RSA_publicKey = "<RSAKeyValue><Modulus>4UdQ4HttFv3wLdm5cQ8zU3u9YjMXVLsJkmG3E/60G7nxNMJ4gBLQiSGfj4ByKBR0Pvyk2HJ4PCVb3csHjgORjmzF2UeNQgu2SiqD1P+6nU1i2eugp4AxAJed91WRXn6dSb3vqTcwi+KaswcngR0/+YJ9szHi/VADsAQtORc3zBU=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        private string RSA_privateKey = "<RSAKeyValue><Modulus>4UdQ4HttFv3wLdm5cQ8zU3u9YjMXVLsJkmG3E/60G7nxNMJ4gBLQiSGfj4ByKBR0Pvyk2HJ4PCVb3csHjgORjmzF2UeNQgu2SiqD1P+6nU1i2eugp4AxAJed91WRXn6dSb3vqTcwi+KaswcngR0/+YJ9szHi/VADsAQtORc3zBU=</Modulus><Exponent>AQAB</Exponent><P>9YuKs6X7UU+rtQ0NFRAhr1KMbSe/k7L2OuKkNo9NpHUa3bubb2SY0sNACmLVgp7/wOcflSP1lJcH04J2P/gJHQ==</P><Q>6t7eKKSOZJIqWAQZDEr2SsGecKK3dM+1yMwKe78JfwhyQRdAq9rgblqyD4QvSpvn+mTZIlf+2cwgN+m6Pu5VWQ==</Q><DP>YiqUnDf6nspkUnDSTx5w6R/uhmFCxTDiIi6kCjAGkX5D7Gvpu4ITWwe2XbCfvaYFh8CfLsf+kZZECbp5vh9SvQ==</DP><DQ>uCgLVR7Br0WUAfMkmKjmOHNcAcDzy5lZVZn21lRR49MBktvij11M//oJB3WDhyJ7X69XOUB5yNfuoyiWKeXB8Q==</DQ><InverseQ>x9BzXYBzpw2chFdo+pyTDno5KuilsDGkMiwyqnIsb5eyu5XZm3B2hSpPyBmCzpIJE5z6PJRJiKtrpgEJ3unljw==</InverseQ><D>Xqxv6sc0I1N42mwDqOXwdgcsodZC2dL4xNHX9Mk3u+c63SdVKM2/YcIFonMihoGCEO5wAJ6qtOwmXWFzvVT2mBBsZSROl9VKQboWdjLyBb/q81pnR1skolrBVs913eOHxOdBXVl+yIuhOBr83MFsP/pshafnIS5hHoOF7CzHG8E=</D></RSAKeyValue>";
        private string DSA_publicKey = "<DSAKeyValue><P>mCE5tPSFf3GC1zNmGyLkUig/uJIjMdmRAZzMnHLh2jbONG3UWJNrb8Z2wkfD0qg22bIvhpVH3t/WW7l2XZkTl9pGWm8y2P+cN2gcQGtSN8ieINYJDeWXJ+BOK5PcFA341PR9q2O78Puva1C1d6P+AyR+l7Wflmpgr3lRtaRz5nc=</P><Q>kyx91vkJKz1kIaQQnNPPIJmgb08=</Q><G>UirS5wZE6hsMwA8siOpKMsh5j8x0YGh/q/KFWsJhia7DSr3TtsAJBhmu7hwexBPBO3MLUormmO+YBjVlfN87unwZEvQuKnYr4pl/JlJUaGHBRf/tB+0Xdq/o3LHm1eOyZky/pPEbZJi0tRs5zkKpMzG9d/HZ5iArs0Yd7uBhcxM=</G><Y>WhjlTZlDWcv01p9aO4gFILAOMhiMLszMCIVMZ6DAWhM0PfEl66BP3Z4g47KC1TuqlU77H3Co1pjAhGjnMQhXLELq9GvFLpcGZlvlp1TT6mKKAfTFyGZs8FpGFa/yCH2auvMjvdth0IUJ9TMLO8f/9Z0hidKY+pwjcsmAh6E0qOM=</Y><J>AAAAAQie4vQUDGzD2eT/CbLpzQutVdoBAf4TQVpRJA4x4L7oMkveY2Au12ZF+RipuIJiphk5X0mKUsnN8b3FLmrI9ygHtk5CLg3YzWHPDwIyQBZ6D2+Fm2hUcmFbW1tNX4mgtsRzTWmLCOpaSddEqg==</J><Seed>kjXiFd6I9vObtM1DCz9sBulpVSs=</Seed><PgenCounter>AdE=</PgenCounter></DSAKeyValue>";
        private string DSA_privateKey = "<DSAKeyValue><P>mCE5tPSFf3GC1zNmGyLkUig/uJIjMdmRAZzMnHLh2jbONG3UWJNrb8Z2wkfD0qg22bIvhpVH3t/WW7l2XZkTl9pGWm8y2P+cN2gcQGtSN8ieINYJDeWXJ+BOK5PcFA341PR9q2O78Puva1C1d6P+AyR+l7Wflmpgr3lRtaRz5nc=</P><Q>kyx91vkJKz1kIaQQnNPPIJmgb08=</Q><G>UirS5wZE6hsMwA8siOpKMsh5j8x0YGh/q/KFWsJhia7DSr3TtsAJBhmu7hwexBPBO3MLUormmO+YBjVlfN87unwZEvQuKnYr4pl/JlJUaGHBRf/tB+0Xdq/o3LHm1eOyZky/pPEbZJi0tRs5zkKpMzG9d/HZ5iArs0Yd7uBhcxM=</G><Y>WhjlTZlDWcv01p9aO4gFILAOMhiMLszMCIVMZ6DAWhM0PfEl66BP3Z4g47KC1TuqlU77H3Co1pjAhGjnMQhXLELq9GvFLpcGZlvlp1TT6mKKAfTFyGZs8FpGFa/yCH2auvMjvdth0IUJ9TMLO8f/9Z0hidKY+pwjcsmAh6E0qOM=</Y><J>AAAAAQie4vQUDGzD2eT/CbLpzQutVdoBAf4TQVpRJA4x4L7oMkveY2Au12ZF+RipuIJiphk5X0mKUsnN8b3FLmrI9ygHtk5CLg3YzWHPDwIyQBZ6D2+Fm2hUcmFbW1tNX4mgtsRzTWmLCOpaSddEqg==</J><Seed>kjXiFd6I9vObtM1DCz9sBulpVSs=</Seed><PgenCounter>AdE=</PgenCounter><X>Alq2Zb28XX80wghPXVLBnzFbhBI=</X></DSAKeyValue>";

        [TestMethod]
        public void TestTripleDESEncrypt()
        {
            var encrypt = CryptographyFactory.Create(CryptoAlgorithm.TripleDES) as SymmetricCrypto;
            encrypt.SetKey("faib studio");

            var bytes = encrypt.Encrypt("1234", Encoding.GetEncoding(0));
            Console.WriteLine(bytes.Length);
            var s = encrypt.Decrypt(bytes, Encoding.GetEncoding(0));
            Assert.AreEqual("1234", s);
        }

        [TestMethod]
        public void TestRC2Encrypt()
        {
            var encrypt = CryptographyFactory.Create(CryptoAlgorithm.RC2) as SymmetricCrypto;
            encrypt.SetKey("faib studio");

            var bytes = encrypt.Encrypt("1234", Encoding.GetEncoding(0));
            Console.WriteLine(bytes.Length);
            var s = encrypt.Decrypt(bytes, Encoding.GetEncoding(0));
            Assert.AreEqual("1234", s);
        }

        [TestMethod]
        public void TestRC4Encrypt()
        {
            var encrypt = CryptographyFactory.Create(CryptoAlgorithm.RC4) as SymmetricCrypto;
            encrypt.SetKey("faib studio");

            var bytes = encrypt.Encrypt("1234", Encoding.GetEncoding(0));
            Console.WriteLine(bytes.Length);
            var s = encrypt.Decrypt(bytes, Encoding.GetEncoding(0));
            Assert.AreEqual("1234", s);
        }

        [TestMethod]
        public void TestDESEncrypt()
        {
            var encrypt = CryptographyFactory.Create(CryptoAlgorithm.DES) as SymmetricCrypto;
            encrypt.SetKey("faib studio");

            var bytes = encrypt.Encrypt("1234", Encoding.GetEncoding(0));
            Console.WriteLine(bytes.Length);
            var s = encrypt.Decrypt(bytes, Encoding.GetEncoding(0));
            Assert.AreEqual("1234", s);
        }

        [TestMethod]
        public void TestAESEncrypt()
        {
            var encrypt = CryptographyFactory.Create(CryptoAlgorithm.AES) as SymmetricCrypto;
            encrypt.SetKey("faib studio");

            var bytes = encrypt.Encrypt("1234", Encoding.GetEncoding(0));
            Console.WriteLine(bytes.Length);
            var s = encrypt.Decrypt(bytes, Encoding.GetEncoding(0));
            Assert.AreEqual("1234", s);
        }

        [TestMethod]
        public void TestRijndaelEncrypt()
        {
            var encrypt = CryptographyFactory.Create(CryptoAlgorithm.Rijndael) as SymmetricCrypto;
            encrypt.SetKey("faib studio");

            var bytes = encrypt.Encrypt("1234", Encoding.GetEncoding(0));
            Console.WriteLine(bytes.Length);
            var s = encrypt.Decrypt(bytes, Encoding.GetEncoding(0));
            Assert.AreEqual("1234", s);
        }

        [TestMethod]
        public void TestRSAEncrypt()
        {
            var encrypt = CryptographyFactory.Create(CryptoAlgorithm.RSA) as AsymmetricCrypto;
            encrypt.PublicKey = RSA_publicKey;
            encrypt.PrivateKey = RSA_privateKey;

            var bytes = encrypt.Encrypt("1234", Encoding.GetEncoding(0));
            Console.WriteLine(bytes.Length);
            var s = encrypt.Decrypt(bytes, Encoding.GetEncoding(0));
            Assert.AreEqual("1234", s);
        }

        [TestMethod]
        public void TestRSASign()
        {
            var encrypt = CryptographyFactory.Create(CryptoAlgorithm.RSA) as AsymmetricCrypto;
            encrypt.PublicKey = RSA_publicKey;
            encrypt.PrivateKey = RSA_privateKey;

            var bytes = encrypt.CreateSignature(Encoding.GetEncoding(0).GetBytes("1234"));
            var ver = encrypt.VerifySignature(Encoding.GetEncoding(0).GetBytes("1234"), bytes);
            Assert.IsTrue(ver);
        }

        [TestMethod]
        public void TestRSAGenerateKey()
        {
            var encrypt = CryptographyFactory.Create(CryptoAlgorithm.RSA) as AsymmetricCrypto;
            Console.WriteLine(encrypt.GeneratePrivateKey());
            Console.WriteLine(encrypt.GeneratePublicKey());
        }

        [TestMethod]
        public void TestDSASign()
        {
            var encrypt = CryptographyFactory.Create(CryptoAlgorithm.DSA) as AsymmetricCrypto;
            encrypt.PublicKey = DSA_publicKey;
            encrypt.PrivateKey = DSA_privateKey;

            var bytes = encrypt.CreateSignature(Encoding.GetEncoding(0).GetBytes("1234"));
            var ver = encrypt.VerifySignature(Encoding.GetEncoding(0).GetBytes("1234"), bytes);
            Assert.IsTrue(ver);
        }

        [TestMethod]
        public void TestDSAGenerateKey()
        {
            var encrypt = CryptographyFactory.Create(CryptoAlgorithm.DSA) as AsymmetricCrypto;
            Console.WriteLine(encrypt.GeneratePrivateKey());
            Console.WriteLine(encrypt.GeneratePublicKey());
        }

        [TestMethod]
        public void TestMD5Encrypt()
        {
            var str = @"<xml>
  <head>
    <requestCode>0104</requestCode>
    <authticCode>001</authticCode>
    <sign></sign>
    <randomStr>16c8924a58ad40a09997d91f30d7dc2d</randomStr>
  </head>
  <msg>
    <row EmpCode=""""></row>
  </msg>
</xml>0eb4c393-3e66-44e0-88cf-d5cad6ed0da0";

            var encrypt = CryptographyFactory.Create(CryptoAlgorithm.MD5);
            Console.WriteLine(encrypt.Encrypt(str.Replace("\r", ""), Encoding.ASCII).ToHex());
        }

        [TestMethod]
        public void TestSHA1Encrypt()
        {
            var encrypt = CryptographyFactory.Create(CryptoAlgorithm.SHA1);
            Console.WriteLine(encrypt.Encrypt("1234", Encoding.GetEncoding(0)).ToHex());
        }

        [TestMethod]
        public void TestSHA256Encrypt()
        {
            var encrypt = CryptographyFactory.Create(CryptoAlgorithm.SHA256);
            Console.WriteLine(encrypt.Encrypt("1234", Encoding.GetEncoding(0)).ToHex());
        }

        [TestMethod]
        public void TestSHA384Encrypt()
        {
            var encrypt = CryptographyFactory.Create(CryptoAlgorithm.SHA384);
            Console.WriteLine(encrypt.Encrypt("1234", Encoding.GetEncoding(0)).ToHex());
        }

        [TestMethod]
        public void TestSHA512Encrypt()
        {
            var encrypt = CryptographyFactory.Create(CryptoAlgorithm.SHA512);
            Console.WriteLine(encrypt.Encrypt("1234", Encoding.GetEncoding(0)).ToHex());
        }
    }
}
