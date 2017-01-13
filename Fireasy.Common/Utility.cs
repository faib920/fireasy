// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Reflection;

namespace Fireasy.Common
{
    /// <summary>
    /// 提供可用的辅助方法。
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// 解析路径中带目录的参数值。
        /// </summary>
        /// <param name="path">文件路径。</param>
        /// <example>如 |system|db1.mdb 等等。</example>
        /// <returns>绝对路径。</returns>
        public static string ResolveDirectory(string path)
        {
            int dirIndex;
            if ((dirIndex = path.LastIndexOf("|")) != -1)
            {
                var file = path.Substring(dirIndex + 1);
                var folderName = path.Substring(1, dirIndex - 1);
#if N35
                var folder = Environment.SpecialFolder.System;
                try
                {
                    folder = (Environment.SpecialFolder)Enum.Parse(typeof(Environment.SpecialFolder), folderName);
                }
                catch
                {
                    return path;
                }
#else
                Environment.SpecialFolder folder;
                if (!Enum.TryParse(folderName, out folder))
                {
                    return path;
                }
#endif
                var directory = Environment.GetFolderPath(folder);
                if (!directory.EndsWith("\\"))
                {
                    directory += "\\";
                }

                return new Uri(new Uri(directory), file).LocalPath;
            }

            return path;
        }
    }
}
