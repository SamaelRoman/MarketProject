using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace MyMarketProject.Controllers
{
    public static class FileDownloader
    {
        private static string AlphaBet { get; } = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM;"; //Строка для генерации имени файла

        public static string Upload(HttpPostedFileBase File)
        {
            if (GetDirectory(File) != null)
            {
                string FileName = CreateFileName(File, 12);
                string FileSrc = GetDirectory(File) + "/" + FileName;
                File.SaveAs(FileSrc);
                return FileName;
            }
            else
            {
                return null;
            }
        }
        public static void Delete(string FilePath)
        {
            var fullPath = HttpContext.Current.Server.MapPath(FilePath);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
        private static string CreateFileName(HttpPostedFileBase File, int NameLength)
        {
            StringBuilder SB = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < NameLength; i++)
            {
                SB.Append(AlphaBet[rnd.Next(0, AlphaBet.Length - 1)]);
            }
            SB.Append(Path.GetExtension(File.FileName));
            return SB.ToString();
        }

        private static string GetDirectory(HttpPostedFileBase File)
        {
            if (Path.GetExtension(File.FileName.ToLower()) == ".jpg" || Path.GetExtension(File.FileName.ToLower()) == ".png")
            {
                return HttpContext.Current.Server.MapPath("~/Content/ProductImg");
            }
            else
            {
                return null;
            }
        }

    }
}