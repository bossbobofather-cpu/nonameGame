using System;
using System.Collections.Generic;
using NoName.Core.Cards;
using NoName.Core.Services;

namespace NoName.Game.Cards
{
	/// <summary>
	/// 유저가 소유한 카드 인스턴스(인벤토리)를 관리합니다.
	/// </summary>
	public sealed class CardInventory
	{
		private readonly IStaticDataService _staticData;
		private readonly List<CardInstance> _ownedCards = new();

		/// <summary>
		/// 인벤토리 변경 이벤트입니다.
		/// </summary>
		public event Action? InventoryChanged;

		/// <summary>
		/// 유저가 소유한 카드 인스턴스 목록입니다. (중복 소유 시 각각 개체로 존재)
		/// </summary>
		public IReadOnlyList<CardInstance> OwnedCards => _ownedCards;

		/// <summary>
		/// 생성자입니다.
		/// </summary>
		public CardInventory(IStaticDataService staticData)
		{
			_staticData = staticData;
		}

		/// <summary>
		/// 카드 정의 ID로 카드 인스턴스를 추가합니다.
		/// </summary>
		public CardInstanceId AddCard(string cardDefinitionId)
		{
			if (!_staticData.TryGetCardDefinition(cardDefinitionId, out var definition))
			{
				throw new InvalidOperationException($"카드 정의를 찾을 수 없습니다. cardDefinitionId={cardDefinitionId}");
			}

			var instanceId = new CardInstanceId(Guid.NewGuid());
			var currentHp = GetInitialHp(definition);
			var instance = new CardInstance(instanceId, definition.Id, definition.Type, currentHp);
			_ownedCards.Add(instance);
			InventoryChanged?.Invoke();
			return instanceId;
		}

		/// <summary>
		/// 카드 인스턴스를 제거합니다.
		/// </summary>
		public bool RemoveCard(CardInstanceId instanceId)
		{
			var removed = _ownedCards.RemoveAll(x => x.InstanceId.Equals(instanceId)) > 0;
			if (removed)
			{
				InventoryChanged?.Invoke();
			}

			return removed;
		}

		/// <summary>
		/// 카드 인스턴스를 찾습니다.
		/// </summary>
		public bool TryGetCard(CardInstanceId instanceId, out CardInstance? instance)
		{
			foreach (var card in _ownedCards)
			{
				if (card.InstanceId.Equals(instanceId))
				{
					instance = card;
					return true;
				}
			}

			instance = null;
			return false;
		}

		private int? GetInitialHp(CardDefinition definition)
		{
			if (definition.Type != CardType.Character)
			{
				return null;
			}

			if (string.IsNullOrWhiteSpace(definition.CharacterId))
			{
				return null;
			}

			if (!_staticData.TryGetCharacterDefinition(definition.CharacterId, out var character))
			{
				return null;
			}

			return character.MaxHp;
		}
	}
}

