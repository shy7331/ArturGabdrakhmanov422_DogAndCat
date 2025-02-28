using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace ArturGabdrakhmanov422_DogAndCat.Components
{
    public partial class PhotoDog
    {
       

        public ImageSource PhotoSource
        {
            get
            {
                if (PhotoBit != null && PhotoBit.Length > 0)
                {
                    using (var ms = new MemoryStream(PhotoBit))
                    {
                        BitmapImage img = new BitmapImage();
                        img.BeginInit();
                        img.StreamSource = ms;
                        img.CacheOption = BitmapCacheOption.OnLoad;
                        img.EndInit();
                        return img;
                    }
                }
                return null;
            }
        }
    }
}
