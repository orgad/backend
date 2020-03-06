using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace dotnet_wms_ef.Services
{
    public class ImageIOService
    {
        public string basePath = "";

        public string Upload(FormFile file, string index)
        {
            var fileName = file.FileName;
            var sPath = basePath + "\\images\\asn-check";
            if (!Directory.Exists(sPath))
            {
                Directory.CreateDirectory(sPath);
            }

            var i = fileName.LastIndexOf(".");
            var ext = fileName.Substring(i);
            var shortName = index + "-" +fileName;
            var sFileName = sPath + "\\" + shortName;
            var vName = "images/asn-check/"+shortName;

            FileInfo f = new FileInfo(sFileName);
            if (!f.Exists)
            {
                using (FileStream fs = new FileStream(file.ToString(), FileMode.Create))
                {
                    file.CopyTo(fs);
                    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(fs);//将MemoryStream对象转换成Bitmap对象
                    bmp.Save(sFileName);
                }
            }
            return vName;
        }
    }
}