using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class SanPhamDao
    {
        private HoMinhThangContext dbcont;

        public SanPhamDao()
        {

            dbcont = new HoMinhThangContext();
        }
        public string Insert(san_pham entityUser)
        {
            try
            {
                dbcont.san_pham.Add(entityUser);

                dbcont.SaveChanges();
                return entityUser.Name;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public bool Delete(string id)
        {
            try
            {
                var Product = dbcont.san_pham.Find(id);
                dbcont.san_pham.Remove(Product);
                dbcont.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(san_pham entityUser)
        {
            try
            {
                var Cate = dbcont.san_pham.Find(entityUser.ID);
                /* Cate.Name = Entity.Name;
                 Cate.ParentID = Entity.ParentID;
                 Cate.Slug = Entity.Slug;*/
                Cate.Name = entityUser.Name;
                Cate.UnitCost = entityUser.UnitCost;
                Cate.Quantity = entityUser.Quantity;

                Cate.Image = entityUser.Image;

                Cate.ID_l = entityUser.ID_l;

                Cate.Description = entityUser.Description;

                Cate.Status = entityUser.Status;



                dbcont.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public san_pham Find(string id)
        {
            return dbcont.san_pham.Find(id);

        }

        public List<san_pham> ListAll(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
                return dbcont.san_pham.Where(x => x.ID.Contains(searchString) || x.Name.Contains(searchString)
                || x.UnitCost.ToString().Contains(searchString)
                || x.ID_l.ToString().Contains(searchString)).ToList();
            return dbcont.san_pham.ToList();
        }
        public List<san_pham> ListSP(string searchString)
        {

            if (!string.IsNullOrEmpty(searchString))
                return dbcont.san_pham.Where(x => x.ID.Contains(searchString) || x.Name.Contains(searchString)
                || x.UnitCost.ToString().Contains(searchString)
                || x.ID_l.ToString().Contains(searchString)).OrderByDescending(x => x.UnitCost).ThenBy(x => x.ID_l).ToList();
            return dbcont.san_pham.OrderByDescending(x => x.UnitCost).ThenBy(x => x.ID_l).ToList();
        }

        public List<san_pham> ListViewDetail(string id)
        {
            return dbcont.san_pham.Where(x => x.ID.Contains(id)).ToList();

        }
    }
}
