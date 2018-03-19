using FCL.Cockerham.Ogsm.Data.Contracts;
using System;

namespace FCL.Cockerham.Ogsm.ClientSite.Core
{
    public class BasePage : System.Web.UI.Page
    {
        public IUnitOfWork DataRepositoryFactory { get; set; }

        protected override void OnLoad(EventArgs e)
        {            
            var containerTest = MvcApplication.baseContainer;
            DataRepositoryFactory = containerTest.GetExportedValue<IUnitOfWork>();
            base.OnLoad(e);
        }
    }
}