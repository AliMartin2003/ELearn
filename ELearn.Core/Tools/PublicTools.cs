using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Http;

namespace ELearn.Core.Tools
{
    public static class PublicTools
    {

        public static async Task<bool> SaveOriginalImageAsync(
        IFormFile imageFile,
        string folderName,
        string fileNameWithoutExtension)
        {
            try
            {

                var targetDir = Path.Combine(Directory.GetCurrentDirectory(),"images", folderName, "org");
                Directory.CreateDirectory(targetDir);
                var extension = Path.GetExtension(imageFile.FileName);
                var fullPath = Path.Combine(targetDir, fileNameWithoutExtension + extension);
                using var stream = new FileStream(fullPath, FileMode.Create);
                await imageFile.CopyToAsync(stream);

                return true;
            }
            catch
            {
                return false;
            }
        }


        public static async Task<bool> SaveThumbnailImageAsync(
            IFormFile imageFile,
            string folderName,
            string fileNameWithoutExtension,
            int thumbWidth = 150,
            int thumbHeight = 150,
            int jpegQuality = 75)
        {
            try
            {
                var targetDir = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                Directory.CreateDirectory(targetDir);
                using var mem = new MemoryStream();
                await imageFile.CopyToAsync(mem);
                mem.Position = 0;
                using var img = Image.FromStream(mem);
                using var thumb = img.GetThumbnailImage(thumbWidth, thumbHeight, () => false, IntPtr.Zero);
                var encoder = GetEncoder(ImageFormat.Jpeg);
                var encParams = new EncoderParameters(1);
                encParams.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);

                var thumbPath = Path.Combine(targetDir, fileNameWithoutExtension + ".jpg");
                thumb.Save(thumbPath, encoder, encParams);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            return ImageCodecInfo
                .GetImageDecoders()
                .FirstOrDefault(c => c.FormatID == format.Guid);
        }
    }
}
