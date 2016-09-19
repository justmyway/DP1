using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_board.Model
{
    class Board
    {
        private List<Node> _inputProbes;
        private List<Node> _outputprobes;
        private string[] _errorLog;

        public List<Node> setInputProbes { set { _inputProbes = value; } }
        public List<Node> setOutputProbes { set { _outputprobes = value; } }

        public bool Verify()
        {
            Array.Clear(_errorLog, 0, _errorLog.Length);
            foreach (Node inputProbe in _inputProbes) {
                _errorLog = inputProbe.Validate(_errorLog);
            }
            return _errorLog.Length == 0;
        }

        public string[] ErrorLog()
        {
            return _errorLog;
        }
    }
}
