using UnityEngine;

namespace NoName.Unity.StaticData
{
	/// <summary>
	/// 게임에 존재하는 카드 정의 목록(카탈로그) 에셋입니다.
	/// </summary>
	[CreateAssetMenu(menuName = "NoName/Static Data/Card Catalog", fileName = "CardCatalog")]
	public sealed class CardCatalogAsset : ScriptableObject
	{
		[SerializeField] private CardDefinitionAsset[] _cards = System.Array.Empty<CardDefinitionAsset>();

		/// <summary>
		/// 게임에 존재하는 모든 카드 정의입니다.
		/// </summary>
		public CardDefinitionAsset[] Cards => _cards;
	}
}

