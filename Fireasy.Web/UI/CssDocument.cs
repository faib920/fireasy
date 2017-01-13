// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Fireasy.Web.UI
{
    /// <summary>
    /// 提供对 Css 样式文件加载和保存的文档结构。
    /// </summary>
    public class CssDocument
    {
        /// <summary>
        /// 获取文件内容。
        /// </summary>
        public string Context { get; private set; }

        /// <summary>
        /// 获取文档内的元素集合。
        /// </summary>
        public List<CssElement> Elements { get; private set; }

        /// <summary>
        /// 获取指定名称的元素。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public CssElement this[string name]
        {
            get
            {
                for (int i = 0; i < Elements.Count; i++)
                {
                    if (Elements[i].Name.Equals(name))
                    {
                        return Elements[i];
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 获取文件名。
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// 从指定的文件中加载文档。
        /// </summary>
        /// <param name="fileName"></param>
        public void Load(string fileName)
        {
            FileName = fileName;
            using (var sr = new StreamReader(fileName))
            {
                Context = sr.ReadToEnd();
                sr.Close();
            }

            var parse = new CssParse();
            parse.Source = Regex.Replace(Context, @"/\*.*?\*/", "", RegexOptions.Compiled);
            Elements = parse.Parse();
        }

        /// <summary>
        /// 添加一个元素。
        /// </summary>
        /// <param name="element"></param>
        public void Add(CssElement element)
        {
            Elements.Add(element);
        }

        /// <summary>
        /// 保存文档内容。
        /// </summary>
        public void Save()
        {
            Save(FileName);
        }

        /// <summary>
        /// 保存文档内容。
        /// </summary>
        /// <param name="fileName"></param>
        public void Save(string fileName)
        {
            using (var sw = new StreamWriter(fileName, false))
            {
                for (var i = 0; i < Elements.Count; i++)
                {
                    var element = (CssElement)Elements[i];
                    sw.WriteLine(element.Name + " {");
                    foreach (string name in element.Attributes.AllKeys)
                    {
                        sw.WriteLine("\t{0}:{1};", name, element.Attributes[name]);
                    }

                    sw.WriteLine("}");
                }

                sw.Flush();
                sw.Close();
            }
        }
    }

    /// <summary>
    /// 表示 Css 元素。
    /// </summary>
    public class CssElement
    {
        /// <summary>
        /// 获取或设置元素的名称。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置属性列表。
        /// </summary>
        public NameValueCollection Attributes { get; set; }

        /// <summary>
        /// 初始化 <see cref="CssElement"/> 类的新实例。
        /// </summary>
        /// <param name="name"></param>
        public CssElement(string name)
        {
            this.Name = name;
            Attributes = new NameValueCollection();
        }

        /// <summary>
        /// 为元素添加属性。
        /// </summary>
        /// <param name="attrName">属性名称。</param>
        /// <param name="value">属性值。</param>
        public void Add(string attrName, string value)
        {
            Attributes[attrName] = value;
        }
    }

    internal class CssParse
    {
        private int m_idx;

        public static bool IsWhiteSpace(char ch)
        {
            return ("\t\n\r ".IndexOf(ch) != -1);
        }

        public void EatWhiteSpace()
        {
            while (!Eof())
            {
                if (!IsWhiteSpace(GetCurrentChar()))
                {
                    return;
                }

                m_idx++;
            }
        }

        public bool Eof()
        {
            return (m_idx >= Source.Length);
        }

        public string ParseElementName()
        {
            var element = new StringBuilder();
            EatWhiteSpace();
            while (!Eof())
            {
                if (GetCurrentChar() == '{')
                {
                    m_idx++;
                    break;
                }

                element.Append(GetCurrentChar());
                m_idx++;
            }

            EatWhiteSpace();
            return element.ToString().Trim();
        }

        public string ParseAttributeName()
        {
            var attribute = new StringBuilder();
            EatWhiteSpace();

            while (!Eof())
            {
                if (GetCurrentChar() == ':')
                {
                    m_idx++;
                    break;
                }
                attribute.Append(GetCurrentChar());
                m_idx++;
            }

            EatWhiteSpace();
            return attribute.ToString().Trim();
        }

        public string ParseAttributeValue()
        {
            var attribute = new StringBuilder();
            EatWhiteSpace();
            while (!Eof())
            {
                if (GetCurrentChar() == ';')
                {
                    m_idx++;
                    break;
                }
                attribute.Append(GetCurrentChar());
                m_idx++;
            }

            EatWhiteSpace();
            return attribute.ToString().Trim();
        }

        public char GetCurrentChar()
        {
            return GetCurrentChar(0);
        }

        public char GetCurrentChar(int peek)
        {
            if ((m_idx + peek) < Source.Length)
            {
                return Source[m_idx + peek];
            }
            else
            {
                return (char)0;
            }
        }

        public char AdvanceCurrentChar()
        {
            return Source[m_idx++];
        }

        public void Advance()
        {
            m_idx++;
        }

        public string Source { get; set; }

        public List<CssElement> Parse()
        {
            var elements = new List<CssElement>();

            while (!Eof())
            {
                var elementName = ParseElementName();

                if (elementName == null)
                {
                    break;
                }

                var element = new CssElement(elementName);

                var name = ParseAttributeName();
                var value = ParseAttributeValue();

                while (name != null && value != null)
                {
                    element.Add(name, value);

                    EatWhiteSpace();

                    if (GetCurrentChar() == '}')
                    {
                        m_idx++;
                        break;
                    }

                    name = ParseAttributeName();
                    value = ParseAttributeValue();
                }

                elements.Add(element);
            }

            return elements;
        }
    }
}
