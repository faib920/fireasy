// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common;
using Fireasy.Data.Entity.Linq;
using Fireasy.Data.Entity.Linq.Translators;
using Fireasy.Data.Entity.Test.Model;
using Fireasy.Data.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Fireasy.Data.Entity.Test
{
    [TestClass()]
    public class TranslationTests : DbTestBase
    {
        private const string Var1 = "lon";

        private EntityPersister<Customers> m_Customers;
        private EntityPersister<Orders> m_order;
        private EntityPersister<Products> m_products;
        private EntityPersister<OrderDetails> m_details;

        public QuerySet<Customers> Customers
        {
            get
            {
                if (m_Customers == null)
                {
                    m_Customers = new EntityPersister<Customers>(instanceName);
                }

                return m_Customers.Query();
            }
        }

        public QuerySet<Orders> Orders
        {
            get
            {
                if (m_order == null)
                {
                    m_order = new EntityPersister<Orders>(instanceName);
                }

                return m_order.Query();
            }
        }

        public QuerySet<Products> Products
        {
            get
            {
                if (m_products == null)
                {
                    m_products = new EntityPersister<Products>(instanceName);
                }

                return m_products.Query();
            }
        }

        public QuerySet<OrderDetails> Details
        {
            get
            {
                if (m_details == null)
                {
                    m_details = new EntityPersister<OrderDetails>(instanceName);
                }

                return m_details.Query();
            }
        }

        private void TestQuery(IQueryable q)
        {
            Console.WriteLine(TimeWatcher.Watch(() =>
                {
                    var result = (q.Provider as ITranslateSupport).Translate(q.Expression);
                    var queryText = result.QueryText;

                    foreach (Parameter par in result.Parameters)
                    {
                        queryText += "\r\n-- " + par.ParameterName + "=" + par.Value;
                    }

                    Console.WriteLine(queryText);
#if Q
                    var r = q.GetEnumerator();
                    while (r.MoveNext())
                    {
                    }
#endif
                }));
        }

        private void TestQuery(Expression<Func<object>> query)
        {
            Console.WriteLine(TimeWatcher.Watch(() =>
                {
                    var exp = query.Body;
                    if (exp.NodeType == ExpressionType.Convert &&
                        exp.Type == typeof(object))
                    {
                        exp = ((UnaryExpression)exp).Operand;
                    }

                    using (var database = DatabaseFactory.CreateDatabase(instanceName))
                    {
                        var enq = new EntityQueryProvider(database);
                        var result = enq.Translate(exp);
                        var queryText = result.QueryText;
                        if (result.DataSegment != null)
                        {
                            queryText = database.Provider.GetService<ISyntaxProvider>().Segment(queryText, result.DataSegment);
                        }

                        foreach (Parameter par in result.Parameters)
                        {
                            queryText += "\r\n-- " + par;
                        }
                        Console.WriteLine(queryText);

    #if Q
                        Console.WriteLine(enq.Execute(exp));
    #endif
                    }
                }));
        }

        [TestMethod()]
        public void TestWhere()
        {
            TestQuery(Customers.Where(c => c.City == "London"));
        }

        [TestMethod()]
        public void TestWhereStrings()
        {
            TestQuery(Customers.Where(c => c.City == new string('a', 10)));
        }

        [TestMethod()]
        public void TestWhereVar()
        {
            var par = "London";
            TestQuery(Customers.Where(c => c.City == par));
        }

        [TestMethod()]
        public void TestWhereVar1()
        {
            TestQuery(Customers.Where(c => c.City == Var1));
        }

        [TestMethod()]
        public void TestWhereVar2()
        {
            var par = new Customers { City = "dfafd" };
            TestQuery(Customers.Where(c => c.City == par.City));
        }

        [TestMethod()]
        public void TestWhereVar3()
        {
            TestQuery(Customers.Where(c => c.City == new Customers { City = "dfafd" }.City));
        }

        [TestMethod()]
        public void TestWhereVar4()
        {
            var id = 55;
            TestQuery(Products.Where(c => c.CategoryID == id));
        }

        [TestMethod()]
        public void TestWhereSum()
        {
            TestQuery(Customers.Where(c => c.Orderses.Sum(s => s.OrderID) > 1000));
        }

        [TestMethod()]
        public void TestWhereCount()
        {
            TestQuery(
                from c in Customers
                where Orders.Count() > 100
                select c
                );
        }

        [TestMethod()]
        public void TestWhereTrue()
        {
            TestQuery(Customers.Where(c => true));
        }

        [TestMethod()]
        public void TestWhereFalse()
        {
            TestQuery(Customers.Where(c => false));
        }

        [TestMethod()]
        public void TestSelectScalar()
        {
            TestQuery(Customers.Select(c => c.City));
        }

        [TestMethod()]
        public void TestSelectAnonymousOne()
        {
            TestQuery(Customers.Select(c => new { c.City }));
        }

        [TestMethod()]
        public void TestSelectAnonymousFunc()
        {
            TestQuery(Customers.Select(c => new { Country1 = c.Country, A = c.City.Length, B = c.City.Substring(0, 10) + c.Address }));
        }

        [TestMethod()]
        public void TestSelectAnonymousTwo()
        {
            TestQuery(Customers.Select(c => new { A = c.City, B = c.Phone }));
        }

        [TestMethod()]
        public void TestSelectAnonymousThree()
        {
            TestQuery(Customers.Select(c => new { c.City, c.Phone, c.Country }));
        }

        [TestMethod()]
        public void TestSelectCustomersTable()
        {
            TestQuery(Customers);
        }

        [TestMethod()]
        public void TestSelectCustomeridentity()
        {
            TestQuery(Customers.Select(c => c));
        }

        [TestMethod()]
        public void TestSelectAnonymousWithObject()
        {
            TestQuery(Customers.Select(c => new { c.City, c }));
        }

        [TestMethod()]
        public void TestSelectAnonymousNested()
        {
            TestQuery(Customers.Select(c => new { c.City, Country = new { c.Country } }));
        }

        [TestMethod()]
        public void TestSelectAnonymousEmpty()
        {
            TestQuery(Customers.Select(c => new { }));
        }

        [TestMethod()]
        public void TestSelectAnonymousLiteral()
        {
            TestQuery(Customers.Select(c => new { c.Address, X = 10 }));
        }

        [TestMethod()]
        public void TestSelectConstantInt()
        {
            TestQuery(Customers.Select(c => 0));
        }

        [TestMethod()]
        public void TestSelectConstantNullString()
        {
            TestQuery(Customers.Select(c => (string)null));
        }

        [TestMethod()]
        public void TestSelectLocal()
        {
            int x = 10;
            TestQuery(Customers.Select(c => x));
        }

        [TestMethod()]
        public void TestSelectNestedCollection()
        {
            TestQuery(
                from c in Customers
                where c.CustomerID == "ALFKI"
                select Orders.Where(o => o.CustomerID == c.CustomerID && o.OrderDate.Value.Year == 1997).Select(o => o.OrderID)
                );
        }

        [TestMethod()]
        public void TestSelectNestedCollectionInAnonymousType()
        {
            TestQuery(
                from c in Customers
                where c.CustomerID == "ALFKI"
                select new { Foos = Orders.Where(o => o.CustomerID == c.CustomerID && o.OrderDate.Value.Year == 1997).Select(o => o.OrderID) }
                );
        }

        [TestMethod()]
        public void TestJoinCustomersOrderss()
        {
            TestQuery(
                from c in Customers
                join o in Orders on c.CustomerID equals o.CustomerID
                select new { Contactname = c.ContactName, Orderid = o.OrderID }
                );
        }

        [TestMethod()]
        public void TestJoinLeft()
        {
            TestQuery(
                from c in Customers
                join o in Orders.DefaultIfEmpty() on c.CustomerID equals o.CustomerID
                select new { Contactname = c.ContactName, Orderid = o.OrderID }
                );
        }

        [TestMethod()]
        public void TestJoinLeft1()
        {
            TestQuery(
                from c in Customers
                join o in Orders on c.CustomerID equals o.CustomerID into o1
                from o11 in o1.DefaultIfEmpty()
                join t in Details on o11.OrderID equals t.OrderID into t1
                from t11 in t1.DefaultIfEmpty()
                select new { Contactname = c.ContactName, Orderid = o11.OrderID, Productid = t11.ProductID }
                );
        }

        [TestMethod()]
        public void TestJoinLeft2()
        {
            TestQuery(
                from c in Customers
                join o in Orders.DefaultIfEmpty() on c.CustomerID equals o.CustomerID
                join t in Details.DefaultIfEmpty() on o.OrderID equals t.OrderID
                select new { Contactname = c.ContactName, Orderid = o.OrderID, Productid = t.ProductID }
                );
        }

        [TestMethod()]
        public void TestJoinRight()
        {
            TestQuery(
                from c in Customers.DefaultIfEmpty()
                join o in Orders on c.CustomerID equals o.CustomerID
                select new { Contactname = c.ContactName, Orderid = o.OrderID }
                );
        }

        [TestMethod()]
        public void TestJoinCustomersByColumn()
        {
            TestQuery(
                from c in Customers
                join o in Orders on c.CustomerID equals o.CustomerID
                select new { CustomersPhone = c.Phone }
                );
        }

        [TestMethod()]
        public void TestSelectManyCustomersOrderss()
        {
            TestQuery(
                from c in Customers
                from o in Orders
                where c.CustomerID == o.CustomerID
                select new { Contactname = c.ContactName, Orderid = o.OrderID }
                );
        }

        [TestMethod()]
        public void TestOrderBy()
        {
            TestQuery(
                Customers.OrderBy(c => c.CustomerID)
                );
        }

        [TestMethod()]
        public void TestOrderLinqBy()
        {
            TestQuery(
                Customers.OrderBy("Customerid").ThenBy("Address", SortOrder.Ascending)
                );
        }

        [TestMethod()]
        public void TestOrderBySelect()
        {
            TestQuery(
                Customers.OrderBy(c => c.CustomerID).Select(c => c.ContactName)
                );
        }

        [TestMethod()]
        public void TestOrderBySelectSingle()
        {
            TestQuery(
                () => Customers.OrderBy(c => c.CustomerID).Select(c => c.ContactName).FirstOrDefault()
                );
        }

        [TestMethod()]
        public void TestOrderByOrderBy()
        {
            TestQuery(
                Customers.OrderBy(c => c.CustomerID).OrderBy(c => c.Country).Select(c => c.City)
                );
        }

        [TestMethod()]
        public void TestOrderByThenBy()
        {
            TestQuery(
                Customers.OrderBy(c => c.CustomerID).ThenBy(c => c.Country).Select(c => c.City)
                );
        }

        [TestMethod()]
        public void TestOrderByMutil()
        {
            TestQuery(
                Customers.OrderBy(c => new { Customerid = c.CustomerID, Companyname = c.CompanyName })
                );
        }

        [TestMethod()]
        public void TestOrderByThenByMutil()
        {
            TestQuery(
                Customers.OrderBy(c => c.Fax).ThenBy(c => new { Customerid = c.CustomerID, Companyname = c.CompanyName })
                );
        }

        [TestMethod()]
        public void TestOrderByMutilJoin()
        {
            TestQuery(
                Orders.OrderBy(c => new { Orderid = c.OrderID, Customerid = c.Customers.CustomerID })
                );
        }

        [TestMethod()]
        public void TestOrderByMutilDescending()
        {
            TestQuery(
                Customers.OrderByDescending(c => new { Customerid = c.CustomerID, Companyname = c.CompanyName })
                );
        }

        [TestMethod()]
        public void TestOrderByDescending()
        {
            TestQuery(
                Customers.OrderByDescending(c => c.CustomerID).Select(c => c.City)
                );
        }

        [TestMethod()]
        public void TestOrderByDescendingThenBy()
        {
            TestQuery(
                Customers.OrderByDescending(c => c.CustomerID).ThenBy(c => c.Country).Select(c => c.City)
                );
        }

        [TestMethod()]
        public void TestOrderByDescendingThenByDescending()
        {
            TestQuery(
                Customers.OrderByDescending(c => c.CustomerID).ThenByDescending(c => c.Country).Select(c => c.City)
                );
        }

        [TestMethod()]
        public void TestOrderByJoin()
        {
            TestQuery(
                from c in Customers.OrderBy(c => c.CustomerID)
                join o in Orders.OrderBy(o => o.OrderID) on c.CustomerID equals o.CustomerID
                select new { Customerid = c.CustomerID, Orderid = o.OrderID }
                );
        }

        [TestMethod()]
        public void TestOrderBySelectMany()
        {
            TestQuery(
                from c in Customers.OrderBy(c => c.CustomerID)
                from o in Orders.OrderBy(o => o.OrderID)
                where c.CustomerID == o.CustomerID
                select new { Contactname = c.ContactName, Orderid = o.OrderID }
                );

        }

        [TestMethod()]
        public void TestGroupBy()
        {
            TestQuery(
                Customers.GroupBy(c => c.City)
                );
        }

        [TestMethod()]
        public void TestGroupBySelectMany()
        {
            TestQuery(
                Customers.GroupBy(c => c.City).SelectMany(g => g)
                );
        }

        [TestMethod()]
        public void TestGroupBySum()
        {
            TestQuery(
                Orders.GroupBy(o => o.CustomerID).Select(g => g.Sum(o => o.OrderID))
                );
        }

        [TestMethod()]
        public void TestGroupByCount()
        {
            TestQuery(
                Orders.GroupBy(o => o.CustomerID).Select(g => g.Count())
                );
        }

        [TestMethod()]
        public void TestGroupBySumMinMaxAvg()
        {
            TestQuery(
                Orders.GroupBy(o => o.CustomerID).Select(g =>
                    new
                    {
                        Sum = g.Sum(o => o.OrderID),
                        Min = g.Min(o => o.OrderID),
                        Max = g.Max(o => o.OrderID),
                        Avg = g.Average(o => o.OrderID)
                    })
                );
        }

        [TestMethod()]
        public void TestGroupByWithResultSelector()
        {
            TestQuery(
                Orders.GroupBy(o => o.CustomerID, (k, g) =>
                    new
                    {
                        Sum = g.Sum(o => o.OrderID),
                        Min = g.Min(o => o.OrderID),
                        Max = g.Max(o => o.OrderID),
                        Avg = g.Average(o => o.OrderID)
                    })
                );
        }

        [TestMethod()]
        public void TestGroupByWithElementSelectorSum()
        {
            TestQuery(
                Orders.GroupBy(o => o.CustomerID, o => o.OrderID).Select(g => g.Sum())
                );
        }

        [TestMethod()]
        public void TestGroupByWithElementSelector()
        {
            // note: groups are retrieved through a separately execute subquery per row
            TestQuery(
                Orders.GroupBy(o => o.CustomerID, o => o.OrderID)
                );
        }

        [TestMethod()]
        public void TestGroupByWithElementSelectorSumMax()
        {
            TestQuery(
                Orders.GroupBy(o => o.CustomerID, o => o.OrderID).Select(g => new { Sum = g.Sum(), Max = g.Max() })
                );
        }

        [TestMethod()]
        public void TestGroupByWithAnonymousElement()
        {
            TestQuery(
                Orders.GroupBy(o => o.CustomerID, o => new { Orderid = o.OrderID }).Select(g => g.Sum(x => x.Orderid))
                );
        }

        [TestMethod()]
        public void TestGroupByWithTwoPartKey()
        {
            TestQuery(
                Orders.GroupBy(o => new { Customerid = o.CustomerID, Orderdate = o.OrderDate }).Select(g => g.Sum(o => o.OrderID))
                );
        }

        [TestMethod()]
        public void TestOrderByGroupBy()
        {
            // note: order-by is lost when group-by is applied (the sequence of groups is not ordered)
            TestQuery(
                Orders.OrderBy(o => o.OrderID).GroupBy(o => o.CustomerID).Select(g => g.Sum(o => o.OrderID))
                );
        }

        [TestMethod()]
        public void TestOrderByGroupBySelectMany()
        {
            // note: order-by is preserved within grouped sub-collections
            TestQuery(
                Orders.OrderBy(o => o.OrderID).GroupBy(o => o.CustomerID).SelectMany(g => g)
                );
        }

        [TestMethod()]
        public void TestSumWithNoArg()
        {
            TestQuery(
                () => Orders.Select(o => o.OrderID).Sum()
                );
        }

        [TestMethod()]
        public void TestSumWithArg()
        {
            TestQuery(
                () => Orders.Sum(o => o.OrderID)
                );
        }

        [TestMethod()]
        public void TestSumComplex()
        {
            TestQuery(
                () => Orders.Select(s => new { CompanyName = s.Customers.CompanyName, Sum = s.OrderDetailses.Sum(t => t.UnitPrice) })
                );
        }

        [TestMethod()]
        public void TestCountWithNoPredicate()
        {
            TestQuery(
                () => Orders.Count()
                );
        }

        [TestMethod()]
        public void TestCountWithPredicate()
        {
            TestQuery(
                () => Orders.Count(o => o.CustomerID == "ALFKI")
                );
        }

        [TestMethod()]
        public void TestDistinct()
        {
            TestQuery(
                Customers.Distinct()
                );
        }

        [TestMethod()]
        public void TestDistinctScalar()
        {
            TestQuery(
                Customers.Select(c => c.City).Distinct()
                );
        }

        [TestMethod()]
        public void TestOrderByDistinct()
        {
            TestQuery(
                Customers.OrderBy(c => c.CustomerID).Select(c => c.City).Distinct()
                );
        }

        [TestMethod()]
        public void TestDistinctOrderBy()
        {
            TestQuery(
                Customers.Select(c => c.City).Distinct().OrderBy(c => c)
                );
        }

        [TestMethod()]
        public void TestDistinctGroupBy()
        {
            TestQuery(
                Orders.Distinct().GroupBy(o => o.CustomerID)
                );
        }

        [TestMethod()]
        public void TestGroupByDistinct()
        {
            TestQuery(
                Orders.GroupBy(o => o.CustomerID).Distinct()
                );

        }

        [TestMethod()]
        public void TestDistinctCount()
        {
            TestQuery(
                () => Customers.Distinct().Count()
                );
        }

        [TestMethod()]
        public void TestSelectDistinctCount()
        {
            // cannot do: SELECT COUNT(DISTINCT some-colum) FROM some-table
            // because COUNT(DISTINCT some-column) does not count nulls
            TestQuery(
                () => Customers.Select(c => c.City).Distinct().Count()
                );
        }

        [TestMethod()]
        public void TestSelectSelectDistinctCount()
        {
            TestQuery(
                () => Customers.Select(c => c.City).Select(c => c).Distinct().Count()
                );
        }

        [TestMethod()]
        public void TestDistinctCountPredicate()
        {
            TestQuery(
                () => Customers.Distinct().Count(c => c.CustomerID == "ALFKI")
                );
        }

        [TestMethod()]
        public void TestDistinctSumWithArg()
        {
            TestQuery(
                () => Orders.Distinct().Sum(o => o.OrderID)
                );
        }

        [TestMethod()]
        public void TestSelectDistinctSum()
        {
            TestQuery(
                () => Orders.Select(o => o.OrderID).Distinct().Sum()
                );
        }

        [TestMethod()]
        public void TestTake()
        {
            TestQuery(
                Orders.Take(5)
                );
        }

        [TestMethod()]
        public void TestTakeDistinct()
        {
            // distinct must be forced to apply after top has been computed
            TestQuery(
                Orders.Take(5).Distinct()
                );
        }

        [TestMethod()]
        public void TestDistinctTake()
        {
            // top must be forced to apply after distinct has been computed
            TestQuery(
                Orders.Distinct().Take(5)
                );
        }

        [TestMethod()]
        public void TestDistinctTakeCount()
        {
            TestQuery(
                () => Orders.Distinct().Take(5).Count()
                );
        }

        [TestMethod()]
        public void TestTakeDistinctCount()
        {
            TestQuery(
                () => Orders.Take(5).Distinct().Count()
                );
        }

        [TestMethod()]
        public void TestSkip()
        {
            TestQuery(
                Customers.OrderBy(c => c.ContactName).Skip(5)
                );
        }

        [TestMethod()]
        public void TestSkipTake()
        {
            TestQuery(
                Customers.OrderBy(c => c.ContactName).Skip(5).Take(10)
                );
        }

        [TestMethod()]
        public void TestTakeSkip()
        {
            TestQuery(
                Customers.OrderBy(c => c.ContactName).Take(10).Skip(5)
                );
        }

        [TestMethod()]
        public void TestSkipDistinct()
        {
            TestQuery(
                Customers.OrderBy(c => c.ContactName).Skip(5).Distinct()
                );
        }

        [TestMethod()]
        public void TestDistinctSkip()
        {
            TestQuery(
                Customers.Distinct().OrderBy(c => c.ContactName).Skip(5)
                );
        }

        [TestMethod()]
        public void TestSkipTakeDistinct()
        {
            TestQuery(
                Customers.OrderBy(c => c.ContactName).Skip(5).Take(10).Distinct()
                );
        }

        [TestMethod()]
        public void TestTakeSkipDistinct()
        {
            TestQuery(
                Customers.OrderBy(c => c.ContactName).Take(10).Skip(5).Distinct()
                );
        }

        [TestMethod()]
        public void TestDistinctSkipTake()
        {
            TestQuery(
                Customers.Distinct().OrderBy(c => c.ContactName).Skip(5).Take(10)
                );
        }


        [TestMethod()]
        public void TestFirst()
        {
            TestQuery(
                () => Customers.First()
                );
        }

        [TestMethod()]
        public void TestFirstPredicate()
        {
            TestQuery(
                () => Customers.First(c => c.CustomerID == "ALFKI")
                );
        }

        [TestMethod()]
        public void TestWhereFirst()
        {
            TestQuery(
                () => Customers.Where(c => c.CustomerID == "ALFKI").First()
                );
        }

        [TestMethod()]
        public void TestFirstOrDefault()
        {
            TestQuery(
                () => Customers.FirstOrDefault()
                );
        }

        [TestMethod()]
        public void TestFirstOrDefaultPredicate()
        {
            TestQuery(
                () => Customers.FirstOrDefault(c => c.CustomerID == "ALFKI")
                );
        }

        [TestMethod()]
        public void TestWhereFirstOrDefault()
        {
            TestQuery(
                () => Customers.Where(c => c.CustomerID == "ALFKI").FirstOrDefault()
                );
        }

        [TestMethod()]
        public void TestSegment()
        {
            var pager = new DataPager(10);
            TestQuery(
                () => Customers.OrderBy(s => s.City).Segment(pager)
                );
        }

        [TestMethod()]
        public void TestSingle()
        {
            TestQuery(
                () => Customers.Single()
                );
        }

        [TestMethod()]
        public void TestSinglePredicate()
        {
            TestQuery(
                () => Customers.Single(c => c.CustomerID == "ALFKI")
                );
        }

        [TestMethod()]
        public void TestWhereSingle()
        {
            TestQuery(
                () => Customers.Where(c => c.CustomerID == "ALFKI").Single()
                );
        }

        [TestMethod()]
        public void TestSingleOrDefault()
        {
            TestQuery(
                () => Customers.SingleOrDefault()
                );
        }

        [TestMethod()]
        public void TestSingleOrDefaultPredicate()
        {
            TestQuery(
                () => Customers.SingleOrDefault(c => c.CustomerID == "ALFKI")
                );
        }

        [TestMethod()]
        public void TestWhereSingleOrDefault()
        {
            TestQuery(
                () => Customers.Where(c => c.CustomerID == "ALFKI").SingleOrDefault()
                );
        }

        [TestMethod()]
        public void TestAnyWithSubquery()
        {
            TestQuery(
                Customers.Where(c => Orders.Where(o => o.CustomerID == c.CustomerID).Any(o => o.OrderDate.Value.Year == 1997))
                );
        }

        [TestMethod()]
        public void TestAnyWithSubqueryNoPredicate()
        {
            TestQuery(
                Customers.Where(c => Orders.Where(o => o.CustomerID == c.CustomerID).Any())
                );
        }

        [TestMethod()]
        public void TestAnyWithLocalCollection()
        {
            string[] ids = new[] { "ABCDE", "ALFKI" };
            TestQuery(
                Customers.Where(c => ids.Any(id => c.CustomerID == id))
                );
        }

        [TestMethod()]
        public void TestAnyTopLevel()
        {
            TestQuery(
                () => Customers.Any()
                );
        }

        [TestMethod()]
        public void TestAllWithSubquery()
        {
            TestQuery(
                Customers.Where(c => Orders.Where(o => o.CustomerID == c.CustomerID).All(o => o.OrderDate.Value.Year == 1997))
                );
        }

        [TestMethod()]
        public void TestAllWithLocalCollection()
        {
            string[] patterns = new[] { "a", "e" };

            TestQuery(
                Customers.Where(c => patterns.All(p => c.ContactName.Contains(p)))
                );
            TestQuery(
                Customers.BatchAnd(patterns, (c, p) => c.CompanyName.Contains(p))
                );
        }

        [TestMethod()]
        public void TestAllTopLevel()
        {
            TestQuery(
                () => Customers.All(c => c.ContactName.StartsWith("a"))
                );
        }

        [TestMethod()]
        public void TestContainsWithSubquery()
        {
            TestQuery(
                Customers.Where(c => Orders.Select(o => o.CustomerID).Contains(c.CustomerID))
                );
        }

        [TestMethod()]
        public void TestContainsWithSubquery1()
        {
            TestQuery(
                Customers.Where(c => Orders
                    .Where(v => Products.Select(p => p.ProductName).Contains(v.CustomerID))
                    .Select(o => o.CustomerID)
                    .Contains(c.CustomerID))
            );
        }

        [TestMethod()]
        public void TestContainsWithOutquery1()
        {
            var products = Products.Select(p => p.ProductName);
            var orders = Orders.Where(v => products.Contains(v.CustomerID)).Select(o => o.CustomerID);
            TestQuery(
                Customers.Where(c => orders.Contains(c.CustomerID))
                );
        }

        [TestMethod()]
        public void TestContainsWithOutquery()
        {
            var ss = Orders.Select(o => o.CustomerID);
            TestQuery(
                Customers.Where(c => ss.Contains(c.CustomerID))
                );
        }

        [TestMethod()]
        public void TestContainsWithLocalCollection()
        {
            string[] ids = new[] { "ABCDE", "ALFKI" };
            TestQuery(
                Customers.Where(c => ids.Contains(c.CustomerID))
                );
        }

        [TestMethod()]
        public void TestContainsTopLevel()
        {
            TestQuery(
                () => Customers.Select(c => c.CustomerID).Contains("ALFKI")
                );
        }

        // framework function tests

        [TestMethod()]
        public void TestStringLength()
        {
            TestQuery(Customers.Where(c => c.City.Length == 7));
        }

        [TestMethod()]
        public void TestStringStartsWithLiteral()
        {
            TestQuery(Customers.Where(c => c.ContactName.StartsWith("M")));
        }

        [TestMethod()]
        public void TestStringStartsWithColumn()
        {
            TestQuery(Customers.Where(c => c.ContactName.StartsWith(c.ContactName)));
        }

        [TestMethod()]
        public void TestStringEndsWithLiteral()
        {
            TestQuery(Customers.Where(c => c.ContactName.EndsWith("s")));
        }

        [TestMethod()]
        public void TestStringEndsWithColumn()
        {
            TestQuery(Customers.Where(c => c.ContactName.EndsWith(c.ContactName)));
        }

        [TestMethod()]
        public void TestStringContainsLiteral()
        {
            TestQuery(Customers.Where(c => c.ContactName.Contains("and")));
        }

        [TestMethod()]
        public void TestStringContainsColumn()
        {
            TestQuery(Customers.Where(c => c.ContactName.Contains(c.ContactName)));
        }

        [TestMethod()]
        public void TestStringConcatImplicit2Args()
        {
            TestQuery(Customers.Where(c => c.ContactName + "X" == "X"));
        }

        [TestMethod()]
        public void TestStringConcatExplicit2Args()
        {
            TestQuery(Customers.Where(c => string.Concat(c.ContactName, "X") == "X"));
        }

        [TestMethod()]
        public void TestStringConcatExplicit3Args()
        {
            TestQuery(Customers.Where(c => string.Concat(c.ContactName, "X", c.Country) == "X"));
        }

        [TestMethod()]
        public void TestStringConcatExplicitNArgs()
        {
            TestQuery(Customers.Where(c => string.Concat(new string[] { c.ContactName, "X", c.Country }) == "X"));
        }

        [TestMethod()]
        public void TestStringIsNullOrEmpty()
        {
            TestQuery(Customers.Where(c => string.IsNullOrEmpty(c.City)));
        }

        [TestMethod()]
        public void TestStringToUpper()
        {
            TestQuery(Customers.Where(c => c.City.ToUpper() == "SEATTLE"));
        }

        [TestMethod()]
        public void TestStringToLower()
        {
            TestQuery(Customers.Where(c => c.City.ToLower() == "seattle"));
        }

        [TestMethod()]
        public void TestStringReplace()
        {
            TestQuery(Customers.Where(c => c.City.Replace("ea", "ae") == "Saettle"));
        }

        [TestMethod()]
        public void TestStringReplaceChars()
        {
            TestQuery(Customers.Where(c => c.City.Replace("e", "y") == "Syattly"));
        }

        [TestMethod()]
        public void TestStringSubstring()
        {
            TestQuery(Customers.Where(c => c.City.Substring(0, 4) == "Seat"));
        }

        [TestMethod()]
        public void TestStringSubstringNest()
        {
            TestQuery(Customers.Where(c => c.City.Substring(0, c.City.Length + 6) == "Seat"));
        }

        [TestMethod()]
        public void TestStringSubstringNoLength()
        {
            TestQuery(Customers.Where(c => c.City.Substring(4) == "tle"));
        }

        [TestMethod()]
        public void TestStringRemove()
        {
            TestQuery(Customers.Where(c => c.City.Remove(1, 2) == "Sttle"));
        }

        [TestMethod()]
        public void TestStringRemoveNoCount()
        {
            TestQuery(Customers.Where(c => c.City.Remove(4) == "Seat"));
        }

        [TestMethod()]
        public void TestStringIndexOf()
        {
            TestQuery(Customers.Where(c => c.City.IndexOf("tt") == 4));
        }

        [TestMethod()]
        public void TestStringIndexOfChar()
        {
            TestQuery(Customers.Where(c => c.City.IndexOf('t') == 4));
        }

        [TestMethod()]
        public void TestStringTrim()
        {
            TestQuery(Customers.Where(c => c.City.Trim() == "Seattle"));
        }

        [TestMethod()]
        public void TestStringToString()
        {
            TestQuery(Customers.Where(c => c.City.ToString() == "Seattle"));
        }

        [TestMethod()]
        public void TestParseDecimal()
        {
            TestQuery(Customers.Where(c => decimal.Parse(c.CustomerID) == 56));
        }

        [TestMethod()]
        public void TestParseDateTime()
        {
            TestQuery(Customers.Where(c => DateTime.Parse(c.City) == DateTime.Now));
        }

        [TestMethod()]
        public void TestParseInt32()
        {
            TestQuery(Customers.Where(c => int.Parse(c.CustomerID) == 44));
        }

        [TestMethod()]
        public void TestConvertInt32()
        {
            TestQuery(Products.Where(c => Convert.ToInt32(c.ProductID) == 44));
        }

        [TestMethod()]
        public void TestChangeType()
        {
            TestQuery(Products.Where(c => (int)Convert.ChangeType(c.ProductID, typeof(int)) == 44));
        }

        [TestMethod()]
        public void TestChangeType1()
        {
            TestQuery(Products.Where(c => (int)Convert.ChangeType(c.ProductID, TypeCode.Int32) == 44));
        }

        [TestMethod()]
        public void TestRegexIsMatch()
        {
            //TestQuery(Products.Where(c => Regex.IsMatch(c.ProductName, @"\d+")));
            //TestQuery(Products.Where(c => Regex.IsMatch("aa", c.ProductName)));
        }

        [TestMethod()]
        public void TestDateTimeConstructYMD()
        {
            TestQuery(Orders.Where(o => o.OrderDate == new DateTime(o.OrderDate.Value.Year, 1, 1)));
        }

        [TestMethod()]
        public void TestDateTimeConstructYMD1()
        {
            TestQuery(Orders.Where(o => o.OrderDate == new DateTime(o.OrderDate.Value.Year, o.OrderDate.Value.Month, 1)));
        }

        [TestMethod()]
        public void TestDateTimeConstructYMD2()
        {
            TestQuery(Orders.Where(o => o.OrderDate == new DateTime(2009, o.OrderDate.Value.Month, 1)));
        }

        //public void TestDateTimeConstructYMDHMS()
        //{
        //    TestQuery(Orderss.Where(o => o.Orderdate == new DateTime(o.Orderdate.Value.Year, 1, 1, 10, 25, 55)));
        //}

        [TestMethod()]
        public void TestDateTimeConstruct()
        {
            TestQuery(Orders.Where(o => o.OrderDate == new DateTime(2007, 1, 1)));
        }

        [TestMethod()]
        public void TestDateTimeNow()
        {
            TestQuery(Orders.Where(o => o.OrderDate == DateTime.Now));
        }

        [TestMethod()]
        public void TestDateTimeParse()
        {
            TestQuery(Orders.Where(o => o.OrderDate == DateTime.Parse("2009-4-5")));
        }

        [TestMethod()]
        public void TestDateTimeParse1()
        {
            TestQuery(Orders.Select(s => DateTime.Parse(s.ShipCity)));
        }

        [TestMethod()]
        public void TestDateTimeMax()
        {
            TestQuery(Orders.Where(o => o.OrderDate == DateTime.MaxValue));
        }

        [TestMethod()]
        public void TestDateTimeDay()
        {
            TestQuery(Orders.Where(o => o.OrderDate.Value.Day == 5));
        }

        [TestMethod()]
        public void TestDateTimeMonth()
        {
            TestQuery(Orders.Where(o => o.OrderDate.Value.Month == 12));
        }

        [TestMethod()]
        public void TestDateTimeYear()
        {
            TestQuery(Orders.Where(o => o.OrderDate.Value.Year == 1997));
        }

        [TestMethod()]
        public void TestDateTimeHour()
        {
            TestQuery(Orders.Where(o => o.OrderDate.Value.Hour == 6));
        }

        [TestMethod()]
        public void TestDateTimeMinute()
        {
            TestQuery(Orders.Where(o => o.OrderDate.Value.Minute == 32));
        }

        [TestMethod()]
        public void TestDateTimeSecond()
        {
            TestQuery(Orders.Where(o => o.OrderDate.Value.Second == 47));
        }

        [TestMethod()]
        public void TestDateTimeMillisecond()
        {
            TestQuery(Orders.Where(o => o.OrderDate.Value.Millisecond == 200));
        }

        [TestMethod()]
        public void TestDateTimeToShortTimeString()
        {
            TestQuery(Orders.Where(s => s.OrderDate.Value.ToShortTimeString() == ""));
        }

        [TestMethod()]
        public void TestDateTimeDiff()
        {
            TestQuery(Orders.Select(s => s.OrderDate.Value - s.RequiredDate));
        }

        [TestMethod()]
        public void TestDateTimeDayOfWeek()
        {
            TestQuery(Orders.Where(o => o.OrderDate.Value.DayOfWeek == DayOfWeek.Friday));
        }

        [TestMethod()]
        public void TestDateTimeDayOfYear()
        {
            TestQuery(Orders.Where(o => o.OrderDate.Value.DayOfYear == 360));
        }

        [TestMethod()]
        public void TestMathAbs()
        {
            TestQuery(Orders.Where(o => Math.Abs(o.OrderID) == 10));
        }

        [TestMethod()]
        public void TestMathAcos()
        {
            TestQuery(Orders.Where(o => Math.Acos(o.OrderID) == 0));
        }

        [TestMethod()]
        public void TestMathAsin()
        {
            TestQuery(Orders.Where(o => Math.Asin(o.OrderID) == 0));
        }

        [TestMethod()]
        public void TestMathAtan()
        {
            TestQuery(Orders.Where(o => Math.Atan(o.OrderID) == 0));
        }

        [TestMethod()]
        public void TestMathAtan2()
        {
            //TestQuery(Orderss.Where(o => Math.Atan2(o.Orderid, 3) == 0));
        }

        [TestMethod()]
        public void TestMathCos()
        {
            TestQuery(Orders.Where(o => Math.Cos(o.OrderID) == 0));
        }

        [TestMethod()]
        public void TestMathSin()
        {
            TestQuery(Orders.Where(o => Math.Sin(o.OrderID) == 0));
        }

        [TestMethod()]
        public void TestMathTan()
        {
            TestQuery(Orders.Where(o => Math.Tan(o.OrderID) == 0));
        }

        [TestMethod()]
        public void TestMathExp()
        {
            TestQuery(Orders.Where(o => Math.Exp(o.OrderID < 1000 ? 1 : 2) == 0));
        }

        [TestMethod()]
        public void TestMathLog()
        {
            TestQuery(Orders.Where(o => Math.Log(o.OrderID) == 0));
        }

        [TestMethod()]
        public void TestMathLog10()
        {
            TestQuery(Orders.Where(o => Math.Log10(o.OrderID) == 0));
        }

        [TestMethod()]
        public void TestMathSqrt()
        {
            TestQuery(Orders.Where(o => Math.Sqrt(o.OrderID) == 0));
        }

        [TestMethod()]
        public void TestMathCeiling()
        {
            TestQuery(Orders.Where(o => Math.Ceiling((double)o.OrderID) == 0));
        }

        [TestMethod()]
        public void TestMathFloor()
        {
            TestQuery(Orders.Where(o => Math.Floor((double)o.OrderID) == 0));
        }

        [TestMethod()]
        public void TestMathPow()
        {
            TestQuery(Orders.Where(o => Math.Pow(o.OrderID < 1000 ? 1 : 2, 3) == 0));
        }

        [TestMethod()]
        public void TestMathRoundDefault()
        {
            TestQuery(Orders.Where(o => Math.Round((decimal)o.OrderID) == 0));
        }

        [TestMethod()]
        public void TestMathRoundToPlace()
        {
            TestQuery(Orders.Where(o => Math.Round((decimal)o.OrderID, 2) == 0));
        }

        [TestMethod()]
        public void TestMathTruncate()
        {
            TestQuery(Orders.Where(o => Math.Truncate((double)o.OrderID) == 0));
        }

        [TestMethod()]
        public void TestStringCompareToLT()
        {
            TestQuery(Customers.Where(c => c.City.CompareTo("Seattle") < 0));
        }

        [TestMethod()]
        public void TestStringCompareToLE()
        {
            TestQuery(Customers.Where(c => c.City.CompareTo("Seattle") <= 0));
        }

        [TestMethod()]
        public void TestStringCompareToGT()
        {
            TestQuery(Customers.Where(c => c.City.CompareTo("Seattle") > 0));
        }

        [TestMethod()]
        public void TestStringCompareToGE()
        {
            TestQuery(Customers.Where(c => c.City.CompareTo("Seattle") >= 0));
        }

        [TestMethod()]
        public void TestStringCompareToEQ()
        {
            TestQuery(Customers.Where(c => c.City.CompareTo("Seattle") == 0));
        }

        [TestMethod()]
        public void TestStringCompareToNE()
        {
            TestQuery(Customers.Where(c => c.City.CompareTo("Seattle") != 0));
        }

        [TestMethod()]
        public void TestStringCompareLT()
        {
            TestQuery(Customers.Where(c => string.Compare(c.City, "Seattle") < 0));
        }

        [TestMethod()]
        public void TestStringCompareLE()
        {
            TestQuery(Customers.Where(c => string.Compare(c.City, "Seattle") <= 0));
        }

        [TestMethod()]
        public void TestStringCompareGT()
        {
            TestQuery(Customers.Where(c => string.Compare(c.City, "Seattle") > 0));
        }

        [TestMethod()]
        public void TestStringCompareGE()
        {
            TestQuery(Customers.Where(c => string.Compare(c.City, "Seattle") >= 0));
        }

        [TestMethod()]
        public void TestStringCompareEQ()
        {
            TestQuery(Customers.Where(c => string.Compare(c.City, "Seattle") == 0));
        }

        [TestMethod()]
        public void TestStringCompareNE()
        {
            TestQuery(Customers.Where(c => string.Compare(c.City, "Seattle") != 0));
        }

        [TestMethod()]
        public void TestIntCompareTo()
        {
            // prove that x.CompareTo(y) works for types other than string
            TestQuery(Orders.Where(o => o.OrderID.CompareTo(1000) == 0));
        }

        [TestMethod()]
        public void TestDecimalCompare()
        {
            // prove that type.Compare(x,y) works with decimal
            TestQuery(Orders.Where(o => decimal.Compare((decimal)o.OrderID, 0.0m) == 0));
        }

        [TestMethod()]
        public void TestDecimalAdd()
        {
            TestQuery(Orders.Where(o => decimal.Add(o.OrderID, 0.0m) == 0.0m));
        }

        [TestMethod()]
        public void TestDecimalSubtract()
        {
            TestQuery(Orders.Where(o => decimal.Subtract(o.OrderID, 0.0m) == 0.0m));
        }

        [TestMethod()]
        public void TestDecimalMultiply()
        {
            TestQuery(Orders.Where(o => decimal.Multiply(o.OrderID, 1.0m) == 1.0m));
        }

        [TestMethod()]
        public void TestDecimalDivide()
        {
            TestQuery(Orders.Where(o => decimal.Divide(o.OrderID, 1.0m) == 1.0m));
        }

        [TestMethod()]
        public void TestDecimalRemainder()
        {
            TestQuery(Orders.Where(o => decimal.Remainder(o.OrderID, 1.0m) == 0.0m));
        }

        [TestMethod()]
        public void TestDecimalNegate()
        {
            TestQuery(Orders.Where(o => decimal.Negate(o.OrderID) == 1.0m));
        }

        [TestMethod()]
        public void TestDecimalCeiling()
        {
            TestQuery(Orders.Where(o => decimal.Ceiling(o.OrderID) == 0.0m));
        }

        [TestMethod()]
        public void TestDecimalFloor()
        {
            TestQuery(Orders.Where(o => decimal.Floor(o.OrderID) == 0.0m));
        }

        [TestMethod()]
        public void TestDecimalRoundDefault()
        {
            TestQuery(Orders.Where(o => decimal.Round(o.OrderID) == 0m));
        }

        [TestMethod()]
        public void TestDecimalRoundPlaces()
        {
            TestQuery(Orders.Where(o => decimal.Round(o.OrderID, 2) == 0.00m));
        }

        [TestMethod()]
        public void TestDecimalTruncate()
        {
            TestQuery(Orders.Where(o => decimal.Truncate(o.OrderID) == 0m));
        }

        [TestMethod()]
        public void TestDecimalLT()
        {
            // prove that decimals are treated normally with respect to normal comparison operators
            TestQuery(Orders.Where(o => ((decimal)o.OrderID) < 0.0m));
        }

        [TestMethod()]
        public void TestIntLessThan()
        {
            TestQuery(Orders.Where(o => o.OrderID < 0));
        }

        [TestMethod()]
        public void TestIntLessThanOrEqual()
        {
            TestQuery(Orders.Where(o => o.OrderID <= 0));
        }

        [TestMethod()]
        public void TestIntGreaterThan()
        {
            TestQuery(Orders.Where(o => o.OrderID > 0));
        }

        [TestMethod()]
        public void TestIntGreaterThanOrEqual()
        {
            TestQuery(Orders.Where(o => o.OrderID >= 0));
        }

        [TestMethod()]
        public void TestIntEqual()
        {
            TestQuery(Orders.Where(o => o.OrderID == 0));
        }

        [TestMethod()]
        public void TestIntNotEqual()
        {
            TestQuery(Orders.Where(o => o.OrderID != 0));
        }

        [TestMethod()]
        public void TestIntAdd()
        {
            TestQuery(Orders.Where(o => o.OrderID + 0 == 0));
        }

        [TestMethod()]
        public void TestIntSubtract()
        {
            TestQuery(Orders.Where(o => o.OrderID - 0 == 0));
        }

        [TestMethod()]
        public void TestIntMultiply()
        {
            TestQuery(Orders.Where(o => o.OrderID * 1 == 1));
        }

        [TestMethod()]
        public void TestIntDivide()
        {
            TestQuery(Orders.Where(o => o.OrderID / 1 == 1));
        }

        [TestMethod()]
        public void TestIntModulo()
        {
            TestQuery(Orders.Where(o => o.OrderID % 1 == 0));
        }

        [TestMethod()]
        public void TestIntLeftShift()
        {
            TestQuery(Orders.Where(o => o.OrderID << 1 == 0));
        }

        [TestMethod()]
        public void TestIntRightShift()
        {
            TestQuery(Orders.Where(o => o.OrderID >> 1 == 0));
        }

        [TestMethod()]
        public void TestIntBitwiseAnd()
        {
            TestQuery(Orders.Where(o => (o.OrderID & 1) == 0));
        }

        [TestMethod()]
        public void TestIntBitwiseOr()
        {
            TestQuery(Orders.Where(o => (o.OrderID | 1) == 1));
        }

        [TestMethod()]
        public void TestIntBitwiseExclusiveOr()
        {
            TestQuery(Orders.Where(o => (o.OrderID ^ 1) == 1));
        }

        [TestMethod()]
        public void TestIntBitwiseNot()
        {
            TestQuery(Orders.Where(o => ~o.OrderID == 0));
        }

        [TestMethod()]
        public void TestIntNegate()
        {
            TestQuery(Orders.Where(o => -o.OrderID == -1));
        }

        [TestMethod()]
        public void TestAnd()
        {
            TestQuery(Orders.Where(o => o.OrderID > 0 && o.OrderID < 2000));
        }

        [TestMethod()]
        public void TestOr()
        {
            TestQuery(Orders.Where(o => o.OrderID < 5 || o.OrderID > 10));
        }

        [TestMethod()]
        public void TestNot()
        {
            TestQuery(Orders.Where(o => (o.OrderID != 0)));
        }

        [TestMethod()]
        public void TestEqualNull()
        {
            TestQuery(Customers.Where(c => c.City == null));
        }

        [TestMethod()]
        public void TestEqualNullReverse()
        {
            TestQuery(Customers.Where(c => null == c.City));
        }

        [TestMethod()]
        public void TestCoalsce()
        {
            TestQuery(Customers.Where(c => (c.City ?? "Seattle") == "Seattle"));
        }

        [TestMethod()]
        public void TestCoalesce2()
        {
            TestQuery(Customers.Where(c => (c.City ?? c.Country ?? "Seattle") == "Seattle"));
        }

        [TestMethod()]
        public void TestConditional()
        {
            TestQuery(Orders.Where(o => (o.CustomerID == "ALFKI" ? 1000 : 0) == 1000));
        }

        [TestMethod()]
        public void TestConditional2()
        {
            TestQuery(Orders.Where(o => (o.CustomerID == "ALFKI" ? 1000 : o.CustomerID == "ABCDE" ? 2000 : 0) == 1000));
        }

        [TestMethod()]
        public void TestConditionalTestIsValue()
        {
            TestQuery(Orders.Where(o => (((bool)(object)o.OrderID) ? 100 : 200) == 100));
        }

        [TestMethod()]
        public void TestConditionalResultsArePredicates()
        {
            TestQuery(Orders.Where(o => (o.CustomerID == "ALFKI" ? o.OrderID < 10 : o.OrderID > 10)));
        }

        [TestMethod()]
        public void TestSelectManyJoined()
        {
            TestQuery(
                from c in Customers
                from o in Orders.Where(o => o.CustomerID == c.CustomerID)
                select new { Contactname = c.ContactName, Orderdate = o.OrderDate }
                );
        }

        [TestMethod()]
        public void TestSelectManyJoinedDefaultIfEmpty()
        {
            TestQuery(
                from c in Customers
                from o in Orders.Where(o => o.CustomerID == c.CustomerID).DefaultIfEmpty()
                select new { Contactname = c.ContactName, Orderdate = o.OrderDate }
                );
        }

        [TestMethod()]
        public void TestSelectWhereAssociation()
        {
            TestQuery(
                from o in Orders
                where o.Customers.City == "Seattle"
                select o
                );
        }

        [TestMethod()]
        public void TestSelectWhereAssociations()
        {
            TestQuery(
                from o in Orders
                where o.Customers.City == "Seattle" && o.Customers.Phone != "555 555 5555"
                select o
                );
        }

        [TestMethod()]
        public void TestSelectWhereAssociationTwice()
        {
            TestQuery(
                from o in Orders
                where o.Customers.City == "Seattle" && o.Customers.Phone != "555 555 5555"
                select o
                );
        }

        [TestMethod()]
        public void TestSelectAssociation()
        {
            TestQuery(
                from o in Orders
                select o.Customers
                );
        }

        [TestMethod()]
        public void TestSelectAssociation1()
        {
            TestQuery(
                from o in Orders
                select o.Customers.ContactName
                );
        }

        [TestMethod()]
        public void TestSelectAssociation2()
        {
            TestQuery(
                from o in Orders
                orderby o.Customers.City
                select new { Companyname = o.Customers.CompanyName, Contactname = o.Customers.ContactName }
                );
        }

        [TestMethod()]
        public void TestSelectAssociations()
        {
            TestQuery(
                from o in Orders
                select new { A = o.Customers, B = o.Customers }
                );
        }

        [TestMethod()]
        public void TestSelectAssociationsWhereAssociations()
        {
            TestQuery(
                from o in Orders
                where o.Customers.City == "Seattle"
                where o.Customers.Phone != "555 555 5555"
                select new { A = o.Customers, B = o.Customers }
                );
        }

        [TestMethod()]
        public void TestCompareDateTimesWithDifferentNullability()
        {
            TestQuery(
                from o in Orders
                where o.OrderDate < DateTime.Today && ((DateTime?)o.OrderDate) < DateTime.Today
                select o
                );
        }

        [TestMethod]
        public void TestCompareEntityEqual()
        {
            var alfki = new Customers { CustomerID = "ALFKI" };
            TestQuery(
                Customers.Where(c => c == alfki)
                );
        }

        [TestMethod]
        public void TestCompareEntityNotEqual()
        {
            var alfki = new Customers { CustomerID = "ALFKI" };
            TestQuery(
                Customers.Where(c => c != alfki)
                );
        }

        [TestMethod]
        public void TestCompareConstructedMultiValueEqual()
        {
            TestQuery(
                Customers.Where(c => new { x = c.City, y = c.Country } == new { x = "London", y = "UK" })
                );
        }

        [TestMethod]
        public void TestCompareConstructedMultiValueNotEqual()
        {
            TestQuery(
                Customers.Where(c => new { x = c.City, y = c.Country } != new { x = "London", y = "UK" })
                );
        }

        [TestMethod]
        public void TestCompareConstructed()
        {
            TestQuery(
                Customers.Where(c => new { x = c.City } == new { x = "London" })
                );
        }

        [TestMethod()]
        public void TestContainsWithEmptyLocalList()
        {
            var ids = new string[0];
            TestQuery(
                from c in Customers
                where ids.Contains(c.CustomerID)
                select c
                );
        }

        [TestMethod()]
        public void TestContainsWithSubQuery()
        {
            var n = "London";
            var custsInLondon = Customers.Where(c => c.City == n).Select(c => c.CustomerID);

            TestQuery(
                from c in Customers
                where custsInLondon.Contains(c.CustomerID)
                select c
                );
        }

        [TestMethod()]
        public void TestCombineQueriesDeepNesting()
        {
            var custs = Customers.Where(c => c.ContactName.StartsWith("xxx"));
            var ords = Orders.Where(o => custs.Any(c => c.CustomerID == o.CustomerID));
            TestQuery(
                Details.Where(d => ords.Any(o => o.OrderID == d.OrderID))
                );
        }

        [TestMethod()]
        public void TestOuterApply()
        {
            var customers = Customers.Where(s => true);
            TestQuery(
                Orders.Select(s => new { Customerid = s.CustomerID, Allow = customers.FirstOrDefault(t => t.Address == s.CustomerID) != null })
                );
        }

        [TestMethod()]
        public void TestLetWithSubquery()
        {
            TestQuery(
                from customers in Customers
                let Orderss =
                    from order in Orders
                    where order.CustomerID == customers.CustomerID
                    select order
                select new
                {
                    Customers = customers,
                    OrderssCount = Orderss.Count(),
                }
                );
        }

        [TestMethod()]
        public void TestSelectDelFlag1()
        {
            TestQuery(from o in Products select o);
        }

        [TestMethod()]
        public void TestSelectDelFlag2()
        {
            TestQuery(from o in Products where o.ProductID > 20 select o);
        }

        [TestMethod()]
        public void TestSelectDelFlag3()
        {
            TestQuery(from o in Details where o.Products.ProductID > 20 select o);
        }

        [TestMethod()]
        public virtual void TestBigQueryWithOrderingGroupingAndNestedGroupCounts()
        {
            TestQuery(Customers
                          .OrderBy(c => c.City)
                          .Take(10)
                          .GroupBy(c => c.City)
                          .OrderBy(g => g.Key)
                          .Select(g => new { Key = g.Key, ItemCount = g.Count(), HasSubGroups = false, Items = g }));
        }

    }
}
