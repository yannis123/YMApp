

namespace YMApp.DocManage.Documents.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="DocumentAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class DocumentPermissions
	{
		/// <summary>
		/// Document权限节点
		///</summary>
		public const string Node = "Pages.Document";

		/// <summary>
		/// Document查询授权
		///</summary>
		public const string Query = "Pages.Document.Query";

		/// <summary>
		/// Document创建权限
		///</summary>
		public const string Create = "Pages.Document.Create";

		/// <summary>
		/// Document修改权限
		///</summary>
		public const string Edit = "Pages.Document.Edit";

		/// <summary>
		/// Document删除权限
		///</summary>
		public const string Delete = "Pages.Document.Delete";

        /// <summary>
		/// Document批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.Document.BatchDelete";

		/// <summary>
		/// Document导出Excel
		///</summary>
		public const string ExportExcel="Pages.Document.ExportExcel";

		 
		 
         
    }

}

