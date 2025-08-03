using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHomeDAL
{
    /// <summary>
    /// 订单状态表访问层
    /// </summary>
    public class OrderTypeDAL
    {
        /// <summary>
        /// 查询
        /// </summary>
        public List<OrderType> GetOrderType()
        {
            using (PetHomeDbContext con = new PetHomeDbContext())
            {
                List<OrderType> list = con.OrderTypes.ToList();
                return list;
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public bool AddOrderType(string SType)
        {
            using (PetHomeDbContext con = new PetHomeDbContext())
            {
                OrderType orderType = new OrderType
                {
                    Stype = SType
                };
                con.OrderTypes.Add(orderType);
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
        /// 修改
        /// </summary>
        public int UpdataOrderType(int? Sid, string SType)
        {
            using (PetHomeDbContext con = new PetHomeDbContext())
            {
                OrderType orderType = con.OrderTypes.Find(Sid);
                if (orderType != null)
                {
                    orderType.Stype = SType;
                    con.OrderTypes.Update(orderType);
                    int count = con.SaveChanges();
                    if (count > 0)
                    {
                        return 200;
                    }
                    else
                    {
                        return 405;
                    }
                }
                else
                {
                    return 503;
                }
                
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public int DeleteOrderType(int? Sid)
        {
            using (PetHomeDbContext con = new PetHomeDbContext())
            {
                OrderType orderType = con.OrderTypes.Find(Sid);
                if (orderType != null)
                {
                    con.OrderTypes.Remove(orderType);
                    int count = con.SaveChanges();
                    if (count > 0)
                    {
                        return 200;
                    }
                    else
                    {
                        return 405;
                    }
                }
                else
                {
                    return 503;
                }

            }
        }
    }
}
