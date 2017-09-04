﻿using Photo2cvShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Photo2cvShare.Controllers {
	public class PhotoController : Controller {

		private PhotoSharingContext context = new PhotoSharingContext();
		// GET: Photo

		public ActionResult Index() {
			return View("index", context.Photos.ToList());
		}

		public ActionResult Display(int Id) {
			Photo photo = context.Photos.Find(Id);
			if (photo == null) {
				return HttpNotFound();
			}
			return View("Disply", photo);
		}

		public ActionResult Create() {
			Photo newPhoto = new Photo();
			newPhoto.CreatedDate = DateTime.Today;
			return View("Create", newPhoto);
		}

		[HttpPost]
		public ActionResult Create(Photo photo, HttpPostedFileBase image) {
			photo.CreatedDate = DateTime.Today;
			if (!ModelState.IsValid) {
				return View("Create", photo);
			} else {
				if(image != null) {
					photo.ImageMimeType = image.ContentType;
					photo.PhotoFile = new byte[image.ContentLength];
					image.InputStream.Read(photo.PhotoFile, 0, image.ContentLength);
				}
				context.Photos.Add(photo);
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			
		}

		public ActionResult Delete(int Id) {
			Photo photo = context.Photos.Find(Id);
			if (photo == null) {
				return HttpNotFound();
			}
			return View("Delete", photo);
		}

		[HttpPost]
		[ActionName("Delete")]
		public ActionResult DeleteConfirmed(int Id) {
			Photo photo = context.Photos.Find(Id);
			context.Photos.Remove(photo);
			if (photo != null) {
				return File(photo.PhotoFile, photo.ImageMimeType);
			} else {
				return null;
			}
		}
	}
}