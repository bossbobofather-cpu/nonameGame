using NoName.Core.Cards;

namespace NoName.UI.Cards
{
	/// <summary>
	/// 카드 목록(ListView) 표시용 ViewModel 입니다.
	/// </summary>
	public sealed class CardListItemViewModel
	{
		/// <summary>
		/// 카드 인스턴스 ID 입니다.
		/// </summary>
		public CardInstanceId InstanceId { get; }

		/// <summary>
		/// 표시 이름입니다.
		/// </summary>
		public string DisplayName { get; }

		/// <summary>
		/// 코스트입니다.
		/// </summary>
		public int Cost { get; }

		/// <summary>
		/// 현재 HP 입니다. (캐릭터 카드가 아니면 null)
		/// </summary>
		public int? CurrentHp { get; }

		/// <summary>
		/// 카드 타입입니다.
		/// </summary>
		public CardType Type { get; }

		/// <summary>
		/// 생성자입니다.
		/// </summary>
		public CardListItemViewModel(CardInstanceId instanceId, string displayName, int cost, int? currentHp, CardType type)
		{
			InstanceId = instanceId;
			DisplayName = displayName;
			Cost = cost;
			CurrentHp = currentHp;
			Type = type;
		}
	}
}

