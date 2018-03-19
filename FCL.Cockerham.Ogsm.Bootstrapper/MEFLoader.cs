#region Header
///-------------------------------------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Cockerham.Ogsm.Bootstrapper
///MODULE        :         
///SUB MODULE    :    
///Class         : MefLoader
///AUTHOR        : Asela Chamara      
///CREATED       : 06/14/2015
///LAST EDITED   : 11/30/2015
///DESCRIPTION   : Purpose is to create the exported classes container for the application for Dependancy Injections 
///MODIFICATION HISTORY:  
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------------------------------------
#endregion

using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using FCL.Cockerham.Ogsm.Data;
using FCL.Web.Framework.Core.Common.Logger;
using FCL.Cockerham.Ogsm.Domain;

namespace FCL.Cockerham.Ogsm.Bootstrapper
{
    public static class MefLoader
    {
        public static CompositionContainer Init()
        {
            return Init(null);
        }

        public static CompositionContainer Init(ICollection<ComposablePartCatalog> catalogParts)
        {
            AggregateCatalog catalog = new AggregateCatalog();

            //VERY IMPORTANT - READ, READ, READ
            //Since we are using MEF (Managed Extensibility Framework), exported modules are loaded dynamically
            //This method should include ONLY ONE unique reference to an assembly that has exported services
            //If you include multiple types in the same assembly, MEF will load duplicate exports and it'll screw things up
            //Below example gives a reference to FCL.Cockerham.Ogsm.Data assembly and FCL.Web.Framework.Core.Common assembly.
            
            //search & load exports from FCL.Cockerham.Ogsm.Data
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(BaseRepository<>).Assembly));

            //search & load exports from FCL.Web.Framework.Core.Common
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Log4NetLoggerService).Assembly));

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(UserService).Assembly));

            if (catalogParts != null)
            {
                foreach (var part in catalogParts)
                {
                    //Add any controllers that has exported actions
                    catalog.Catalogs.Add(part);
                }
            }

            CompositionContainer container = new CompositionContainer(catalog);
            return container;
        }
    }
}
