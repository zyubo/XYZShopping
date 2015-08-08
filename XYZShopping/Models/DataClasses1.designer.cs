﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18052
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace XYZShopping.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="XYZShopping")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void Insertcart(cart instance);
    partial void Updatecart(cart instance);
    partial void Deletecart(cart instance);
    partial void Insertordered(ordered instance);
    partial void Updateordered(ordered instance);
    partial void Deleteordered(ordered instance);
    partial void Insertproducts(products instance);
    partial void Updateproducts(products instance);
    partial void Deleteproducts(products instance);
    partial void Insertusers(users instance);
    partial void Updateusers(users instance);
    partial void Deleteusers(users instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["XYZShoppingConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<cart> cart
		{
			get
			{
				return this.GetTable<cart>();
			}
		}
		
		public System.Data.Linq.Table<ordered> ordered
		{
			get
			{
				return this.GetTable<ordered>();
			}
		}
		
		public System.Data.Linq.Table<products> products
		{
			get
			{
				return this.GetTable<products>();
			}
		}
		
		public System.Data.Linq.Table<users> users
		{
			get
			{
				return this.GetTable<users>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.cart")]
	public partial class cart : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _email;
		
		private int _id;
		
		private int _pcount;
		
		private EntityRef<products> _products;
		
		private EntityRef<users> _users;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnpcountChanging(int value);
    partial void OnpcountChanged();
    #endregion
		
		public cart()
		{
			this._products = default(EntityRef<products>);
			this._users = default(EntityRef<users>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="NChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					if (this._users.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					if (this._products.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pcount", DbType="Int NOT NULL")]
		public int pcount
		{
			get
			{
				return this._pcount;
			}
			set
			{
				if ((this._pcount != value))
				{
					this.OnpcountChanging(value);
					this.SendPropertyChanging();
					this._pcount = value;
					this.SendPropertyChanged("pcount");
					this.OnpcountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="products_cart", Storage="_products", ThisKey="id", OtherKey="id", IsForeignKey=true)]
		public products products
		{
			get
			{
				return this._products.Entity;
			}
			set
			{
				products previousValue = this._products.Entity;
				if (((previousValue != value) 
							|| (this._products.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._products.Entity = null;
						previousValue.cart.Remove(this);
					}
					this._products.Entity = value;
					if ((value != null))
					{
						value.cart.Add(this);
						this._id = value.id;
					}
					else
					{
						this._id = default(int);
					}
					this.SendPropertyChanged("products");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="users_cart", Storage="_users", ThisKey="email", OtherKey="email", IsForeignKey=true)]
		public users users
		{
			get
			{
				return this._users.Entity;
			}
			set
			{
				users previousValue = this._users.Entity;
				if (((previousValue != value) 
							|| (this._users.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._users.Entity = null;
						previousValue.cart.Remove(this);
					}
					this._users.Entity = value;
					if ((value != null))
					{
						value.cart.Add(this);
						this._email = value.email;
					}
					else
					{
						this._email = default(string);
					}
					this.SendPropertyChanged("users");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ordered")]
	public partial class ordered : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _email;
		
		private int _id;
		
		private int _pcount;
		
		private int _orderid;
		
		private string _address;
		
		private bool _delivered;
		
		private float _cardnum;
		
		private string _arrive;
		
		private double _total;
		
		private EntityRef<products> _products;
		
		private EntityRef<users> _users;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnpcountChanging(int value);
    partial void OnpcountChanged();
    partial void OnorderidChanging(int value);
    partial void OnorderidChanged();
    partial void OnaddressChanging(string value);
    partial void OnaddressChanged();
    partial void OndeliveredChanging(bool value);
    partial void OndeliveredChanged();
    partial void OncardnumChanging(float value);
    partial void OncardnumChanged();
    partial void OnarriveChanging(string value);
    partial void OnarriveChanged();
    partial void OntotalChanging(double value);
    partial void OntotalChanged();
    #endregion
		
		public ordered()
		{
			this._products = default(EntityRef<products>);
			this._users = default(EntityRef<users>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					if (this._users.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL")]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					if (this._products.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pcount", DbType="Int NOT NULL")]
		public int pcount
		{
			get
			{
				return this._pcount;
			}
			set
			{
				if ((this._pcount != value))
				{
					this.OnpcountChanging(value);
					this.SendPropertyChanging();
					this._pcount = value;
					this.SendPropertyChanged("pcount");
					this.OnpcountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_orderid", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int orderid
		{
			get
			{
				return this._orderid;
			}
			set
			{
				if ((this._orderid != value))
				{
					this.OnorderidChanging(value);
					this.SendPropertyChanging();
					this._orderid = value;
					this.SendPropertyChanged("orderid");
					this.OnorderidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_address", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string address
		{
			get
			{
				return this._address;
			}
			set
			{
				if ((this._address != value))
				{
					this.OnaddressChanging(value);
					this.SendPropertyChanging();
					this._address = value;
					this.SendPropertyChanged("address");
					this.OnaddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_delivered", DbType="Bit NOT NULL")]
		public bool delivered
		{
			get
			{
				return this._delivered;
			}
			set
			{
				if ((this._delivered != value))
				{
					this.OndeliveredChanging(value);
					this.SendPropertyChanging();
					this._delivered = value;
					this.SendPropertyChanged("delivered");
					this.OndeliveredChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cardnum", DbType="Real NOT NULL")]
		public float cardnum
		{
			get
			{
				return this._cardnum;
			}
			set
			{
				if ((this._cardnum != value))
				{
					this.OncardnumChanging(value);
					this.SendPropertyChanging();
					this._cardnum = value;
					this.SendPropertyChanged("cardnum");
					this.OncardnumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_arrive", DbType="NChar(50) NOT NULL", CanBeNull=false)]
		public string arrive
		{
			get
			{
				return this._arrive;
			}
			set
			{
				if ((this._arrive != value))
				{
					this.OnarriveChanging(value);
					this.SendPropertyChanging();
					this._arrive = value;
					this.SendPropertyChanged("arrive");
					this.OnarriveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_total", DbType="Float NOT NULL")]
		public double total
		{
			get
			{
				return this._total;
			}
			set
			{
				if ((this._total != value))
				{
					this.OntotalChanging(value);
					this.SendPropertyChanging();
					this._total = value;
					this.SendPropertyChanged("total");
					this.OntotalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="products_ordered", Storage="_products", ThisKey="id", OtherKey="id", IsForeignKey=true)]
		public products products
		{
			get
			{
				return this._products.Entity;
			}
			set
			{
				products previousValue = this._products.Entity;
				if (((previousValue != value) 
							|| (this._products.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._products.Entity = null;
						previousValue.ordered.Remove(this);
					}
					this._products.Entity = value;
					if ((value != null))
					{
						value.ordered.Add(this);
						this._id = value.id;
					}
					else
					{
						this._id = default(int);
					}
					this.SendPropertyChanged("products");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="users_ordered", Storage="_users", ThisKey="email", OtherKey="email", IsForeignKey=true)]
		public users users
		{
			get
			{
				return this._users.Entity;
			}
			set
			{
				users previousValue = this._users.Entity;
				if (((previousValue != value) 
							|| (this._users.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._users.Entity = null;
						previousValue.ordered.Remove(this);
					}
					this._users.Entity = value;
					if ((value != null))
					{
						value.ordered.Add(this);
						this._email = value.email;
					}
					else
					{
						this._email = default(string);
					}
					this.SendPropertyChanged("users");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.products")]
	public partial class products : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _title;
		
		private int _available;
		
		private double _price;
		
		private string _image;
		
		private string _summary;
		
		private string _details;
		
		private EntitySet<cart> _cart;
		
		private EntitySet<ordered> _ordered;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OntitleChanging(string value);
    partial void OntitleChanged();
    partial void OnavailableChanging(int value);
    partial void OnavailableChanged();
    partial void OnpriceChanging(double value);
    partial void OnpriceChanged();
    partial void OnimageChanging(string value);
    partial void OnimageChanged();
    partial void OnsummaryChanging(string value);
    partial void OnsummaryChanged();
    partial void OndetailsChanging(string value);
    partial void OndetailsChanged();
    #endregion
		
		public products()
		{
			this._cart = new EntitySet<cart>(new Action<cart>(this.attach_cart), new Action<cart>(this.detach_cart));
			this._ordered = new EntitySet<ordered>(new Action<ordered>(this.attach_ordered), new Action<ordered>(this.detach_ordered));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_title", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string title
		{
			get
			{
				return this._title;
			}
			set
			{
				if ((this._title != value))
				{
					this.OntitleChanging(value);
					this.SendPropertyChanging();
					this._title = value;
					this.SendPropertyChanged("title");
					this.OntitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_available", DbType="Int NOT NULL")]
		public int available
		{
			get
			{
				return this._available;
			}
			set
			{
				if ((this._available != value))
				{
					this.OnavailableChanging(value);
					this.SendPropertyChanging();
					this._available = value;
					this.SendPropertyChanged("available");
					this.OnavailableChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_price", DbType="Float NOT NULL")]
		public double price
		{
			get
			{
				return this._price;
			}
			set
			{
				if ((this._price != value))
				{
					this.OnpriceChanging(value);
					this.SendPropertyChanging();
					this._price = value;
					this.SendPropertyChanged("price");
					this.OnpriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_image", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string image
		{
			get
			{
				return this._image;
			}
			set
			{
				if ((this._image != value))
				{
					this.OnimageChanging(value);
					this.SendPropertyChanging();
					this._image = value;
					this.SendPropertyChanged("image");
					this.OnimageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_summary", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string summary
		{
			get
			{
				return this._summary;
			}
			set
			{
				if ((this._summary != value))
				{
					this.OnsummaryChanging(value);
					this.SendPropertyChanging();
					this._summary = value;
					this.SendPropertyChanged("summary");
					this.OnsummaryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_details", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string details
		{
			get
			{
				return this._details;
			}
			set
			{
				if ((this._details != value))
				{
					this.OndetailsChanging(value);
					this.SendPropertyChanging();
					this._details = value;
					this.SendPropertyChanged("details");
					this.OndetailsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="products_cart", Storage="_cart", ThisKey="id", OtherKey="id")]
		public EntitySet<cart> cart
		{
			get
			{
				return this._cart;
			}
			set
			{
				this._cart.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="products_ordered", Storage="_ordered", ThisKey="id", OtherKey="id")]
		public EntitySet<ordered> ordered
		{
			get
			{
				return this._ordered;
			}
			set
			{
				this._ordered.Assign(value);
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
		
		private void attach_cart(cart entity)
		{
			this.SendPropertyChanging();
			entity.products = this;
		}
		
		private void detach_cart(cart entity)
		{
			this.SendPropertyChanging();
			entity.products = null;
		}
		
		private void attach_ordered(ordered entity)
		{
			this.SendPropertyChanging();
			entity.products = this;
		}
		
		private void detach_ordered(ordered entity)
		{
			this.SendPropertyChanging();
			entity.products = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.users")]
	public partial class users : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _username;
		
		private string _email;
		
		private string _password;
		
		private EntitySet<cart> _cart;
		
		private EntitySet<ordered> _ordered;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnusernameChanging(string value);
    partial void OnusernameChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OnpasswordChanging(string value);
    partial void OnpasswordChanged();
    #endregion
		
		public users()
		{
			this._cart = new EntitySet<cart>(new Action<cart>(this.attach_cart), new Action<cart>(this.detach_cart));
			this._ordered = new EntitySet<ordered>(new Action<ordered>(this.attach_ordered), new Action<ordered>(this.detach_ordered));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_username", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string username
		{
			get
			{
				return this._username;
			}
			set
			{
				if ((this._username != value))
				{
					this.OnusernameChanging(value);
					this.SendPropertyChanging();
					this._username = value;
					this.SendPropertyChanged("username");
					this.OnusernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="NChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this.OnpasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("password");
					this.OnpasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="users_cart", Storage="_cart", ThisKey="email", OtherKey="email")]
		public EntitySet<cart> cart
		{
			get
			{
				return this._cart;
			}
			set
			{
				this._cart.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="users_ordered", Storage="_ordered", ThisKey="email", OtherKey="email")]
		public EntitySet<ordered> ordered
		{
			get
			{
				return this._ordered;
			}
			set
			{
				this._ordered.Assign(value);
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
		
		private void attach_cart(cart entity)
		{
			this.SendPropertyChanging();
			entity.users = this;
		}
		
		private void detach_cart(cart entity)
		{
			this.SendPropertyChanging();
			entity.users = null;
		}
		
		private void attach_ordered(ordered entity)
		{
			this.SendPropertyChanging();
			entity.users = this;
		}
		
		private void detach_ordered(ordered entity)
		{
			this.SendPropertyChanging();
			entity.users = null;
		}
	}
}
#pragma warning restore 1591
