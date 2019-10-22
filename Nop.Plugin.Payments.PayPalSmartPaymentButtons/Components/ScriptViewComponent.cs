using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Payments.PayPalSmartPaymentButtons.Models;
using Nop.Plugin.Payments.PayPalSmartPaymentButtons.Services;
using Nop.Web.Framework.Components;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Payments.PayPalSmartPaymentButtons.Components
{
    /// <summary>
    /// Represents the view component to add script to pages
    /// </summary>
    [ViewComponent(Name = Defaults.SCRIPT_VIEW_COMPONENT_NAME)]
    public class ScriptViewComponent : NopViewComponent
    {
        #region Fields

        private readonly ServiceManager _serviceManager;

        #endregion

        #region Ctor

        public ScriptViewComponent(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoke view component
        /// </summary>
        /// <param name="widgetZone">Widget zone name</param>
        /// <param name="additionalData">Additional data</param>
        /// <returns>View component result</returns>
        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            if (!widgetZone.Equals(PublicWidgetZones.CheckoutPaymentInfoTop) &&
                !widgetZone.Equals(PublicWidgetZones.OpcContentBefore) &&
                !widgetZone.Equals(PublicWidgetZones.ProductDetailsTop) &&
                !widgetZone.Equals(PublicWidgetZones.OrderSummaryContentBefore))
            {
                return Content(string.Empty);
            }

            var model = new ScriptModel { ScriptUrl = _serviceManager.GetScriptUrl() };
            return View("~/Plugins/Payments.PayPalSmartPaymentButtons/Views/Script.cshtml", model);
        }

        #endregion
    }
}