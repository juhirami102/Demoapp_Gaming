using System;

namespace CliqueHR.Helpers.ExceptionHelper {
    public class BusinessException : IExceptionHelper {
        protected IExceptionStrategy _strategy;
        public BusinessException (Exception ex) {
            if (ex is IExceptionStrategy)
                _strategy = ex as IExceptionStrategy;
            else if (ex is ValidationException) {
                _strategy = new ValidationStrategy (ex as ValidationException, Level.BL);

            } else {
                _strategy = new Status500Strategy (ex, Level.DL);
            }
        }
        public BusinessException (IExceptionStrategy strategy) {
            this._strategy = strategy;
        }
        public virtual Exception GetException() {
            return _strategy as Exception;
        }
        public virtual IExceptionStrategy GetStrategy() {
            return this._strategy;
        }
    }
}