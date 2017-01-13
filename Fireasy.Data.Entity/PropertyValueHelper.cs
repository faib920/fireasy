// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using Fireasy.Common;
using Fireasy.Common.Extensions;
using System.Data;
using Fireasy.Data.Converter;

namespace Fireasy.Data.Entity
{
    /// <summary>
    /// 属性值的辅助类。
    /// </summary>
    internal static class PropertyValueHelper
    {
        /// <summary>
        /// 判断指定的类型是否受 <see cref="PropertyValue"/> 类型支持。这些类型主要是值类型。
        /// </summary>
        /// <param name="type">要判断的类型。</param>
        /// <returns></returns>
        internal static bool IsSupportedType(Type type)
        {
            type = type.GetNonNullableType();
            return (type == typeof(bool) ||
                type == typeof(char) ||
                type == typeof(byte) ||
                type == typeof(byte[]) ||
                type == typeof(DateTime) ||
                type == typeof(decimal) ||
                type == typeof(double) ||
                type == typeof(Guid) ||
                type == typeof(int) ||
                type == typeof(short) ||
                type == typeof(long) ||
                type == typeof(float) ||
                type == typeof(string) ||
                type == typeof(TimeSpan) ||
                type.IsEnum);
        }

        internal static bool IsNumberType(StorageType type)
        {
            switch (type)
            {
                case StorageType.Int16:
                case StorageType.Int32:
                case StorageType.Int64:
                case StorageType.Single:
                case StorageType.Double:
                case StorageType.Decimal:
                case StorageType.Byte:
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 的值转换为 <typeparamref name="T"/> 类型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">一个 <see cref="PropertyValue"/> 对象。</param>
        /// <returns></returns>
        internal static T GetValue<T>(PropertyValue value)
        {
            if (value == null)
            {
                return default(T);
            }
            //如果是受支持的类型，强制转换，这样不会被装箱
            if (IsSupportedType(typeof(T)))
            {
                if (typeof(T).GetNonNullableType() == typeof(Guid))
                {
                    return GetGuidValue<T>(value);
                }
            }
            return value.Cast<T>();
        }

        internal static object GetValueSafely(PropertyValue value)
        {
            if (value == null || value.IsEmpty)
            {
                return null;
            }

            return value.GetStorageValue();
        }

        /// <summary>
        /// 转换为 <see cref="System.Guid"/>，<see cref="System.Guid"/> 无法强制转换。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        private static T GetGuidValue<T>(PropertyValue value)
        {
            if (value.Object != null)
            {
                return (T)(object)new Guid(value.Object.ToString());
            }
            return value.Cast<T>();
        }

        /// <summary>
        /// 使用一个值构造一个 <see cref="PropertyValue"/>。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static PropertyValue NewValue<T>(T value)
        {
            var valueType = value == null ? typeof(T) : value.GetType();
            var nonNullType = valueType.GetNonNullableType();

            //如果是受支持的类型
            if (IsSupportedType(valueType))
            {
                //枚举
                if (nonNullType.IsEnum)
                {
                    return value == null && valueType.IsNullableType() ? null : (Enum)Enum.Parse(nonNullType, value.ToString());
                }
                //字节数组
                if (nonNullType.IsArray && valueType.GetElementType() == typeof(byte))
                {
                    return value == null ? new byte[0] : (byte[])(object)value;
                }
                var isNull = value.IsNullOrEmpty();
                switch (nonNullType.FullName)
                {
                    case "System.Boolean": return isNull ? new bool?() : (bool)(object)value;
                    case "System.Byte": return isNull ? new byte?() : (byte)(object)value;
                    case "System.Char": return isNull ? new char?() : (char)(object)value;
                    case "System.DateTime": return isNull ? new DateTime?() : (DateTime)(object)value;
                    case "System.Decimal": return isNull ? new decimal?() : (decimal)(object)value;
                    case "System.Double": return isNull ? new double?() : (double)(object)value;
                    case "System.Guid": return isNull ? new Guid?() : (Guid)(object)value;
                    case "System.Int16": return isNull ? new short?() : (short)(object)value;
                    case "System.Int32": return isNull ? new int?() : (int)(object)value;
                    case "System.Int64": return isNull ? new long?() : (long)(object)value;
                    case "System.Single": return isNull ? new float?() : (float)(object)value;
                    case "System.String": return isNull ? null : (string)(object)value;
                    case "System.Time": return isNull ? new TimeSpan?() : (TimeSpan)(object)value; 
                    default: return null;
                }
            }
            return new PropertyValue(StorageType.Object) { Object = value };
        }

        /// <summary>
        /// 使用一个值构造一个 <see cref="PropertyValue"/>。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        internal static PropertyValue NewValue(object value, Type valueType)
        {
            Guard.ArgumentNull(valueType, "valueType");

            var nonNullType = valueType.GetNonNullableType();

            //如果是受支持的类型
            if (IsSupportedType(valueType))
            {
                //枚举
                if (nonNullType.IsEnum)
                {
                    return value == null && valueType.IsNullableType() ? null : (Enum)Enum.Parse(nonNullType, value.ToString());
                }
                //字节数组
                if (nonNullType.IsArray && valueType.GetElementType() == typeof(byte))
                {
                    return value == null ? new byte[0] : (byte[])value;
                }
                var isNull = value.IsNullOrEmpty();
                switch (nonNullType.FullName)
                {
                    case "System.Boolean": return isNull ? new bool?() : Convert.ToBoolean(value);
                    case "System.Byte": return isNull ? new byte?() : Convert.ToByte(value);
                    case "System.Char": return isNull ? new char?() : Convert.ToChar(value);
                    case "System.DateTime": return isNull ? new DateTime?() : Convert.ToDateTime(value);
                    case "System.Decimal": return isNull ? new decimal?() : Convert.ToDecimal(value);
                    case "System.Double": return isNull ? new double?() : Convert.ToDouble(value);
                    case "System.Guid": return isNull ? new Guid?() : new Guid(value.ToString());
                    case "System.Int16": return isNull ? new short?() : Convert.ToInt16(value);
                    case "System.Int32": return isNull ? new int?() : Convert.ToInt32(value);
                    case "System.Int64": return isNull ? new long?() : Convert.ToInt64(value);
                    case "System.Single": return isNull ? new float?() : Convert.ToSingle(value);
                    case "System.String": return isNull ? null : Convert.ToString(value);
                    case "System.Time": return isNull ? new TimeSpan?() : TimeSpan.Parse(value.ToString());
                    default: return null;
                }
            }
            return new PropertyValue(StorageType.Object) { Object = value };
        }

        /// <summary>
        /// 根据指定的<see cref="PropertyValue"/> 来设置 <see cref="Parameter"/> 的值。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        internal static Parameter Set(PropertyValue value, Parameter parameter)
        {
            switch (value.StorageType)
            {
                case StorageType.Boolean:
                    parameter.Value = value.Boolean;
                    parameter.DbType = DbType.Boolean;
                    break;
                case StorageType.Byte:
                    parameter.Value = value.Byte;
                    parameter.DbType = DbType.Byte;
                    break;
                case StorageType.ByteArray:
                    parameter.Value = value.ByteArray;
                    parameter.DbType = DbType.Binary;
                    break;
                case StorageType.Char:
                    parameter.Value = value.Char;
                    parameter.DbType = DbType.AnsiString;
                    break;
                case StorageType.DateTime:
                    parameter.Value = value.DateTime;
                    parameter.DbType = DbType.DateTime;
                    break;
                case StorageType.Decimal:
                    parameter.Value = value.Decimal;
                    parameter.DbType = DbType.Decimal;
                    break;
                case StorageType.Double:
                    parameter.Value = value.Double;
                    parameter.DbType = DbType.Double;
                    break;
                case StorageType.Enum:
                    parameter.Value = value.Enum.To<int>();
                    parameter.DbType = DbType.Int32;
                    break;
                case StorageType.Guid:
                    parameter.Value = value.Guid;
                    parameter.DbType = DbType.Guid;
                    break;
                case StorageType.Int16:
                    parameter.Value = value.Int16;
                    parameter.DbType = DbType.Int16;
                    break;
                case StorageType.Int32:
                    parameter.Value = value.Int32;
                    parameter.DbType = DbType.Int32;
                    break;
                case StorageType.Int64:
                    parameter.Value = value.Int64;
                    parameter.DbType = DbType.Int64;
                    break;
                case StorageType.Single:
                    parameter.Value = value.Single;
                    parameter.DbType = DbType.Single;
                    break;
                case StorageType.String:
                    parameter.Value = value.String;
                    parameter.DbType = DbType.AnsiString;
                    break;
                case StorageType.TimeSpan:
                    parameter.Value = value.TimeSpan;
                    parameter.DbType = DbType.Time;
                    break;
                case StorageType.Object:
                    var converter = ConvertManager.GetConverter(value.Object.GetType());
                    if (converter != null)
                    {
                        var dbType = value.Property.Info.DataType ?? DbType.String;
                        parameter.Value = converter.ConvertTo(value.Object, dbType);
                        parameter.DbType = dbType;
                    }
                    break;
            }

            return parameter;
        }
    }
}
