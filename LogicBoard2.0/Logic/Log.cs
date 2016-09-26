using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LogicBoard2._0.Logic
{
    class Log
    {
        private static Log instance;
        private List<ILoggeble> recipients;

        private Log() {
            recipients = new List<ILoggeble>();
        }

        public static Log Instance {
            get
            {
                if (instance == null)
                    instance = new Log();

                return instance;
            }
        }

        public void AddRecipient(ILoggeble windowRecipient) {
            recipients.Add(windowRecipient);
        }

        public void AddLogLine(string logLines)
        {
            AddLogLine(new string []{ logLines });
        }

        public void AddLogLine(string[] logLines)
        {
            foreach (ILoggeble recipient in recipients)
                recipient.DisplayLogLine(logLines);
        }

        public void AddErrorLogLine(string logLines)
        {
            AddErrorLogLine(new string[] { logLines });
        }

        public void AddErrorLogLine(string[] logLines)
        {
            foreach (ILoggeble recipient in recipients)
                recipient.DisplayErrorLogLine(logLines);
        }
    }
}
