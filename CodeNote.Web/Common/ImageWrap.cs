using System;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CodeNote.Web.Common
{
    /// <summary>
    /// 用于处理图片信息
    /// </summary>
    public class ImageWrap
    {
        #region DrawWatermark
        /// <summary>
        /// 画水印
        /// </summary>
        /// <param name="wateMark">水印字符</param>
        /// <param name="imgFilePath"></param>
        /// <returns></returns>
        public static Image DrawWatermark(string waterMark, string imgFilePath)
        {
            return DrawWatermark(waterMark, imgFilePath, new Font("Lucida Sans Unicode", 10, FontStyle.Regular), new PointF(5, 5));
        }

        public static Image DrawWatermark(string waterMark, string imgFilePath, Font font, PointF poinF)
        {
            Image temp = Image.FromFile(imgFilePath);
            Bitmap bitMap = new Bitmap(temp.Width, temp.Height);
            Graphics g = Graphics.FromImage(bitMap);
            //透明背景色
            g.Clear(Color.Transparent);
            g.SmoothingMode = SmoothingMode.AntiAlias;//质量为消除齿 
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            SolidBrush solid = new SolidBrush(Color.Wheat);
            g.DrawImage(temp, 0, 0);
            g.DrawString(waterMark, font, solid, poinF);

            Image retImg = Image.FromHbitmap(bitMap.GetHbitmap());
            g.Dispose();
            bitMap.Dispose();
            temp.Dispose();
            return retImg;
        }

        public static Image DrawWatermarkImg(string waterMarkPath, string imgFilePath)
        {
            Image mark = Image.FromFile(waterMarkPath);
            return DrawWatermark(mark, imgFilePath);
        }
        public static Image DrawWatermarkImg(string waterMarkPath, string imgFilePath, int marginRight, int marginBottom)
        {
            Image mark = Image.FromFile(waterMarkPath);
            return DrawWatermark(mark, imgFilePath, marginRight, marginBottom);
        }

        public static Image DrawWatermark(Image mark, string imgFilePath)
        {
            Image dest = Image.FromFile(imgFilePath);
            return DrawWatermark(mark, dest, new Rectangle(dest.Width - mark.Width - 5, dest.Height - mark.Height - 5, mark.Width, mark.Height), new Rectangle(0, 0, mark.Width, mark.Height));
        }

        public static Image DrawWatermark(Image mark, string imgFilePath, int marginRight, int marginBottom)
        {
            Image dest = Image.FromFile(imgFilePath);
            return DrawWatermark(mark, dest, new Rectangle(dest.Width - mark.Width - marginRight, dest.Height - mark.Height - marginBottom, mark.Width, mark.Height), new Rectangle(0, 0, mark.Width, mark.Height));
        }

        /// <summary>
        /// 绘制图片水印
        /// </summary>
        /// <param name="waterMark"></param>
        /// <param name="imgFilePath"></param>
        /// <param name="destRect"></param>
        /// <param name="srcRect"></param>
        /// <returns></returns>
        public static Image DrawWatermark(Image waterMark, Image destImage, Rectangle destRect, Rectangle srcRect)
        {
            Image temp = destImage;
            Image mark = waterMark;
            int bitWidth = temp.Width;
            int bitHeight = temp.Height;
            if (bitWidth < destRect.X + destRect.Width)
            {
                bitWidth = destRect.X + destRect.Width;
            }
            if (bitHeight < destRect.Y + destRect.Height)
            {
                bitHeight = destRect.Y + destRect.Height;
            }
            Bitmap bitMap = new Bitmap(bitWidth, bitHeight);
            Graphics g = Graphics.FromImage(bitMap);
            g.Clear(Color.White);//设画布背景为白色 
            g.SmoothingMode = SmoothingMode.AntiAlias;//质量为消除齿 
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            SolidBrush solid = new SolidBrush(Color.Wheat);

            g.DrawImage(temp, 0, 0, temp.Width, temp.Height);
            g.DrawImage(mark, destRect, srcRect, GraphicsUnit.Pixel);

            Image retImg = Image.FromHbitmap(bitMap.GetHbitmap());
            g.Dispose();
            bitMap.Dispose();
            temp.Dispose();
            return retImg;
        }


        public static Image DrawWatermarkCircle(string imgFilePath)
        {
            Image temp = Image.FromFile(imgFilePath);
            int cWidth = 40;
            int cHeight = 40;
            return DrawWatermark(temp, new Rectangle(temp.Width- cWidth-50,temp.Height- cHeight-10, cWidth, cHeight), Color.FromArgb(11,116,246), 1, Color.White, "5折Lucida Sans ", new Font("Lucida Sans Unicode", 10, FontStyle.Regular));
        }

        /// <summary>
        /// 绘制圆形标水印
        /// </summary>
        /// <param name="image"></param>
        /// <param name="rectCircle"></param>
        /// <param name="bgColor"></param>
        /// <param name="borColor"></param>
        /// <param name="circleStr"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        public static Image DrawWatermark(Image image, Rectangle rectCircle, Color bgColor, int borderWidth, Color borColor, string circleStr, Font font)
        {
            Image temp = image;
            int bitWidth = temp.Width;
            int bitHeight = temp.Height;
            if (bitWidth < rectCircle.X + rectCircle.Width*1.5)
            {
                bitWidth = rectCircle.X + (int)(rectCircle.Width * 1.5);
            }
            if (bitHeight < rectCircle.Y + rectCircle.Height * 1.5)
            {
                bitHeight = rectCircle.Y + (int)(rectCircle.Height * 1.5);
            }

            Bitmap bitMap = new Bitmap(bitWidth, bitHeight);
            Graphics g = Graphics.FromImage(bitMap);
            //透明背景色
            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.AntiAlias;//质量为消除齿 
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            SolidBrush solid = new SolidBrush(Color.Wheat);
            g.DrawImage(temp, 0, 0,temp.Width,temp.Height);
            g.DrawEllipse(new Pen(borColor, rectCircle.Width), rectCircle);//背景
            Rectangle rect = new Rectangle(rectCircle.X + borderWidth, rectCircle.Y + borderWidth, rectCircle.Width - (borderWidth * 2), rectCircle.Height - (borderWidth * 2));
            g.DrawEllipse(new Pen(bgColor, rectCircle.Width - (borderWidth * 2)),rect);
            StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Near;
            
            sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Hide;
            
            g.DrawString(circleStr, font, solid,new Rectangle(rect.X-8,rect.Y-8,rect.Width+16,rect.Height+16),sf);

            Image retImg = Image.FromHbitmap(bitMap.GetHbitmap());
            g.Dispose();
            bitMap.Dispose();
            temp.Dispose();
            return retImg;
        }
        #endregion
    }
}
