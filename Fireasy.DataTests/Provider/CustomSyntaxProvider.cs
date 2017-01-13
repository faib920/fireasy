// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using Fireasy.Data.Syntax;

namespace Fireasy.Data.Provider.Test
{
    public class CustomSyntaxProvider : ISyntaxProvider
    {
        public StringSyntax String
        {
            get { throw new NotImplementedException(); }
        }

        public DateTimeSyntax DateTime
        {
            get { throw new NotImplementedException(); }
        }

        public MathSyntax Math
        {
            get { throw new NotImplementedException(); }
        }

        public string IdentitySelect
        {
            get { throw new NotImplementedException(); }
        }

        public string IdentityColumn
        {
            get { throw new NotImplementedException(); }
        }

        public string FakeSelect
        {
            get { throw new NotImplementedException(); }
        }

        public string ParameterPrefix
        {
            get { throw new NotImplementedException(); }
        }

        public string[] Quote
        {
            get { throw new NotImplementedException(); }
        }

        public string Linefeed
        {
            get { throw new NotImplementedException(); }
        }

        public bool SupportDistinctInAggregates
        {
            get { throw new NotImplementedException(); }
        }

        public string Segment(string commandText, IDataSegment segment)
        {
            throw new NotImplementedException();
        }

        public string Segment(CommandContext context)
        {
            throw new NotImplementedException();
        }

        public string Convert(object sourceExp, System.Data.DbType dbType)
        {
            throw new NotImplementedException();
        }

        public string Column(System.Data.DbType dbType, int? length = null, int? precision = null, int? scale = null)
        {
            throw new NotImplementedException();
        }

        public string Coalesce(object sourceExp, params object[] argExps)
        {
            throw new NotImplementedException();
        }

        public string FormatParameter(string parameterName)
        {
            throw new NotImplementedException();
        }

        public string ExistsTable(string tableName)
        {
            throw new NotImplementedException();
        }


        public System.Data.DbType CorrectDbType(System.Data.DbType dbType)
        {
            throw new NotImplementedException();
        }


        public string RowsAffected
        {
            get { throw new NotImplementedException(); }
        }

        public bool SupportSubqueryInSelectWithoutFrom
        {
            get { throw new NotImplementedException(); }
        }
    }
}
