using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogService.Model
{
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class DateConfig
	{

		private string baseOnWorkDateTimeField;

		private string baseOnLeaveDatimeField;

		private string onWorkTomorrowOnWorkField;

		private string onLeaveTomorrowField;

		private DateConfigOnWorkRange onWorkRangeField;

		private DateConfigOnLeaveRange onLeaveRangeField;

		/// <remarks/>
		public string baseOnWorkDateTime
		{
			get
			{
				return this.baseOnWorkDateTimeField;
			}
			set
			{
				this.baseOnWorkDateTimeField = value;
			}
		}

		/// <remarks/>
		public string baseOnLeaveDatime
		{
			get
			{
				return this.baseOnLeaveDatimeField;
			}
			set
			{
				this.baseOnLeaveDatimeField = value;
			}
		}

		/// <remarks/>
		public string OnWorkTomorrowOnWork
		{
			get
			{
				return this.onWorkTomorrowOnWorkField;
			}
			set
			{
				this.onWorkTomorrowOnWorkField = value;
			}
		}

		/// <remarks/>
		public string OnLeaveTomorrow
		{
			get
			{
				return this.onLeaveTomorrowField;
			}
			set
			{
				this.onLeaveTomorrowField = value;
			}
		}

		/// <remarks/>
		public DateConfigOnWorkRange OnWorkRange
		{
			get
			{
				return this.onWorkRangeField;
			}
			set
			{
				this.onWorkRangeField = value;
			}
		}

		/// <remarks/>
		public DateConfigOnLeaveRange OnLeaveRange
		{
			get
			{
				return this.onLeaveRangeField;
			}
			set
			{
				this.onLeaveRangeField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DateConfigOnWorkRange
	{

		private byte beforeHourField;

		private byte afterHourField;

		private byte beforeMinField;

		private byte afterMinField;

		/// <remarks/>
		public byte beforeHour
		{
			get
			{
				return this.beforeHourField;
			}
			set
			{
				this.beforeHourField = value;
			}
		}

		/// <remarks/>
		public byte afterHour
		{
			get
			{
				return this.afterHourField;
			}
			set
			{
				this.afterHourField = value;
			}
		}

		/// <remarks/>
		public byte beforeMin
		{
			get
			{
				return this.beforeMinField;
			}
			set
			{
				this.beforeMinField = value;
			}
		}

		/// <remarks/>
		public byte afterMin
		{
			get
			{
				return this.afterMinField;
			}
			set
			{
				this.afterMinField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class DateConfigOnLeaveRange
	{

		private byte beforeField;

		private byte afterField;

		private byte beforeMinField;

		private byte afterMinField;

		/// <remarks/>
		public byte before
		{
			get
			{
				return this.beforeField;
			}
			set
			{
				this.beforeField = value;
			}
		}

		/// <remarks/>
		public byte after
		{
			get
			{
				return this.afterField;
			}
			set
			{
				this.afterField = value;
			}
		}

		/// <remarks/>
		public byte beforeMin
		{
			get
			{
				return this.beforeMinField;
			}
			set
			{
				this.beforeMinField = value;
			}
		}

		/// <remarks/>
		public byte afterMin
		{
			get
			{
				return this.afterMinField;
			}
			set
			{
				this.afterMinField = value;
			}
		}
	}



}
