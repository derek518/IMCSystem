using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMCSystem.Server.Models
{
    public class Drug : Entity
    {
        public Drug()
        {

        }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [StringLength(128)]
        public string AliasName { get; set; }       // 药品别名
        [Index(IsUnique = true)]
        [Required]
        [StringLength(64)]
        public string Code { get; set; }            // 药品唯一编码
        [Index(IsUnique = true)]
        [Required]
        [StringLength(64)]
        public string BarCode { get; set; }         // 条形码
        [Index]
        [StringLength(64)]
        public string SuperCode { get; set; }       // 监管码
        [Index]
        [StringLength(64)]
        public string SearchCode { get; set; }      // 药品名称的拼音简码，方便药品检索
        [StringLength(64)]
        public string Specification { get; set; }   // 表示药品的剂量规格，如：2g*6袋
        [StringLength(16)]
        public string PackageUnit { get; set; }     // 入库或出药单位
        public int PackageNum { get; set; }         // 药品整包装量
        [StringLength(32)]
        public string Vendor { get; set; }          // 药品厂家
        [StringLength(32)]
        public string VendorCode { get; set; }      // 药品厂家编码
        [StringLength(512)]
        public string Notes { get; set; }           // 药品说明
        public double Length { get; set; }          // 药盒长度
        public double Width { get; set; }           // 药盒宽度
        public double Height { get; set; }          // 药盒高度
        public IList<DrugImage> Images { get; set; } // 药盒图片
}
}
