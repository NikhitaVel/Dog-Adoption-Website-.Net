using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Pages
{
    public class AboutUsModel : PageModel
    {
        public void OnGet()
        {
        }

        public class ImageController : Controller
        {
            public IActionResult AddTextToImage()
            {
                // Load the image from a file (replace "image.jpg" with your image file)
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "image.jpg");
                using (var image = Image.FromFile(imagePath))
                using (var graphics = Graphics.FromImage(image))
                {
                    // Define the text and font
                    var text = "Hello, ASP.NET Core!";
                    var font = new Font("Arial", 24);
                    var brush = new SolidBrush(Color.White);

                    // Define the position to draw the text (adjust as needed)
                    var point = new PointF(50, 50);

                    // Draw the text on the image
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.DrawString(text, font, brush, point);

                    // Save the modified image to a MemoryStream
                    var ms = new MemoryStream();
                    image.Save(ms, ImageFormat.Jpeg);

                    // Set the position of the MemoryStream to the beginning
                    ms.Seek(0, SeekOrigin.Begin);

                    // Return the image as a file result
                    return File(ms, "image/jpeg");
                }
            }
        }

    }
}

