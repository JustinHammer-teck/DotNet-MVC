﻿using System.Linq;
using DotNet_MVC.Application.Common.Repository;
using DotNet_MVC.Application.Data;
using DotNet_MVC.Domain.Intities;

namespace DotNet_MVC.Infrastructure.Repository
{
    public class CovertypeRepository : Repository<CoverType>, ICovertypeRepository
    {
        private readonly ApplicationDbContext _db;

        public CovertypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CoverType coverType)
        {
            var obj = _db.CoverTypes.FirstOrDefault(s => s.Id == coverType.Id);

            if (obj != null)
            {
                obj.Name = coverType.Name;

                _db.SaveChanges();
            }
        }
    }
}