using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Tests
{
    public class AppInitializer
    {
        public const string ApkPath = @"C:\Users\Kurkulya\AppData\Local\Packages\Microsoft.SkypeApp_kzf8qxf38zg5c\LocalState\Downloads\vkontakte.android-4_8_3.apk";
        public const string AppPath = "";
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .InstalledApp("ADataBase.ADataBase")
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}

