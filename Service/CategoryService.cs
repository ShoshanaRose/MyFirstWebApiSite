﻿using Entities;
using Repository;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetCategory()
        {
            return await _categoryRepository.getCategory();
        }
    }
}
