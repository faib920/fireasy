// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Data.Entity;
using System;

namespace Fireasy.Windows.Entity
{
    public interface IEntityEditableForm
    {
        Type EntityType { get; set; }

        string InfoId { get; set; }

        EntityPropertyExtend EntityPropertyExtend { get; set; }

        IEntity Refer { get; set; }

        IEntity EntityAdded { get; }

        bool ViewMode { get; set; }

        System.Windows.Forms.Control.ControlCollection Controls { get; }
    }
}
