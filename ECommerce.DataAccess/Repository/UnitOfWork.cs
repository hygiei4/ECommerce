﻿using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository.IRepository;

namespace ECommerce.DataAccess.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            }
        public ICategoryRepository Category { get; private set; }
       
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}