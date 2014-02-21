using System.Collections.Generic;

namespace BotHandler.Engine {
    public class AttackChecker{

        #region Fields

        private static readonly Dictionary<string, CheckAttack> attackCheck = new Dictionary<string, CheckAttack>();
        private delegate bool CheckAttack(Battle battle, int range, int srcX, int srcY, int dstX, int dstY, bool catapult);

        #endregion Fields

        #region Private

        private static bool CheckPathVert(Battle battle,int stat, int src, int dst, bool catapult){
            for (int i = src+1; i < dst; ++i){
                if (battle.SectorHasElement(i,stat) && !catapult){
                    return false;
                }
            }
            return true;
        }

        private static bool CheckPathHoriz(Battle battle,int stat, int src, int dst, bool catapult){
            for (int i = src; i < dst; ++i){
                if (battle.SectorHasElement(stat,i) && !catapult){
                    return false;
                }
            }
            return true;
        }

        private static bool CheckAttackN(Battle battle, int range, int srcX,int srcY,int dstX,int dstY, bool catapult){
            int v = srcX - range;

            if (v <= 0 && dstX == 0 && dstY == 0){
                return CheckPathVert(battle, srcY, dstX + 1, srcX, catapult);
            }

            if (CheckPathVert(battle, srcY, dstX, srcX, catapult)){
                bool first = dstX < srcX && dstX >= v;
                if (srcY == 9 ){
                    return first;
                }
                return first && srcY == dstY;
            }
            return false;
        }

        private static bool CheckAttackS(Battle battle, int range, int srcX,int srcY,int dstX,int dstY, bool catapult){
            int v = srcX + range;

            if (CheckPathVert(battle, srcY, srcX + 1, dstX, catapult)){
                bool first = dstX > srcX && dstX <= v;
                if ((srcY == 0 || srcY == 9 || dstY == 0 || dstY == 9) ){
                    return first;
                }
                return first && srcY == dstY;
            }
            return false;
        }

        private static bool CheckAttackW(Battle battle, int range, int srcX,int srcY,int dstX,int dstY, bool catapult){
            int v = srcY - range;
            if (CheckPathHoriz(battle, srcX, dstY + 1, srcY, catapult)){
                return dstY < srcY && dstY >= v && srcX == dstX;
            }
            return false;
        }

        private static bool CheckAttackE(Battle battle, int range, int srcX,int srcY,int dstX,int dstY, bool catapult){
            int v = srcY + range;
            if (CheckPathHoriz(battle, srcX, srcY + 1, dstY, catapult)){
                return dstY > srcY && dstY <= v && srcX == dstX;
            }
            return false;
        }

        #endregion Private

        #region Public

        public static bool CanAttack(Battle battle, Element element, Element dstElement){
            if (element.OwnerId == dstElement.OwnerId) {
                return false;
            }
            if (!element.CanbeMoved) {
                return false;
            }
            return attackCheck[element.Direction](battle, element.Unit.Range, element.Coordinate.X, element.Coordinate.Y, dstElement.Coordinate.X, dstElement.Coordinate.Y, element.Unit.Catapult);
        }

        #endregion Public

        #region Constructor

        static AttackChecker(){
            attackCheck.Add("N", CheckAttackN);
            attackCheck.Add("S", CheckAttackS);
            attackCheck.Add("E", CheckAttackE);
            attackCheck.Add("W", CheckAttackW);
        }

        #endregion Constructor
    }
}
