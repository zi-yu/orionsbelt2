namespace OrionsBelt.Generic {

	public class GenericSuccess : ResultItem  {

        #region ResultItem Implementation

        public override bool Ok {
            get {
                return true;
            }
        }

        public GenericSuccess()
        {
            log = "Generic Success";
        }

        #endregion ResultItem Implementation

    }
}
