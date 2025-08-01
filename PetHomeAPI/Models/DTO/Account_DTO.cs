using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class Account_DTO
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string? Number { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 页数
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 最大显示数量
        /// </summary>
        public int limit { get; set; }
    }
}
