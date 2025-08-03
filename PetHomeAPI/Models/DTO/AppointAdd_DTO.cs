using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    /// <summary>
    /// 预约表工具类
    /// </summary>
    public class AppointAdd_DTO
    {
        /// <summary>
        /// 预约用户
        /// </summary>
        public int Auid { get; set; }
        /// <summary>
        /// 预约状态
        /// </summary>
        public int Astate { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public int Amid { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime Atime { get; set; }
        /// <summary>
        /// 预约服务类型
        /// </summary>
        public int Atype { get; set; }
    }
}
