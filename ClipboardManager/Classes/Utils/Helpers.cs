using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardManager.Classes.Utils
{
    public class Helpers
    {
        private static readonly IList<int> _listOf365Munbers = new List<int>(Enumerable.Range(1, 365));
        public static IList<int> ListOf365Munbers
        {
            get { return _listOf365Munbers; }
        }
    }
}
