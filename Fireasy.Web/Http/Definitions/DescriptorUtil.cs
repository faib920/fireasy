// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Caching;
using System;

namespace Fireasy.Web.Http.Definitions
{
    public static class DescriptorUtil
    {
        public static ServiceDescriptor GetServiceDescriptor(string serviceName, Type serviceType, Func<string, Type, ServiceDescriptor> factory)
        {
            var cacheMgr = CacheManagerFactory.CreateManager();
            return cacheMgr.TryGet(serviceType.FullName, () => factory(serviceName, serviceType));
        }
    }
}
