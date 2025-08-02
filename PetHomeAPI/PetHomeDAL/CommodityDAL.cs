using Models.DTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHomeDAL
{
    /// <summary>
    /// 商品表访问层
    /// </summary>
    public class CommodityDAL
    {
        /// <summary>
        /// 添加商品信息
        /// </summary>
        public bool AddCommdity(CommodityAdd_DTO model)
        {
            using (PetHomeDbContext con = new PetHomeDbContext())
            {
                Commodity commodity = new Commodity()
                {
                    Cname = model.Cname,
                    DateIssued = model.DateIssued,
                    Describe = model.Describe,
                    Expiration = model.Expiration,
                    Inventory = model.Inventory,
                    ManufactureTiem = model.ManufactureTiem,
                    Price = model.Price,
                    SalesVolume = model.SalesVolume,
                    Yieldly = model.Yieldly
                };
                con.Commodities.Add(commodity);
                int count = con.SaveChanges();
                if (count>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 修改商品信息
        /// </summary>
        public bool UpdataCommdity(CommodityUpdata_DTO model)
        {
            using (PetHomeDbContext con = new PetHomeDbContext())
            {
                Commodity commodity = con.Commodities.Find(model.Cid);
                if (commodity != null)
                {
                    commodity.Cname = model.Cname;
                    commodity.Price = model.Price;
                    commodity.Inventory = model.Inventory;
                    commodity.Describe = commodity.Describe == null? commodity.Describe : model.Describe;
                    commodity.DateIssued = commodity.DateIssued == null ? commodity.DateIssued : model.DateIssued;

                    con.Commodities.Update(commodity);
                    int count = con.SaveChanges();
                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false ;
                }
                
            }
        }
        /// <summary>
        /// 删除商品信息
        /// </summary>
        public int DeleteCommodity(int cid)
        {
            using (PetHomeDbContext con = new PetHomeDbContext())
            {
                if (con.Commodities.Find(cid) != null)
                {
                    con.Commodities.Remove(con.Commodities.Find(cid));
                    int count = con.SaveChanges();
                    if (count>0)
                    {
                        return 200;
                    }
                    else
                    {
                        return 405;
                    }
                }else
                {
                    return 503;
                }
            }
        }
    }
}
