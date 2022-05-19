using System;


namespace OddCommon.Debug
{
    public class WorkerThreadLogger : OddBehaviourSingle<WorkerThreadLogger>
    {
        #region Methods
        #region Unity Messages
        protected virtual void Start()
        {
            AppDomain.CurrentDomain.UnhandledException += this.WorkerThreadUnhandledExceptionHandler;
        }
        #endregion //Unity Messages

        #region Event Handlers
        protected virtual void WorkerThreadUnhandledExceptionHandler(object obj, UnhandledExceptionEventArgs args)
        {
            Logging.Exception(args.ExceptionObject as Exception);
        }
        #endregion //Event Handlers
        #endregion//Methods
    }   
}