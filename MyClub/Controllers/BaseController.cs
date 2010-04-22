using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Benzmann.Definitions;
using Benzmann.BuisnessLogic.MyClub;
using Benzmann.Definitions.Exceptions;
using Benzmann.Definitions.Services;
using Benzmann.BuisnessLogic;

namespace MyClub.Controllers
{
    [HandleError]
    public class BaseController : Controller
    {
        protected AppContext appContext;

        public BaseController() : base()
        {
            AppContext appContext = new AppContext();
            this.appContext = appContext;
        }

        public void Initialize()
        {
            string customerName = "ClubAmore";
            CustomerService customerService = appContext.GetService<CustomerService>(new GetIServiceFromCacheDelegate(this.GetServiceFromCache));
            try
            {
                Customer customer = customerService.GetByName(customerName);
                appContext.Customer = customer;
            }
            catch (Exception e)
            {
                this.appContext.Logger.ErrorFormat("BaseController->__construct() - Couldn't get Customer with the Name: {0}. Error Message: {1}", customerName, e.ToString());
            }
        }
        public object GetServiceFromCache(Type type)
        {
            string typeName = type.Name;
            Object service = this.HttpContext.Application[typeName];
            try
            {
                if (service == null)
                {
                    service = (Activator.CreateInstance(type, this.appContext.Logger)) as object;
                    this.HttpContext.Application[typeName] = service;
                    return service;
                }
                else
                    return service;
            }
            catch (Exception e)
            {
                this.appContext.CreateException<MyClubException>("BaseController->GetServiceFromCache() - Couldn't Loade the DAC: " + type.Name + " Exception Message: " + e.ToString());
                return null;
            }
        }
    }
}
