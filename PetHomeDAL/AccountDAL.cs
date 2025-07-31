using Models.DTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHomeDAL
{
    public class AccountDAL
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Account GetAccountLogin(Login_DTO model)
        {
            using(PetHomeDbContext con = new PetHomeDbContext())
            {
                Account account  = con.Accounts.FirstOrDefault(x => x.Number == model.Number);

                return account;



            }

        }
        /// <summary>
        /// 注册
        /// </summary>
        public bool Add_Account(AddAccount_DTO model)
        {
            using (PetHomeDbContext con = new PetHomeDbContext())
            {
                //用户表
                Account account = new Account()
                {
                    Admins = model.Admins,//是否管理员
                    IdNumber = model.IdNumber,//身份验证
                    Location = model.Location,//地址
                    Name = model.Name,//真实姓名
                    Nickname = model.Nickname,//昵称
                    Number = model.Number,//账号
                    Password = model.Password,//密码
                    Phone = model.Phone,//电话
                    Sex = model.Sex//姓名
                };
                con.Accounts.Add(account);//添加
                int count = con.SaveChanges();//获取受影响行数
                if (count > 0)
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
        /// 获取用户表
        /// </summary>
        public List<Account> GetAcc(Account_DTO model,out int TotalCount)
        {
            using (PetHomeDbContext con = new PetHomeDbContext())
            {

                IQueryable<Account> iquery = from a in con.Accounts
                                           select new Account()
                                           {
                                               Aid = a.Aid,
                                               Number = a.Number,
                                               Password = a.Password,
                                               Nickname = a.Nickname,
                                               Name = a.Name,
                                               Sex = a.Sex,
                                               Phone = a.Phone,
                                               Location = a.Location,
                                               IdNumber = a.IdNumber,
                                               Admins = a.Admins
                                           };
                if (!string.IsNullOrEmpty(model.Number))
                {
                    iquery = iquery.Where(x => x.Number == model.Number);
                }
                if (!string.IsNullOrEmpty(model.Name))
                {
                    iquery = iquery.Where(x => x.Name == model.Name);
                }
                TotalCount = iquery.Count();
                List<Account> list = iquery
                    .OrderBy(x => x.Aid)
                    .Skip((model.page - 1) * model.limit)
                    .Take(model.limit)
                    .ToList();
                return list;

            }
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        public int AccountModify(ModifyAccount_DTO model)
        {

            using (PetHomeDbContext con = new PetHomeDbContext())
            {
                Account account = con.Accounts.FirstOrDefault( x => x.Aid == model.Aid);

                if (account != null) {
                    account.Number = model.Number;
                    account.Name = model.Name;
                    account.Nickname = model.Nickname;
                    account.Password = model.Password;
                    account.Phone = model.Phone;
                    account.Sex = model.Sex;
                    account.Location = model.Location;
                    account.IdNumber = model.IdNumber;
                    account.Admins = model.Admins;
                    con.Accounts.Update(account);
                   int count =  con.SaveChanges();

                    if (count > 0) {
                        return 200;
                    }
                    else
                    {
                        return 506;
                    }
                   
                }
                else
                {
                    return 404;
                }
            }

        }


        /// <summary>
        /// 删除用户
        /// </summary>
        public int AccountDelete(int Aid)
        {
            using(PetHomeDbContext con = new PetHomeDbContext())
            {
                Account account  = con.Accounts.Find(Aid);

                if (account != null) { 
                   con.Accounts.Remove(account);

                    int count = con.SaveChanges();

                    if (count > 0) {
                        return 200;
                    }
                    else
                    {
                        return 506;
                    }
                
                }
                else {
                    return 404;
                }



            }                          






        }




      



    }
}
