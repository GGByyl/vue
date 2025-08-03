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
    /// 订单表访问层
    /// </summary>
    public class OrderDAL
    {
        public static object _lock = new object();
        //生成订单编号
        public string GetRandom1()
        {
            lock (_lock)
            {
                Random ran = new Random();
                var number = "P" + DateTime.Now.ToString("yyMMddHHmmss") + ran.Next(1000, 9999).ToString();
                return number;
            }
        }


        /// <summary>
        /// 添加订单信息
        /// </summary>
        public int AddOrder(OrderAdd_DTO model)
        {
            using (PetHomeDbContext con = new PetHomeDbContext())
            {
                Order order = new Order()
                {
                    OrderNumber = GetRandom1(),
                    OrderUserId = model.OrderUserId,
                    OrderGoodsId = model.OrderGoodsId,
                    OrderSite = model.OrderSite,
                    OrderState = model.OrderState,
                    Principal = model.Principal,
                    TotalPrices = model.TotalPrices,
                    Quantity = model.Quantity,
                    UnitPrice = model.UnitPrice,
                    OrderTime = model.OrderTime
                };
                con.Orders.Add(order);
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
        }
        /// <summary>
        /// 修改订单信息
        /// </summary>
        public int UpdataOrder(OrderUpdata_DTO model)
        {
            using (PetHomeDbContext con = new PetHomeDbContext())
            {
                Order order = con.Orders.Find(model.OrderNumber);
                if (order != null)
                {
                    order.OrderSite = model.OrderSite;
                    order.OrderState = model.OrderState;
                    con.Update(order);
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
        /// 删除订单信息
        /// </summary>
        public int DeleteOrder(string orderNumber)
        {
            using (PetHomeDbContext con = new PetHomeDbContext())
            {
                Order order = con.Orders.Find(orderNumber);
                if (order != null)
                {
                    con.Orders.Remove(order);
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
