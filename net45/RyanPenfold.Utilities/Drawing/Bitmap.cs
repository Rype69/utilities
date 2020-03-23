namespace RyanPenfold.Utilities.Drawing
{
    public class Bitmap
    {
        /// <summary>
        /// Produces a random base64 image <see cref="string"/>.
        /// </summary>
        /// <param name="width">The width of the image</param>
        /// <param name="height">The height of the image</param>
        /// <returns>A random base64 image <see cref="string"/>.</returns>
        public static string GenerateBase64ImageString(int width, int height)
        {
            string rtn;

            // 1. Create a bitmap
            using (var bitmap = new System.Drawing.Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb))
            {
                // 2. Get access to the raw bitmap data
                var data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, bitmap.PixelFormat);

                // 3. Generate RGB noise and write it to the bitmap's buffer.
                // Note that we are assuming that data.Stride == 3 * data.Width for simplicity/brevity here.
                var noise = new byte[data.Width * data.Height * 3];
                new System.Random().NextBytes(noise);
               System.Runtime.InteropServices.Marshal.Copy(noise, 0, data.Scan0, noise.Length);

                bitmap.UnlockBits(data);

                // 4. Save as JPEG and convert to Base64
                using (var jpegStream = new System.IO.MemoryStream())
                {
                    bitmap.Save(jpegStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    rtn = System.Convert.ToBase64String(jpegStream.ToArray());
                }
            }

            return rtn;
        }
    }
}
