#region Header
///-------------------------------------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Cockerham.Ogsm.Data.Data_Repositories
///MODULE        :         
///SUB MODULE    :    
///Class         : UserRepository
///AUTHOR        : Asela Chamara      
///CREATED       : 05/10/2015
///LAST EDITED   : 11/28/2015
///DESCRIPTION   : Purpose is to provide a repository class to override existing BaseRepository methods or create specific 
///              : methods to save/ mofyfy/ retrive data related to FCL.Cockerham.Ogsm.Entities.User entity   
///MODIFICATION HISTORY:  V2
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------------------------------------
#endregion

using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class FiscalYearRepository : BaseRepository<FiscalYear>, IFiscalYearRepository
    {
        public FiscalYearRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}
