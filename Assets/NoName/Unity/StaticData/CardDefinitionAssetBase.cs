using NoName.Core.Cards;
using UnityEngine;

namespace NoName.Unity.StaticData
{
	/// <summary>
	/// 카드 정의(정적 데이터) 에셋의 공통 베이스입니다.
	/// </summary>
	public abstract class CardDefinitionAssetBase : ScriptableObject
	{
		[SerializeField] private string _id = string.Empty;
		[SerializeField] private string _displayName = string.Empty;
		[SerializeField] private int _cost = 1;

		/// <summary>
		/// 카드 정의 ID 입니다.
		/// </summary>
		public string Id => _id;

		/// <summary>
		/// 표시 이름입니다.
		/// </summary>
		public string DisplayName => _displayName;

		/// <summary>
		/// 코스트입니다. (페이즈 번호와 연동)
		/// </summary>
		public int Cost => _cost;

		/// <summary>
		/// 카드 타입입니다.
		/// </summary>
		public abstract CardType Type { get; }

		/// <summary>
		/// Core 레이어에서 사용하는 런타임 정의로 변환합니다.
		/// </summary>
		public CardDefinition ToDefinition()
		{
			return new CardDefinition(_id, _displayName, Type, _cost, GetCharacterId());
		}

		/// <summary>
		/// 캐릭터 카드인 경우 매칭되는 캐릭터 ID를 반환합니다.
		/// </summary>
		protected virtual string? GetCharacterId()
		{
			return null;
		}
	}
}

