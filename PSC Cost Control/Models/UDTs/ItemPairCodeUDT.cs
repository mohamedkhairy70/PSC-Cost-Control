using EntityFrameworkExtras.EF6;

namespace PSC_Cost_Control.Models.UDTs
{
    [UserDefinedTableType("ItemPairCode")]
    public class ItemPairCodeUDT
    {
        
        [UserDefinedTableTypeColumn(1)]
        public int? ItemId { set; get; }

        [UserDefinedTableTypeColumn(2)]
        public int? ProjectCodeId { set; get; }
    }
}
