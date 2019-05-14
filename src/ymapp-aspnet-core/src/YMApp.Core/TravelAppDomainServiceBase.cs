

using Abp.Domain.Services;
using YMApp;

namespace YMApp
{
	public abstract class YMAppDomainServiceBase : DomainService
	{
		/* Add your common members for all your domain services. */
		/*在领域服务中添加你的自定义公共方法*/





		protected YMAppDomainServiceBase()
		{
			LocalizationSourceName = YMAppConsts.LocalizationSourceName;
		}
	}
}
