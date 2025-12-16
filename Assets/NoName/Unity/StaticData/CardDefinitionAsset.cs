using System;
using NoName.Core.Cards;
using UnityEngine;

namespace NoName.Unity.StaticData
{
	/// <summary>
	/// (레거시) 카드 정의 에셋입니다.
	/// 기존에 `CardDefinitionAsset` 기반으로 만들어진 에셋과의 호환을 위해 유지합니다.
	/// </summary>
	[Obsolete("Use CharacterCardDefinitionAsset / SkillCardDefinitionAsset / PassiveCardDefinitionAsset instead.")]
	public sealed class CardDefinitionAsset : CardDefinitionAssetBase
	{
		[SerializeField] private CardType _type = CardType.Character;
		[SerializeField] private CharacterDefinitionAsset? _character;

		/// <inheritdoc />
		public override CardType Type => _type;

		/// <summary>
		/// 캐릭터 카드인 경우 매칭되는 캐릭터 정의 에셋입니다.
		/// </summary>
		public CharacterDefinitionAsset? Character => _character;

		/// <inheritdoc />
		protected override string? GetCharacterId()
		{
			return _type == CardType.Character ? _character?.Id : null;
		}
	}
}

