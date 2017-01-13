// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Fireasy.Data.Batcher;

namespace Fireasy.Data.Provider.Test
{
    public class CustomBatcherProvider : IBatcherProvider
    {
        public void Insert(IDatabase database, System.Data.DataTable dataTable, int batchSize = 1000, Action<int> completePercentage = null)
        {
            throw new NotImplementedException();
        }

        public void Insert<T>(IDatabase database, IEnumerable<T> list, string tableName, int batchSize = 1000, Action<int> completePercentage = null)
        {
            throw new NotImplementedException();
        }
    }
}
