using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Charlie.Web.WordPress.Config
{
  public static  class WebConfig
    {
      public static void Initialize()
      {
          Initialize("~");
          
      }

      public static void Initialize(string path)
      {
          var isChanged = false;
          var cfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(path);
          var comm = (SiteCommonConfig)cfg.GetSection(SiteCommonConfig.SectionName);
          if (comm == null)
          {
              comm = new SiteCommonConfig()
              {
                  Title = "New WordPress Site for .Net",
                  TimeZone = TimeZoneInfo.Local.Id,
                  SubTitle = string.Empty,
                  FirstDayOfWeek = DayOfWeek.Monday
              };
              cfg.Sections.Add(SiteCommonConfig.SectionName, comm);
              isChanged = true;
          }

          if (isChanged)
          {
              cfg.Save();

          }
      }
    }
}
