using System.Collections.Generic;
using NoName.Core.Cards;

namespace NoName.Core.Services
{
	/// <summary>
	/// 정적 데이터(카드 정의/캐릭터 정의 등) 접근 인터페이스입니다.
	/// </summary>
	public interface IStaticDataService
	{
		/// <summary>
		/// 정적 데이터가 준비되었는지 여부입니다.
		/// </summary>
		bool IsReady { get; }

		/// <summary>
		/// 카드 정의를 가져옵니다.
		/// </summary>
		bool TryGetCardDefinition(string cardDefinitionId, out CardDefinition definition);

		/// <summary>
		/// 캐릭터 정의를 가져옵니다.
		/// </summary>
		bool TryGetCharacterDefinition(string characterId, out CharacterDefinition definition);

		/// <summary>
		/// 현재 로드된 모든 카드 정의를 반환합니다.
		/// </summary>
		IReadOnlyList<CardDefinition> GetAllCardDefinitions();
	}
}
