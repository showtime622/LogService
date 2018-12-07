using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.IO;
using LogService.Model;
using log4net;
using System.Reflection;

namespace LogService
{
	public partial class LogService : ServiceBase
	{
		private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		private Timer tmr = new Timer();
		private bool isEvenDay = DateTime.Now.Day % 2 == 0;
		public DateConfig ConfigObj = new DateConfig();
		public LogService()
		{
			InitializeComponent();
			ConfigObj = DateConfig.LoadConfig();
		}

		protected override void OnStart(string[] args)
		{
			tmr.Interval = 1000;
			tmr.Enabled = true;
			tmr.Elapsed += Log;
		}

		protected override void OnStop()
		{
			tmr.Enabled = false;
		}
		
		void Log(object sender, ElapsedEventArgs arg)
		{
			string currentTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
			if (isEvenDay)
			{
				if(currentTime == ConfigObj.baseOnWorkDateTime)
				{
					//Run executive file to punch in 

					Random rand = new Random();
					int dealyMins = rand.Next(5, ConfigObj.OnWorkRange.afterMin);
					ConfigObj.OnWorkTomorrowOnWork = Convert.ToDateTime(ConfigObj.baseOnWorkDateTime).AddMinutes(dealyMins).ToString("hh:mm");
					DateConfig.UpdateConfig(ConfigObj);
				}
				else if(currentTime == ConfigObj.baseOnLeaveDatime)
				{
					//Run executive file to punch out

					Random rand = new Random();
					int dealyMins = rand.Next(5, ConfigObj.OnLeaveRange.afterMin);
					ConfigObj.OnLeaveTomorrow = Convert.ToDateTime(ConfigObj.baseOnLeaveDatime).AddMinutes(dealyMins).ToString("hh:mm");
					DateConfig.UpdateConfig(ConfigObj);
				}
			}
			else
			{
				if (currentTime == ConfigObj.OnWorkTomorrowOnWork)
				{
					//Run executive file to punch in 

					Random rand = new Random();
					int dealyMins = rand.Next(5, ConfigObj.OnWorkRange.afterMin);
					ConfigObj.baseOnWorkDateTime = Convert.ToDateTime(ConfigObj.OnWorkTomorrowOnWork).AddMinutes(dealyMins).ToString("hh:mm");
					DateConfig.UpdateConfig(ConfigObj);
				}
				else if (currentTime == ConfigObj.OnLeaveTomorrow)
				{
					//Run executive file to punch out

					Random rand = new Random();
					int dealyMins = rand.Next(5, ConfigObj.OnLeaveRange.afterMin);
					ConfigObj.baseOnLeaveDatime = Convert.ToDateTime(ConfigObj.OnLeaveTomorrow).AddMinutes(dealyMins).ToString("hh:mm");
					DateConfig.UpdateConfig(ConfigObj);
				}
			}
		}
	}
}
