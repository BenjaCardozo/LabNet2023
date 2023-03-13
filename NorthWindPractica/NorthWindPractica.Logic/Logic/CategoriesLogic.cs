using NorthWindPractica.Data;
using NorthWindPractica.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NorthWindPractica.Logic.Logic
{
    public class CategoriesLogic : BaseLogic, IABMLogic<Categories, int>
    {
        public void Add(Categories newCategory)
        {
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
        }

        public void Delete(Categories deleteCategory)
        {
            _context.Categories.Remove(deleteCategory);
            _context.SaveChanges();
        }

        public bool ExistID(int id) => _context.Categories.Any(c => c.CategoryID == id);

        public IEnumerable<Categories> GetAll() => _context.Categories.ToList();

        public Categories GetById(int id) => _context.Categories.First(c => c.CategoryID == id);

        public void Update(Categories updateCategory)
        {
            var categoryToUpdate = _context.Categories.Find(updateCategory.CategoryID);

            categoryToUpdate.CategoryName = updateCategory.CategoryName;
            categoryToUpdate.Description = updateCategory.Description;

            _context.SaveChanges();
        }
        public int IdGenerator()
        {
            return _context.Categories.Max(x => x.CategoryID) + 1;
        }
        public IEnumerable<Categories> Find(string find) => _context.Categories
                .Where(c => c.CategoryName.ToLower().Contains(find))
                .ToList();
    }
}
