using NoName.Core.Services;
using NoName.Game.Cards;
using NoName.Game.Phases;
using UnityEngine;

namespace NoName.Unity.Runtime
{
	/// <summary>
	/// 런타임 서비스(정적 데이터/인벤토리/페이즈 등)의 생성/보관을 담당합니다.
	/// </summary>
	public sealed class NoNameServices : MonoBehaviour
	{
		/// <summary>
		/// 서비스 싱글톤 인스턴스입니다.
		/// </summary>
		public static NoNameServices? Instance { get; private set; }

		/// <summary>
		/// 정적 데이터 서비스입니다.
		/// </summary>
		public IStaticDataService StaticData { get; private set; } = null!;

		/// <summary>
		/// 카드 인벤토리 서비스입니다.
		/// </summary>
		public CardInventory CardInventory { get; private set; } = null!;

		/// <summary>
		/// 게임 페이즈 서비스입니다.
		/// </summary>
		public GamePhaseService GamePhase { get; private set; } = null!;

		private void Awake()
		{
			if (Instance != null && Instance != this)
			{
				Destroy(gameObject);
				return;
			}

			Instance = this;
			DontDestroyOnLoad(gameObject);

			var staticDataService = new StaticDataService();
			staticDataService.Initialize();
			StaticData = staticDataService;

			CardInventory = new CardInventory(StaticData);
			GamePhase = new GamePhaseService();

#if UNITY_EDITOR || DEVELOPMENT_BUILD
			gameObject.AddComponent<NoNameDebugCheats>();
#endif
		}
	}
}

