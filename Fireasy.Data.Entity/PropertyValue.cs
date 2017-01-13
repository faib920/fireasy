// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Fireasy.Common.Extensions;
using System;

namespace Fireasy.Data.Entity
{
    /// <summary>
    /// 使属性能够存储各种类型的值，而不需要进行装箱或拆箱。无法继承此类。
    /// </summary>
    [Serializable]
    public sealed class PropertyValue : ICloneable, IConvertible, IComparable
    {
        #region 构造
        /// <summary>
        /// 使用空值初始化 <see cref="PropertyValue"/> 类的新实例。
        /// </summary>
        internal PropertyValue(StorageType storageType)
        {
            StorageType = storageType;
        }
        #endregion

        /// <summary>
        /// 使用 object 数据构造一个 <see cref="PropertyValue"/> 对象。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        public static PropertyValue New(object value, Type valueType = null)
        {
            if (value != null && valueType == null)
            {
                valueType = value.GetType();
            }

            return PropertyValueHelper.NewValue(value, valueType);
        }

        #region char
        /// <summary>
        /// 将 <see cref="Char"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(char value)
        {
            return new PropertyValue(StorageType.Char) { Char = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Char"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator char(PropertyValue value)
        {
            return value == null || value.IsEmpty ? '\0' : ((IConvertible)value).ToChar(null);
        }

        /// <summary>
        /// 将 <see cref="Nullable&lt;Char&gt;"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(char? value)
        {
            return new PropertyValue(StorageType.Char) { Char = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Nullable&lt;Char&gt;"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator char?(PropertyValue value)
        {
            return value == null || value.IsEmpty ? (char?) null : ((IConvertible) value).ToChar(null);
        }

        #endregion

        #region bool
        /// <summary>
        /// 将 <see cref="Boolean"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(bool value)
        {
            return new PropertyValue(StorageType.Boolean) { Boolean = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Boolean"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator bool(PropertyValue value)
        {
            return value != null && ((IConvertible)value).ToBoolean(null);
        }

        /// <summary>
        /// 将 <see cref="Nullable&lt;Boolean&gt;"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(bool? value)
        {
            return new PropertyValue(StorageType.Boolean) { Boolean = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Nullable&lt;Boolean&gt;"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator bool?(PropertyValue value)
        {
            return value == null || value.IsEmpty ? (bool?) null : ((IConvertible) value).ToBoolean(null);
        }

        #endregion

        #region byte
        /// <summary>
        /// 将 <see cref="Byte"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(byte value)
        {
            return new PropertyValue(StorageType.Byte) { Byte = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Byte"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator byte(PropertyValue value)
        {
            return value == null || value.IsEmpty ? (byte)0 : ((IConvertible)value).ToByte(null);
        }

        /// <summary>
        /// 将 <see cref="Nullable&lt;Byte&gt;"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(byte? value)
        {
            return new PropertyValue(StorageType.Byte) { Byte = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Nullable&lt;Byte&gt;"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator byte?(PropertyValue value)
        {
            return value == null || value.IsEmpty ? (byte?) null : ((IConvertible) value).ToByte(null);
        }

        #endregion

        #region bytes
        /// <summary>
        /// 将 <see cref="Byte"/> 数组类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(byte[] value)
        {
            return new PropertyValue(StorageType.ByteArray) { ByteArray = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Byte"/> 数组类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator byte[](PropertyValue value)
        {
            if (value == null)
            {
                return new byte[0];
            }
            return value.Object != null ? (byte[])value.Object : value.ByteArray == null ? new byte[0] : value.ByteArray;
        }
        #endregion

        #region DateTime
        /// <summary>
        /// 将 <see cref="DateTime"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(DateTime value)
        {
            return new PropertyValue(StorageType.DateTime) { DateTime = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="DateTime"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator DateTime(PropertyValue value)
        {
            return value == null || value.IsEmpty ? System.DateTime.MinValue : ((IConvertible)value).ToDateTime(null);
        }

        /// <summary>
        /// 将 <see cref="Nullable&lt;DateTime&gt;"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(DateTime? value)
        {
            return new PropertyValue(StorageType.DateTime) { DateTime = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Nullable&lt;DateTime&gt;"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator DateTime?(PropertyValue value)
        {
            return value == null || value.IsEmpty ? (DateTime?) null : ((IConvertible) value).ToDateTime(null);
        }

        #endregion

        #region decimal
        /// <summary>
        /// 将 <see cref="Decimal"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(decimal value)
        {
            return new PropertyValue(StorageType.Decimal) { Decimal = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Decimal"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator decimal(PropertyValue value)
        {
            return value == null || value.IsEmpty ? 0 : ((IConvertible)value).ToDecimal(null);
        }

        /// <summary>
        /// 将 <see cref="Nullable&lt;Decimal&gt;"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(decimal? value)
        {
            return new PropertyValue(StorageType.Decimal) { Decimal = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Nullable&lt;Decimal&gt;"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator decimal?(PropertyValue value)
        {
            return value == null || value.IsEmpty ? (decimal?) null : ((IConvertible) value).ToDecimal(null);
        }

        #endregion

        #region double
        /// <summary>
        /// 将 <see cref="Double"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(double value)
        {
            return new PropertyValue(StorageType.Double) { Double = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Double"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator double(PropertyValue value)
        {
            return value == null || value.IsEmpty ? 0 : ((IConvertible)value).ToDouble(null);
        }

        /// <summary>
        /// 将 <see cref="Nullable&lt;Double&gt;"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(double? value)
        {
            return new PropertyValue(StorageType.Double) { Double = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Nullable&lt;Double&gt;"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator double?(PropertyValue value)
        {
            return value == null || value.IsEmpty ? (double?) null : ((IConvertible) value).ToDouble(null);
        }

        #endregion

        #region Guid
        /// <summary>
        /// 将 <see cref="Guid"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(Guid value)
        {
            return new PropertyValue(StorageType.Guid) { Guid = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Guid"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator Guid(PropertyValue value)
        {
            if (value == null)
            {
                return System.Guid.Empty;
            }
            if (value.Object != null)
            {
                return (Guid)value.Object;
            }
            if (value.Guid != null)
            {
                return value.Guid.Value;
            }
            if (value.String != null)
            {
                return new Guid(value.String);
            }
            if (value.ByteArray != null)
            {
                return new Guid(value.ByteArray);
            }
            return System.Guid.Empty;
        }

        /// <summary>
        /// 将 <see cref="Nullable&lt;Guid&gt;"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(Guid? value)
        {
            return new PropertyValue(StorageType.Guid) { Guid = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Nullable&lt;Guid&gt;"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator Guid?(PropertyValue value)
        {
            if (value == null)
            {
                return null;
            }
            return (Guid)value;
        }
        #endregion

        #region int
        /// <summary>
        /// 将 <see cref="Int32"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(int value)
        {
            return new PropertyValue(StorageType.Int32) { Int32 = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Int32"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator int(PropertyValue value)
        {
            return value == null || value.IsEmpty ? 0 : ((IConvertible)value).ToInt32(null);
        }

        /// <summary>
        /// 将 <see cref="Nullable&lt;Int32&gt;"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(int? value)
        {
            return new PropertyValue(StorageType.Int32) { Int32 = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Nullable&lt;Int32&gt;"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator int?(PropertyValue value)
        {
            return value == null || value.IsEmpty ? (int?) null : ((IConvertible) value).ToInt32(null);
        }

        #endregion

        #region short
        /// <summary>
        /// 将 <see cref="Int16"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(short value)
        {
            return new PropertyValue(StorageType.Int16) { Int16 = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Int16"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator short(PropertyValue value)
        {
            return value == null || value.IsEmpty ? (short)0 : ((IConvertible)value).ToInt16(null);
        }

        /// <summary>
        /// 将 <see cref="Nullable&lt;Int16&gt;"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(short? value)
        {
            return new PropertyValue(StorageType.Int16) { Int16 = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Nullable&lt;Int16&gt;"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator short?(PropertyValue value)
        {
            return value == null || value.IsEmpty ? (short?) null : ((IConvertible) value).ToInt16(null);
        }

        #endregion

        #region long
        /// <summary>
        /// 将 <see cref="Int64"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(long value)
        {
            return new PropertyValue(StorageType.Int64) { Int64 = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Int64"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator long(PropertyValue value)
        {
            return value == null || value.IsEmpty ? 0 : ((IConvertible)value).ToInt64(null);
        }

        /// <summary>
        /// 将 <see cref="Nullable&lt;Int64&gt;"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(long? value)
        {
            return new PropertyValue(StorageType.Int64) { Int64 = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Nullable&lt;Int64&gt;"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator long?(PropertyValue value)
        {
            return value == null || value.IsEmpty ? (long?) null : ((IConvertible) value).ToInt64(null);
        }

        #endregion

        #region float
        /// <summary>
        /// 将 <see cref="Single"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(float value)
        {
            return new PropertyValue(StorageType.Single) { Single = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Single"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator float(PropertyValue value)
        {
            return value == null || value.IsEmpty ? 0 : ((IConvertible)value).ToSingle(null);
        }

        /// <summary>
        /// 将 <see cref="Nullable&lt;Single&gt;"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(float? value)
        {
            return new PropertyValue(StorageType.Single) { Single = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Nullable&lt;Single&gt;"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator float?(PropertyValue value)
        {
            return value == null || value.IsEmpty ? (float?) null : ((IConvertible) value).ToSingle(null);
        }

        #endregion

        #region string
        /// <summary>
        /// 将 <see cref="String"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(string value)
        {
            return new PropertyValue(StorageType.String) { String = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="String"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator string(PropertyValue value)
        {
            return value == null || value.IsEmpty ? string.Empty : ((IConvertible)value).ToString(null);
        }

        #endregion

        #region timespan
        /// <summary>
        /// 将 <see cref="TimeSpan"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(TimeSpan value)
        {
            return new PropertyValue(StorageType.TimeSpan) { TimeSpan = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="TimeSpan"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator TimeSpan(PropertyValue value)
        {
            if (value == null)
            {
                return System.TimeSpan.Zero;
            }
            if (value.Object != null)
            {
                return (TimeSpan)value.Object;
            }
            if (value.TimeSpan != null)
            {
                return value.TimeSpan.Value;
            }
            if (value.Int64 != null)
            {
                return System.TimeSpan.FromTicks(value.Int64.Value);
            }
            return System.TimeSpan.Zero;
        }

        /// <summary>
        /// 将 <see cref="Nullable&lt;TimeSpan&gt;"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(TimeSpan? value)
        {
            return new PropertyValue(StorageType.TimeSpan) { TimeSpan = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Nullable&lt;TimeSpan&gt;"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator TimeSpan?(PropertyValue value)
        {
            if (value == null)
            {
                return null;
            }
            return (TimeSpan)value;
        }
        #endregion

        #region enum
        /// <summary>
        /// 将 <see cref="Enum"/> 类型隐式转换为 <see cref="PropertyValue"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator PropertyValue(Enum value)
        {
            return new PropertyValue(StorageType.Enum) { Enum = value };
        }

        /// <summary>
        /// 将 <see cref="PropertyValue"/> 类型显示转换为 <see cref="Enum"/> 类型。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator Enum(PropertyValue value)
        {
            if (value == null)
            {
                return null;
            }
            return value.Object != null ? (Enum)value.Object : value.Enum;
        }
        #endregion

        #region ==和!=
        public static bool operator ==(PropertyValue v1, PropertyValue v2)
        {
            if (object.Equals(v1, null) && object.Equals(v2, null))
            {
                return true;
            }

            if ((object.Equals(v1, null) && !object.Equals(v2, null)) || (!object.Equals(v1, null) && object.Equals(v2, null)))
            {
                return false;
            }

            if (v1.StorageType != v2.StorageType)
            {
                return false;
            }

            switch (v1.StorageType)
            {
                case StorageType.Boolean: return v1.Boolean == v2.Boolean;
                case StorageType.Byte: return v1.Byte == v2.Byte;
                case StorageType.Char: return v1.Char == v2.Char;
                case StorageType.DateTime: return v1.DateTime == v2.DateTime;
                case StorageType.Decimal: return v1.Decimal == v2.Decimal;
                case StorageType.Double: return v1.Double == v2.Double;
                case StorageType.Enum: return v1.Enum == v2.Enum;
                case StorageType.Guid: return v1.Guid == v2.Guid;
                case StorageType.Int16: return v1.Int16 == v2.Int16;
                case StorageType.Int32: return v1.Int32 == v2.Int32;
                case StorageType.Int64: return v1.Int64 == v2.Int64;
                case StorageType.Single: return v1.Single == v2.Single;
                case StorageType.String: return v1.String == v2.String;
                case StorageType.TimeSpan: return v1.TimeSpan == v2.TimeSpan;
                default: return v1.Object == v2.Object;
            }
        }

        public static bool operator !=(PropertyValue v1, PropertyValue v2)
        {
            return !(v1 == v2);
        }

        #endregion

        internal IProperty Property { get; set; }

        /// <summary>
        /// 获取存储数据的实际类型。
        /// </summary>
        internal StorageType StorageType { get; private set; }

        internal char? Char { get; set; }

        internal bool? Boolean { get; set; }

        internal byte? Byte { get; set; }

        internal byte[] ByteArray { get; set; }

        internal DateTime? DateTime { get; set; }

        internal decimal? Decimal { get; set; }

        internal double? Double { get; set; }

        internal Guid? Guid { get; set; }

        internal short? Int16 { get; set; }

        internal int? Int32 { get; set; }

        internal long? Int64 { get; set; }

        internal float? Single { get; set; }

        internal string String { get; set; }

        internal Enum Enum { get; set; }

        internal TimeSpan? TimeSpan { get; set; }

        internal object Object { get; set; }

        /// <summary>
        /// 获取该对象是否为空。
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                switch (StorageType)
                {
                    case StorageType.Boolean: return Boolean == null;
                    case StorageType.Byte: return Byte == null;
                    case StorageType.ByteArray: return ByteArray == new byte[0];
                    case StorageType.Char: return Char == null;
                    case StorageType.DateTime: return DateTime == null;
                    case StorageType.Decimal: return Decimal == null;
                    case StorageType.Double: return Double == null;
                    case StorageType.Enum: return Enum == null;
                    case StorageType.Guid: return Guid == null;
                    case StorageType.Int16: return Int16 == null;
                    case StorageType.Int32: return Int32 == null;
                    case StorageType.Int64: return Int64 == null;
                    case StorageType.Object: return Object == null;
                    case StorageType.Single: return Single == null;
                    case StorageType.String: return String == null;
                    case StorageType.TimeSpan: return TimeSpan == null;
                    default: return true;
                }
            }
        }

        /// <summary>
        /// 获取该对象是否有效，即数字不为 0、字符串不为空字符时有效。
        /// </summary>
        public bool IsValid
        {
            get
            {
                switch (StorageType)
                {
                    case StorageType.Byte: return Byte != 0;
                    case StorageType.Char: return Char != '\0';
                    case StorageType.Decimal: return Decimal != 0;
                    case StorageType.Double: return Double != 0;
                    case StorageType.Int16: return Int16 != 0;
                    case StorageType.Int32: return Int32 != 0;
                    case StorageType.Int64: return Int64 != 0;
                    case StorageType.Single: return Single != 0;
                    case StorageType.String: return String != "";
                    default: return true;
                }
            }
        }

        /// <summary>
        /// 纠正存储值的类型。
        /// </summary>
        /// <param name="correctType">要纠正的实际存储的类型。</param>
        internal void Correct(Type correctType)
        {
            if (correctType.IsEnum)
            {
                if (StorageType != StorageType.Enum)
                {
                    CorrectToEnum(correctType);
                }
            }
            else if (correctType.GetNonNullableType() == typeof(bool))
            {
                if (StorageType != StorageType.Boolean)
                {
                    CorrectToBoolean();
                }
            }
            else if (correctType.GetNonNullableType() == typeof(Guid))
            {
                if (StorageType != StorageType.Guid)
                {
                    CorrectToGuid();
                }
            }
        }

        private void CorrectToEnum(Type correctType)
        {
            switch (StorageType)
            {
                case StorageType.Int32:
                    Enum = (Enum)Enum.Parse(correctType, Int32.ToString());
                    Int32 = null;
                    break;
                case StorageType.Int16:
                    Enum = (Enum)Enum.Parse(correctType, Int16.ToString());
                    Int16 = null;
                    break;
                case StorageType.Int64:
                    Enum = (Enum)Enum.Parse(correctType, Int64.ToString());
                    Int64 = null;
                    break;
            }
            StorageType = StorageType.Enum;
        }

        private void CorrectToBoolean()
        {
            switch (StorageType)
            {
                case StorageType.Int16:
                    Boolean = Int16 == null ? null : (bool?)(Int16.Value != 0);
                    Int16 = null;
                    break;
                case StorageType.Int32:
                    Boolean = Int32 == null ? null : (bool?)(Int32.Value != 0);
                    Int32 = null;
                    break;
                case StorageType.Int64:
                    Boolean = Int64 == null ? null : (bool?)(Int64.Value != 0);
                    Int64 = null;
                    break;
            }
            StorageType = StorageType.Boolean;
        }

        private void CorrectToGuid()
        {
            switch (StorageType)
            {
                case StorageType.String:
                    Guid = new Guid(String);
                    String = null;
                    break;
                case StorageType.ByteArray:
                    Guid = new Guid(ByteArray);
                    ByteArray = null;
                    break;
            }
            StorageType = StorageType.Guid;
        }

        internal T Cast<T>()
        {
            if (IsEmpty)
            {
                return default(T);
            }
            switch (StorageType)
            {
                case StorageType.Boolean: return (T)(object)Boolean;
                case StorageType.Byte: return (T)(object)Byte;
                case StorageType.ByteArray: return (T)(object)ByteArray;
                case StorageType.Char: return (T)(object)Char;
                case StorageType.DateTime: return (T)(object)DateTime;
                case StorageType.Decimal: return (T)(object)Decimal;
                case StorageType.Double: return (T)(object)Double;
                case StorageType.Enum: return (T)(object)Enum;
                case StorageType.Guid: return (T)(object)Guid;
                case StorageType.Int16: return (T)(object)Int16;
                case StorageType.Int32: return (T)(object)Int32;
                case StorageType.Int64: return (T)(object)Int64;
                case StorageType.Object: return (T)Object;
                case StorageType.Single: return (T)(object)Single;
                case StorageType.String: return (T)(object)String;
                case StorageType.TimeSpan: return (T)(object)TimeSpan;
                default: return default(T);
            }
        }

        #region object
        /// <summary>
        /// 获取实际存储的值，转换为 <see cref="System.Object"/> 表示。
        /// </summary>
        /// <returns></returns>
        public object GetStorageValue()
        {
            switch (StorageType)
            {
                case StorageType.Boolean: return Boolean;
                case StorageType.Byte: return Byte;
                case StorageType.ByteArray: return ByteArray;
                case StorageType.Char: return Char;
                case StorageType.DateTime: return DateTime;
                case StorageType.Decimal: return Decimal;
                case StorageType.Double: return Double;
                case StorageType.Enum: return Enum;
                case StorageType.Guid: return Guid;
                case StorageType.Int16: return Int16;
                case StorageType.Int32: return Int32;
                case StorageType.Int64: return Int64;
                case StorageType.Object: return Object;
                case StorageType.Single: return Single;
                case StorageType.String: return String;
                case StorageType.TimeSpan: return TimeSpan;
                default: return null;
            }
        }

        /// <summary>
        /// 判断是否与指定的属性值相等。
        /// </summary>
        /// <param name="right"></param>
        /// <returns></returns>
        public override bool Equals(object right)
        {
            if (ReferenceEquals(right, null))
            {
                return false;
            }
            if (ReferenceEquals(this, right))
            {
                return true;
            }
            var s = right.As<PropertyValue>();
            if (StorageType != s.StorageType)
            {
                return false;
            }
            return GetHashCode() == right.GetHashCode();
        }

        /// <summary>
        /// 获取属性值的哈希码。
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            switch (StorageType)
            {
                case StorageType.Boolean: return Boolean == null ? 0 : Boolean.GetHashCode();
                case StorageType.Byte: return Byte == null ? 0 : Byte.GetHashCode();
                case StorageType.Char: return Char == null ? 0 : Char.GetHashCode();
                case StorageType.DateTime: return DateTime == null ? 0 : DateTime.GetHashCode();
                case StorageType.Decimal: return Decimal == null ? 0 : Decimal.GetHashCode();
                case StorageType.Double: return Double == null ? 0 : Double.GetHashCode();
                case StorageType.Enum: return Enum == null ? 0 : Enum.GetHashCode();
                case StorageType.Guid: return Guid == null ? 0 : Guid.GetHashCode();
                case StorageType.Int16: return Int16 == null ? 0 : Int16.GetHashCode();
                case StorageType.Int32: return Int32 == null ? 0 : Int32.GetHashCode();
                case StorageType.Int64: return Int64 == null ? 0 : Int64.GetHashCode();
                case StorageType.Single: return Single == null ? 0 : Single.GetHashCode();
                case StorageType.String: return String == null ? 0 : String.GetHashCode();
                case StorageType.TimeSpan: return TimeSpan == null ? 0 : TimeSpan.GetHashCode();
            }
            return base.GetHashCode();
        }

        /// <summary>
        /// 克隆该对象副本。
        /// </summary>
        /// <returns></returns>
        public PropertyValue Clone()
        {
            switch (StorageType)
            {
                case StorageType.Boolean: return Boolean;
                case StorageType.Byte: return Byte;
                case StorageType.Char: return Char;
                case StorageType.DateTime: return DateTime;
                case StorageType.Decimal: return Decimal;
                case StorageType.Double: return Double;
                case StorageType.Enum: return Enum;
                case StorageType.Guid: return Guid;
                case StorageType.Int16: return Int16;
                case StorageType.Int32: return Int32;
                case StorageType.Int64: return Int64;
                case StorageType.Single: return Single;
                case StorageType.String: return string.IsNullOrEmpty(String) ? string.Empty : string.Copy(String);
                case StorageType.TimeSpan: return TimeSpan;
                default:
                    if (Object == null)
                    {
                        return null;
                    }
                    var staClone = Object.As<IKeepStateCloneable>();
                    if (staClone != null)
                    {
                        return new PropertyValue(StorageType.Object) { Object = staClone.Clone() };
                    }
                    var cloneable = Object.As<ICloneable>();
                    return new PropertyValue(StorageType.Object) { Object = cloneable == null ? Object : cloneable.Clone() };
            }
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// 使用字符串表示该属性。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return IsEmpty ? string.Empty : GetStorageValue().ToString();
        }

        #endregion

        #region 静态方法
        /// <summary>
        /// 判断指定的值是否为空。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(PropertyValue value)
        {
            return value == null || value.IsEmpty;
        }

        /// <summary>
        /// 获取指定 <see cref="PropertyValue"/> 真实的值。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object GetValue(PropertyValue value)
        {
            return value.IsNullOrEmpty() ? null : value.GetStorageValue();
        }
        #endregion

        #region 实现 IConvertible 接口
        TypeCode IConvertible.GetTypeCode()
        {
            switch (StorageType)
            {
                case StorageType.Boolean: return TypeCode.Boolean;
                case StorageType.Byte: return TypeCode.Byte;
                case StorageType.Char: return TypeCode.Char;
                case StorageType.DateTime: return TypeCode.DateTime;
                case StorageType.Decimal: return TypeCode.Decimal;
                case StorageType.Double: return TypeCode.Double;
                case StorageType.Int16: return TypeCode.Int16;
                case StorageType.Int32: return TypeCode.Int32;
                case StorageType.Int64: return TypeCode.Int64;
                case StorageType.Single: return TypeCode.Single;
                case StorageType.String: return TypeCode.String;
                default:
                    return TypeCode.Object;
            }
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            if (Object != null)
            {
                return Convert.ToBoolean(Object, provider);
            }
            if (Boolean != null)
            {
                return Boolean.Value;
            }
            if (Byte != null)
            {
                return Convert.ToBoolean(Byte.Value);
            }
            if (Char != null)
            {
                return Convert.ToBoolean(Char.Value);
            }
            if (Int16 != null)
            {
                return Convert.ToBoolean(Int16.Value);
            }
            if (Int32 != null)
            {
                return Convert.ToBoolean(Int32.Value);
            }
            if (Int64 != null)
            {
                return Convert.ToBoolean(Int64.Value);
            }
            if (Decimal != null)
            {
                return Convert.ToBoolean(Decimal.Value);
            }
            if (Double != null)
            {
                return Convert.ToBoolean(Double.Value);
            }
            if (Single != null)
            {
                return Convert.ToBoolean(Single.Value);
            }
            if (String != null)
            {
                return Convert.ToBoolean(String);
            }
            return false;
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            if (Object != null)
            {
                return Convert.ToChar(Object, provider);
            }
            if (Char != null)
            {
                return Char.Value;
            }
            if (Boolean != null)
            {
                return Convert.ToChar(Boolean.Value);
            }
            if (Byte != null)
            {
                return Convert.ToChar(Byte.Value);
            }
            if (Int16 != null)
            {
                return Convert.ToChar(Int16.Value);
            }
            if (Int32 != null)
            {
                return Convert.ToChar(Int32.Value);
            }
            if (Int64 != null)
            {
                return Convert.ToChar(Int64.Value);
            }
            if (Decimal != null)
            {
                return Convert.ToChar(Decimal.Value);
            }
            if (Double != null)
            {
                return Convert.ToChar(Double.Value);
            }
            if (Single != null)
            {
                return Convert.ToChar(Single.Value);
            }
            if (String != null)
            {
                return Convert.ToChar(String);
            }
            return '\0';
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            throw new InvalidCastException(SR.GetString(SRKind.InvalidCastPropertyValue, typeof(sbyte)));
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            if (Object != null)
            {
                return Convert.ToByte(Object, provider);
            }
            if (Byte != null)
            {
                return Byte.Value;
            }
            if (Boolean != null)
            {
                return Convert.ToByte(Boolean.Value);
            }
            if (Char != null)
            {
                return Convert.ToByte(Char.Value);
            }
            if (Int16 != null)
            {
                return Convert.ToByte(Int16.Value);
            }
            if (Int32 != null)
            {
                return Convert.ToByte(Int32.Value);
            }
            if (Int64 != null)
            {
                return Convert.ToByte(Int64.Value);
            }
            if (Decimal != null)
            {
                return Convert.ToByte(Decimal.Value);
            }
            if (Double != null)
            {
                return Convert.ToByte(Double.Value);
            }
            if (Single != null)
            {
                return Convert.ToByte(Single.Value);
            }
            if (String != null)
            {
                return Convert.ToByte(String);
            }
            return 0;
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            if (Object != null)
            {
                return Convert.ToInt16(Object, provider);
            }
            if (Int16 != null)
            {
                return Int16.Value;
            }
            if (Boolean != null)
            {
                return Convert.ToInt16(Boolean.Value);
            }
            if (Byte != null)
            {
                return Convert.ToInt16(Byte.Value);
            }
            if (Char != null)
            {
                return Convert.ToInt16(Char.Value);
            }
            if (Int32 != null)
            {
                return Convert.ToInt16(Int32.Value);
            }
            if (Int64 != null)
            {
                return Convert.ToInt16(Int64.Value);
            }
            if (Decimal != null)
            {
                return Convert.ToInt16(Decimal.Value);
            }
            if (Double != null)
            {
                return Convert.ToInt16(Double.Value);
            }
            if (Single != null)
            {
                return Convert.ToInt16(Single.Value);
            }
            if (String != null)
            {
                return Convert.ToInt16(String, provider);
            }
            return 0;
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            throw new InvalidCastException(SR.GetString(SRKind.InvalidCastPropertyValue, typeof(ushort)));
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            if (Object != null)
            {
                return Convert.ToInt32(Object, provider);
            }
            if (Int32 != null)
            {
                return Int32.Value;
            }
            if (Boolean != null)
            {
                return Convert.ToInt32(Boolean.Value);
            }
            if (Byte != null)
            {
                return Convert.ToInt32(Byte.Value);
            }
            if (Char != null)
            {
                return Convert.ToInt32(Char.Value);
            }
            if (Int16 != null)
            {
                return Convert.ToInt32(Int16.Value);
            }
            if (Int64 != null)
            {
                return Convert.ToInt32(Int64.Value);
            }
            if (Decimal != null)
            {
                return Convert.ToInt32(Decimal.Value);
            }
            if (Double != null)
            {
                return Convert.ToInt32(Double.Value);
            }
            if (Single != null)
            {
                return Convert.ToInt32(Single.Value);
            }
            if (String != null)
            {
                return Convert.ToInt32(String, provider);
            }
            return 0;
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            throw new InvalidCastException(SR.GetString(SRKind.InvalidCastPropertyValue, typeof(uint)));
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            if (Object != null)
            {
                return Convert.ToInt64(Object, provider);
            }
            if (Int64 != null)
            {
                return Int64.Value;
            }
            if (Boolean != null)
            {
                return Convert.ToInt64(Boolean.Value);
            }
            if (Byte != null)
            {
                return Convert.ToInt64(Byte.Value);
            }
            if (Char != null)
            {
                return Convert.ToInt64(Char.Value);
            }
            if (Int16 != null)
            {
                return Convert.ToInt64(Int16.Value);
            }
            if (Int32 != null)
            {
                return Convert.ToInt64(Int32.Value);
            }
            if (Decimal != null)
            {
                return Convert.ToInt64(Decimal.Value);
            }
            if (Double != null)
            {
                return Convert.ToInt64(Double.Value);
            }
            if (Single != null)
            {
                return Convert.ToInt64(Single.Value);
            }
            if (String != null)
            {
                return Convert.ToInt64(String, provider);
            }
            return 0;
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            throw new InvalidCastException(SR.GetString(SRKind.InvalidCastPropertyValue, typeof(ulong)));
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            if (Boolean != null)
            {
                return Convert.ToSingle(Boolean.Value);
            }
            if (Byte != null)
            {
                return Convert.ToSingle(Byte.Value);
            }
            if (Char != null)
            {
                return Convert.ToSingle(Char.Value);
            }
            if (Int16 != null)
            {
                return Convert.ToSingle(Int16.Value);
            }
            if (Int32 != null)
            {
                return Convert.ToSingle(Int32.Value);
            }
            if (Int64 != null)
            {
                return Convert.ToSingle(Int64.Value);
            }
            if (Decimal != null)
            {
                return Convert.ToSingle(Decimal.Value);
            }
            if (Double != null)
            {
                return Convert.ToSingle(Double.Value);
            }
            if (String != null)
            {
                return Convert.ToSingle(String, provider);
            }
            return 0;
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            if (Object != null)
            {
                return Convert.ToDouble(Object, provider);
            }
            if (Double != null)
            {
                return Double.Value;
            }
            if (Boolean != null)
            {
                return Convert.ToDouble(Boolean.Value);
            }
            if (Byte != null)
            {
                return Convert.ToDouble(Byte.Value);
            }
            if (Char != null)
            {
                return Convert.ToDouble(Char.Value);
            }
            if (Int16 != null)
            {
                return Convert.ToDouble(Int16.Value);
            }
            if (Int32 != null)
            {
                return Convert.ToDouble(Int32.Value);
            }
            if (Int64 != null)
            {
                return Convert.ToDouble(Int64.Value);
            }
            if (Decimal != null)
            {
                return Convert.ToDouble(Decimal.Value);
            }
            if (Single != null)
            {
                return Convert.ToDouble(Single.Value);
            }
            if (String != null)
            {
                return Convert.ToDouble(String, provider);
            }
            return 0;
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            if (Object != null)
            {
                return Convert.ToDecimal(Object, provider);
            }
            if (Decimal != null)
            {
                return Decimal.Value;
            }
            if (Boolean != null)
            {
                return Convert.ToDecimal(Boolean.Value);
            }
            if (Byte != null)
            {
                return Convert.ToDecimal(Byte.Value);
            }
            if (Char != null)
            {
                return Convert.ToDecimal(Char.Value);
            }
            if (Int16 != null)
            {
                return Convert.ToDecimal(Int16.Value);
            }
            if (Int32 != null)
            {
                return Convert.ToDecimal(Int32.Value);
            }
            if (Int64 != null)
            {
                return Convert.ToDecimal(Int64.Value);
            }
            if (Double != null)
            {
                return Convert.ToDecimal(Double.Value);
            }
            if (Single != null)
            {
                return Convert.ToDecimal(Single.Value);
            }
            if (String != null)
            {
                return Convert.ToDecimal(String, provider);
            }
            return 0;
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            if (Object != null)
            {
                return Convert.ToDateTime(Object, provider);
            }
            if (DateTime != null)
            {
                return DateTime.Value;
            }
            if (String != null)
            {
                return Convert.ToDateTime(String, provider);
            }
            return System.DateTime.MinValue;
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            if (Object != null)
            {
                return Convert.ToString(Object, provider);
            }
            if (String != null)
            {
                return String;
            }
            if (Boolean != null)
            {
                return Convert.ToString(Boolean.Value);
            }
            if (Byte != null)
            {
                return Convert.ToString(Byte.Value);
            }
            if (Char != null)
            {
                return Convert.ToString(Char.Value);
            }
            if (Int16 != null)
            {
                return Convert.ToString(Int16.Value);
            }
            if (Int32 != null)
            {
                return Convert.ToString(Int32.Value);
            }
            if (Int64 != null)
            {
                return Convert.ToString(Int64.Value);
            }
            if (Decimal != null)
            {
                return Convert.ToString(Decimal.Value);
            }
            if (Double != null)
            {
                return Convert.ToString(Double.Value);
            }
            if (Single != null)
            {
                return Convert.ToString(Single.Value);
            }
            return string.Empty;
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(GetStorageValue(), conversionType, provider);
        }
        #endregion

        public int CompareTo(object obj)
        {
            var o = obj as PropertyValue;
            if (o == null)
            {
                return 1;
            }

            if (IsEmpty && o.IsEmpty)
            {
                return 1;
            }

            if (o.StorageType != StorageType)
            {
                return -1;
            }

            switch (StorageType)
            {
                case Entity.StorageType.Boolean:
                    return (Boolean as IComparable).CompareTo(o.Boolean);
                case Entity.StorageType.Byte:
                    return (Byte as IComparable).CompareTo(o.Byte);
                case Entity.StorageType.Char:
                    return (Char as IComparable).CompareTo(o.Char);
                case Entity.StorageType.DateTime:
                    return (DateTime as IComparable).CompareTo(o.DateTime);
                case Entity.StorageType.Decimal:
                    return (Decimal as IComparable).CompareTo(o.Decimal);
                case Entity.StorageType.Double:
                    return (Double as IComparable).CompareTo(o.Double);
                case Entity.StorageType.Enum:
                    return (Enum as IComparable).CompareTo(o.Enum);
                case Entity.StorageType.Guid:
                    return (Guid as IComparable).CompareTo(o.Guid);
                case Entity.StorageType.Int16:
                    return (Int16 as IComparable).CompareTo(o.Int16);
                case Entity.StorageType.Int32:
                    return (Int32 as IComparable).CompareTo(o.Int32);
                case Entity.StorageType.Int64:
                    return (Int64 as IComparable).CompareTo(o.Int64);
                case Entity.StorageType.Single:
                    return (Single as IComparable).CompareTo(o.Single);
                case Entity.StorageType.String:
                    return (String as IComparable).CompareTo(o.String);
                case Entity.StorageType.TimeSpan:
                    return (TimeSpan as IComparable).CompareTo(o.TimeSpan);
                    
                default:
                    var c = Object as IComparable;
                    if (c != null)
                    {
                        return c.CompareTo(o.Object);
                    }
                    break;
            }

            return -1;
        }
    }

    /// <summary>
    /// 存储数据的类别。
    /// </summary>
    internal enum StorageType
    {
        /// <summary>
        /// 空的，没有存储数据。
        /// </summary>
        Empty,
        /// <summary>
        /// System.Char 类型的数据。
        /// </summary>
        Char,
        /// <summary>
        /// System.Enum 类型的数据。
        /// </summary>
        Enum,
        /// <summary>
        /// System.Boolean 类型的数据。
        /// </summary>
        Boolean,
        /// <summary>
        /// System.Byte 类型的数据。
        /// </summary>
        Byte,
        /// <summary>
        /// System.Byte[] 类型的数据。
        /// </summary>
        ByteArray,
        /// <summary>
        /// System.DateTime 类型的数据。
        /// </summary>
        DateTime,
        /// <summary>
        /// System.Decimal 类型的数据。
        /// </summary>
        Decimal,
        /// <summary>
        /// System.Double 类型的数据。
        /// </summary>
        Double,
        /// <summary>
        /// System.Guid 类型的数据。
        /// </summary>
        Guid,
        /// <summary>
        /// System.Int16 类型的数据。
        /// </summary>
        Int16,
        /// <summary>
        /// System.Int32 类型的数据。
        /// </summary>
        Int32,
        /// <summary>
        /// System.Int64 类型的数据。
        /// </summary>
        Int64,
        /// <summary>
        /// System.Single 类型的数据。
        /// </summary>
        Single,
        /// <summary>
        /// System.String 类型的数据。
        /// </summary>
        String,
        /// <summary>
        /// System.TimeSpan 类型的数据。
        /// </summary>
        TimeSpan,
        /// <summary>
        /// System.Object 类型的数据。
        /// </summary>
        Object
    }
}
