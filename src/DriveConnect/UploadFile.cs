using System;
using System.Windows.Forms;

using SxGoogle;

namespace DriveConnect
{
    public class UploadFile
    {
        public static void Upload(string FilePath, string FileName)
        {
            Drive.FileDescription = "An example file";
            Drive.FileMimeType = "text/plain";

            Drive.UploadFile(FilePath, FileName, GDriveSettingsManager.ApiUserKey, GDriveSettingsManager.ApiUserSecret);
        }
    }
}
