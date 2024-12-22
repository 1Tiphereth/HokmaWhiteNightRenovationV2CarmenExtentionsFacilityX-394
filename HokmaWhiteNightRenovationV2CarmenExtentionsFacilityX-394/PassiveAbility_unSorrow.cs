using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_unSorrow : PassiveAbilityBase
    {
        int _stack = 0;
        public override void OnStartBattle()
        {
            for (int i = 0; i < _stack; i++)
            {
                DiceCardXmlInfo cardItem = ItemXmlDataList.instance.GetCardItem(607101);
                new DiceBehaviour();
                List<BattleDiceBehavior> list = new List<BattleDiceBehavior>();
                int num = 0;
                foreach (DiceBehaviour diceBehaviour in cardItem.DiceBehaviourList)
                {
                    BattleDiceBehavior battleDiceBehavior = new BattleDiceBehavior();
                    battleDiceBehavior.behaviourInCard = diceBehaviour.Copy();
                    battleDiceBehavior.SetIndex(num++);
                    list.Add(battleDiceBehavior);
                }
                owner.cardSlotDetail.keepCard.AddBehaviours(cardItem, list);
            }
        }

        public override void OnDieOtherUnit(BattleUnitModel unit)
        {
            if (unit.faction == owner.faction)
            {
                _stack++;
            }
        }
    }
}
