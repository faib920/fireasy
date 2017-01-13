// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Serialization;

namespace Fireasy.Redis
{
    /// <summary>
    /// 对象序列化。
    /// </summary>
    public class ObjectSerializer
    {
        private JsonSerializer serializer;

        public ObjectSerializer()
        {
            var option = new JsonSerializeOption();
            option.Converters.Add(new FullDateTimeJsonConverter());
            serializer = new JsonSerializer(option);
        }

        /// <summary>
        /// json序列化后进行压缩。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual byte[] Serialize<T>(T value)
        {
            var compress = new BinaryCompressSerializer();
            return compress.Serialize(serializer.Serialize(value));
        }

        /// <summary>
        /// 解压缩后json反序列化。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public virtual T Deserialize<T>(byte[] bytes)
        {
            var compress = new BinaryCompressSerializer();
            return serializer.Deserialize<T>(compress.Deserialize<string>(bytes));
        }
    }
}
