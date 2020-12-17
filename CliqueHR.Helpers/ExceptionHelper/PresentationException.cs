using System;

namespace CliqueHR.Helpers.ExceptionHelper
{
    public class PresentationException : IExceptionHelper {
        protected IExceptionStrategy _strategy;
        public PresentationException (Exception ex) {
            if (ex is IExceptionStrategy)
                _strategy = ex as IExceptionStrategy;
            else
                _strategy = new Status500Strategy (ex, Level.PL);
        }
        public PresentationException (Exception ex, IExceptionStrategy strategy) {
            this._strategy = strategy;
        }
        public virtual Exception GetException() {
            return null;
        }
        public virtual IExceptionStrategy GetStrategy() {
            return this._strategy;
        }
    }
}