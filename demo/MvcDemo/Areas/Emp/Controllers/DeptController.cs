
using Demo.Data.Model;
using Fireasy.Common.Extensions;
using Fireasy.Data.Entity;
using Fireasy.EasyUI;
using Fireasy.Web.Http;
using Fireasy.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcDemo.Areas.Emp.Controllers
{
    public partial class DeptController : Controller
    {
        public ActionResult List()
        {
            return View();
        }
    		
        public ActionResult Edit()
        {
            ViewBag.ParentId = Request.QueryString["parentId"];
            return View();
        }
    		
        /// <summary>
        /// 根据ID获取部门。
        /// </summary>
        /// <param name="id">信息ID。</param>
        /// <returns></returns>
        public JsonResult Get(string id)
        {
            using (var context = new DbContext())
            {
                var info = context.Depts.Get(id);
                if (info != null)
                {
                    var persister = context.CreateTreePersister<Dept>();

                    //扩展一个 ParentId 属性
                    var parent = persister.RecurrenceParent(info).FirstOrDefault();
                    if (parent != null)
                    {
                        return Json(info.Extend(new { ParentId = parent.Id }));
                    }

                    return Json(info);
                }
                return null;
            }
        }

        /// <summary>
        /// 保存部门。
        /// </summary>
        /// <param name="id">id。</param>
        /// <param name="parentId">上级部门ID。</param>
        /// <param name="info">要保存的数据。</param>
        /// <returns>id</returns>
        public JsonResult Save(int? id, string parentId, Dept info)
        {
            using (var context = new DbContext())
            {
                var persister = context.CreateTreePersister<Dept>();
                if (id == null)
                {
                    if (string.IsNullOrEmpty(parentId))
                    {
                        persister.Create(info);
                    }
                    else
                    {
                        //插入为parent的孩子
                        persister.Insert(info, context.Depts.Get(parentId), EntityTreePosition.Children);
                    }
                }
                else
                {
                    context.Depts.Update(info.Normalize(id));

                    //要重新提一下no
                    info.No = context.Depts.Get(id).No;

                    //移动到parent下
                    persister.Move(info, context.Depts.Get(parentId), EntityTreePosition.Children);
                }

                return Json(Result.Success("保存成功。", info.Id));
            }
        }
        
        /// <summary>
        /// 根据查询条件获取部门。
        /// </summary>
        /// <param name="id">父id。</param>
        /// <param name="targetId">目标id，按它所在的路径进行展开，以便选中它。</param>
        /// <param name="currentId">当前修改的id，防止树中列出它。</param>
        /// <returns></returns>
        [ExceptionBehavior(true)] //发生异常的时候返回一个空数组
        public JsonResult Data(int? id, int? targetId, int? currentId)
        {
            //添加转换器，easyui-treegrid、easyui-tree 接收的数据格式如 [{ id: '', text: '', state: 'close', attributes: { no: '' }, children: [] }]
            ActionContext.Current.Converters.Add(new DeptJsonConverter());
            return Json(GetDepts(id, targetId, currentId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">父id。</param>
        /// <param name="targetId">目标id，按它所在的路径进行展开，以便选中它。</param>
        /// <param name="currentId">当前修改的id，防止树中列出它。</param>
        /// <returns></returns>
        private List<Dept> GetDepts(int? id, int? targetId, int? currentId)
        {
            var result = new List<Dept>();
            using (var context = new DbContext())
            {
                Dept parent = null;
                if (id != null)
                {
                    parent = context.Depts.Get(id);
                }

                var persister = context.CreateTreePersister<Dept>();

                //获得孩子的同时再判断是否有孙子
                var children = from s in persister.QueryChildren(parent)
                                   select new { s, HasChildren = persister.HasChildren(s, null) };

                foreach (var child in children)
                {
                    if (child.s.Id == currentId)
                    {
                        continue;
                    }

                    result.Add(child.s);
                    child.s.HasChildren = child.HasChildren;
                    child.s.Children = new List<Dept>();
                }


                if (targetId != null && !TreeNodeExpandChecker.IsExpanded())
                {
                    //获得它的所有父id，根据编码000100010001这样从后往前递归
                    var target = context.Depts.Get(targetId);
                    if (target != null)
                    {
                        var parents = persister.RecurrenceParent(target).Select(s => s.Id).ToList();
                        result.Expand(parents, s => GetDepts(s, targetId, currentId), parents.Count - 1);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 删除部门。
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public JsonResult Delete(string id)
        {
            using (var context = new DbContext())
            {
                context.Depts.Delete(new[] { id });
                return Json(Result.Success("删除成功。"));
            }
        }

        /// <summary>
        /// Dept的转换器。
        /// </summary>
        private class DeptJsonConverter : TreeNodeJsonConverter<Dept>
        {
            public DeptJsonConverter()
                : base(new Dictionary<string, Func<Dept, object>> 
                { 
                    { "text", s => s.Name },
                    { "order", s => s.OrderNo },
                    { "attributes", s => new { no = s.No } },
                })
            {
            }
        }
    }
}
