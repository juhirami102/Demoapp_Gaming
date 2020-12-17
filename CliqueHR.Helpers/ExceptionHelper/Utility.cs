using System;

namespace CliqueHR.Helpers.ExceptionHelper
{

    public enum Level {
        DL,
        BL,
        PL
    }
    public class ExceptionData {
        public int Status { get; set; }
        public object Data { get; set; }
    }
    public interface IUserException {
        object Data { get; set; }
    }
    public interface IExceptionHelper {
        Exception GetException ();
        IExceptionStrategy GetStrategy();
    }

    public interface IExceptionStrategy {
        int StatusCode { get; }
        object GetData ();
    }

    public class Status500Message {
        public string Level { get; set; }
        public string Error { get; set; }
    }

    public abstract class AbstractStrategy : Exception {
        private Exception _exception;
        protected object _data = null;
        public AbstractStrategy (Exception ex, Level level) : base ("", ex.InnerException) {
            _exception = ex;
            Generate (ex, level);
        }
        protected abstract void Generate (Exception ex, Level level);

        public override string StackTrace {
            get {
                return _exception.StackTrace;
            }
        }

        public override string Source {
            get {
                return _exception.Source;
            }
        }
    }
    public class Status500Strategy : AbstractStrategy, IExceptionStrategy {
        public int StatusCode {
            get {
                return 500;
            }
        }
        public Status500Strategy (Exception ex, Level level) : base (ex, level) { }
        public object GetData () {
            return this._data;
        }
        protected override void Generate (Exception ex, Level level) {
            var data = new Status500Message ();
            data.Level = level.ToString ();
            data.Error = ex.Message;
            this._data = data as object;

        }
        public override string Message {
            get {
                Status500Message message = this._data as Status500Message;
                return "(" + message.Level.ToString () + ")" + message.Error;
            }
        }
    }

    public class ValidationStrategy : AbstractStrategy, IExceptionStrategy {
        public int StatusCode {
            get {
                return 400;
            }
        }
        public ValidationStrategy (ValidationException ex, Level level) : base (ex, level) { }
        public object GetData () {
            return this._data;
        }
        protected override void Generate(Exception ex, Level level){
            if(ex is IUserException){
                this._data = (ex as IUserException).Data;
            }
        }

        public override string Message {
            get {
                return "Validation Error.";
            }
        }
    }

}