// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Xml.Serialization;
using Fireasy.Common.Serialization;

namespace Fireasy.Data.Entity
{
    /// <summary>
    /// 一个没有实际意义的实体类型。无法继承此类。
    /// </summary>
    public sealed class UnrealEntityObject : IEntity
    {
        [XmlIgnore]
        [SoapIgnore]
        [NoTextSerializable]
        EntityState IEntity.EntityState
        {
            get { throw new NotImplementedException(); }
        }

        [XmlIgnore]
        [SoapIgnore]
        [NoTextSerializable]
        Type IEntity.EntityType
        {
            get { throw new NotImplementedException(); }
        }

        PropertyValue IEntity.GetValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        void IEntity.SetValue(string propertyName, PropertyValue value)
        {
            throw new NotImplementedException();
        }
    }
}
