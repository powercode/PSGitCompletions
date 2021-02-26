using System;
using System.Collections.Generic;

namespace PowerCode {
    public struct GitExecuterScope : IDisposable
    {
        private readonly Func<string, IEnumerable<string>> _executer;

        public GitExecuterScope(Func<string, IEnumerable<string>> executer)
        {
            _executer = executer;
        }

        public void Dispose()
        {
            Git.GitExecuter = _executer;
        }
    }
}