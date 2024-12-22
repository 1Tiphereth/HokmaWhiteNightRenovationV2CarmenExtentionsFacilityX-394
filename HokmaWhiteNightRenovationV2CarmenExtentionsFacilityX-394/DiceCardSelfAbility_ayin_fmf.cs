using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class DiceCardSelfAbility_ayin_fmf : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            base.OnUseCard();
            string ids = Init.GetOwnId(owner);
            Init.UpdateSP(ids, -15);
            
            if (Init.IsCorroded(ids))
            {

                List<BattlePlayingCardDataInUnitModel.SubTarget> list = new List<BattlePlayingCardDataInUnitModel.SubTarget>();
                var list1 = BattleObjectManager.instance.GetAliveList();
                list1.Remove(owner);
                foreach (BattleUnitModel battleUnitModel in list1)
                {
                    list.Add(new BattlePlayingCardDataInUnitModel.SubTarget
                    {
                        target = battleUnitModel,
                        targetSlotOrder = UnityEngine.Random.Range(0, battleUnitModel.speedDiceResult.Count)
                    });
                }
                card.subTargets = list;
                DiceCardXmlInfo cardItem = new DiceCardXmlInfo { DiceBehaviourList = new List<DiceBehaviour> { new DiceBehaviour { Min = 15, Dice = 30, Type = BehaviourType.Atk, Detail = BehaviourDetail.Slash, MotionDetail = MotionDetail.H, Script = "ayin_fmf_dice", ActionScript = "malkuthboss_scorched" } } };
                BattleDiceBehavior battleDiceBehavior = new BattleDiceBehavior();
                battleDiceBehavior.behaviourInCard = cardItem.DiceBehaviourList[0].Copy();
                battleDiceBehavior.SetIndex(1);
                card.AddDice(battleDiceBehavior);
            }
        }
    }
}
