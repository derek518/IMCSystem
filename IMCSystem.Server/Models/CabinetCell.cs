using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMCSystem.Server.Models
{
    public class CabinetCell : Entity
    {
        public CabinetCell()
        {

        }

        [Index("SeqAndDeviceId", 1)]
        public int Seq { get; set; }            // 储位序号（本药柜内）
        //[Index("SeqAndFloorId", 1)]
        public int SeqInFloor { get; set; }     // 储位序号（本层内）
        public int Align { get; set; }          // 0: 居中, 1: 左; 2: 右
        public double Width { get; set; }       // 储位宽度
        public double Height { get; set; }      // 储位高度
        public double Depth { get; set; }       // 储位深度
        public CabinetPosition Position { get; set; }   // 储位中间点坐标

        [Index("SeqAndDeviceId", 2, IsUnique = true)]
        public int DeviceId { get; set; }               // 药柜设备Id
        [ForeignKey("DeviceId")]
        public CabinetDevice Device { get; set; }       // 药柜设备信息
        //[Index("SeqAndFloorId", 2, IsUnique = true)]
        //public int FloorId { get; set; }                // 药柜分层Id
        //[ForeignKey("FloorId")]
        //public CabinetFloor Floor { get; set; }         // 药柜分层
    }
}