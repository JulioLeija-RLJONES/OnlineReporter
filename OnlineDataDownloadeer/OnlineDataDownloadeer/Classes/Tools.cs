using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDataDownloadeer.Classes
{
    class Tools
    {
        static System.Windows.Forms.Form commingFrom;

        static public OnlineDriver OnlineChrome = new OnlineDriver(commingFrom);

    }
}
