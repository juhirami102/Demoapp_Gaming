using System;

namespace CliqueHR.Helpers.ExceptionHelper
{
    public class DataException : IExceptionHelper {
        protected IExceptionStrategy _strategy;
        public DataException (Exception ex){
            _strategy = new Status500Strategy (ex, Level.DL);
        }
        public DataException (IExceptionStrategy strategy) {
                this._strategy = strategy;
        }
        public virtual Exception GetException() {
            return _strategy as Exception;
        }
        public virtual IExceptionStrategy GetStrategy()
        {
            return this._strategy;
        }
        
    }

}