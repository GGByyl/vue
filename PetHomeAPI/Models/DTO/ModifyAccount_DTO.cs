using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class ModifyAccount_DTO
    {
        public int Aid { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 身份证件
        /// </summary>
        public string IdNumber { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public int Admins { get; set; }
    }
}
