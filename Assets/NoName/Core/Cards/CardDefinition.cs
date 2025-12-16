namespace NoName.Core.Cards
{
	/// <summary>
	/// 카드의 정적(정의) 데이터입니다. (유저 소유 인스턴스가 아님)
	/// </summary>
	/// <param name="Id">카드 정의 ID 입니다.</param>
	/// <param name="DisplayName">표시 이름입니다.</param>
	/// <param name="Type">카드 타입입니다.</param>
	/// <param name="Cost">코스트입니다. (페이즈 번호와 연동)</param>
	/// <param name="CharacterId">캐릭터 카드인 경우 매칭되는 캐릭터 ID 입니다.</param>
	public sealed record CardDefinition(
		string Id,
		string DisplayName,
		CardType Type,
		int Cost,
		string? CharacterId = null
	);
}
