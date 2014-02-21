namespace OrionsBelt.Engine.Universe {
	public abstract class UniverseVisibility {
		public virtual int Level {
			get { return 1; }
		}

		public virtual int ImportanceLevel {
			get { return 1; }
		}

		public virtual UniverseVisibility EvalImportance( UniverseVisibility other ) {
			if( ImportanceLevel > other.ImportanceLevel ) {
				return this;
			}
			return other;
		}

		public override string ToString() {
			return GetType().Name;
		}

	}
}