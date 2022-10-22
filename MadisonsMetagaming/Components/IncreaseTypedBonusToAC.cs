using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadisonsMetagaming.Components
{
	[AllowMultipleComponents]
	[AllowedOn(typeof(BlueprintUnitFact), false)]
	[TypeId("29c078a1b8874507b188f781440c9d08")]
	public class IncreaseTypedBonusToAC :
        UnitFactComponentDelegate<ACBonusAgainstAttacks.RuntimeData>,
        ISubscriber,
        ITargetRulebookSubscriber,
        ITargetRulebookHandler<RuleCalculateAC>,
        IRulebookHandler<RuleCalculateAC>
    {
		private static readonly LogWrapper Logger = LogWrapper.Get("MadisonsMetagaming");

		public void OnEventAboutToTrigger(RuleCalculateAC evt)
		{
			Logger.Info("IncreaseTypedBonusToAC OnEventAboutToTrigger");

			int luckBonusIndex = evt.GetRuleTarget().Stats.AC.Modifiers.FindIndex((ModifiableValue.Modifier m) => m.ModDescriptor == ModifierDescriptor.Luck);
			if (luckBonusIndex >= 0)
			{
				Logger.Info("LuckBonusIndex >= 0");

				int currentLuckBonus = evt.GetRuleTarget().Stats.AC.Modifiers.ElementAt(luckBonusIndex).ModValue;

				Bonus = new ContextValue();
				Bonus.Value = currentLuckBonus + 1;

				Logger.Info("Current Luck Bonus " + currentLuckBonus);

				evt.AddModifier(Bonus.Value, base.Fact, Descriptor);
			}
		}
		public void OnEventDidTrigger(RuleCalculateAC evt)
		{
		}

		// Token: 0x0400914A RID: 37194
		public ModifierDescriptor Descriptor = ModifierDescriptor.Luck;

		// Token: 0x0400914B RID: 37195
		public int Value;

		// Token: 0x0400914C RID: 37196
		public ContextValue Bonus;
	}
}
