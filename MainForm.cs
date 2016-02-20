using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ExifLib;
using Microsoft.VisualBasic.FileIO;
using System.Threading;
using System.Threading.Tasks;

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

        private struct asyncWorkData
        {
            public string path;
            public List<imageInfo> targetList;
        }

        private struct asyncResultData
        {
            public List<imageInfo> resultList;
            public List<imageInfo> targetList;
        }

        private List<imageInfo> BaseList = new List<imageInfo>();
        private List<List<imageInfo>> CompareLists = new List<List<imageInfo>>();
        private int numDeleted;

        public MainForm()
        {
            InitializeComponent();
            ExtLog.Logger = logger1;
        }

        private static List<imageInfo> listFiles(string RootFolder, string CurrentFolder)
        {
            var DI = new DirectoryInfo(CurrentFolder);

            var clist = new ConcurrentBag<imageInfo>();
            Parallel.ForEach(DI.GetFiles("*.jpg"),
                jpgFile => clist.Add(LoadImageFileInfo(jpgFile.FullName, RootFolder)));

            var list = clist.ToList();

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
                    ExtLog.AddLine("Scanning folder: " + compareFolderBox.Lines[i]);
                    compareAndDelete(CompareLists[i], compareFolderBox.Lines[i]);
                    ExtLog.AddLine((numDeleted - nuldeletedbeforethisfolder).ToString("D") + " Files deleted.");
                }
                ExtLog.AddLine(numDeleted.ToString("D") + " Files deleted total.");
            }
            else ExtLog.AddLine("Error: No folders to compare.");
        }

        private void compareAndDelete(List<imageInfo> listToCompare, string StartFolder)
        {
            Parallel.ForEach(BaseList, currentBaseImage =>
            {
                for (var compareIndex = 0; compareIndex < listToCompare.Count; compareIndex++)
                {
                    if (DateAndSizesEqual(currentBaseImage, listToCompare[compareIndex]))
                    {
                        if ((File.Exists(listToCompare[compareIndex].filePath)) &&
                            (DataEquals(currentBaseImage, listToCompare[compareIndex])))
                        {
                            ExtLog.AddLine("Deleting duplicate: " +
                                removePath(listToCompare[compareIndex].filePath, StartFolder));
                            SafeDelete(listToCompare[compareIndex].filePath);
                        }
                    }
                }


            });



        }

        private static bool DateAndSizesEqual(imageInfo img1, imageInfo img2)
        {
            return ((img1.dateTaken == img2.dateTaken) && (img1.width == img2.width) && (img1.height == img2.height));
        }

        private static bool DataEquals(imageInfo img1, imageInfo img2)
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
            if (File.Exists(fullFileName))
            {
                try
                {
                    FileSystem.DeleteFile(fullFileName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    numDeleted++;
                }
                catch (Exception ex)
                {
                    ExtLog.AddLine("Error deleting file \"" + fullFileName + "\"" + ex.Message);
                }
            }
            else ExtLog.AddLine("Error deleting file \"" + fullFileName + "\" File not found");
        }

        private static string removePath(string FullName, string Path)
        {
            return FullName.Substring(Path.Length);
        }

        private static imageInfo LoadImageFileInfo(string fullFileName, string RootFolder)
        {
            var fi = new FileInfo(fullFileName);
            try
            {
                using (var reader = new ExifReader(fullFileName))
                {

                    DateTime datePictureTaken;
                    if (!reader.GetTagValue(ExifTags.DateTimeDigitized, out datePictureTaken))
                    {
                        ExtLog.AddLine("Error reading [DateTimeDigitized] tag of: " + removePath(fullFileName, RootFolder));
                        datePictureTaken = fi.LastWriteTime;
                    }

                    object pictureWidth;
                    if (!reader.GetTagValue(ExifTags.PixelXDimension, out pictureWidth))
                    {
                        ExtLog.AddLine("Error reading [ImageWidth] tag of: " + removePath(fullFileName, RootFolder));
                    }

                    object pictureHeight;
                    if (!reader.GetTagValue(ExifTags.PixelYDimension, out pictureHeight))
                    {
                        ExtLog.AddLine("Error reading [ImageLength] tag of: " + removePath(fullFileName, RootFolder));
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
                ExtLog.AddLine(string.Format("Error: {0}, in: {1}", ex.Message, removePath(fullFileName, RootFolder)));

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

        public static byte[] ImageToData(Bitmap data)
        {
            var pixelSize = Image.GetPixelFormatSize(data.PixelFormat) / 8;
            var pixelBufferSize = data.Width * data.Height * pixelSize;

            var pixelSource = new byte[pixelBufferSize];

            var pixData = data.LockBits(new Rectangle(0, 0, data.Width, data.Height), ImageLockMode.ReadOnly, data.PixelFormat);
            Marshal.Copy(pixData.Scan0, pixelSource, 0, pixelBufferSize);
            data.UnlockBits(pixData);

            return pixelSource;
        }

        private static byte[] LoadImageFileData(string fullFileName)
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
                    ExtLog.AddLine("Error loading image file data of " + fullFileName + " : " + ex.Message);
                }
            }
            return null;
        }

        private void selectBaseFolderButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                baseFolderBox.Text = folderBrowserDialog1.SelectedPath;

                AsyncListFiles(folderBrowserDialog1.SelectedPath, BaseList);
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

                    CompareLists.Add(new List<imageInfo>());
                    AsyncListFiles(folderBrowserDialog1.SelectedPath, CompareLists[CompareLists.Count - 1]);
                }
                else ExtLog.AddLine("Error Selecting Path: Path already selected as base path or compare path");
            }
        }

        private void ChangeTrashFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                trashFolderBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void AsyncListFiles(string listPath, List<imageInfo> targetResultList)
        {
            var workData = new asyncWorkData
            {
                path = listPath,
                targetList = targetResultList
            };
            backgroundWorker1.RunWorkerAsync(workData);
            //Enabled = false;
            UseWaitCursor = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var workArguments = (asyncWorkData)e.Argument;
            if (workArguments.path != null)
            {
                var results = new asyncResultData
                {
                    targetList = workArguments.targetList,
                    resultList = listFiles(workArguments.path, workArguments.path)
                };
                e.Result = results;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UseWaitCursor = false;

            if (e.Cancelled)
            {
                ExtLog.AddLine("Scan Cancelled.");
            }
            else
            {
                var workArguments = (asyncResultData)e.Result;
                ExtLog.AddLine("Scan Completed.");
                if (workArguments.resultList != null)
                {
                    ExtLog.AddLine(workArguments.resultList.Count.ToString("D") + " Files Loaded.");
                    workArguments.targetList.Clear();
                    workArguments.targetList.AddRange(workArguments.resultList);
                }
            }

        }


    }
}
