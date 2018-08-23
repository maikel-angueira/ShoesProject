using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Systems.Appollo.Shoes.Client.WinForm.Utils
{
    public sealed class PictureViewUtils
    {
        public static byte[] ReadImageFromFilePath(string filePath)
        {
            FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);
            byte[] photo = reader.ReadBytes((int)stream.Length);
            reader.Close();
            stream.Close();
            return photo;
        }

        public static void LoadImageToControl(byte[] images, PictureBox pictureBox )
        {
            ImageConverter converter = new ImageConverter();
            Image img = (Image)converter.ConvertFrom(images);
            pictureBox.Image = img;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Refresh();
        }

        public static byte[] ImageToByteArray(PictureBox pictureBox)
        {
            var img = pictureBox.Image;
            MemoryStream ms = new MemoryStream();
            if (pictureBox.Image != null)
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            return ms.ToArray();
        }

        public Image GetDataToImage(byte[] images)
        {
            try
            {
                ImageConverter imgConverter = new ImageConverter();
                return imgConverter.ConvertFrom(images) as Image;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
