// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;

namespace Fireasy.Web.Http
{
    public class HttpServiceException : Exception
    {
        public HttpServiceException(string message)
            : base(message, null)
        {
        }

        public HttpServiceException(string message, Exception innerExp)
            : base (message, innerExp)
        {
        }
    }
}
