namespace BotHandler.Engine{
    public class SimpleElement{
		public short Id;
		public short Quantity;
        public char Direction;
        public int hash = 0;
    	private bool hasBeenAttack = false;
    	private short unitsDestroyed = 0;

    	public bool CanBeMoved {
			get { return Id > 10000; }
    	}

    	public bool Enemy {
			get { return Id >= 1000 && Id < 10000; }
    	}

    	public bool HasBeenAttack {
    		get { return hasBeenAttack; }
    		set { hasBeenAttack = value; }
    	}

		public short UnitsDestroyed {
			get { return unitsDestroyed; }
			set { unitsDestroyed = value; }
    	}

    	public override int GetHashCode(){
            if(hash==0) {
				hash = Id * 1000000 + Quantity * 100000 + unitsDestroyed * 1000 + Direction * 100;
            }
            return hash;
        }

		public SimpleElement DeepClone() {
			return new SimpleElement(Id,Quantity,Direction,GetHashCode());
		}

    	public SimpleElement(short id, short quantity,char direction) {
            Id = id;
            Quantity = quantity;
            Direction = direction;
        }

		public SimpleElement(short id, short quantity, char direction,int hash) {
			Id = id;
			Quantity = quantity;
			Direction = direction;
			this.hash = hash;
		}
    }
}
