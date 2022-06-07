using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u20679483_hw3.Models;

namespace u20679483_hw3.Controllers
{
    public class HomeController : Controller
    {
        public static List<FileModel> files = new List<FileModel>();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string type)
        {
            Random random = new Random();

            if (type == "doc")
            {
                try//manage possible crashes
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName); //Not sure if file will be valid
                     
                        string _path = Path.Combine(Server.MapPath("~/Media/Documents"), _FileName); 
                       
                        FileModel item = new FileModel();

                        item.Link = "~/Media/Documents" + _FileName;
                        item.FileName = _FileName;
                        item.id = random.Next(10000);
                        item.type = "doc";
                        files.Add(item);
                        Session["files"] = files;
                        file.SaveAs(_path); //Possible point of error
                    }
                    ViewBag.Message = "File Uploaded Successfully!!";
                    return View();
                }
                catch
                {
                    ViewBag.Message = "File upload failed!!";
                    return View();
                }
            }
            if (type == "img")
            {
                try
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Media/Images"), _FileName);

                        FileModel item = new FileModel();

                        item.Link = "~/Media/Images" + _FileName;
                        item.FileName = _FileName;
                        item.id = random.Next(10000);
                        item.type = "img";
                        files.Add(item);
                        Session["files"] = files;
                        file.SaveAs(_path);
                    }
                    ViewBag.Message = "File Uploaded Successfully!!";
                    return View();
                }
                catch
                {
                    ViewBag.Message = "File upload failed!!";
                    return View();
                }
            }
            if (type == "vid")
            {
                try
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Media/Videos"), _FileName);

                        FileModel item = new FileModel();
                        item.Link = "~/Media/Videos" + _FileName;
                        item.FileName = _FileName;
                        item.id = random.Next(10000);
                        item.type = "vid";
                        files.Add(item);
                        Session["files"] = files;
                        file.SaveAs(_path);
                    }
                    ViewBag.Message = "File Uploaded Successfully!!";
                    return View();
                }
                catch
                {
                    ViewBag.Message = "File upload failed!!";
                    return View();
                }
            }
            return View();

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}