using System;
using System.Collections.Generic;
using NoName.Core.Cards;
using NoName.Core.Services;
using NoName.Unity.StaticData;
using UnityEngine;

namespace NoName.Unity.Runtime
{
	/// <summary>
	/// Unity 프로젝트의 정적 데이터 로드/캐싱 구현체입니다.
	/// </summary>
	public sealed class StaticDataService : IStaticDataService
	{
		private const string SettingsResourcesPath = "NoName/StaticData/StaticDataSettings";

		private readonly List<CardDefinition> _cardDefinitions = new();
		private readonly Dictionary<string, CardDefinition> _cardDefinitionsById = new(StringComparer.Ordinal);
		private readonly Dictionary<string, CharacterDefinition> _characterDefinitionsById = new(StringComparer.Ordinal);

		/// <inheritdoc />
		public bool IsReady { get; private set; }

		/// <summary>
		/// 정적 데이터를 로드하고 캐시를 구성합니다.
		/// </summary>
		public void Initialize()
		{
			Clear();

			var settings = Resources.Load<StaticDataSettingsAsset>(SettingsResourcesPath);
			if (settings == null || settings.CardCatalog == null)
			{
				Debug.LogWarning($"[NoName] StaticDataSettingsAsset을 찾지 못했습니다. Resources/{SettingsResourcesPath}.asset 경로를 확인하세요. 임시 더미 데이터로 진행합니다.");
				BuildFallbackData();
				IsReady = true;
				return;
			}

			foreach (var cardAsset in settings.CardCatalog.Cards)
			{
				if (cardAsset == null)
				{
					continue;
				}

				var definition = cardAsset.ToDefinition();
				if (string.IsNullOrWhiteSpace(definition.Id) || _cardDefinitionsById.ContainsKey(definition.Id))
				{
					continue;
				}

				_cardDefinitions.Add(definition);
				_cardDefinitionsById.Add(definition.Id, definition);

				if (definition.Type != CardType.Character || cardAsset.Character == null)
				{
					continue;
				}

				var characterDefinition = cardAsset.Character.ToDefinition();
				if (string.IsNullOrWhiteSpace(characterDefinition.Id) || _characterDefinitionsById.ContainsKey(characterDefinition.Id))
				{
					continue;
				}

				_characterDefinitionsById.Add(characterDefinition.Id, characterDefinition);
			}

			IsReady = true;
		}

		/// <inheritdoc />
		public bool TryGetCardDefinition(string cardDefinitionId, out CardDefinition definition)
		{
			return _cardDefinitionsById.TryGetValue(cardDefinitionId, out definition!);
		}

		/// <inheritdoc />
		public bool TryGetCharacterDefinition(string characterId, out CharacterDefinition definition)
		{
			return _characterDefinitionsById.TryGetValue(characterId, out definition!);
		}

		/// <inheritdoc />
		public IReadOnlyList<CardDefinition> GetAllCardDefinitions()
		{
			return _cardDefinitions;
		}

		private void Clear()
		{
			IsReady = false;
			_cardDefinitions.Clear();
			_cardDefinitionsById.Clear();
			_characterDefinitionsById.Clear();
		}

		private void BuildFallbackData()
		{
			var warrior = new CharacterDefinition("character_warrior", "워리어", 100);
			var archer = new CharacterDefinition("character_archer", "아처", 70);
			_characterDefinitionsById[warrior.Id] = warrior;
			_characterDefinitionsById[archer.Id] = archer;

			AddFallbackCard(new CardDefinition("card_character_warrior", "워리어 카드", CardType.Character, 1, warrior.Id));
			AddFallbackCard(new CardDefinition("card_character_archer", "아처 카드", CardType.Character, 1, archer.Id));
		}

		private void AddFallbackCard(CardDefinition cardDefinition)
		{
			_cardDefinitions.Add(cardDefinition);
			_cardDefinitionsById.Add(cardDefinition.Id, cardDefinition);
		}
	}
}

