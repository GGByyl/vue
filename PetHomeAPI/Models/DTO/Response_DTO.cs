using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    /// <summary>
    /// 数据响应模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response_DTO<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int StatuCode { get; set; }
        /// <summary>
        /// 输出的字符串
        /// </summary>
        public string? Message { get; set; }
        /// <summary>
        /// T和F 状态
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public T Conten { get; set; }
    }
}
