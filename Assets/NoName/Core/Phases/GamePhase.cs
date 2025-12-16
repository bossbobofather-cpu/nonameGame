namespace NoName.Core.Phases
{
	/// <summary>
	/// 게임 페이즈(턴 스텝 묶음)입니다.
	/// </summary>
	public enum GamePhase
	{
		/// <summary>
		/// 배치(및 회수) 단계입니다.
		/// </summary>
		Placement = 0,

		/// <summary>
		/// 전투 단계입니다.
		/// </summary>
		Battle = 1,

		/// <summary>
		/// 결과 정산 단계입니다.
		/// </summary>
		Resolution = 2,
	}
}
