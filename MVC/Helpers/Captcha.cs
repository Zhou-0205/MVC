using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace MVC.Helpers
{
    public class Captcha
    {
        public static string GenerateString()
        {
            Random random = new Random();
            string str = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                int index = random.Next(str.Length);
                stringBuilder.Append(str[index]);
            }
            string CaptchStr = stringBuilder.ToString();
            return CaptchStr;
        }
        public static Image GenerateBitmap(string CaptchStr)
        {
            int width = 60, height = 24;
            Bitmap image = new Bitmap(width, height);
            Random random = new Random();
            Graphics graphics = Graphics.FromImage(image);
            graphics.Clear(Color.White);
            for (int i = 0; i < 20; i++)
            {
                int startX = random.Next(width / 2),
                    startY = random.Next(height),
                    endX = random.Next(startX, width),
                    endY = random.Next(height);
                graphics.DrawLine(
                    new Pen(Color.FromArgb
                    (
                        random.Next(255),
                        random.Next(255),
                        random.Next(255),
                        random.Next(255))
                    ),
                    new Point(startX, startY),
                    new Point(endX, endY)
                    );
            }

            graphics.DrawString(
                CaptchStr,
                new Font("Tahoma", 14),
                new SolidBrush(Color.FromArgb(random.Next(200), random.Next(200), random.Next(200))),
                new PointF(1, 0)
                );
            for (int i = 0; i < 80; i++)
            {
                image.SetPixel(random.Next(width), random.Next(height), Color.Black);
            }
            image.SetResolution(72, 92);
            return image;
            
        }
    }
}