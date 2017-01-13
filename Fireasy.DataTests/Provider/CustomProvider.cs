// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Fireasy.Data.Extensions;

namespace Fireasy.Data.Provider.Test
{
    public class CustomProvider : IProvider
    {
        public System.Data.Common.DbProviderFactory DbProviderFactory
        {
            get;
            private set;
        }

        public string DbName
        {
            get { return string.Empty; }
        }

        public ConnectionParameter GetConnectionParameter(ConnectionString connectionString)
        {
            throw new NotImplementedException();
        }

        public TProvider GetService<TProvider>() where TProvider : class, IProviderService
        {
            return ProviderExtension.GetService<TProvider>(this);
        }

        public IEnumerable<IProviderService> GetServices()
        {
            return ProviderExtension.GetServices(this);
        }

        string IProvider.DbName
        {
            get { throw new NotImplementedException(); }
        }

        System.Data.Common.DbProviderFactory IProvider.DbProviderFactory
        {
            get { throw new NotImplementedException(); }
        }

        ConnectionParameter IProvider.GetConnectionParameter(ConnectionString connectionString)
        {
            throw new NotImplementedException();
        }

        TProvider IProvider.GetService<TProvider>()
        {
            throw new NotImplementedException();
        }

        IEnumerable<IProviderService> IProvider.GetServices()
        {
            throw new NotImplementedException();
        }


        public string UpdateConnectionString(ConnectionString connectionString, ConnectionParameter parameter)
        {
            throw new NotImplementedException();
        }
    }
}
