using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMCSystem.Server.Models
{
    public class CabinetFloor : Entity
    {
        public CabinetFloor()
        {

        }

        [Index("SeqAndDeviceId", 1)]
        public int Seq { get; set; }            // 层数序号
        public double Width { get; set; }       // 本层宽度
        public double Height { get; set; }      // 本层高度
        public double CellWidth { get; set; }   // 本层储位宽度规格

        [Index("SeqAndDeviceId", 2, IsUnique = true)]
        public int DeviceId { get; set; }       // 药柜设备Id
        [ForeignKey("DeviceId")]
        public CabinetDevice Device { get; set; }       // 药柜设备信息
        //public IList<CabinetCell> Cells { get; set; }   // 本层储位列表
    }
}