using OrionsBelt.Core;

namespace OrionsBelt.Engine.Exceptions{
    public class NoFleetException : OrionsBeltException {
        /// <summary>
        /// ELOException constructor
        /// </summary>
        public NoFleetException( int sectorId, int id )
            :base("A fleet with the id '{0}' should be associated with sector with id '{1}'",id,sectorId){}

    }
}
