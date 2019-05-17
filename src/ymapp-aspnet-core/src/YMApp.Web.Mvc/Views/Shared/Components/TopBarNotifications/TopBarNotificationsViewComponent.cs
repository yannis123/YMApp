using Microsoft.AspNetCore.Mvc;

namespace YMApp.Web.Views.Shared.Components.TopBarNotifications
{
    public class TopBarNotificationsViewComponent : YMAppViewComponent
    {
 
        public TopBarNotificationsViewComponent()
        {
        
        }

        public IViewComponentResult Invoke()
        {
         

            return View();
        }
    }
}
