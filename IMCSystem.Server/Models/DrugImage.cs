namespace IMCSystem.Server.Models
{
    public class DrugImage : Entity
    {
        public DrugImage()
        {

        }

        //Foreign key for Drug
        public int DrugId { get; set; }
        public Drug Drug { get; set; }

        public byte[] Content { get; set; }     // 保存图片数据
    }
}