using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MadisonsMetagaming.Components
{

	[AllowMultipleComponents]
	[AllowedOn(typeof(BlueprintUnitFact), false)]
	[TypeId("67e7bb3956614e82bc0e6425e8723b4f")]
	public class BonusHealingPerDie : UnitFactComponentDelegate, 
		ITargetRulebookHandler<RuleHealDamage>,
		IRulebookHandler<RuleHealDamage>, 
		ISubscriber, 
		ITargetRulebookSubscriber
	{
		private static readonly LogWrapper Logger = LogWrapper.Get("MadisonsMetagaming");

		public void OnEventAboutToTrigger(RuleHealDamage evt)
		{
            try
            {
				if (evt.Reason.Ability == null)
				{
					return;
				}

				if(evt.GetRuleTarget().Equals(base.Owner))
                {
					HealBonus = new ContextValue();
					HealBonus.Value = evt.HealFormula.ModifiedValue.Rolls * 2;

					evt.AdditionalBonus.Add(new Modifier(this.HealBonus.Calculate(base.Context), base.Fact, ModifierDescriptor.UntypedStackable));
				}
			}
			catch (Exception ex)
            {
				Logger.Error("Caught exception in OnEventAboutToTrigger", ex);
            }
		}

		public void OnEventDidTrigger(RuleHealDamage evt)
		{
		}

		public ContextValue HealBonus;
		
	}
}