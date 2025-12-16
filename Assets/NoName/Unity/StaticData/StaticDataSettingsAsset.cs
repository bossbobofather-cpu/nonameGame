using UnityEngine;

namespace NoName.Unity.StaticData
{
	/// <summary>
	/// 정적 데이터 로드 설정입니다. (Resources에서 로드)
	/// </summary>
	[CreateAssetMenu(menuName = "NoName/Settings/Static Data Settings", fileName = "StaticDataSettings")]
	public sealed class StaticDataSettingsAsset : ScriptableObject
	{
		[SerializeField] private CardCatalogAsset? _cardCatalog;

		/// <summary>
		/// 카드 카탈로그 에셋입니다.
		/// </summary>
		public CardCatalogAsset? CardCatalog => _cardCatalog;
	}
}

