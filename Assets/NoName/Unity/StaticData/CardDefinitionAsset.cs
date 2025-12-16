using NoName.Core.Cards;
using UnityEngine;

namespace NoName.Unity.StaticData
{
	/// <summary>
	/// 카드 정의(정적 데이터) 에셋입니다.
	/// </summary>
	[CreateAssetMenu(menuName = "NoName/Static Data/Card Definition", fileName = "CardDefinition_")]
	public sealed class CardDefinitionAsset : ScriptableObject
	{
		[SerializeField] private string _id = string.Empty;
		[SerializeField] private string _displayName = string.Empty;
		[SerializeField] private CardType _type = CardType.Character;
		[SerializeField] private int _cost = 1;
		[SerializeField] private CharacterDefinitionAsset? _character;

		/// <summary>
		/// 카드 정의 ID 입니다.
		/// </summary>
		public string Id => _id;

		/// <summary>
		/// 표시 이름입니다.
		/// </summary>
		public string DisplayName => _displayName;

		/// <summary>
		/// 카드 타입입니다.
		/// </summary>
		public CardType Type => _type;

		/// <summary>
		/// 코스트입니다. (페이즈 번호와 연동)
		/// </summary>
		public int Cost => _cost;

		/// <summary>
		/// 캐릭터 카드인 경우 매칭되는 캐릭터 정의 에셋입니다.
		/// </summary>
		public CharacterDefinitionAsset? Character => _character;

		/// <summary>
		/// Core 레이어에서 사용하는 런타임 정의로 변환합니다.
		/// </summary>
		public CardDefinition ToDefinition()
		{
			var characterId = _type == CardType.Character ? _character?.Id : null;
			return new CardDefinition(_id, _displayName, _type, _cost, characterId);
		}
	}
}

