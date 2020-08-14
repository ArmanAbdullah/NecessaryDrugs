﻿using NecessaryDrugs.Core.Entities;
using NecessaryDrugs.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecessaryDrugs.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private IMedicineStoreUnitOfWork _medicineStoreUnitOfWork;
        public CategoryService(IMedicineStoreUnitOfWork medicineStoreUnitOfWork)
        {
            _medicineStoreUnitOfWork = medicineStoreUnitOfWork;
        }
        public void AddANewCategory(Category category)
        {
            if(category==null|| string.IsNullOrWhiteSpace(category.Name))
            {
                throw new InvalidOperationException("Category name is missing");
            }
            else
            {
                _medicineStoreUnitOfWork.CategoryRepository.Add(category);
                _medicineStoreUnitOfWork.Save();
            }
        }

        public IEnumerable<Category> GetCategories(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered)
        {
            return _medicineStoreUnitOfWork.CategoryRepository.Get(
                out total, out totalFiltered, x => x.Name.Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true
                );
        }
    }
}
