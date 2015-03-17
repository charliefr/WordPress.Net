using System;
using System.Diagnostics;
using System.Text;
using Charlie.Web.WordPress.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Web.Routing;

namespace Charlie.Web.WordPress.Tests.Configs
{
    [TestClass]
    public class ConfigTest
    {

        [TestMethod]
        public void CommonConfigTest()
        {
      
            var sp = "VirtualPathHash,Publish,Status,Name,UserId,Title,Summary,Keywords,Content".Split(',');
            const string table = "Post";
            const string tmp = "[Display(ResourceType = typeof(DataResources.DispayResource), Name = \"{0}_{1}_Name\", Description = \"{0}_{1}_Description\", Prompt = \"{0}_{1}_Prompt\")]";
            const string rsbtmp = "{0}_{1}_Name\t{0}_{1}_Name\tTable {0} 's Field {1} Resource Name\r\n{0}_{1}_Description\t{0}_{1}_Description\tTable {0} 's Field {1} Resource Description\r\n{0}_{1}_Prompt\t{0}_{1}_Prompt\tTable {0} 's Field {1} Resource Prompt";
            var sb = new StringBuilder();
            var rsb = new StringBuilder();

            foreach (var s in sp)
            {
                sb.AppendLine(string.Format(tmp, table, s));
                rsb.AppendLine(string.Format(rsbtmp, table, s));
            }
            Debug.WriteLine("-----------------------------------");
            Debug.WriteLine(sb.ToString());
            Debug.WriteLine("-----------------------------------");
            Debug.WriteLine(rsb.ToString());
            Debug.WriteLine("-----------------------------------");
        }
    }
}
