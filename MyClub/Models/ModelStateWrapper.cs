using System;
using System.Collections.Generic;
using System.Web;
using HP.IPS.Backbone.Entities.BackOffice;
using HP.IPS.Backbone.Services.BackOffice.WebUI.Classes;
using HP.IPS.Backbone.Entities.BackOffice.Services;
using HP.IPS.Backbone.SDK.Server.BackOffice;
using System.Web.Mvc;

namespace HP.IPS.Backbone.Services.BackOffice.WebUI.Models
{
    public class ModelStateWrapper : IValidationDictionary
    {
        private ModelStateDictionary modelState;
        private TranslationService translationService;

        public ModelStateWrapper(ModelStateDictionary modelState)
        {
            this.translationService = SessionHelper.GetAppContext().GetService<TranslationService>();
            this.modelState = modelState;
        }

        public void AddError(string key, string errorMessage)
        {
            modelState.AddModelError(key, translationService.Get(errorMessage));
        }

        public void AddError(string key, string errorMessage, Dictionary<string, object> param)
        {
            modelState.AddModelError(key, translationService.Get(errorMessage, param));
        }

        public bool IsValid()
        {
            return modelState.IsValid;
        }
    }
}
