namespace PSC_Cost_Control.Models.DTO
{
    public class IndirectItemProjecCodeWithId:IItemPairWithId<IndirectCostItems>
    {
        public int Id { get; set; }
        public IndirectCostItems Item { get; set; }
        public int ItemId { get; set; }
        public C_Cost_Project_Codes ProjectCode { get; set; }
        public int ProjecCodeId { set; get; }
    }
}
