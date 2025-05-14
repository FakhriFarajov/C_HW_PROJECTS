using Project.Models;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace Project.Services
{
    public static class PdfService
    {
        public static List<string> pdfPaths = new List<string>();

        public static void Pdf(User user)
        {
            var document = new PdfDocument();
            var font = new XFont("Verdana", 12);
            int y = 40;
            int movieCount = 0;
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            foreach (var movie in user.Favourites)
            {
                if (movieCount > 0 && movieCount % 5 == 0)
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    y = 40;
                }

                gfx.DrawString(movie.MovieTitle, font, XBrushes.Black,
                    new XRect(20, y, page.Width, 20), XStringFormats.TopLeft);
                y += 20;

                gfx.DrawString(movie.releaseDate, font, XBrushes.Gray,
                    new XRect(20, y, page.Width - 40, 40), XStringFormats.TopLeft);
                y += 60;

                movieCount++;
            }

            string filename = "FavoriteMovies.pdf";
            document.Save(filename);
            pdfPaths.Add(filename);
        }
    }
}