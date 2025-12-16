using NoName.Core.Cards;
using UnityEngine;

namespace NoName.Unity.StaticData
{
	/// <summary>
	/// 스킬 카드 정의(정적 데이터) 에셋입니다.
	/// </summary>
	[CreateAssetMenu(menuName = "NoName/Static Data/Cards/Skill Card Definition", fileName = "CardDefinition_Skill_")]
	public sealed class SkillCardDefinitionAsset : CardDefinitionAssetBase
	{
		/// <inheritdoc />
		public override CardType Type => CardType.Skill;
	}
}

