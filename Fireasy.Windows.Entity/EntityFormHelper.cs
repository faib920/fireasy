// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Data.Entity;
using Fireasy.Data.Entity.Dynamic;
using Fireasy.Data.Entity.Validation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fireasy.Windows.Entity
{
    /// <summary>
    /// 窗体对实体的操作辅助类。
    /// </summary>
    public class EntityFormHelper
    {
        private ErrorProvider errorProvider1;
        private IEntityEditableForm form;

        /// <summary>
        /// 初始化 <see cref="EntityFormHelper"/> 类的新实例。
        /// </summary>
        /// <param name="form"></param>
        /// <param name="errorProvider"></param>
        public EntityFormHelper(IEntityEditableForm form, ErrorProvider errorProvider)
        {
            this.form = form;
            errorProvider1 = errorProvider;
        }

        /// <summary>
        /// 从库里加载实体填充到窗体。首先判断窗体的 Refer 对象，然后再使用 InfoId 查询对象。
        /// </summary>
        public void Load()
        {
            if (form.Refer != null)
            {
                FillEntityValues(form.Refer);
            }
            else if (!string.IsNullOrEmpty(form.InfoId))
            {
                using (var persister = new AssignedEntityPersister(form.EntityType))
                {
                    var entity = persister.First(form.InfoId) as IEntity;
                    if (entity == null)
                    {
                        return;
                    }

                    FillEntityValues(entity);
                }

                if (form.ViewMode)
                {
                    SetViewMode();
                }
            }
        }

        /// <summary>
        /// 将窗体数据保存到库。
        /// </summary>
        /// <param name="preSaving"></param>
        /// <param name="afterSaved"></param>
        /// <param name="customSave"></param>
        /// <returns></returns>
        public IEntity Save(Action<IEntity> preSaving = null, Action<IEntity> afterSaved = null, Action<EntityPersister, IEntity> customSave = null)
        {
            if (errorProvider1 != null)
            {
                errorProvider1.Clear();
            }

            try
            {
                using (var persister = new AssignedEntityPersister(form.EntityType))
                {
                    IEntity entity = null;
                    if (!string.IsNullOrEmpty(form.InfoId))
                    {
                        entity = (IEntity)persister.First(form.InfoId);
                    }

                    if (entity == null)
                    {
                        entity = (IEntity)persister.NewEntity();
                    }

                    ReadEntityValues(entity);

                    var infoId = string.Empty;
                    if (entity.EntityState == EntityState.Attached)
                    {
                        SetPrimaryProperty(entity);
                    }

                    //保存之前
                    if (preSaving != null)
                    {
                        preSaving(entity);
                    }

                    //执行保存
                    if (customSave == null)
                    {
                        persister.Save(entity);
                    }
                    else
                    {
                        customSave(persister, entity);
                    }

                    //保存之后
                    if (afterSaved != null)
                    {
                        afterSaved(entity);
                    }

                    return entity;
                }
            }
            catch (EntityInvalidateException exp)
            {
                ShowPropertyInvalidateMessages(exp);
            }
            catch (Exception exp)
            {
                MessageBox.Show("数据保存失败。\n" + exp.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        /// <summary>
        /// 将实体的属性值填充到窗体上。
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void FillEntityValues(IEntity entity)
        {
            foreach (var kvp in form.EntityPropertyExtend.GetProperties())
            {
                var value = GetEntityValue(entity, kvp.Value);
                if (value == null || value.IsEmpty)
                {
                    continue;
                }

                var converter = ControlEntityMapConfig.Get(kvp.Key.GetType());

                if (converter != null)
                {
                    var ovalue = GetFormatValue(kvp.Key, value.GetStorageValue());
                    converter.SetValue(kvp.Key, ovalue);
                }
            }
        }

        /// <summary>
        /// 获取实体的属性值。
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private PropertyValue GetEntityValue(IEntity entity, string propertyName)
        {
            //级联属性
            if (propertyName.IndexOf('.') != -1)
            {
                PropertyValue pvalue = null;
                object value = null;
                foreach (var p in propertyName.Split('.'))
                {
                    pvalue = entity.GetValue(p);
                    if (!pvalue.IsEmpty)
                    {
                        value = pvalue.GetStorageValue();
                        if (value is IEntity)
                        {
                            entity = (IEntity)value;
                        }
                        else
                        {
                            return pvalue;
                        }
                    }
                }
            }

            return entity.GetValue(propertyName);
        }

        /// <summary>
        /// 读取窗口上的控件值，写给实体属性。
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void ReadEntityValues(IEntity entity)
        {
            foreach (var kvp in form.EntityPropertyExtend.GetProperties())
            {
                var box = kvp.Key as TextBoxBase;
                if (box != null && box.ReadOnly)
                {
                    continue;
                }

                var converter = ControlEntityMapConfig.Get(kvp.Key.GetType());

                if (converter != null)
                {
                    var value = converter.GetValue(kvp.Key);
                    if (value != null)
                    {
                        var property = PropertyUnity.GetProperty(form.EntityType, kvp.Value);
                        entity.SetValue(kvp.Value, PropertyValue.New(value, property.Type));
                    }
                }
            }
        }

        /// <summary>
        /// 清空控件里的值。
        /// </summary>
        public void ClearForm()
        {
            if (errorProvider1 != null)
            {
                errorProvider1.Clear();
            }

            foreach (var kvp in form.EntityPropertyExtend.GetProperties())
            {
                var converter = ControlEntityMapConfig.Get(kvp.Key.GetType());

                if (converter != null && form.EntityPropertyExtend.GetCanClear(kvp.Key))
                {
                    converter.Clear(kvp.Key);
                }
            }
        }

        /// <summary>
        /// 根据属性名称获取对应控件的文本值。
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected object GetControlValue(string propertyName)
        {
            var map = form.EntityPropertyExtend.GetProperties().FirstOrDefault(s => s.Value == propertyName);
            if (map.Key != null)
            {
                var converter = ControlEntityMapConfig.Get(map.Key.GetType());
                if (converter != null)
                {
                    return converter.GetValue(map.Key);
                }
            }

            return null;
        }

        /// <summary>
        /// 根据属性名称获取对应控件的文本值。
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected string GetControlText(string propertyName)
        {
            var map = form.EntityPropertyExtend.GetProperties().FirstOrDefault(s => s.Value == propertyName);
            if (map.Key != null)
            {
                return map.Key.Text;
            }

            return null;
        }

        /// <summary>
        /// 设置主键的值，并返回主键属性。
        /// </summary>
        /// <param name="entity"></param>
        protected void SetPrimaryProperty(IEntity entity)
        {
            var pk = PropertyUnity.GetPrimaryProperties(form.EntityType).FirstOrDefault();
            if (pk.Info.GenerateType == IdentityGenerateType.None &&
                pk.Type == typeof(string))
            {
                var keyValue = Guid.NewGuid().ToString();
                var accessor = entity as IEntityPropertyAccessor;
                accessor.SetValue(pk, keyValue);
                form.InfoId = keyValue;
            }
        }

        /// <summary>
        /// 显示验证失败的信息。
        /// </summary>
        /// <param name="exp"></param>
        protected virtual void ShowPropertyInvalidateMessages(EntityInvalidateException exp)
        {
            var sb = new StringBuilder();
            foreach (var property in exp.PropertyErrors)
            {
                //查找有没有验证失败属性相关联的控件
                var map = form.EntityPropertyExtend.GetProperties().Where(s => s.Value == property.Key.Name).FirstOrDefault();
                if (map.Key == null)
                {
                    sb.AppendLine(string.Join("\n", property.Value.ToArray()));
                    continue;
                }

                if (errorProvider1 != null)
                {
                    //在控件上显示验证失败的信息
                    errorProvider1.SetError(map.Key, string.Join("\n", property.Value.ToArray()));
                }
            }

            if (sb.Length > 0)
            {
                MessageBox.Show("填写的数据不完整，还包括以下这些信息：\n" + sb.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 设置预览模式。
        /// </summary>
        private void SetViewMode()
        {
            var removeList = new List<Control>();
            var addList = new Dictionary<Control, string>();

            foreach (var kvp in form.EntityPropertyExtend.GetProperties())
            {
                var map = ControlEntityMapConfig.Get(kvp.Key.GetType());
                if (map != null)
                {
                    var newControl = map.SetViewControl(kvp.Key);
                    if (newControl != null)
                    {
                        removeList.Add(kvp.Key);
                        addList.Add(newControl, kvp.Value);
                    }
                }
            }

            foreach (var control in removeList)
            {
                form.EntityPropertyExtend.SetPropertyName(control, string.Empty);
            }

            foreach (var kvp in addList)
            {
                form.EntityPropertyExtend.SetPropertyName(kvp.Key, kvp.Value);
            }
        }

        private object GetFormatValue(Control control, object value)
        {
            var format = form.EntityPropertyExtend.GetFormat(control);
            var formatable = value as IFormattable;
            if (!string.IsNullOrEmpty(format) && formatable != null)
            {
                return formatable.ToString(format, CultureInfo.CurrentCulture);
            }

            return value;
        }
    }
}
