using System;
using System.Collections.Generic;
using NoName.Core.Services;
using NoName.Game.Cards;

namespace NoName.UI.Cards
{
	/// <summary>
	/// 카드 목록(ListView) 전체 ViewModel 입니다.
	/// </summary>
	public sealed class CardListViewModel : IDisposable
	{
		private readonly CardInventory _cardInventory;
		private readonly IStaticDataService _staticData;
		private readonly List<CardListItemViewModel> _items = new();

		/// <summary>
		/// 리스트 아이템 목록입니다.
		/// </summary>
		public IList<CardListItemViewModel> Items => _items;

		/// <summary>
		/// 목록 변경 이벤트입니다.
		/// </summary>
		public event Action? ItemsChanged;

		/// <summary>
		/// 생성자입니다.
		/// </summary>
		public CardListViewModel(CardInventory cardInventory, IStaticDataService staticData)
		{
			_cardInventory = cardInventory;
			_staticData = staticData;

			_cardInventory.InventoryChanged += HandleInventoryChanged;
			RebuildItems();
		}

		/// <inheritdoc />
		public void Dispose()
		{
			_cardInventory.InventoryChanged -= HandleInventoryChanged;
		}

		private void HandleInventoryChanged()
		{
			RebuildItems();
			ItemsChanged?.Invoke();
		}

		private void RebuildItems()
		{
			_items.Clear();

			foreach (var instance in _cardInventory.OwnedCards)
			{
				if (!_staticData.TryGetCardDefinition(instance.DefinitionId, out var def))
				{
					continue;
				}

				_items.Add(new CardListItemViewModel(
					instance.InstanceId,
					def.DisplayName,
					def.Cost,
					instance.CurrentHp,
					instance.Type
				));
			}
		}
	}
}

