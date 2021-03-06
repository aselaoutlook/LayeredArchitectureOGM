﻿using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class ScorecardPerspectiveRepository : BaseRepository<ScorecardPerspective>, IScorecardPerspectiveRepository
    {
        public ScorecardPerspectiveRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}