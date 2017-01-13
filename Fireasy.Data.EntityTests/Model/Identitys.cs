// ------------------------------
// 本模块由CodeBuilder工具生成,该类适用于 Fireasy.Data.Entity 1.5 数据框架
// 版权所有 (C) Fireasy 2011

// 项目名称: 实体框架测试项目
// 模块名称: Identitys 实体类
// 代码编写: Huangxd
// 文件路径: C:\Users\Ruibron\Desktop\Model\Identitys.cs
// 创建时间: 2013/10/15 10:28:27
// ------------------------------

using System;
using Fireasy.Data.Entity;

namespace Fireasy.Data.Entity.Test.Model
{
    /// <summary>
    /// Identitys 实体类。
    /// </summary>
    [Serializable]
    [EntityMapping("Identitys")]
    public partial class Identitys : EntityObject
    {
        #region Static Property Definition
        
        /// <summary>
        /// Id1的依赖属性。
        /// </summary>
        public static readonly IProperty EpId1 = PropertyUnity.RegisterProperty<Identitys>(s => s.Id1, new PropertyMapInfo { IsPrimaryKey = true, GenerateType = IdentityGenerateType.AutoIncrement, IsNullable = false, FieldName = "Id1" });

        /// <summary>
        /// Id2的依赖属性。
        /// </summary>
        public static readonly IProperty EpId2 = PropertyUnity.RegisterProperty<Identitys>(s => s.Id2, new PropertyMapInfo { IsPrimaryKey = true, GenerateType = IdentityGenerateType.Generator, IsNullable = false, FieldName = "Id2" });

        /// <summary>
        /// Id2的依赖属性。
        /// </summary>
        public static readonly IProperty EpId3 = PropertyUnity.RegisterProperty<Identitys>(s => s.Id3, new PropertyMapInfo { IsPrimaryKey = true, IsNullable = false, FieldName = "Id3" });

        #endregion

        #region Properties
        
        /// <summary>
        /// 获取或设置Id1。
        /// </summary>
        public int Id1
        {
            get { return (int)GetValue(EpId1); }
            set { SetValue(EpId1, value); }
        }

        /// <summary>
        /// 获取或设置Id2。
        /// </summary>
        public int Id2
        {
            get { return (int)GetValue(EpId2); }
            set { SetValue(EpId2, value); }
        }

        /// <summary>
        /// 获取或设置Id3。
        /// </summary>
        public string Id3
        {
            get { return (string)GetValue(EpId3); }
            set { SetValue(EpId3, value); }
        }

        #endregion

    }
}