using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMCSystem.Server.Models
{
    public class CabinetDevice : Entity
    {
        public CabinetDevice()
        {

        }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        [Required]
        public int Seq { get; set; }            // 药柜序号
        [StringLength(32)]
        public string Vendor { get; set; }      // 药柜厂家
        [StringLength(32)]
        public string Model { get; set; }       // 药柜型号
        public bool IsIntegration { get; set; }       // 是否为一体化控制设备
        public ProtocolAddress DosingAddress { get; set; }          // 加药控制地址
        public ProtocolAddress DispensingAddress { get; set; }      // 发药控制地址
        [StringLength(512)]
        public string Notes { get; set; }       // 备注描述

        public int Window { get; set; }         // 出药窗口编号
        public double Width { get; set; }       // 药柜宽度
        public double Height { get; set; }      // 药柜高度
        public double Depth { get; set; }       // 药柜深度
        public CabinetPosition Origin { get; set; }       // 原点位置坐标
        public CabinetPosition TopLeft { get; set; }      // 原点位置坐标
        public CabinetPosition TopRight { get; set; }     // 原点位置坐标
        public CabinetPosition BottomLeft { get; set; }   // 原点位置坐标
        public CabinetPosition BottomRight { get; set; }  // 原点位置坐标

        public int FloorCount { get; set; }     // 药柜层数
        public IList<CabinetFloor> Floors { get; set; }   // 药柜层列表
        public IList<CabinetCell> Cells { get; set; }   // 药柜储位列表
    }
}
