using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace GIFTools
{
    public class GIFDecoder
    {
        private string filePath;
        private Image mImage;
        private FrameDimension mDimension;
        private int mWidth;
        private int mHeight;
        private int mFramesCount;

        public int Width
        {
            get { return mWidth; }
        }
        public int Height
        {
            get { return mHeight; }
        }
        public int FramesCount
        {
            get { return mFramesCount; }
        }

        public int SelectActiveFrame(int index)
        {
            int res = mImage.SelectActiveFrame(mDimension, index);
            mWidth = mImage.Width;
            mHeight = mImage.Height;
            return res;
        }

        public Bitmap GetCurrentFrameImage() {
            Bitmap frame = new Bitmap(mWidth, mHeight);
            Graphics.FromImage(frame).DrawImage(mImage, Point.Empty);
            return frame;
        }

        public GIFDecoder(string path)
        {
            filePath = path;
            mImage = Image.FromFile(filePath);
            mDimension = new FrameDimension(mImage.FrameDimensionsList[0]);
            mFramesCount = mImage.GetFrameCount(mDimension);
            mWidth = mImage.Width;
            mHeight = mImage.Height;
        }
    }
}
