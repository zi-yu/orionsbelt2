using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OrionsBelt.Generic {

	/// <summary>
	/// Represents the result of an action
	/// </summary>
	public class Result {
	
		#region Static Fields

		private static List<ResultItem> dummy = new List<ResultItem>();
		
        public static Result Empty {
            get { return new Result(); }
        }

        public static Result Fail {
            get {
                Result result = new Result();
                result.AddFailed(new GenericFail());
                return result;
            }
        }

        public static Result Success {
            get {
                Result result = new Result();
                result.AddPassed(new GenericSuccess());
                return result;
            }
        }

        public static Result Ignore {
            get {
                Result result = new Result();
                result.AddPassed(new GenericIgnore());
                return result;
            }
        }

		#endregion

        #region Static Utils

        public static Result Create(params ResultItem[] items)
        {
            Result result = new Result();

            foreach (ResultItem item in items) {
                result.Add(item);
            }

            return result;
        }


        public static Result CreateFail(params ResultItem[] items)
        {
            Result result = new Result();

            foreach (ResultItem item in items) {
                result.AddFailed(item);
            }

            return result;
        }

        public static Result CreateOk(params ResultItem[] items)
        {
            Result result = new Result();

            foreach (ResultItem item in items) {
                result.AddPassed(item);
            }

            return result;
        }

        #endregion Static Utils

        #region Instance Fields

        private List<ResultItem> passedList;
		private List<ResultItem> failedList;
		
		#endregion
		
		#region Properties
		
		/// <summary>Indica se o resultado foi com sucesso ou não</summary>
		public bool Ok {
			get { 
				return (failedList == null || failedList.Count == 0) && PassedCount > 0;  
			}
		}
		
		/// <summary>Indica o total de Items deste Result</summary>
		public int Total {
			get {
				return FailedCount + PassedCount;
			}
		}
		
		/// <summary>Indica o total de items que falharam</summary>
		public int FailedCount {
			get {
				return failedList == null ? 0 : failedList.Count; 
			}
		}
		
		/// <summary>Indica o total de items que passaram</summary>
		public int PassedCount {
			get {
				return passedList == null ? 0 : passedList.Count; 
			}
		}
		
		/// <summary>Indica todos os ResultItems que passaram</summary>
		public List<ResultItem> Passed {
			get {
				if (passedList == null ){
					return dummy;
				} 
				
				return passedList;
			}
		}
		
		/// <summary>Indica todos os ResultItems que falharam</summary>
		public List<ResultItem> Failed {
			get {
				if (failedList == null ){
					return dummy;
				} 

				return failedList;
			}
		}

		#endregion Properties

		#region Instance Methods

        public void Merge(Result other)
        {
            foreach (ResultItem item in other.Passed) {
                AddPassed(item);
            }
            foreach (ResultItem item in other.Failed) {
                AddFailed(item);
            }
        }

        public void Add(ResultItem item)
        {
            if (item.Ok) {
                AddPassed(item);
            } else {
                AddFailed(item);
            }
        }

		/// <summary>
		/// Adiciona um ResultItem ao contentor de items passados
		/// </summary>
		public void AddPassed( ResultItem item ) {
			if( passedList == null ) {
				passedList = new List<ResultItem>();
			}
			
			passedList.Add(item);
		}
		
		/// <summary>
		/// Adiciona um ResultItem ao contentor de items que falharam
		/// </summary>
		public void AddFailed( ResultItem item ) {
			if( failedList == null ) {
				failedList = new List<ResultItem>();
			}
			
			failedList.Add(item);
		}
		
		#endregion
		
		#region UtilityMethods
		
		public string Log() {
            using (TextWriter writer = new StringWriter()) {

                int pass = PassedCount;
                int fail = FailedCount;
                int total = pass + fail;

                writer.WriteLine();
                writer.WriteLine("Total: {0} ", total);
                if (total > 0) {
                    writer.WriteLine("Passed: {0}; Failed: {1}", pass, fail);
                }

                if (Passed.Count > 0) {
                    writer.WriteLine("-- Passed --");
                    foreach (ResultItem item in Passed) {
                        writer.WriteLine(item.Log());
                    }
                }

                if (Failed.Count > 0) {
                    writer.WriteLine("-- Failed --");
                    foreach (ResultItem item in Failed) {
                        writer.WriteLine(item.Log());
                    }
                }

                return writer.ToString();
            }
		}
		
		#endregion

		#region Constructor

		public Result(){}

		/// <summary>
		/// Builds a Result with an ResultItem
		/// </summary>
		/// <param name="item">Item to add</param>
		public Result( ResultItem item ) 
            : this(item, !item.Ok) {
			
		}

		/// <summary>
		/// Builds a Result with an ResultItem
		/// </summary>
		/// <param name="item">Item to add</param>
		/// <param name="failed">If this item is a result of a failure or not</param>
		public Result(ResultItem item, bool failed ) {
			if( failed ) {
				AddFailed(item);
			}else {
				AddPassed(item);
			}
		}

		#endregion

    };

};