using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEngine.UI.GridLayoutGroup;

namespace HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394
{
    public class PassiveAbility_theProxy : PassiveAbilityBase
    {
        public static readonly List<int> targetIds = new List<int> { 611041, 611042, 611043, 611044 };
        public static readonly List<int> egoIds = new List<int> { 305, 306, 307, 611044 };

        public override void OnStartBattle()
        {
            foreach (int egoId in egoIds)
            {
                owner.personalEgoDetail.AddCard(new LorId(HokmaWhiteNightRenovationV2CarmenExtentionsFacilityX_394.Init.packageName, egoId));
            }
        }

        public override void OnRoundStart()
        {
            foreach (int targetId in targetIds)
            {
                owner.personalEgoDetail.RemoveCard(targetId);
            }
            List<int> list = new List<int>(targetIds);
            if (owner.emotionDetail.EmotionLevel >= 3)
            {
                AddOne(list);
                AddOne(list);
            }
            else
            {
                AddOne(list);
            }
        }

        private void AddOne(List<int> list)
        {
            if (list.Count > 0)
            {
                int num = RandomUtil.SelectOne(list);
                owner.personalEgoDetail.AddCard(num);
                list.Remove(num);
            }
        }
    }
}
