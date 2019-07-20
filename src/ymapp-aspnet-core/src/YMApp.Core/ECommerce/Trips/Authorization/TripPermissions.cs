

namespace YMApp.ECommerce.Trips.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="TripAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class TripPermissions
	{
		/// <summary>
		/// Trip权限节点
		///</summary>
		public const string Node = "Pages.Trip";

		/// <summary>
		/// Trip查询授权
		///</summary>
		public const string Query = "Pages.Trip.Query";

		/// <summary>
		/// Trip创建权限
		///</summary>
		public const string Create = "Pages.Trip.Create";

		/// <summary>
		/// Trip修改权限
		///</summary>
		public const string Edit = "Pages.Trip.Edit";

		/// <summary>
		/// Trip删除权限
		///</summary>
		public const string Delete = "Pages.Trip.Delete";

        /// <summary>
		/// Trip批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.Trip.BatchDelete";

		/// <summary>
		/// Trip导出Excel
		///</summary>
		public const string ExportExcel="Pages.Trip.ExportExcel";

		 
		 
         
    }

}

