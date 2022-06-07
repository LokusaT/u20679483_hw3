using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u20679483_hw3.Models;

namespace u20679483_hw3.Controllers
{
    public class ImagesController : Controller
    {
        static public List<FileModel> items = new List<FileModel>();
        // GET: Images
        public ActionResult Index()
        {
            items = ((List<FileModel>)Session["files"]);
            var thing = items.Where(x => x.type == "img"); //linq query 
            return View(thing.ToList());
        }
        public FileResult Download(int id)
        {
            items = ((List<FileModel>)Session["files"]);
            FileModel fileModel = new FileModel();
            fileModel = items.FirstOrDefault(x => x.id == id); //Linq query to find the selected file in the list
            string path = Server.MapPath("~/Files/" + fileModel.FileName); //Find
            byte[] bytes = System.IO.File.ReadAllBytes(path);//Read

            return File(bytes, "application/octet-stream", fileModel.FileName);//Return
        }
        public ActionResult Delete(int id)
        {
            items = ((List<FileModel>)Session["files"]);
            FileModel fileModel = new FileModel();
            fileModel = items.FirstOrDefault(x => x.id == id); //Linq query to find the item that needs to be deleted  

            items.Remove(fileModel); // Delete the item
            Session["files"] = items; //Updating session
            return View("Index");
        }
    }
}