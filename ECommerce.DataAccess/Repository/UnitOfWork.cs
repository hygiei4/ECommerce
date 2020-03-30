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
            Product = new ProductRepository(_db);
            SubCategory = new SubCategoryRepository(_db);
            }
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product{ get; private set; }
        public ISubCategoryRepository SubCategory { get; private set; }
       
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
