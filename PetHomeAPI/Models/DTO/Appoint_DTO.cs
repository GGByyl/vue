using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class Appoint_DTO
    {
        /// <summary>
        /// 预约编号
        /// </summary>
        public int Aid { get; set; }
        /// <summary>
        /// 预约用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 预约状态
        /// </summary>
        public string Astate { get; set; }
        /// <summary>
        /// 负责人名
        /// </summary>
        public string Amname { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime Atime { get; set; }
        /// <summary>
        /// 预约服务类型
        /// </summary>
        public string Atype { get; set; }
    }
}
