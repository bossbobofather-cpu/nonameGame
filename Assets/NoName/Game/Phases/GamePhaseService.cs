using System;
using NoName.Core.Phases;

namespace NoName.Game.Phases
{
	/// <summary>
	/// 게임 페이즈를 관리합니다.
	/// </summary>
	public sealed class GamePhaseService
	{
		/// <summary>
		/// 페이즈 변경 이벤트입니다.
		/// </summary>
		public event Action<GamePhase>? PhaseChanged;

		/// <summary>
		/// 현재 페이즈입니다.
		/// </summary>
		public GamePhase CurrentPhase { get; private set; } = GamePhase.Placement;

		/// <summary>
		/// 다음 페이즈로 진행합니다. (Placement → Battle → Resolution → Placement ...)
		/// </summary>
		public void Advance()
		{
			CurrentPhase = CurrentPhase switch
			{
				GamePhase.Placement => GamePhase.Battle,
				GamePhase.Battle => GamePhase.Resolution,
				_ => GamePhase.Placement
			};

			PhaseChanged?.Invoke(CurrentPhase);
		}

		/// <summary>
		/// 특정 페이즈로 강제 설정합니다.
		/// </summary>
		public void SetPhase(GamePhase phase)
		{
			if (CurrentPhase == phase)
			{
				return;
			}

			CurrentPhase = phase;
			PhaseChanged?.Invoke(CurrentPhase);
		}
	}
}

