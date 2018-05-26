// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using Sgml;

namespace SeleniumExcelAddIn.Tools
{
    public class ReferenceConverter
    {
        class Item
        {
            public string Name;
            public string Target;
            public string Value;
            public string Description;
        }

        class ItemComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Item item1 = (Item)x;
                Item item2 = (Item)y;

                return string.CompareOrdinal(item1.Name, item2.Name);
            }
        }

        private bool IsCommandExists(string name)
        {
            var names = TestCommandFactory.GetCommandNames();
            return 0 < names.Where(i => string.Equals(i, name, StringComparison.OrdinalIgnoreCase)).Count();
        }

        public string Convert()
        {
            var items = new List<Item>();
            var xml = this.GetXml();
            var ns = xml.Root.Name.Namespace;
            var elements = xml.XPathSelectElements("//strong/a[@name]");

            foreach (var element in elements)
            {
                var item = new Item()
                {
                    Name = element.Attribute("name").Value,
                };

                XElement dt = element.Parent.Parent;
                this.GetArgs(item, dt);

                XElement dd = dt.ElementsAfterSelf().First();
                this.GetArgs2(item, dd);
                this.GetDescription(item, dd);

                var tmps = new List<Item>();
                tmps.Add(item);
                tmps.AddRange(this.GetSubItems(dd, item.Description));

                foreach (var tmp in tmps)
                {
                    var andWaitName = tmp.Name + "AndWait";

                    if (this.IsCommandExists(andWaitName))
                    {
                        items.Add(new Item()
                        {
                            Name = andWaitName,
                            Target = item.Target,
                            Value = item.Value,
                            Description = item.Description,
                        });
                    }
                }

                items.AddRange(tmps);
            }

            var missing = new StringBuilder();
            foreach (var name in TestCommandFactory.GetCommandNames())
            {
                if (0 == items.Where(i => string.Equals(i.Name, name, StringComparison.OrdinalIgnoreCase)).Count())
                {
                    missing.AppendLine(name);
                }
            }

            File.WriteAllText(Path.Combine(App.TempDir, "commands-missing.txt"), missing.ToString());


            StringBuilder sb = new StringBuilder();

            foreach (var item in items
                .Where(i => this.IsCommandExists(i.Name))
                .OrderBy(i => i.Name))
            {
                var s = @"
<div class=""command"">
<h3 id=""***NAME***"">***NAME***</h3>
<ul>
***TARGET***
***VALUE***
</ul>
<div class=""command-description"">***DESC***</div>
</div>
";

                s = s.Replace("***NAME***", item.Name);

                if (string.IsNullOrWhiteSpace(item.Target))
                {
                    s = s.Replace("***TARGET***", string.Empty);
                }
                else
                {
                    s = s.Replace("***TARGET***", @"<li class=""command-target""><strong>Target</strong> = <span class=""command-target-description"">" + item.Target + "</span></li>");
                }

                if (string.IsNullOrWhiteSpace(item.Value))
                {
                    s = s.Replace("***VALUE***", string.Empty);
                }
                else
                {
                    s = s.Replace("***VALUE***", @"<li class=""command-value""><strong>Value</strong> = <span class=""command-value-description"">" + item.Value + "</span></li>");
                }

                s = s.Replace("***DESC***", item.Description);

                sb.AppendLine(s);
            }

            return sb.ToString();
        }

        private IEnumerable<Item> GetSubItems(XElement dd, string description)
        {
            var p = dd.XPathSelectElement("p[normalize-space(text())='Related Assertions, automatically generated:']");
            var items = new List<Item>();

            if (null == p)
            {
                return items;
            }

            var lis = p.ElementsAfterSelf("ul").First().Elements("li");

            foreach (var li in lis)
            {
                var item = new Item()
                {
                    Name = li.Value.Substring(0, li.Value.IndexOf("(")).Trim(),
                    Description = description,
                };

                this.GetArgs(item, li);
                items.Add(item);
            }

            return items;
        }

        private void GetDescription(Item item, XElement dd)
        {
            var s = dd.ToString().Replace("<dd>", "");

            var ix = s.IndexOf("<p>Arguments:</p>");

            if (0 <= ix)
            {
                item.Description = s.Substring(0, ix);
                return;
            }

            ix = s.IndexOf("<dl>");

            if (0 <= ix)
            {
                item.Description = s.Substring(0, ix);
                return;
            }

            item.Description = s;
        }

        private void GetArgs2(Item item, XElement dd)
        {
            var p = dd.Descendants("p").FirstOrDefault();

            if (null == p)
            {
                return;
            }

            if (p.Value != "Arguments:")
            {
                return;
            }

            var ul = p.ElementsAfterSelf("ul").FirstOrDefault();

            if (null == ul)
            {
                return;
            }

            var lis = ul.Elements("li");

            switch (lis.Count())
            {
                case 1:
                    item.Target = lis.ElementAt(0).Value;
                    break;

                case 2:
                    item.Target = lis.ElementAt(0).Value;
                    item.Value = lis.ElementAt(1).Value;
                    break;
            }
        }

        private void GetArgs(Item item, XElement dt)
        {
            var s = dt.Value;
            var st = s.IndexOf("(") + 1;
            var en = s.IndexOf(")");
            var arg = s.Substring(st, en - st);
            var args = arg.Split(',');

            switch (args.Count())
            {
                case 1:
                    item.Target = args[0].Trim();
                    break;

                case 2:
                    item.Target = args[0].Trim();
                    item.Value = args[1].Trim();
                    break;
            }
        }


        private XDocument GetXml()
        {
            using (var reader = new StringReader(Properties.Resources.selenium_reference))
            {
                using (var sgmlReader = new SgmlReader()
                {
                    DocType = "HTML",
                    CaseFolding = CaseFolding.ToLower,
                    IgnoreDtd = true,
                    InputStream = reader,
                })
                {
                    return XDocument.Load(sgmlReader);
                }
            }
        }
    }
}
