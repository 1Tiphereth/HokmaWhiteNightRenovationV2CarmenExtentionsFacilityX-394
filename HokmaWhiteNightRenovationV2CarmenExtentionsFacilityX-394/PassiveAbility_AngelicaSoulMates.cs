using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_AngelicaSoulMates : PassiveAbilityBase
    {
        int _c = -1;
        public override int SpeedDiceNumAdder()
        {
            int num = 1;
            if (owner.bufListDetail.GetActivatedBufList().Exists((BattleUnitBuf x) => x is BattleUnitBuf_SpiritLink))
            {
                num = 2;
            }
            int num2 = owner.emotionDetail.SpeedDiceNumAdder();
            if (num2 > 0)
            {
                num -= num2;
            }
            return num;
        }

        public override void OnWaveStart()
        {
            base.OnWaveStart();
            owner.allyCardDetail.DrawCards(2);
        }

        public override void OnRoundEnd()
        {
            base.OnRoundEnd();
            if (owner.bufListDetail.GetActivatedBufList().Exists((BattleUnitBuf x) => x is BattleUnitBuf_SpiritLink))
            {
                owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_SpiritLink).stack -= 1;
            }
        }

        public override void OnRoundStart()
        {

            if (owner.bufListDetail.GetActivatedBufList().Exists((BattleUnitBuf x) => x is BattleUnitBuf_SpiritLink))
            {
                if (owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_SpiritLink).stack <= 0)
                {
                    owner.bufListDetail.RemoveBuf(new BattleUnitBuf_SpiritLink());
                }
            }

            base.OnRoundStart();
            if (_c == -1)
            {
                owner.bufListDetail.AddReadyBuf(new BattleUnitBuf_SpiritLink());
                _c = 0;
            }

            if (!owner.bufListDetail.GetActivatedBufList().Exists((BattleUnitBuf x) => x is BattleUnitBuf_SpiritLink))
            {
                _c = _c + 1;
            }

            if (_c == 2)
            {
                _c = -1;
            }
            

        }
    }
}
