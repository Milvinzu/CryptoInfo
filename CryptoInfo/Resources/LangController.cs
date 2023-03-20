using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoInfo.Resources
{
    class LangController
    {
        public static LangTypes CurrentLang { get; set; }

        public enum LangTypes
        {
            en_US, ua_UA, pl_PL
        }

        public static ResourceDictionary LangDictionary
        {
            get { return Application.Current.Resources.MergedDictionaries[0]; }
            set { Application.Current.Resources.MergedDictionaries.Add(value); }
        }

        private static void ChangeLang(Uri uri)
        {
            LangDictionary = new ResourceDictionary() { Source = uri };
        }

        public static void SetLang(LangTypes lang)
        {
            string langCode = null;
            CurrentLang = lang;
            switch (lang)
            {
                case LangTypes.en_US: langCode = "en-US"; break;
                case LangTypes.ua_UA: langCode = "ua-UA"; break;
                case LangTypes.pl_PL: langCode = "pl-PL"; break;
            }

            try
            {
                if (!string.IsNullOrEmpty(langCode))
                    ChangeLang(new Uri($"Resources/{langCode}.xaml", UriKind.Relative));
            }
            catch { }
        }
    }
}
