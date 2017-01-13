using Fireasy.Common.Security;

namespace Fireasy.Data.EntityTests
{
    class CodedDataConverter : Fireasy.Data.Converter.CodedDataConverter
    {
        private ICryptoProvider cryptor = CryptographyFactory.Create(CryptoAlgorithm.RC2);

        protected override byte[] EncodeDataToBytes(CodedData data)
        {
            return cryptor.Encrypt(data.Data);
        }

        protected override CodedData DecodeDataFromBytes(byte[] data)
        {
            return new CodedData(cryptor.Decrypt(data));
        }
    }
}
