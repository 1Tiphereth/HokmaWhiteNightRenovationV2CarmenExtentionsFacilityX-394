using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_brokenArbiter : PassiveAbilityBase
    {

        bool _hasShockWave = false;
        bool _hasBaral = false;
        bool _hasZena = false;
        public override void OnRoundStart()
        {
            int count = owner.allyCardDetail.GetHand().Count;
            int num = 4 - count;
            if (num > 0)
            {
                owner.allyCardDetail.DrawCards(num);
            }

            if (!_hasShockWave)
            {
                _hasShockWave = true;
                owner.personalEgoDetail.AddCard(706203);
            }

            if (owner.emotionDetail.EmotionLevel >= 3 && !_hasZena)
            {
                owner.allyCardDetail.AddCardToHand(BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(new LorId(HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.packageName, 101), false)));
                _hasZena = true;
            }

            if (owner.emotionDetail.EmotionLevel >= 5 && !_hasBaral)
            {
                owner.allyCardDetail.AddCardToHand(BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(new LorId(HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.packageName, 100), false)));
                _hasBaral = true;
            }
        }

        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            base.OnSucceedAttack(behavior);
            if (owner.emotionDetail.EmotionLevel >= 3)
            {
                behavior.card.target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Fairy, 1);
                behavior.card.target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Bleeding, 1);
            }
            else
            {
                behavior.card.target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Fairy, 1);
            }
        }
    }
}
