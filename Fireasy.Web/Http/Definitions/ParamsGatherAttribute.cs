// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Fireasy.Web.Http.Definitions
{
    /// <summary>
    /// 指示参数的值来自 <see cref="HttpRequest"/> 的 Params 集合。无法继承此类。
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple=false)]
    public sealed class ParamsGatherAttribute : Attribute
    {
    }
}
