using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Charlie.Web.WordPress.Config
{

    internal sealed class SiteConfigConstant
    {
        internal const string SiteConfig = "SiteConfig";
        internal const string Empty = "";
        internal const string Title = "Title";
        internal const string TitleDefault = "My Site Title";
        internal const string SubTitle = "SubTitle";
        internal const string SubTitleDefault = Empty;
        internal const string TimeZone = "TimeZone";
        internal const string DateFormat = "DateFormat";
        internal const string TimeFormat = "TimeFormat";
        internal const string FirstDayOfWeek = "FirstDayOfWeek";

        internal static bool IsEmpty(object obj)
        {
            return Empty.Equals(obj);
        }

        internal static bool IsNull(object obj)
        {
            return obj == null;
        }
    }

    [Serializable]
  public sealed  class SiteCommonConfig : ConfigurationSection
    {
        internal const string SectionName =@"SiteCommonConfig";
        private static  SiteCommonConfig _default;

        public static  SiteCommonConfig Default
        {

            get
            {
                _default = _default ?? (SiteCommonConfig)System.Web.Configuration.WebConfigurationManager.GetSection(SectionName);
                return _default;
            }
        }

        public void Save()
        {
            //var cfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
            //var section = (SiteCommonConfig)cfg.GetSection(SectionName);
            this.CurrentConfiguration.Save(saveMode: System.Configuration.ConfigurationSaveMode.Full);
        }

        private readonly static System.Globalization.DateTimeFormatInfo DefaultTimeFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat;
        public SiteCommonConfig()
        {
        }

        [ConfigurationProperty(SiteConfigConstant.Title, DefaultValue = SiteConfigConstant.TitleDefault, IsRequired = true)]
        [StringValidator(InvalidCharacters = "<>", MinLength = 1, MaxLength = 60)]
        public String Title
        {
            get
            { return (String)this[SiteConfigConstant.Title]; }
            set
            { this[SiteConfigConstant.Title] = value; }
        }

        [ConfigurationProperty(SiteConfigConstant.SubTitle, DefaultValue = SiteConfigConstant.SubTitleDefault, IsRequired = false)]
        public String SubTitle
        {
            get
            { return (String)this[SiteConfigConstant.SubTitle]; }
            set
            { this[SiteConfigConstant.SubTitle] = value; }
        }




        [ConfigurationProperty(SiteConfigConstant.TimeZone, DefaultValue = null, IsRequired = false)]
        public string TimeZone
        {
            get
            {
                return SiteConfigConstant.IsEmpty(this[SiteConfigConstant.TimeZone]) ? TimeZoneInfo.Local.Id : (string) this[SiteConfigConstant.TimeZone];
            }
            set
            {
                _timeZoneInfo = null;
                this[SiteConfigConstant.TimeZone] = value; 
            }
        }

        private TimeZoneInfo _timeZoneInfo = null;
        public TimeZoneInfo GetTimeZone()
        {
            if (_timeZoneInfo==null)
            {
                _timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(TimeZone);
            }
            return _timeZoneInfo;
        }

        [ConfigurationProperty(SiteConfigConstant.DateFormat, DefaultValue = null, IsRequired = false)]
        public string DateFormat
        {
            get
            {
                return SiteConfigConstant.IsEmpty(this[SiteConfigConstant.DateFormat]) ? DefaultTimeFormat.ShortDatePattern : (string)this[SiteConfigConstant.DateFormat];
            }
            set
            {
                this[SiteConfigConstant.DateFormat] = value;
            }
        }

        [ConfigurationProperty(SiteConfigConstant.TimeFormat, DefaultValue = null, IsRequired = false)]
        public string TimeFormat
        {
            get
            {
                return SiteConfigConstant.IsEmpty(this[SiteConfigConstant.TimeFormat]) ? DefaultTimeFormat.ShortTimePattern : (string)this[SiteConfigConstant.TimeFormat];
            }
            set
            {
                this[SiteConfigConstant.TimeFormat] = value;
            }
        }

        [ConfigurationProperty(SiteConfigConstant.FirstDayOfWeek, DefaultValue = DayOfWeek.Monday, IsRequired = false)]
        public DayOfWeek FirstDayOfWeek
        {
            get
            {
                return (DayOfWeek)this[SiteConfigConstant.FirstDayOfWeek];
            }
            set
            {
                this[SiteConfigConstant.FirstDayOfWeek] = value;
            }
        }









    }


    public sealed class SiteSeoConfig : ConfigurationSection
    {
        internal const string SectionName = @"SiteSeoConfig";
        private static SiteSeoConfig _default;

        public static SiteSeoConfig Default
        {

            get
            {
                _default = _default ?? (SiteSeoConfig)System.Web.Configuration.WebConfigurationManager.GetSection(SectionName);
                return _default;
            }
        }

        //SeoPermission
      
    }
}
