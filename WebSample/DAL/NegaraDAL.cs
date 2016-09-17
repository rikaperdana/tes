using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSample.Models;

namespace WebSample.DAL
{
    public class NegaraDAL:IMasterClass<negara>
    {
        private SampleDBEntities db;

        public NegaraDAL()
        {
            db = new SampleDBEntities();
        }
        public IQueryable<negara> GetAll(string keyword="")
        {
            IQueryable<negara> results;
            if (keyword=="")
            {
                results = from n in db.negaras
                              orderby n.NamaNegara ascending
                              select n;
            }
            else
            {
                results = from n in db.negaras
                          where n.NamaNegara.Contains(keyword)
                          orderby n.NamaNegara ascending
                          select n;
            }

            //var result = db.negaras.Orderby(n => n.NamaNegara);
            return results;
        }

        public negara GetByID(string id)
        {
            //penggunaan tanda kurung sebelum from berguna untuk mengambil hanya
            //satu nilai/objek kemudian diikuti oleh FirstOrDefault
            int intId = Convert.ToInt32(id);
            var result = (from n in db.negaras
                          where n.NegaraId == intId
                          select n).FirstOrDefault();

            return result;
        }

        public void Insert(negara obj)
        {
            try
            {
                db.negaras.Add(obj);
                db.SaveChanges();
            }
            catch (Exception x)
            {
                
                throw new Exception(x.Message);
            }
        }

        public void Update(negara obj)
        {
            //var result = (from n in db.negaras
                          //where n.NegaraId == obj.NegaraId
                          //select n).FirstOrDefault();
            //Bisa menggunakan code diatas, atau bisa menggunakan code dibawah, karena linq yang sama
            //sudah dideklarasikan di method GetByID
            var result = GetByID(obj.NegaraId.ToString());
            try
            {
                result.NamaNegara = obj.NamaNegara;
                db.SaveChanges();
            }
            catch (Exception x)
            {
                
                throw new Exception(x.Message);
            }
        }

        public void Delete(negara obj)
        {
            var result = GetByID(obj.NegaraId.ToString());
            try
            {
                db.negaras.Remove(result);
                db.SaveChanges();
            }
            catch (Exception x)
            {
                
                throw new Exception(x.Message);
            }
        }
    }
}