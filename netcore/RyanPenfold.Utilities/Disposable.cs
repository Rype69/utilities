// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Disposable.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// <remarks>
//   Written by IDesign www.idesign.net
// </remarks>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities
{
    /// <summary>
    /// A disposable base type
    /// </summary>
    public class Disposable : System.IDisposable
    {
        /// <summary>
        /// Denotes disposed
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Finalizes an instance of the <see cref="Disposable"/> class. 
        /// </summary>
        ~Disposable()
        {
            this.Cleanup();
        } 

        /// <summary>
        /// Gets a value indicating whether Disposed.
        /// </summary>
        protected bool Disposed
        {
           get
           {
               lock (this)
               {
                   return this.disposed;
                }
            }
        }

        /// <summary>
        /// Performs a dispose
        /// </summary>
        public void Dispose()
        {
            lock (this)
            {
                if (this.disposed)
                {
                    return;
                }

                this.Cleanup();
                this.disposed = true;

                System.GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// override to provide cleanup
        /// </summary>
        public virtual void Cleanup()
        {
            // override to provide cleanup
        }
    }
}
