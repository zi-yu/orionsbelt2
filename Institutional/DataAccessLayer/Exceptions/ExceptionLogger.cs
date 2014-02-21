using System;
using System.Web;
using Institutional.DataAccessLayer;
using Institutional.Core;

namespace Institutional.DataAccessLayer {
	
	public class ExceptionLogger {
	
		#region Utilities
		
		public static void Log( Exception ex ) {
			try {

				LogErrorToErrOutput(ex);

			    using( IExceptionInfoPersistance info = Persistance.Instance.OpenExceptionInfoPersistance() ) {
				    ExceptionInfo exceptionInfo = info.Create();

				    exceptionInfo.Message = ex.ToString();
				    exceptionInfo.Name = ex.GetType().Name;
				    exceptionInfo.Date = DateTime.Now;
				    exceptionInfo.StackTrace = ex.StackTrace;
    				
				    if (HttpContext.Current != null) {
					    SetPrincipal(exceptionInfo);
					    exceptionInfo.Url = HttpContext.Current.Request.Url.AbsoluteUri;
				    }
    				
				    info.Update( exceptionInfo );
				    info.Flush();
			    }

            } catch( Exception e ) {
                Console.Error.WriteLine("--------- ERROR Saving Log --------------");
                Console.Error.WriteLine(e);
                Console.Error.WriteLine("------------------------------");
            }
		}
		
		private static void LogErrorToErrOutput(Exception ex)
        {
            Console.Error.WriteLine("--------- ERROR --------------");
            if (HttpContext.Current != null && HttpContext.Current.Request != null) {
                Console.Error.WriteLine("RawUrl: {0}", HttpContext.Current.Request.RawUrl);
                Console.Error.WriteLine("Referrer: {0}", HttpContext.Current.Request.UrlReferrer);
            }
            Console.Error.WriteLine(ex);
            Console.Error.WriteLine("------------------------------");
        }
		
		private static void SetPrincipal(ExceptionInfo exceptionInfo)
        {
            try{
                if (HttpContext.Current.User is Principal){
                    exceptionInfo.Principal = (Principal)HttpContext.Current.User;
                }
            }catch{
            }
        }
		
		#endregion Utilities
		
	};
}
