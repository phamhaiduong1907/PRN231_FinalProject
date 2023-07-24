namespace Server.Models.DTO
{
    public class AddOrderDTO
    {
        public int MemberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime Required { get; set; }

        public List<AddOrderDetailDTO> OrderDetails{ get; set; } = new List<AddOrderDetailDTO>();
    }
}
