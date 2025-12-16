namespace NoName.Core.Cards
{
	/// <summary>
	/// 카드의 큰 분류입니다.
	/// </summary>
	public enum CardType
	{
		/// <summary>
		/// 캐릭터 카드입니다.
		/// </summary>
		Character = 0,

		/// <summary>
		/// 전투 시 트리거로 실행되는 스킬 카드입니다.
		/// </summary>
		Skill = 1,

		/// <summary>
		/// 덱에 소유하면 조건 충족 시 발동되는 패시브 카드입니다.
		/// </summary>
		Passive = 2,
	}
}
