namespace OrionsBelt.Generic {

	public class GenericIgnore : ResultItem  {

        #region ResultItem Implementation

        public override bool Ok {
            get {
                return true;
            }
        }

        public GenericIgnore()
        {
            log = "Generic Ignore";
        }

        public override string Log(OrionsBelt.Generic.Messages.IMessageParameterTranslator translator)
        {
            return string.Empty;
        }

        #endregion ResultItem Implementation

    }
}
