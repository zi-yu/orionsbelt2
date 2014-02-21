namespace OrionsBelt.Generic {

	public class GenericFail : ResultItem  {

        #region ResultItem Implementation

        public override bool Ok {
            get {
                return false;
            }
        }

        public GenericFail()
        {
            log = "Generic Fail";
        }

        #endregion ResultItem Implementation

    }
}
