// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Fireasy.Data.Entity
{
    internal class EntityPropertyFieldMappingResolver
    {
        internal static IEnumerable<PropertyFieldMapping> GetDbMapping(Type entityType)
        {
            return from s in PropertyUnity.GetLoadedProperties(entityType, true)
                   let name = string.IsNullOrEmpty(s.Info.FieldName) ? s.Name : s.Info.FieldName
                   let dbType = s.Info.DataType == null ? DbType.String : s.Info.DataType.Value
                   select new PropertyFieldMapping(s.Name, s.Info.FieldName, s.Type, dbType)
                       {
                           ValueFunc = e => PropertyValueHelper.GetValueSafely(((IEntity)e).InternalGetValue(s))
                       };
        }
    }
}
