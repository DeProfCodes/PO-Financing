namespace PO_Financing.Helpers
{
    public class FilesHelper
    {
        public static class Folders
        {
            public const string Uploads = "Uploads";
            public const string BusinesRegistrations = "Business Registrations";
            public const string IDdocuments = "ID Documents";
            public const string PurchaseOrders = "Purchase Orders";
            public const string Quotations = "Quotations";
        };

        private static string GetFolderPath(int index)
        {
            switch (index)
            {
                case 0: return $"{Folders.Uploads}\\{Folders.BusinesRegistrations}";
                case 1: return $"{Folders.Uploads}\\{Folders.IDdocuments}";
                case 2: return $"{Folders.Uploads}\\{Folders.PurchaseOrders}";
                case 3: return $"{Folders.Uploads}\\{Folders.Quotations}";
                default: return string.Empty;
            }
        }

        private static string GetFileExtension(string fileName)
        {
            int index = fileName.IndexOf('.');
            return fileName.Substring(index + 1);
        }

        public static string GetFileFullPath(string fileName, int index, string userId)
        {
            var newFileName = $"{userId}.{GetFileExtension(fileName)}";
            string path = $"{GetFolderPath(index)}\\{newFileName}";

            return path;
        }
    }
}
