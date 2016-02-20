using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using ExifLib;
using Microsoft.VisualBasic.FileIO;

namespace ImageComparer
{
    public partial class MainForm : Form
    {
        private struct imageInfo
        {
            public string filePath;
            public string dateTaken;
            public int width;
            public int height;
            public byte[] data;
        }

        private List<imageInfo> BaseList;
        private List<List<imageInfo>> CompareLists = new List<List<imageInfo>>();
        private int numDeleted;

        public MainForm()
        {
            InitializeComponent();
        }

        private void log(string s)
        {
            if (logTextBox.Lines.Length > 0) logTextBox.AppendText("\r\n" + s);
            else logTextBox.Text = s;
        }

        private List<imageInfo> listFiles(string RootFolder)
        {
            return listFiles(RootFolder, RootFolder);
        }
        private List<imageInfo> listFiles(string RootFolder, string CurrentFolder)
        {
            var DI = new DirectoryInfo(CurrentFolder);
            var list = DI.GetFiles("*.jpg").Select(
                file => LoadImageFileInfo(file.FullName, RootFolder)
                ).ToList();
            foreach (var folder in DI.GetDirectories())
            {
                list.AddRange(listFiles(RootFolder, folder.FullName));
            }
            return list;
        }

        private void startCompareButton_Click(object sender, EventArgs e)
        {
            numDeleted = 0;
            if (CompareLists.Count > 0)
            {
                for (var i = 0; i < CompareLists.Count; i++)
                {
                    var nuldeletedbeforethisfolder = numDeleted;
                    log("Scanning folder: " + compareFolderBox.Lines[i]);
                    compareAndDelete(CompareLists[i], compareFolderBox.Lines[i]);
                    log((numDeleted - nuldeletedbeforethisfolder).ToString("D") + " Files deleted.");
                }
                log(numDeleted.ToString("D") + " Files deleted total.");
            }
            else log("Error: No folders to compare.");
        }

        private void compareAndDelete(List<imageInfo> listToCompare, string StartFolder)
        {
            for (var baseIndex = 0; baseIndex < BaseList.Count; baseIndex++)
            {
                for (var compareIndex = 0; compareIndex < listToCompare.Count; compareIndex++)
                {

                    //check dates + sizes
                    //check data
                    //safeDelete

                    if (DateAndSizesEqual(BaseList[baseIndex], listToCompare[compareIndex]))
                    {
                        if ((File.Exists(listToCompare[compareIndex].filePath)) &&
                            (DataEquals(BaseList[baseIndex], listToCompare[compareIndex]))) ;
                        {
                            log("Deleting duplicate: " + removePath(listToCompare[compareIndex].filePath, StartFolder));
                            SafeDelete(listToCompare[compareIndex].filePath);
                        }

                    }
                }
            }
        }

        private static bool DateAndSizesEqual(imageInfo img1, imageInfo img2)
        {
            return ((img1.dateTaken == img2.dateTaken) && (img1.width == img2.width) && (img1.height == img2.height));
        }

        private bool DataEquals(imageInfo img1, imageInfo img2)
        {
            var dataIsEqual = false;
            if (img1.data == null) img1.data = LoadImageFileData(img1.filePath);
            if (img2.data == null) img2.data = LoadImageFileData(img2.filePath);
            if ((img1.data != null) && (img2.data != null) && (img1.data.Length == img2.data.Length))
            {
                dataIsEqual = true;
                var offset = 0;
                while (dataIsEqual && (offset < img1.data.Length))
                {
                    dataIsEqual = (img1.data[offset] == img2.data[offset]);
                    offset++;
                }
            }
            return dataIsEqual;
        }

        private void SafeDelete(string fullFileName)
        {
            //FileSystem.DeleteFile(fullFileName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            numDeleted++;
        }

        private static string removePath(string FullName, string Path)
        {
            return FullName.Substring(Path.Length);
        }
        
