
using Demo.Data.Model;
using Fireasy.Common.Extensions;
using Fireasy.Data.Entity;
using Fireasy.Data.Entity.Linq;
using Fireasy.Utilities.Web;
using Fireasy.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcDemo.Areas.Emp.Controllers
{
    public partial class EmployeeController : Controller
    {
        public ActionResult List()
        {
            return View();
        }
    		
        public ActionResult Edit()
        {
            return View();
        }
    		
        /// <summary>
        /// 根据ID获取员工。
        /// </summary>
        /// <param name="id">信息ID。</param>
        /// <returns></returns>
        public JsonResult Get(string id)
        {
            using (var context = new DbContext())
            {
                return Json(context.Employees.Get(id));
            }
        }

        /// <summary>
        /// 保存员工。
        /// </summary>
        /// <param name="id">id。</param>
        /// <param name="info">要保存的数据。</param>
        /// <returns>id</returns>
        public JsonResult Save(string id, Employee info, List<int> array)
        {
            using (var context = new DbContext())
            {
                //拼音码
                info.No = info.Name.ToPinyin();
                if (string.IsNullOrEmpty(id))
                {
                    info.Id = Guid.NewGuid().ToString();
                    context.Employees.Insert(info);
                }
                else
                {
                    context.Employees.Update(info.Normalize(new[] { id }));
                }

                return Json(Result.Success("保存成功。", info.Id));
            }
        }
        
        /// <summary>
        /// 根据查询条件获取员工。
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        [ExceptionBehavior(true)]
        public JsonResult Data(string deptNo, string keyword)
        {
            //获取 easyui-datagrid 的分页参数和排序参数
            var pager = EasyUIHelper.GetDataPager();
            var sorting = EasyUIHelper.GetSorting();

            sorting.Replace(new Dictionary<string, string> { { "SexText", "Sex" } });

            using (var context = new DbContext())
            {
                //使用AssertWhere拼接linq
                var list = context.Employees
                    .Segment(pager)
                    .AssertWhere(!string.IsNullOrEmpty(deptNo), s => s.Dept.No.StartsWith(deptNo))
                    .AssertWhere(!string.IsNullOrEmpty(keyword), s => s.Name.Contains(keyword) || s.No.Contains(keyword))
                    .OrderBy(sorting, u => u.OrderBy(s => s.Name)) //默认按名称排序
                    .Select(s => s.Extend(() => new
                        {
                            SexText = s.Sex.GetDescription()
                        }))
                    .ToList();

                //如果使用Extend的话，UI不能使用SexText进行排序
                //另一种办法就是把需要显示到UI的属性都打出来
                // .Select(s => new { s.Id, s.Name, Sex = s.Sex.GetDescription() })

                //使用Transfer把列表转换成 easyui-datagrid 的json格式： { total: 10, rows: [{},{}] }
                //注意上面要用 ToList，不然 pager 的记录总数和页码数无法获取
                return Json(EasyUIHelper.Transfer(pager, list));
            }
        }

        /// <summary>
        /// 删除员工。
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public JsonResult Delete(string id)
        {
            using (var context = new DbContext())
            {
                context.Employees.Delete(new[] { id });
                return Json(Result.Success("删除成功。"));
            }
        }
    }
}
