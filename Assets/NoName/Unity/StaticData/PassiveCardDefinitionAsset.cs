using NoName.Core.Cards;
using UnityEngine;

namespace NoName.Unity.StaticData
{
	/// <summary>
	/// 패시브 카드 정의(정적 데이터) 에셋입니다.
	/// </summary>
	[CreateAssetMenu(menuName = "NoName/Static Data/Cards/Passive Card Definition", fileName = "CardDefinition_Passive_")]
	public sealed class PassiveCardDefinitionAsset : CardDefinitionAssetBase
	{
		/// <inheritdoc />
		public override CardType Type => CardType.Passive;
	}
}

