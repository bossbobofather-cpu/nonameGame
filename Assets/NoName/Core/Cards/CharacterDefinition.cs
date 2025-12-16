namespace NoName.Core.Cards
{
	/// <summary>
	/// 캐릭터의 정적(정의) 데이터입니다.
	/// </summary>
	/// <param name="Id">캐릭터 정의 ID 입니다.</param>
	/// <param name="DisplayName">표시 이름입니다.</param>
	/// <param name="MaxHp">최대 HP 입니다.</param>
	public sealed record CharacterDefinition(
		string Id,
		string DisplayName,
		int MaxHp
	);
}
