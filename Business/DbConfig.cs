namespace dotnet_wms_ef.Models
{
    public class DbConfig
    {
        private static string server = "localhost";

        private static int port = 3306;

        private static string database = "";

        private static string user = "root";

        private static string password = "8888";

        private static string pre = "wms_";

        private static string formatString = "server={0};port={1};database={2};user={3};password={4}";

        public static string InboundDb
        {
            get { return string.Format(formatString, server, port, pre + "inbound", user, password); }
        }

        public static string OutboundDb
        {
            get { return string.Format(formatString, server, port, pre + "outbound", user, password); }
        }

        public static string InventoryDb
        {
            get { return string.Format(formatString, server, port, pre + "inventory", user, password); }
        }

        public static string WarehouseDb
        {
            get { return string.Format(formatString, server, port, pre + "warehouse", user, password); }
        }

        public static string CustomerDb
        {
            get { return string.Format(formatString, server, port, pre + "customer", user, password); }
        }

        public static string ProductDb
        {
            get { return string.Format(formatString, server, port, pre + "product", user, password); }
        }

        public static string SupplierDb
        {
            get { return string.Format(formatString, server, port, pre + "supplier", user, password); }
        }

        public static string StockDb
        {
            get { return string.Format(formatString, server, port, pre + "stock", user, password); }
        }
    }
}