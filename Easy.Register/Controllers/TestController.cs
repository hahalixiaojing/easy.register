using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Easy.Register.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "a.jpg");
            string path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "c.jpg");
            string path3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "d.jpg");
            System.Drawing.Bitmap b = new System.Drawing.Bitmap(path);

            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(b);

            var size = g.MeasureString("你好", new System.Drawing.Font("黑体", 80));

            var left = (b.Width - size.Width) * 0.5;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawString("你好", new System.Drawing.Font("黑体", 80), new System.Drawing.SolidBrush(System.Drawing.Color.White), new System.Drawing.PointF((float)left, 1000));

            System.Drawing.Bitmap bx = new System.Drawing.Bitmap(path3);

            g.DrawImage(bx, new System.Drawing.PointF(0, 0));
            b.Save(path2, System.Drawing.Imaging.ImageFormat.Jpeg);
            return Content("");
        }
    }
}