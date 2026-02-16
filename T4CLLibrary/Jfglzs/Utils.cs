using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4CLLibrary.Jfglzs
{
    public static class Utils
    {
        public static string GetVersionString() 
        {
            string regPath = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey uninstallKey = Registry.LocalMachine.OpenSubKey(regPath))
            {
                if (uninstallKey != null)
                {
                    foreach (string subKeyName in uninstallKey.GetSubKeyNames())
                    {
                        using (RegistryKey subKey = uninstallKey.OpenSubKey(subKeyName))
                        {
                            string displayName = subKey.GetValue("DisplayName") as string;
                            if (!string.IsNullOrEmpty(displayName) && displayName.Contains("学生机房管理助手"))
                            {
                                string displayVersion = subKey.GetValue("DisplayVersion") as string;
                                return displayVersion ?? string.Empty;
                            }
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}
