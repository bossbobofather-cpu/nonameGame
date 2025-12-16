using NoName.Core.Cards;
using UnityEngine;

namespace NoName.Unity.StaticData
{
	/// <summary>
	/// 캐릭터 정의(정적 데이터) 에셋입니다.
	/// </summary>
	[CreateAssetMenu(menuName = "NoName/Static Data/Character Definition", fileName = "CharacterDefinition_")]
	public sealed class CharacterDefinitionAsset : ScriptableObject
	{
		[SerializeField] private string _id = string.Empty;
		[SerializeField] private string _displayName = string.Empty;
		[SerializeField] private int _maxHp = 1;

		/// <summary>
		/// 캐릭터 정의 ID 입니다.
		/// </summary>
		public string Id => _id;

		/// <summary>
		/// 표시 이름입니다.
		/// </summary>
		public string DisplayName => _displayName;

		/// <summary>
		/// 최대 HP 입니다.
		/// </summary>
		public int MaxHp => _maxHp;

		/// <summary>
		/// Core 레이어에서 사용하는 런타임 정의로 변환합니다.
		/// </summary>
		public CharacterDefinition ToDefinition()
		{
			return new CharacterDefinition(_id, _displayName, _maxHp);
		}
	}
}

