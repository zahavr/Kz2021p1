﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model;

namespace WebApplication1.EfStuff.Repositoryies
{
    public class dayOfWeekRepository: BaseRepository<dayOfWeek>
    {
        public dayOfWeekRepository(KzDbContext kzDbContext) : base(kzDbContext)
        {
        }
    }
}
