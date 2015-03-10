﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TCSAService.Model
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TCS")]
	public partial class DatabaseDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertActionLog(ActionLog instance);
    partial void UpdateActionLog(ActionLog instance);
    partial void DeleteActionLog(ActionLog instance);
    partial void InsertTraffic(Traffic instance);
    partial void UpdateTraffic(Traffic instance);
    partial void DeleteTraffic(Traffic instance);
    #endregion
		
		public DatabaseDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["TCSConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ActionLog> ActionLogs
		{
			get
			{
				return this.GetTable<ActionLog>();
			}
		}
		
		public System.Data.Linq.Table<Traffic> Traffics
		{
			get
			{
				return this.GetTable<Traffic>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.actionLog")]
	public partial class ActionLog : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _action;
		
		private System.Nullable<System.DateTime> _date;
		
		private System.Nullable<int> _recordId;
		
		private string _lastValue;
		
		private EntityRef<Traffic> _Traffic;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnactionChanging(string value);
    partial void OnactionChanged();
    partial void OndateChanging(System.Nullable<System.DateTime> value);
    partial void OndateChanged();
    partial void OnrecordIdChanging(System.Nullable<int> value);
    partial void OnrecordIdChanged();
    partial void OnlastValueChanging(string value);
    partial void OnlastValueChanged();
    #endregion
		
		public ActionLog()
		{
			this._Traffic = default(EntityRef<Traffic>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_action", DbType="NVarChar(10)")]
		public string action
		{
			get
			{
				return this._action;
			}
			set
			{
				if ((this._action != value))
				{
					this.OnactionChanging(value);
					this.SendPropertyChanging();
					this._action = value;
					this.SendPropertyChanged("action");
					this.OnactionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date", DbType="DateTime")]
		public System.Nullable<System.DateTime> date
		{
			get
			{
				return this._date;
			}
			set
			{
				if ((this._date != value))
				{
					this.OndateChanging(value);
					this.SendPropertyChanging();
					this._date = value;
					this.SendPropertyChanged("date");
					this.OndateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_recordId", DbType="Int")]
		public System.Nullable<int> recordId
		{
			get
			{
				return this._recordId;
			}
			set
			{
				if ((this._recordId != value))
				{
					if (this._Traffic.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnrecordIdChanging(value);
					this.SendPropertyChanging();
					this._recordId = value;
					this.SendPropertyChanged("recordId");
					this.OnrecordIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lastValue", DbType="NVarChar(10)")]
		public string lastValue
		{
			get
			{
				return this._lastValue;
			}
			set
			{
				if ((this._lastValue != value))
				{
					this.OnlastValueChanging(value);
					this.SendPropertyChanging();
					this._lastValue = value;
					this.SendPropertyChanged("lastValue");
					this.OnlastValueChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Traffic_ActionLog", Storage="_Traffic", ThisKey="recordId", OtherKey="Id", IsForeignKey=true)]
		public Traffic Traffic
		{
			get
			{
				return this._Traffic.Entity;
			}
			set
			{
				Traffic previousValue = this._Traffic.Entity;
				if (((previousValue != value) 
							|| (this._Traffic.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Traffic.Entity = null;
						previousValue.ActionLogs.Remove(this);
					}
					this._Traffic.Entity = value;
					if ((value != null))
					{
						value.ActionLogs.Add(this);
						this._recordId = value.Id;
					}
					else
					{
						this._recordId = default(Nullable<int>);
					}
					this.SendPropertyChanged("Traffic");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.traffic")]
	public partial class Traffic : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Nullable<System.DateTime> _insertDate;
		
		private string _recordDate;
		
		private string _recordTime;
		
		private string _detectedPlatePersian;
		
		private string _recordId;
		
		private string _detectedPlateEnglish;
		
		private string _agentId;
		
		private System.Nullable<bool> _state;
		
		private System.Nullable<System.DateTime> _lastModifiedDate;
		
		private EntitySet<ActionLog> _ActionLogs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OninsertDateChanging(System.Nullable<System.DateTime> value);
    partial void OninsertDateChanged();
    partial void OnrecordDateChanging(string value);
    partial void OnrecordDateChanged();
    partial void OnrecordTimeChanging(string value);
    partial void OnrecordTimeChanged();
    partial void OndetectedPlatePersianChanging(string value);
    partial void OndetectedPlatePersianChanged();
    partial void OnrecordIdChanging(string value);
    partial void OnrecordIdChanged();
    partial void OndetectedPlateEnglishChanging(string value);
    partial void OndetectedPlateEnglishChanged();
    partial void OnagentIdChanging(string value);
    partial void OnagentIdChanged();
    partial void OnstateChanging(System.Nullable<bool> value);
    partial void OnstateChanged();
    partial void OnlastModifiedDateChanging(System.Nullable<System.DateTime> value);
    partial void OnlastModifiedDateChanged();
    #endregion
		
		public Traffic()
		{
			this._ActionLogs = new EntitySet<ActionLog>(new Action<ActionLog>(this.attach_ActionLogs), new Action<ActionLog>(this.detach_ActionLogs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_insertDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> insertDate
		{
			get
			{
				return this._insertDate;
			}
			set
			{
				if ((this._insertDate != value))
				{
					this.OninsertDateChanging(value);
					this.SendPropertyChanging();
					this._insertDate = value;
					this.SendPropertyChanged("insertDate");
					this.OninsertDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_recordDate", DbType="NVarChar(10)")]
		public string recordDate
		{
			get
			{
				return this._recordDate;
			}
			set
			{
				if ((this._recordDate != value))
				{
					this.OnrecordDateChanging(value);
					this.SendPropertyChanging();
					this._recordDate = value;
					this.SendPropertyChanged("recordDate");
					this.OnrecordDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_recordTime", DbType="NVarChar(10)")]
		public string recordTime
		{
			get
			{
				return this._recordTime;
			}
			set
			{
				if ((this._recordTime != value))
				{
					this.OnrecordTimeChanging(value);
					this.SendPropertyChanging();
					this._recordTime = value;
					this.SendPropertyChanged("recordTime");
					this.OnrecordTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_detectedPlatePersian", DbType="NVarChar(10)")]
		public string detectedPlatePersian
		{
			get
			{
				return this._detectedPlatePersian;
			}
			set
			{
				if ((this._detectedPlatePersian != value))
				{
					this.OndetectedPlatePersianChanging(value);
					this.SendPropertyChanging();
					this._detectedPlatePersian = value;
					this.SendPropertyChanged("detectedPlatePersian");
					this.OndetectedPlatePersianChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_recordId", DbType="NVarChar(20)")]
		public string recordId
		{
			get
			{
				return this._recordId;
			}
			set
			{
				if ((this._recordId != value))
				{
					this.OnrecordIdChanging(value);
					this.SendPropertyChanging();
					this._recordId = value;
					this.SendPropertyChanged("recordId");
					this.OnrecordIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_detectedPlateEnglish", DbType="NVarChar(10)")]
		public string detectedPlateEnglish
		{
			get
			{
				return this._detectedPlateEnglish;
			}
			set
			{
				if ((this._detectedPlateEnglish != value))
				{
					this.OndetectedPlateEnglishChanging(value);
					this.SendPropertyChanging();
					this._detectedPlateEnglish = value;
					this.SendPropertyChanged("detectedPlateEnglish");
					this.OndetectedPlateEnglishChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_agentId", DbType="NVarChar(50)")]
		public string agentId
		{
			get
			{
				return this._agentId;
			}
			set
			{
				if ((this._agentId != value))
				{
					this.OnagentIdChanging(value);
					this.SendPropertyChanging();
					this._agentId = value;
					this.SendPropertyChanged("agentId");
					this.OnagentIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_state", DbType="Bit")]
		public System.Nullable<bool> state
		{
			get
			{
				return this._state;
			}
			set
			{
				if ((this._state != value))
				{
					this.OnstateChanging(value);
					this.SendPropertyChanging();
					this._state = value;
					this.SendPropertyChanged("state");
					this.OnstateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lastModifiedDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> lastModifiedDate
		{
			get
			{
				return this._lastModifiedDate;
			}
			set
			{
				if ((this._lastModifiedDate != value))
				{
					this.OnlastModifiedDateChanging(value);
					this.SendPropertyChanging();
					this._lastModifiedDate = value;
					this.SendPropertyChanged("lastModifiedDate");
					this.OnlastModifiedDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Traffic_ActionLog", Storage="_ActionLogs", ThisKey="Id", OtherKey="recordId")]
		public EntitySet<ActionLog> ActionLogs
		{
			get
			{
				return this._ActionLogs;
			}
			set
			{
				this._ActionLogs.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ActionLogs(ActionLog entity)
		{
			this.SendPropertyChanging();
			entity.Traffic = this;
		}
		
		private void detach_ActionLogs(ActionLog entity)
		{
			this.SendPropertyChanging();
			entity.Traffic = null;
		}
	}
}
#pragma warning restore 1591
