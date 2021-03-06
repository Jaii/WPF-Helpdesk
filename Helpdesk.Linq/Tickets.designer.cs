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

namespace Helpdesk.Linq
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="helpdesk")]
	public partial class TicketsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InserttblCustomer(tblCustomer instance);
    partial void UpdatetblCustomer(tblCustomer instance);
    partial void DeletetblCustomer(tblCustomer instance);
    partial void InserttblTicket(tblTicket instance);
    partial void UpdatetblTicket(tblTicket instance);
    partial void DeletetblTicket(tblTicket instance);
    partial void InserttblDepartment(tblDepartment instance);
    partial void UpdatetblDepartment(tblDepartment instance);
    partial void DeletetblDepartment(tblDepartment instance);
    partial void InserttblEmployee(tblEmployee instance);
    partial void UpdatetblEmployee(tblEmployee instance);
    partial void DeletetblEmployee(tblEmployee instance);
    partial void InserttblStatuses(tblStatuses instance);
    partial void UpdatetblStatuses(tblStatuses instance);
    partial void DeletetblStatuses(tblStatuses instance);
    #endregion
		
		public TicketsDataContext() : 
				base(global::Helpdesk.Linq.Properties.Settings.Default.helpdeskConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public TicketsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TicketsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TicketsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TicketsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tblCustomer> tblCustomers
		{
			get
			{
				return this.GetTable<tblCustomer>();
			}
		}
		
		public System.Data.Linq.Table<tblTicket> tblTickets
		{
			get
			{
				return this.GetTable<tblTicket>();
			}
		}
		
		public System.Data.Linq.Table<tblDepartment> tblDepartments
		{
			get
			{
				return this.GetTable<tblDepartment>();
			}
		}
		
		public System.Data.Linq.Table<tblEmployee> tblEmployees
		{
			get
			{
				return this.GetTable<tblEmployee>();
			}
		}
		
		public System.Data.Linq.Table<tblStatuses> tblStatuses
		{
			get
			{
				return this.GetTable<tblStatuses>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetEverything")]
		public ISingleResult<GetEverythingResult> GetEverything()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<GetEverythingResult>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblCustomers")]
	public partial class tblCustomer : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _custID;
		
		private string _custName;
		
		private EntitySet<tblTicket> _tblTickets;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OncustIDChanging(System.Guid value);
    partial void OncustIDChanged();
    partial void OncustNameChanging(string value);
    partial void OncustNameChanged();
    #endregion
		
		public tblCustomer()
		{
			this._tblTickets = new EntitySet<tblTicket>(new Action<tblTicket>(this.attach_tblTickets), new Action<tblTicket>(this.detach_tblTickets));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_custID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid custID
		{
			get
			{
				return this._custID;
			}
			set
			{
				if ((this._custID != value))
				{
					this.OncustIDChanging(value);
					this.SendPropertyChanging();
					this._custID = value;
					this.SendPropertyChanged("custID");
					this.OncustIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_custName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string custName
		{
			get
			{
				return this._custName;
			}
			set
			{
				if ((this._custName != value))
				{
					this.OncustNameChanging(value);
					this.SendPropertyChanging();
					this._custName = value;
					this.SendPropertyChanged("custName");
					this.OncustNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblCustomer_tblTicket", Storage="_tblTickets", ThisKey="custID", OtherKey="custID")]
		public EntitySet<tblTicket> tblTickets
		{
			get
			{
				return this._tblTickets;
			}
			set
			{
				this._tblTickets.Assign(value);
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
		
		private void attach_tblTickets(tblTicket entity)
		{
			this.SendPropertyChanging();
			entity.tblCustomer = this;
		}
		
		private void detach_tblTickets(tblTicket entity)
		{
			this.SendPropertyChanging();
			entity.tblCustomer = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblTickets")]
	public partial class tblTicket : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _tixID;
		
		private string _tixNotes;
		
		private string _tixDateCreated;
		
		private string _tixAssignedTo;
		
		private string _tixDateCompleted;
		
		private string _tixLastContacted;
		
		private System.Guid _custID;
		
		private string _empSSN;
		
		private System.Guid _deptID;
		
		private System.Nullable<System.Guid> _statusID;
		
		private EntityRef<tblCustomer> _tblCustomer;
		
		private EntityRef<tblDepartment> _tblDepartment;
		
		private EntityRef<tblEmployee> _tblEmployee;
		
		private EntityRef<tblStatuses> _tblStatuses;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OntixIDChanging(System.Guid value);
    partial void OntixIDChanged();
    partial void OntixNotesChanging(string value);
    partial void OntixNotesChanged();
    partial void OntixDateCreatedChanging(string value);
    partial void OntixDateCreatedChanged();
    partial void OntixAssignedToChanging(string value);
    partial void OntixAssignedToChanged();
    partial void OntixDateCompletedChanging(string value);
    partial void OntixDateCompletedChanged();
    partial void OntixLastContactedChanging(string value);
    partial void OntixLastContactedChanged();
    partial void OncustIDChanging(System.Guid value);
    partial void OncustIDChanged();
    partial void OnempSSNChanging(string value);
    partial void OnempSSNChanged();
    partial void OndeptIDChanging(System.Guid value);
    partial void OndeptIDChanged();
    partial void OnstatusIDChanging(System.Nullable<System.Guid> value);
    partial void OnstatusIDChanged();
    #endregion
		
		public tblTicket()
		{
			this._tblCustomer = default(EntityRef<tblCustomer>);
			this._tblDepartment = default(EntityRef<tblDepartment>);
			this._tblEmployee = default(EntityRef<tblEmployee>);
			this._tblStatuses = default(EntityRef<tblStatuses>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tixID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid tixID
		{
			get
			{
				return this._tixID;
			}
			set
			{
				if ((this._tixID != value))
				{
					this.OntixIDChanging(value);
					this.SendPropertyChanging();
					this._tixID = value;
					this.SendPropertyChanged("tixID");
					this.OntixIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tixNotes", DbType="VarChar(MAX)")]
		public string tixNotes
		{
			get
			{
				return this._tixNotes;
			}
			set
			{
				if ((this._tixNotes != value))
				{
					this.OntixNotesChanging(value);
					this.SendPropertyChanging();
					this._tixNotes = value;
					this.SendPropertyChanged("tixNotes");
					this.OntixNotesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tixDateCreated", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string tixDateCreated
		{
			get
			{
				return this._tixDateCreated;
			}
			set
			{
				if ((this._tixDateCreated != value))
				{
					this.OntixDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._tixDateCreated = value;
					this.SendPropertyChanged("tixDateCreated");
					this.OntixDateCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tixAssignedTo", DbType="VarChar(50)")]
		public string tixAssignedTo
		{
			get
			{
				return this._tixAssignedTo;
			}
			set
			{
				if ((this._tixAssignedTo != value))
				{
					this.OntixAssignedToChanging(value);
					this.SendPropertyChanging();
					this._tixAssignedTo = value;
					this.SendPropertyChanged("tixAssignedTo");
					this.OntixAssignedToChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tixDateCompleted", DbType="VarChar(50)")]
		public string tixDateCompleted
		{
			get
			{
				return this._tixDateCompleted;
			}
			set
			{
				if ((this._tixDateCompleted != value))
				{
					this.OntixDateCompletedChanging(value);
					this.SendPropertyChanging();
					this._tixDateCompleted = value;
					this.SendPropertyChanged("tixDateCompleted");
					this.OntixDateCompletedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tixLastContacted", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string tixLastContacted
		{
			get
			{
				return this._tixLastContacted;
			}
			set
			{
				if ((this._tixLastContacted != value))
				{
					this.OntixLastContactedChanging(value);
					this.SendPropertyChanging();
					this._tixLastContacted = value;
					this.SendPropertyChanged("tixLastContacted");
					this.OntixLastContactedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_custID", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid custID
		{
			get
			{
				return this._custID;
			}
			set
			{
				if ((this._custID != value))
				{
					if (this._tblCustomer.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OncustIDChanging(value);
					this.SendPropertyChanging();
					this._custID = value;
					this.SendPropertyChanged("custID");
					this.OncustIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_empSSN", DbType="VarChar(15)")]
		public string empSSN
		{
			get
			{
				return this._empSSN;
			}
			set
			{
				if ((this._empSSN != value))
				{
					if (this._tblEmployee.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnempSSNChanging(value);
					this.SendPropertyChanging();
					this._empSSN = value;
					this.SendPropertyChanged("empSSN");
					this.OnempSSNChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deptID", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid deptID
		{
			get
			{
				return this._deptID;
			}
			set
			{
				if ((this._deptID != value))
				{
					if (this._tblDepartment.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OndeptIDChanging(value);
					this.SendPropertyChanging();
					this._deptID = value;
					this.SendPropertyChanged("deptID");
					this.OndeptIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_statusID", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> statusID
		{
			get
			{
				return this._statusID;
			}
			set
			{
				if ((this._statusID != value))
				{
					if (this._tblStatuses.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnstatusIDChanging(value);
					this.SendPropertyChanging();
					this._statusID = value;
					this.SendPropertyChanged("statusID");
					this.OnstatusIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblCustomer_tblTicket", Storage="_tblCustomer", ThisKey="custID", OtherKey="custID", IsForeignKey=true)]
		public tblCustomer tblCustomer
		{
			get
			{
				return this._tblCustomer.Entity;
			}
			set
			{
				tblCustomer previousValue = this._tblCustomer.Entity;
				if (((previousValue != value) 
							|| (this._tblCustomer.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tblCustomer.Entity = null;
						previousValue.tblTickets.Remove(this);
					}
					this._tblCustomer.Entity = value;
					if ((value != null))
					{
						value.tblTickets.Add(this);
						this._custID = value.custID;
					}
					else
					{
						this._custID = default(System.Guid);
					}
					this.SendPropertyChanged("tblCustomer");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblDepartment_tblTicket", Storage="_tblDepartment", ThisKey="deptID", OtherKey="deptID", IsForeignKey=true)]
		public tblDepartment tblDepartment
		{
			get
			{
				return this._tblDepartment.Entity;
			}
			set
			{
				tblDepartment previousValue = this._tblDepartment.Entity;
				if (((previousValue != value) 
							|| (this._tblDepartment.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tblDepartment.Entity = null;
						previousValue.tblTickets.Remove(this);
					}
					this._tblDepartment.Entity = value;
					if ((value != null))
					{
						value.tblTickets.Add(this);
						this._deptID = value.deptID;
					}
					else
					{
						this._deptID = default(System.Guid);
					}
					this.SendPropertyChanged("tblDepartment");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblEmployee_tblTicket", Storage="_tblEmployee", ThisKey="empSSN", OtherKey="empSSN", IsForeignKey=true)]
		public tblEmployee tblEmployee
		{
			get
			{
				return this._tblEmployee.Entity;
			}
			set
			{
				tblEmployee previousValue = this._tblEmployee.Entity;
				if (((previousValue != value) 
							|| (this._tblEmployee.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tblEmployee.Entity = null;
						previousValue.tblTickets.Remove(this);
					}
					this._tblEmployee.Entity = value;
					if ((value != null))
					{
						value.tblTickets.Add(this);
						this._empSSN = value.empSSN;
					}
					else
					{
						this._empSSN = default(string);
					}
					this.SendPropertyChanged("tblEmployee");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblStatuses_tblTicket", Storage="_tblStatuses", ThisKey="statusID", OtherKey="statusID", IsForeignKey=true)]
		public tblStatuses tblStatuses
		{
			get
			{
				return this._tblStatuses.Entity;
			}
			set
			{
				tblStatuses previousValue = this._tblStatuses.Entity;
				if (((previousValue != value) 
							|| (this._tblStatuses.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tblStatuses.Entity = null;
						previousValue.tblTickets.Remove(this);
					}
					this._tblStatuses.Entity = value;
					if ((value != null))
					{
						value.tblTickets.Add(this);
						this._statusID = value.statusID;
					}
					else
					{
						this._statusID = default(Nullable<System.Guid>);
					}
					this.SendPropertyChanged("tblStatuses");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblDepartments")]
	public partial class tblDepartment : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _deptID;
		
		private string _deptDescription;
		
		private EntitySet<tblTicket> _tblTickets;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OndeptIDChanging(System.Guid value);
    partial void OndeptIDChanged();
    partial void OndeptDescriptionChanging(string value);
    partial void OndeptDescriptionChanged();
    #endregion
		
		public tblDepartment()
		{
			this._tblTickets = new EntitySet<tblTicket>(new Action<tblTicket>(this.attach_tblTickets), new Action<tblTicket>(this.detach_tblTickets));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deptID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid deptID
		{
			get
			{
				return this._deptID;
			}
			set
			{
				if ((this._deptID != value))
				{
					this.OndeptIDChanging(value);
					this.SendPropertyChanging();
					this._deptID = value;
					this.SendPropertyChanged("deptID");
					this.OndeptIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deptDescription", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string deptDescription
		{
			get
			{
				return this._deptDescription;
			}
			set
			{
				if ((this._deptDescription != value))
				{
					this.OndeptDescriptionChanging(value);
					this.SendPropertyChanging();
					this._deptDescription = value;
					this.SendPropertyChanged("deptDescription");
					this.OndeptDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblDepartment_tblTicket", Storage="_tblTickets", ThisKey="deptID", OtherKey="deptID")]
		public EntitySet<tblTicket> tblTickets
		{
			get
			{
				return this._tblTickets;
			}
			set
			{
				this._tblTickets.Assign(value);
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
		
		private void attach_tblTickets(tblTicket entity)
		{
			this.SendPropertyChanging();
			entity.tblDepartment = this;
		}
		
		private void detach_tblTickets(tblTicket entity)
		{
			this.SendPropertyChanging();
			entity.tblDepartment = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblEmployees")]
	public partial class tblEmployee : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _empSSN;
		
		private string _empName;
		
		private string _empDept;
		
		private EntitySet<tblTicket> _tblTickets;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnempSSNChanging(string value);
    partial void OnempSSNChanged();
    partial void OnempNameChanging(string value);
    partial void OnempNameChanged();
    partial void OnempDeptChanging(string value);
    partial void OnempDeptChanged();
    #endregion
		
		public tblEmployee()
		{
			this._tblTickets = new EntitySet<tblTicket>(new Action<tblTicket>(this.attach_tblTickets), new Action<tblTicket>(this.detach_tblTickets));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_empSSN", DbType="VarChar(15) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string empSSN
		{
			get
			{
				return this._empSSN;
			}
			set
			{
				if ((this._empSSN != value))
				{
					this.OnempSSNChanging(value);
					this.SendPropertyChanging();
					this._empSSN = value;
					this.SendPropertyChanged("empSSN");
					this.OnempSSNChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_empName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string empName
		{
			get
			{
				return this._empName;
			}
			set
			{
				if ((this._empName != value))
				{
					this.OnempNameChanging(value);
					this.SendPropertyChanging();
					this._empName = value;
					this.SendPropertyChanged("empName");
					this.OnempNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_empDept", DbType="VarChar(50)")]
		public string empDept
		{
			get
			{
				return this._empDept;
			}
			set
			{
				if ((this._empDept != value))
				{
					this.OnempDeptChanging(value);
					this.SendPropertyChanging();
					this._empDept = value;
					this.SendPropertyChanged("empDept");
					this.OnempDeptChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblEmployee_tblTicket", Storage="_tblTickets", ThisKey="empSSN", OtherKey="empSSN")]
		public EntitySet<tblTicket> tblTickets
		{
			get
			{
				return this._tblTickets;
			}
			set
			{
				this._tblTickets.Assign(value);
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
		
		private void attach_tblTickets(tblTicket entity)
		{
			this.SendPropertyChanging();
			entity.tblEmployee = this;
		}
		
		private void detach_tblTickets(tblTicket entity)
		{
			this.SendPropertyChanging();
			entity.tblEmployee = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblStatuses")]
	public partial class tblStatuses : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _statusID;
		
		private string _statusName;
		
		private string _statusDescription;
		
		private EntitySet<tblTicket> _tblTickets;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnstatusIDChanging(System.Guid value);
    partial void OnstatusIDChanged();
    partial void OnstatusNameChanging(string value);
    partial void OnstatusNameChanged();
    partial void OnstatusDescriptionChanging(string value);
    partial void OnstatusDescriptionChanged();
    #endregion
		
		public tblStatuses()
		{
			this._tblTickets = new EntitySet<tblTicket>(new Action<tblTicket>(this.attach_tblTickets), new Action<tblTicket>(this.detach_tblTickets));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_statusID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid statusID
		{
			get
			{
				return this._statusID;
			}
			set
			{
				if ((this._statusID != value))
				{
					this.OnstatusIDChanging(value);
					this.SendPropertyChanging();
					this._statusID = value;
					this.SendPropertyChanged("statusID");
					this.OnstatusIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_statusName", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string statusName
		{
			get
			{
				return this._statusName;
			}
			set
			{
				if ((this._statusName != value))
				{
					this.OnstatusNameChanging(value);
					this.SendPropertyChanging();
					this._statusName = value;
					this.SendPropertyChanged("statusName");
					this.OnstatusNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_statusDescription", DbType="VarChar(255)")]
		public string statusDescription
		{
			get
			{
				return this._statusDescription;
			}
			set
			{
				if ((this._statusDescription != value))
				{
					this.OnstatusDescriptionChanging(value);
					this.SendPropertyChanging();
					this._statusDescription = value;
					this.SendPropertyChanged("statusDescription");
					this.OnstatusDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblStatuses_tblTicket", Storage="_tblTickets", ThisKey="statusID", OtherKey="statusID")]
		public EntitySet<tblTicket> tblTickets
		{
			get
			{
				return this._tblTickets;
			}
			set
			{
				this._tblTickets.Assign(value);
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
		
		private void attach_tblTickets(tblTicket entity)
		{
			this.SendPropertyChanging();
			entity.tblStatuses = this;
		}
		
		private void detach_tblTickets(tblTicket entity)
		{
			this.SendPropertyChanging();
			entity.tblStatuses = null;
		}
	}
	
	public partial class GetEverythingResult
	{
		
		private System.Guid _tixID;
		
		private string _tixNotes;
		
		private string _tixDateCreated;
		
		private string _tixAssignedTo;
		
		private string _tixDateCompleted;
		
		private string _tixLastContacted;
		
		private System.Guid _custID;
		
		private string _empSSN;
		
		private System.Guid _deptID;
		
		private System.Nullable<System.Guid> _statusID;
		
		private System.Guid _custID1;
		
		private string _custName;
		
		private System.Guid _deptID1;
		
		private string _deptDescription;
		
		private string _empSSN1;
		
		private string _empName;
		
		private string _empDept;
		
		public GetEverythingResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tixID", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid tixID
		{
			get
			{
				return this._tixID;
			}
			set
			{
				if ((this._tixID != value))
				{
					this._tixID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tixNotes", DbType="VarChar(MAX)")]
		public string tixNotes
		{
			get
			{
				return this._tixNotes;
			}
			set
			{
				if ((this._tixNotes != value))
				{
					this._tixNotes = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tixDateCreated", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string tixDateCreated
		{
			get
			{
				return this._tixDateCreated;
			}
			set
			{
				if ((this._tixDateCreated != value))
				{
					this._tixDateCreated = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tixAssignedTo", DbType="VarChar(50)")]
		public string tixAssignedTo
		{
			get
			{
				return this._tixAssignedTo;
			}
			set
			{
				if ((this._tixAssignedTo != value))
				{
					this._tixAssignedTo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tixDateCompleted", DbType="VarChar(50)")]
		public string tixDateCompleted
		{
			get
			{
				return this._tixDateCompleted;
			}
			set
			{
				if ((this._tixDateCompleted != value))
				{
					this._tixDateCompleted = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tixLastContacted", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string tixLastContacted
		{
			get
			{
				return this._tixLastContacted;
			}
			set
			{
				if ((this._tixLastContacted != value))
				{
					this._tixLastContacted = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_custID", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid custID
		{
			get
			{
				return this._custID;
			}
			set
			{
				if ((this._custID != value))
				{
					this._custID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_empSSN", DbType="VarChar(15)")]
		public string empSSN
		{
			get
			{
				return this._empSSN;
			}
			set
			{
				if ((this._empSSN != value))
				{
					this._empSSN = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deptID", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid deptID
		{
			get
			{
				return this._deptID;
			}
			set
			{
				if ((this._deptID != value))
				{
					this._deptID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_statusID", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> statusID
		{
			get
			{
				return this._statusID;
			}
			set
			{
				if ((this._statusID != value))
				{
					this._statusID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_custID1", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid custID1
		{
			get
			{
				return this._custID1;
			}
			set
			{
				if ((this._custID1 != value))
				{
					this._custID1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_custName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string custName
		{
			get
			{
				return this._custName;
			}
			set
			{
				if ((this._custName != value))
				{
					this._custName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deptID1", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid deptID1
		{
			get
			{
				return this._deptID1;
			}
			set
			{
				if ((this._deptID1 != value))
				{
					this._deptID1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deptDescription", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string deptDescription
		{
			get
			{
				return this._deptDescription;
			}
			set
			{
				if ((this._deptDescription != value))
				{
					this._deptDescription = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_empSSN1", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string empSSN1
		{
			get
			{
				return this._empSSN1;
			}
			set
			{
				if ((this._empSSN1 != value))
				{
					this._empSSN1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_empName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string empName
		{
			get
			{
				return this._empName;
			}
			set
			{
				if ((this._empName != value))
				{
					this._empName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_empDept", DbType="VarChar(50)")]
		public string empDept
		{
			get
			{
				return this._empDept;
			}
			set
			{
				if ((this._empDept != value))
				{
					this._empDept = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
