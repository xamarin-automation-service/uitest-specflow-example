using System;
using Xamarin.UITest;
using System.IO;
using NUnit.Framework;
using System.Reflection;

namespace Xamarin.UITest.SpecFlow
{
    static class AppManager
    {
        static IApp app;
        public static IApp App
        {
            get
            {
                if (app == null)
                    throw new NullReferenceException("'AppManager.App' not set. Call 'AppManager.StartApp()' before trying to access it.");
                return app;
            }
        }

        static Platform? platform;
        public static Platform Platform
        {
            get
            {
                if (platform == null)
                    throw new NullReferenceException("'AppManager.Platform' not set.");
                return platform.Value;
            }

            set
            {
                platform = value;
            }
        }

        public static void StartApp()
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string binariesFolder = Path.Combine(assemblyFolder, "..", "..", "..", "Binaries");

            if (Platform == Platform.Android)
            {
                app = ConfigureApp
                    .Android
                    // Used to run a .apk file:
                    .ApkFile(Path.Combine(binariesFolder, "TaskyDroid.apk"))
                    .StartApp();
            }

            if (Platform == Platform.iOS)
            {
                app = ConfigureApp
                    .iOS
                    // Used to run a .app file on an ios simulator:
                    .AppBundle(Path.Combine(binariesFolder, "TaskyiOS.app"))
                    // Used to run a .ipa file on a physical ios device:
                    //.InstalledApp("com.company.bundleid")
                    .StartApp();
            }
        }
    }
}