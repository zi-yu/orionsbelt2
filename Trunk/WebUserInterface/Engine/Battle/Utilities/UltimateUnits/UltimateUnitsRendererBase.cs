using System.IO;
using DesignPatterns;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.WebUserInterface.WebBattle {

	internal abstract class UltimateUnitsRendererBase : IFactory {
		#region Public

		public abstract void Render(TextWriter writer);
		public abstract void RenderEnemy(TextWriter writer);

		#endregion Public

		#region IFactory Members

		public abstract object create(object args);

		#endregion IFactory Members
	}
}
