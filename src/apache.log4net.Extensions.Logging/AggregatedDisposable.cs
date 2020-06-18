using System;
using System.Collections.Generic;
using System.Linq;

namespace apache.log4net.Extensions.Logging
{
    /// <summary>
    /// Combines multiple <see cref="IDisposable"/>s into one.
    /// </summary>
    internal sealed class AggregatedDisposable : IDisposable
    {
        /// <summary>
        /// The combined <see cref="IDisposable"/>s.
        /// </summary>
        private readonly ICollection<IDisposable> _disposables;

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregatedDisposable"/> class.
        /// </summary>
        /// <param name="disposables">The <see cref="IDisposable"/> which should be combined.</param>
        public AggregatedDisposable(IEnumerable<IDisposable> disposables)
        {
            this._disposables = disposables.ToList();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            foreach (var disposable in this._disposables)
            {
                disposable.Dispose();
            }

            this._disposables.Clear();
        }
    }
}