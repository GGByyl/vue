using Models.DTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PetHomeDAL
{
    /// <summary>
    /// 预约表访问层
    /// </summary>
    public class AppointDAL
    {
        /// <summary>
        /// 查询
        /// </summary>
        public List<Appoint_DTO> GetAppoint(AppointGet_DTO model,out int TotalCount)
        {
            using (PetHomeDbContext con = new PetHomeDbContext())
            {
                IQueryable<Appoint_DTO> iquer =  from a in con.Appoints
                                                join b in con.Accounts
                                                on a.Auid equals b.Aid
                                                join c in con.AppointStates
                                                on a.Astate equals c.Sid
                                                join d in con.ServeTypes
                                                on a.Atype equals d.Seid
                                                join e in con.AppointMangers
                                                on a.Amid equals e.Amid

                                                 select new Appoint_DTO
                                                {
                                                    Aid = a.Aid,
                                                    Name = b.Name,
                                                    Astate = c.State,
                                                    Amname = e.Amname,
                                                    Atime = a.Atime,
                                                    Atype = d.Setype
                                                };
                TotalCount = iquer.Count();
                List<Appoint_DTO> list = iquer
                    .OrderBy(x => x.Aid)
                    .Skip((model.page - 1) * model.limit)
                    .Take(model.limit)
                    .ToList();
                return list;
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public bool AddAppoint(AppointAdd_DTO model)
        {
            using (PetHomeDbContext con = new PetHomeDbContext())
            {
                Appoint appoint = new Appoint()
                {
                    Auid = model.Auid,
                    Astate = model.Astate,
                    Amid = model.Amid,
                    Atime = model.Atime,
                    Atype = model.Atype
                };
                con.Appoints.Add(appoint);
                int count = con.SaveChanges();
                if (count >0)
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
        public int UpdataAppoint(int aid, int astate)
        {
            using (PetHomeDbContext con = new PetHomeDbContext())
            {
                Appoint appoint = con.Appoints.Find(aid);
                if (appoint !=null)
                {
                    AppointState appointState = con.AppointStates.Find(astate);
                    if (appointState != null)
                    {
                        appoint.Astate = astate;
                        con.Appoints.Update(appoint);
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
                        return 506;
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
        public int DeleteAppoint(int aid)
        {
            using (PetHomeDbContext con = new PetHomeDbContext())
            {
                Appoint appoint = con.Appoints.Find(aid);
                if (appoint != null)
                {
                    con.Appoints.Remove(appoint);
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
