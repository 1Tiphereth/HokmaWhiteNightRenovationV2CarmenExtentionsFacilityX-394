using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UI;
using UnityEngine;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_kimsatgat_resent : PassiveAbilityBase
    {
        public class BattleUnitBuf_kimsatgat_resent : BattleUnitBuf
        {
            public override string keywordId => "Growing_Resentment";
            public override void OnTakeDamageByAttack(BattleDiceBehavior atkDice, int dmg)
            {
                stack += dmg;

                if (atkDice.owner.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_kimsatgat_revenge) == null) {
                    atkDice.owner.bufListDetail.AddBuf(new BattleUnitBuf_kimsatgat_revenge());
                }
                atkDice.owner.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_kimsatgat_revenge).stack += (int)Math.Max(1, (decimal)dmg/2);
            }
        }

        public class BattleUnitBuf_kimsatgat_revenge : BattleUnitBuf
        {
            public override string keywordId => "Growing_Resentment";
        }

        bool _hasResent = false;
        int _draw = 0;

        public override void OnStartBattle()
        {
            owner.allyCardDetail.SetMaxHand(12);
            if (!_hasResent)
            {
                owner.bufListDetail.AddBuf(new BattleUnitBuf_kimsatgat_resent());
                _hasResent = true;
            }
        }

        public override void OnRoundStart()
        {
            List<BattleDiceCardModel> list = base.owner.allyCardDetail.GetHand();

            if (_draw == 0)
            {
                owner.allyCardDetail.AddTempCard(new LorId(512001));
                owner.allyCardDetail.AddTempCard(new LorId(512002));
                owner.allyCardDetail.AddTempCard(new LorId(512005));

            }
            else if (_draw == 1)
            {
                owner.allyCardDetail.AddTempCard(new LorId(512001));
                owner.allyCardDetail.AddTempCard(new LorId(512005));
                owner.allyCardDetail.AddTempCard(new LorId(512005));
                owner.allyCardDetail.AddTempCard(new LorId(512004));
            }
            else if (_draw == 3)
            {
                owner.allyCardDetail.AddTempCard(new LorId(512001));
                owner.allyCardDetail.AddTempCard(new LorId(512002));
                owner.allyCardDetail.AddTempCard(new LorId(512003));
                owner.allyCardDetail.AddTempCard(new LorId(512004));
            }
            else if (_draw == 4)
            {
                owner.allyCardDetail.AddTempCard(new LorId(512003));
                owner.allyCardDetail.AddTempCard(new LorId(512005));
                owner.allyCardDetail.AddTempCard(new LorId(512006));
                _draw = -1;
            }
            _draw++;
        }
    }
}
