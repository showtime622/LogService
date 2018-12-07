using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using log4net;
using System.Reflection;

namespace LogService.Model
{
	public partial class DateConfig
	{
		private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		private const string filePath = globalconfig.Config_Path;
		public static DateConfig LoadConfig(string path = filePath)
		{
			if(!File.Exists(path))
			{
				return DefaultDateConfig();
			}
			try
			{
				return Load(path);
			}
			catch(Exception ex)
			{
				Logger.Warn("Load config.xml " + ex);
				return DefaultDateConfig();
			}
		}

		public static void UpdateConfig(DateConfig dateConfig, string path = filePath)
		{
			using (TextWriter writer = new StreamWriter(path))
			{
				writer.Write(dateConfig);
			}
		}

		private static DateConfig Load(string filePath)
		{
			using (TextReader reader = new StreamReader(filePath))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(DateConfig));
				return (DateConfig)(serializer.Deserialize(reader));
			}
		}

		private static DateConfig DefaultDateConfig()
		{
			DateConfig obj = new DateConfig();
			obj.baseOnLeaveDatime = "09:00";
			obj.baseOnWorkDateTime = "18:00";
			obj.OnWorkTomorrowOnWork = "09:10";
			obj.OnLeaveTomorrow = "18:30";
			obj.OnWorkRange = new DateConfigOnWorkRange();
			obj.OnWorkRange.beforeHour = 1;
			obj.OnWorkRange.afterHour = 1;
			obj.OnWorkRange.beforeMin = 30;
			obj.OnWorkRange.afterMin = 30;
			obj.OnLeaveRange = new DateConfigOnLeaveRange();
			obj.OnLeaveRange.before = 1;
			obj.OnLeaveRange.after = 1;
			obj.OnLeaveRange.beforeMin = 30;
			obj.OnLeaveRange.afterMin = 30;
			return obj;
		}
	}
}
