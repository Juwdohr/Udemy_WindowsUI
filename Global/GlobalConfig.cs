using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsUI
{
    public static class GlobalConfig
    {
        public static string LANGUAGE = "";

        public const string ENGLISH = "English";
        public const string HEBREW = "Hebrew";

        public const string DASHBOARD = "Dashboard";
        public const string PAGE = "Page";

        #region events

        public  static event EventHandler LanguageChanged;

        public static void LanguageChangedFunction()
        {
            if (LanguageChanged != null)
            {
                LanguageChanged(new object(), new EventArgs());
            }
        }

        #endregion

    }
}
