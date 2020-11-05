using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App.PET.Resources
{
    public class FileManagement
    {
        private Context _context = Application.Context;

        public async Task<string> ReadDataAsync(string fileName)
        {
            try
            {

                //var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "SettingData.txt");
                //var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);
                using (var asset = _context.Assets.Open(fileName))
                using (var streamReader = new StreamReader(asset))
                {
                    return await streamReader.ReadToEndAsync();
                }

                /*
                if (backingFile == null || !File.Exists(backingFile))
                {
                    return null;
                }
                string FileData = string.Empty;
                using (var reader = new StreamReader(backingFile, true))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        FileData = line;
                    }
                }

                return FileData;
                */
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task SaveData(string fileName, string Data)
        {
            try
            {
                //var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "SettingData.txt");
                var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);
                using (var writer = File.CreateText(backingFile))
                {
                    await writer.WriteLineAsync(Data);
                }
            }
            catch (Exception ex)
            {
            }

        }
    }
}