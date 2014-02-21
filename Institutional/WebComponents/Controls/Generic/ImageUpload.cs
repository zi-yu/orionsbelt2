using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Web.UI;
using Image = System.Drawing.Image;
using System.Drawing.Drawing2D;
using System.Web;
using System.Configuration;

namespace Institutional.WebComponents.Controls {
	 public class ImageUpload : Control{

        #region Fields

        protected FileUpload fileUploader = new FileUpload();
        public static string[] validContentTypes = new string[] { "image/jpeg", "image/jpg", "image/gif", "image/png" };
        protected List<Size> sizes = new List<Size>();
        
        #endregion Fields

        #region Properties

        public List<Size> Sizes { 
			get{ return sizes;}
			set{ sizes = value; }
		}

        public string UploadDir {
            get {
                return string.Format("{0}{1}{3}{2}{3}", HttpContext.Current.Server.MapPath("Images/Uploads/"), DateTime.Now.Year, DateTime.Now.ToString("MM"), Path.DirectorySeparatorChar);
            }
        }

        #endregion Properties
               
        #region Private

        private bool SaveImage(string path, Bitmap img) {
            return SaveImage(path, img, 100);
        }

        private bool SaveImage(string path, Bitmap img, long quality) {
            string dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir)) {
                Directory.CreateDirectory(dir);
            }

            EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, quality);

            ImageCodecInfo jpegCodec = GetEncoderInfo(fileUploader.PostedFile.ContentType);

            if (jpegCodec != null) {
                EncoderParameters encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = qualityParam;

                img.Save(path, jpegCodec, encoderParams);
                return true;
            }
            return false;
        }

        private ImageCodecInfo GetEncoderInfo(string mimeType) {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            for (int i = 0; i < codecs.Length; ++i) {
                if (codecs[i].MimeType == mimeType) {
                    return codecs[i];
                }
            }
            return null;
        }

        private string ResizeAndSaveImage(Image imgToResize, Size size, string name, string extension) {
            if (size.Width < 0 || size.Height < 0) {
                throw new Exception("You need to Provide a valid Width and Height");
            }

            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercentW = ((float)size.Width / (float)sourceWidth);
            float nPercentH = ((float)size.Height / (float)sourceHeight);
            float nPercent = nPercentH < nPercentW ? nPercentH : nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            string imagePath = GetImagePath(name,extension,size);
            if (SaveImage(imagePath, b)) {
                return imagePath;
            }
            return null;
        }

        private string GetImagePath(string name, string extension, Size size) {
            int count = 0;
            string currentName = name;
            while(true) {
                string filePath = string.Format("{0}{1}_{2}x{3}{4}", UploadDir, currentName, size.Width, size.Height, extension);
                if (File.Exists(filePath)) { 
                    ++count;
                    currentName = string.Format("{0}{1}", name, count);
                    continue;
                }
                return filePath;
            }
        }

        private string GetImagePath(string name, string extension) {
            int count = 0;
            string currentName = name;
            while (true) {
                string filePath = string.Format("{0}{1}{2}", UploadDir, currentName, extension);
                if (File.Exists(filePath)) {
                    ++count;
                    currentName = string.Format("{0}{1}", name, count);
                    continue;
                }
                return filePath;
            }
        }
       
        private void SaveResizedImages(List<string> imagesSaved, string name, string ext, Image uploadedImage) {
            foreach (Size size in Sizes) {
                string imageName = ResizeAndSaveImage(uploadedImage, size, name, ext);
                if (!string.IsNullOrEmpty(imageName)) {
                    imagesSaved.Add(imageName);
                }
            }
        }

        private void SaveOriginalImage(List<string> imagesSaved, string name, string ext, Image uploadedImage) {
            string originalFilePath = GetImagePath(name, ext);
            SaveImage(originalFilePath, new Bitmap(uploadedImage));
            imagesSaved.Add(originalFilePath);
        }
        
        #endregion Private

        #region Public

        public bool IsImage() {
            string contentType = fileUploader.PostedFile.ContentType;
            foreach (string ct in validContentTypes) {
                if (ct.Equals(contentType)) {
                    return true;
                }
            }
            return false;
        }

        public void AddSize(Size size) {
            Sizes.Add(size);
        }

        public void AddSize(int width, int height) {
            AddSize(new Size(width, height));
        }

        public List<string> SaveUploadedImage() {
            List<string> imagesSaved = new List<string>();
            if (fileUploader.HasFile && IsImage()) {
                string name = Path.GetFileNameWithoutExtension(fileUploader.FileName);
                string ext = Path.GetExtension(fileUploader.FileName);
                
                Image uploadedImage = Image.FromStream(fileUploader.FileContent);
                SaveOriginalImage(imagesSaved, name, ext, uploadedImage);
                SaveResizedImages(imagesSaved, name, ext, uploadedImage);
            }
            return imagesSaved;
        }

        #endregion Public

        #region Control Events

        protected override void OnInit(EventArgs e) {
            Controls.Add(fileUploader);
            base.OnInit(e);
        }

        #endregion Control Events
    }
}
