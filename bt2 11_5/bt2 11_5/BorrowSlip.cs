namespace bt2_11_5
{
    /// <summary>Phiếu mượn thiết bị. Tên property được dùng làm DataPropertyName cho DataGridView.</summary>
    public class BorrowSlip
    {
        public const string Borrowing = "Đang mượn";
        public const string Returned = "Đã trả";
        public const string Overdue = "Quá hạn";

        public static readonly string[] Statuses = { Borrowing, Overdue, Returned };

        public string Id { get; set; } = "";
        public string StudentId { get; set; } = "";
        public string StudentName { get; set; } = "";
        public string Equipment { get; set; } = "";
        public int Quantity { get; set; } = 1;
        public DateTime BorrowDate { get; set; } = DateTime.Today;
        public DateTime DueDate { get; set; } = DateTime.Today;
        public DateTime? ReturnDate { get; set; }

        /// <summary>Tình trạng được tính tự động, không lưu cố định.</summary>
        public string Status => ComputeStatus(ReturnDate, DueDate);

        public bool IsOverdue => Status == Overdue;

        /// <summary>Đã trả → "Đã trả"; chưa trả và hạn trả trước ngày hiện tại → "Quá hạn"; còn lại → "Đang mượn".</summary>
        public static string ComputeStatus(DateTime? returnDate, DateTime dueDate)
        {
            if (returnDate.HasValue) return Returned;
            return dueDate.Date < DateTime.Today ? Overdue : Borrowing;
        }
    }
}