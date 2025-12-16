namespace NoName.Core.Cards
{
	/// <summary>
	/// 유저가 소유한 카드 인스턴스(실제 카드 데이터) 입니다.
	/// </summary>
	public sealed class CardInstance
	{
		/// <summary>
		/// 카드 인스턴스 ID 입니다.
		/// </summary>
		public CardInstanceId InstanceId { get; }

		/// <summary>
		/// 카드 정의 ID 입니다.
		/// </summary>
		public string DefinitionId { get; }

		/// <summary>
		/// 카드 타입입니다.
		/// </summary>
		public CardType Type { get; }

		/// <summary>
		/// 캐릭터 카드인 경우 현재 HP 입니다. (그 외 타입은 null)
		/// </summary>
		public int? CurrentHp { get; private set; }

		/// <summary>
		/// 생성자입니다.
		/// </summary>
		public CardInstance(CardInstanceId instanceId, string definitionId, CardType type, int? currentHp)
		{
			InstanceId = instanceId;
			DefinitionId = definitionId;
			Type = type;
			CurrentHp = currentHp;
		}

		/// <summary>
		/// 현재 HP를 설정합니다. (캐릭터 카드에서만 사용)
		/// </summary>
		public void SetCurrentHp(int currentHp)
		{
			CurrentHp = currentHp;
		}
	}
}
