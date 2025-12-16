using NoName.Core.Cards;
using UnityEngine;

namespace NoName.Unity.StaticData
{
	/// <summary>
	/// 캐릭터 카드 정의(정적 데이터) 에셋입니다.
	/// </summary>
	[CreateAssetMenu(menuName = "NoName/Static Data/Cards/Character Card Definition", fileName = "CardDefinition_Character_")]
	public sealed class CharacterCardDefinitionAsset : CardDefinitionAssetBase
	{
		[SerializeField] private CharacterDefinitionAsset? _character;

		/// <inheritdoc />
		public override CardType Type => CardType.Character;

		/// <summary>
		/// 매칭되는 캐릭터 정의 에셋입니다.
		/// </summary>
		public CharacterDefinitionAsset? Character => _character;

		/// <inheritdoc />
		protected override string? GetCharacterId()
		{
			return _character?.Id;
		}
	}
}