        private imageInfo LoadImageFileInfo(string fullFileName, string RootFolder)
        {
            var fi = new FileInfo(fullFileName);
            try
            {
                using (var reader = new ExifReader(fullFileName))
                {

                    DateTime datePictureTaken;
                    if (!reader.GetTagValue(ExifTags.DateTimeDigitized, out datePictureTaken))
                    {
                        log("Error reading [DateTimeDigitized] tag of: " + removePath(fullFileName, RootFolder));
                        datePictureTaken = fi.LastWriteTime;
                    }

                    object pictureWidth;
                    if (!reader.GetTagValue(ExifTags.PixelXDimension, out pictureWidth))
                    {
                        log("Error reading [ImageWidth] tag of: " + removePath(fullFileName, RootFolder));
                    }

                    object pictureHeight;
                    if (!reader.GetTagValue(ExifTags.PixelYDimension, out pictureHeight))
                    {
                        log("Error reading [ImageLength] tag of: " + removePath(fullFileName, RootFolder));
                    }

                    return new imageInfo
                    {
                        filePath = fullFileName,
                        width = Convert.ToInt32(pictureWidth),
                        height = Convert.ToInt32(pictureHeight),
                        dateTaken = datePictureTaken.ToString("yyyy-MM-dd hh-mm-ss"),
                        data = null
                    };
                }
            }
            catch (Exception ex)
            {
                log("Error loading exif data: " + ex.Message);
                log("Using basic image data for: " + fullFileName);

                using (var bp = new Bitmap(fullFileName))
                    return new imageInfo
                    {
                        filePath = fullFileName,
                        width = bp.Width,
                        height = bp.Height,
                        dateTaken = fi.LastWriteTime.ToString("yyyy-MM-dd hh-mm-ss"),
                        data = null
                    };
            }
        }

        public byte[] ImageToData(Bitmap data)
        {
            var pixelSize = Image.GetPixelFormatSize(data.PixelFormat) / 8;
            var pixelBufferSize = data.Width * data.Height * pixelSize;

            var pixelSource = new byte[pixelBufferSize];

            var pixData = data.LockBits(new Rectangle(0, 0, data.Width, data.Height), ImageLockMode.ReadOnly, data.PixelFormat);
            Marshal.Copy(pixData.Scan0, pixelSource, 0, pixelBufferSize);
            data.UnlockBits(pixData);

            return pixelSource;
        }

        private byte[] LoadImageFileData(string fullFileName)
        {
            if (File.Exists(fullFileName))
            {
                try
                {
                    using (var bitmap = new Bitmap(fullFileName))
                    {
                        return ImageToData(bitmap);
                    }
                }
                catch (Exception ex)
                {
                    log("Error loading image file data of " + fullFileName + " : " + ex.Message);
                }
            }
            return null;
        }

        private void selectBaseFolderButton_Click(object sender, EventArgs e)
        {
            //folderBrowserDialog1.SelectedPath = folderBrowserDialog1.RootFolder.ToString(); infuriating idea...
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                baseFolderBox.Text = folderBrowserDialog1.SelectedPath;
                BaseList = listFiles(baseFolderBox.Text);
                log(BaseList.Count.ToString("D") + " Files Loaded.");
            }
        }

        private void clearCompareFolderListButton_Click(object sender, EventArgs e)
        {
            compareFolderBox.Clear();
            CompareLists.Clear();
        }

        private void AddCompareFolderButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((folderBrowserDialog1.SelectedPath != baseFolderBox.Text) &&
                    (!compareFolderBox.Lines.Contains(folderBrowserDialog1.SelectedPath)))
                {
                    if (compareFolderBox.Lines.Length > 0) compareFolderBox.AppendText("\r\n");
                    compareFolderBox.AppendText(folderBrowserDialog1.SelectedPath);

                    CompareLists.Add(listFiles(folderBrowserDialog1.SelectedPath));
                    log(CompareLists[CompareLists.Count - 1].Count.ToString("D") + " Files Loaded.");
                }
                else log("Error Selecting Path: Path already selected as base path or compare path");
            }
        }

        private void ChangeTrashFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                trashFolderBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }


    }
}
