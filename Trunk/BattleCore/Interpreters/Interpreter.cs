using System;
using DesignPatterns;
using System.Collections.Generic;
using OrionsBelt.Generic;
using OrionsBelt.BattleCore.Exceptions;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class Interpreter {

		#region Fields

		private static readonly FactoryContainer interpreterFactory = new FactoryContainer(typeof(InterpreterBase));
		private readonly IBattleOwner IBattleOwner;
		private readonly IBattleInfo battleInfo;
		private const int maxNumberOfMoves = 6;
		private static readonly char[] separator = new char[] { ';' };

		#endregion Fields

		#region Constructor

		public Interpreter( IBattleOwner IBattleOwner, IBattleInfo battleInfo ) {
			this.IBattleOwner = IBattleOwner;
			this.battleInfo = battleInfo;
		}

		#endregion Constructor

		#region Private

		/// <summary>
		/// Verifies the final conditions: Number of Moves and If the player 
		/// positioned it's units
		/// </summary>
		private void FinalVerifications( Result result, int moveCost ) {
			if( battleInfo.IsDeployTime ) {
				if( battleInfo.InitialContainer.HasUnits ) {
					result.AddFailed(new MustPositionAllTheUnits());
				} else {
					battleInfo.CurrentBattlePlayer.HasPositioned = true;
				}
			}else{
				if( moveCost > maxNumberOfMoves ) {
					result.AddFailed(new InvalidNumberOfMoves(maxNumberOfMoves.ToString(), moveCost.ToString()));
				}
			}
		}

		/// <summary>
		/// Calls the interpreters to make all the moves
		/// </summary>
		private Result MakeMoves( IEnumerable<string> splittedMoves ) {
			Result result = new Result();
			int moveCost = 0;

			foreach( string move in splittedMoves ) {
				string[] moveSplitted = move.Split(':');
				if( moveSplitted.Length != 2 ) {
					result.AddFailed( new InvalidInterpretationData( move) );
					return result;
				}

				Dictionary<string, object> parameters = new Dictionary<string, object>();
				parameters.Add("info", moveSplitted[1]);
				parameters.Add("battleInfo", battleInfo);
				parameters.Add("IBattleOwner", IBattleOwner);

				InterpreterBase interpreter = (InterpreterBase) interpreterFactory.create(moveSplitted[0], parameters);
				
				ResultItem resultItem = interpreter.CheckMove();
				if( null != resultItem ) {
					result.AddFailed(resultItem);
					return result;
				}

				moveCost += interpreter.MoveCost();

				resultItem = interpreter.Interpretate();
				if( null != resultItem ) {
					result.AddFailed(resultItem);
					return result;
				}
			}

			FinalVerifications(result, moveCost);
			
			result.AddPassed(new MoveSucceded());
			
			return result;
		}

		#endregion

		#region Public

		public Result Interpretate( string moves ) {
			string[] splittedMoves = moves.ToLower().Split(separator, StringSplitOptions.RemoveEmptyEntries);

			Result result;
			try {
			    result = MakeMoves( splittedMoves );
			} catch( BattleException e ) {
			    result = new Result();
			    result.AddFailed( new InvalidMove( e.Message ) );
			}

			return result;
		}

		#endregion
	
	}
}
