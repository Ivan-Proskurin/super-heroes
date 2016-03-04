using Ninject;
using Superheroes.DA;
using Superheroes.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Superheroes.Web.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        [Inject]
        public IFileRepository Files { get; set; }

        // GET: Image
        [HttpGet]
        public ActionResult Show(int id)
        {
            DbFile image = Files.Get(id);
            if (image != null)
            {
                return File(image.Body, image.ContentType);
            }
            else
            {
                return new EmptyResult();
            }
        }

        public static DbFile CreateDbFileFromHttpFile(HttpPostedFileBase file)
        {
            using (BinaryReader reader = new BinaryReader(file.InputStream))
            {
                return new DbFile()
                {
                    Body = reader.ReadBytes(file.ContentLength),
                    ContentType = file.ContentType
                };
            }
        }

    }
}