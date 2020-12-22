using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsUI
{
    public partial class Phrases
    {
        private static Dictionary<string, string> _hebrewDictionary;
        public static Dictionary<string, string> HebrewDictionary
        {
            get
            {
                if (_hebrewDictionary == null)
                {
                    _hebrewDictionary = new Dictionary<string, string>();
                    _hebrewDictionary.Add("ENGLISH", "אנגלית");
                    _hebrewDictionary.Add("HEBREW", "עִברִית");
                    _hebrewDictionary.Add("DASHBOARD", "לוּחַ מַחווָנִים");
                    _hebrewDictionary.Add("ABOUT", "על אודות");
                    _hebrewDictionary.Add("WINDOW", "חלון נוף");
                    _hebrewDictionary.Add("FULLSCREEN", "צפה במסך מלא");
                    _hebrewDictionary.Add("EXIT", "יְצִיאָה");
                    _hebrewDictionary.Add("QUIT", "?האם אתה רוצה להפסיק");
                }
                return _hebrewDictionary;
            }
        }
    }
}
