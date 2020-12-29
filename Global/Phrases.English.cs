using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsUI
{
    public partial class Phrases
    {
        private static Dictionary<string, string> _englishDictionary;
        public static Dictionary<string, string> EnglishDictionary
        {
            get
            {
                if (_englishDictionary == null)
                {
                    _englishDictionary = new Dictionary<string, string>();
                    _englishDictionary.Add("ENGLISH", "English");
                    _englishDictionary.Add("HEBREW", "Hebrew");
                    _englishDictionary.Add("DASHBOARD", "Dashboard");
                    _englishDictionary.Add("ABOUT", "About");
                    _englishDictionary.Add("WINDOW", "View Window");
                    _englishDictionary.Add("FULLSCREEN", "View Full Screen");
                    _englishDictionary.Add("EXIT", "Exit");
                    _englishDictionary.Add("QUIT", "Do you want to quit?");
                    _englishDictionary.Add("PAGE1", "Page 1");
                    _englishDictionary.Add("PAGE2", "Page 2");
                    _englishDictionary.Add("PAGE3", "Page 3");
                    _englishDictionary.Add("BACK", "Back");
                    _englishDictionary.Add("STEP1", "Step 1");
                }
                return _englishDictionary;
            }
        }
    }
}
