namespace btap3_11_5
{
    /// <summary>Đơn đăng ký sửa chữa. Tên property được dùng làm DataPropertyName cho DataGridView.</summary>
    public class RepairOrder
    {
        public const string StatusNew = "Mới tiếp nhận";
        public const string StatusRepairing = "Đang sửa";
        public const string StatusWaitingParts = "Chờ linh kiện";
        public const string StatusDone = "Hoàn tất";
        public const string StatusCancelled = "Đã hủy";

        public static readonly string[] Statuses =
            { StatusNew, StatusRepairing, StatusWaitingParts, StatusDone, StatusCancelled };

        public string Id { get; set; } = "";
        public string CustomerName { get; set; } = "";
        public string Phone { get; set; } = "";
        public string DeviceType { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime ReceivedDate { get; set; } = DateTime.Today;
        public decimal EstimatedCost { get; set; }
        public string Status { get; set; } = StatusNew;

        /// <summary>Đường dẫn ảnh thiết bị (rỗng nếu khách không chọn ảnh).</summary>
        public string ImagePath { get; set; } = "";

        /// <summary>Đơn chưa hoàn tất: chưa "Hoàn tất" và chưa "Đã hủy" (đơn hủy không phát sinh chi phí).</summary>
        public bool IsOpen => Status != StatusDone && Status != StatusCancelled;
    }
}