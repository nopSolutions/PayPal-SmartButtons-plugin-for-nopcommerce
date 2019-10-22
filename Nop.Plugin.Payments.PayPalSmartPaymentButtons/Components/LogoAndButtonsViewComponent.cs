using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Payments.PayPalSmartPaymentButtons.Components
{
    /// <summary>
    /// Represents the view component to display logo and buttons
    /// </summary>
    [ViewComponent(Name = Defaults.BUTTONS_VIEW_COMPONENT_NAME)]
    public class LogoAndButtonsViewComponent : NopViewComponent
    {
        #region Fields

        private readonly PayPalSmartPaymentButtonsSettings _settings;

        #endregion

        #region Ctor

        public LogoAndButtonsViewComponent(PayPalSmartPaymentButtonsSettings settings)
        {
            _settings = settings;
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
            if (!_settings.ButtonsWidgetZones.Contains(widgetZone))
                return Content(string.Empty);

            if (widgetZone.Equals(PublicWidgetZones.ProductDetailsAddInfo) ||
                widgetZone.Equals(PublicWidgetZones.OrderSummaryContentAfter))
            {
                return View("~/Plugins/Payments.PayPalSmartPaymentButtons/Views/Buttons.cshtml", widgetZone);
            }

            if (widgetZone.Equals(PublicWidgetZones.HeaderLinksBefore) ||
                widgetZone.Equals(PublicWidgetZones.Footer))
            {
                return View("~/Plugins/Payments.PayPalSmartPaymentButtons/Views/Logo.cshtml", widgetZone);
            }

            return Content(string.Empty);
        }

        #endregion
    }
}