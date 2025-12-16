using NoName.UI.Cards;
using NoName.Unity.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

namespace NoName.UI
{
	/// <summary>
	/// UI Toolkit 기반 메인 HUD 컨트롤러입니다.
	/// </summary>
	[RequireComponent(typeof(UIDocument))]
	public sealed class MainHudController : MonoBehaviour
	{
		private UIDocument _uiDocument = null!;
		private ListView _cardListView = null!;
		private VisualElement _boardSlots = null!;
		private CardListViewModel? _cardListViewModel;

		private void Awake()
		{
			_uiDocument = GetComponent<UIDocument>();
		}

		private void OnEnable()
		{
			EnsureVisualTree();

			var root = _uiDocument.rootVisualElement;

			var styleSheet = Resources.Load<StyleSheet>("NoName/UI/MainHud");
			if (styleSheet != null)
			{
				root.styleSheets.Add(styleSheet);
			}

			_cardListView = root.Q<ListView>("CardListView");
			_boardSlots = root.Q<VisualElement>("BoardSlots");

			InitializeBoardSlots();
			BindCardList();
		}

		private void OnDisable()
		{
			if (_cardListViewModel != null)
			{
				_cardListViewModel.ItemsChanged -= HandleCardListChanged;
				_cardListViewModel.Dispose();
				_cardListViewModel = null;
			}
		}

		private void EnsureVisualTree()
		{
			if (_uiDocument.visualTreeAsset != null)
			{
				return;
			}

			_uiDocument.visualTreeAsset = Resources.Load<VisualTreeAsset>("NoName/UI/MainHud");
		}

		private void BindCardList()
		{
			var services = NoNameServices.Instance;
			if (services == null)
			{
				return;
			}

			_cardListViewModel = new CardListViewModel(services.CardInventory, services.StaticData);
			_cardListViewModel.ItemsChanged += HandleCardListChanged;

			_cardListView.itemsSource = _cardListViewModel.Items;
			_cardListView.selectionType = SelectionType.Single;
			_cardListView.makeItem = MakeCardItem;
			_cardListView.bindItem = BindCardItem;
			_cardListView.Rebuild();
		}

		private void HandleCardListChanged()
		{
			_cardListView.Rebuild();
		}

		private VisualElement MakeCardItem()
		{
			var root = new VisualElement();
			root.AddToClassList("card-item");

			var nameLabel = new Label { name = "NameLabel" };
			nameLabel.AddToClassList("card-name");

			var metaLabel = new Label { name = "MetaLabel" };
			metaLabel.AddToClassList("card-meta");

			root.Add(nameLabel);
			root.Add(metaLabel);
			return root;
		}

		private void BindCardItem(VisualElement element, int index)
		{
			if (_cardListViewModel == null)
			{
				return;
			}

			if (index < 0 || index >= _cardListViewModel.Items.Count)
			{
				return;
			}

			var item = _cardListViewModel.Items[index];
			var nameLabel = element.Q<Label>("NameLabel");
			var metaLabel = element.Q<Label>("MetaLabel");

			nameLabel.text = item.DisplayName;

			var hpText = item.CurrentHp.HasValue ? item.CurrentHp.Value.ToString() : "-";
			metaLabel.text = $"Cost {item.Cost} | HP {hpText} | {item.Type}";
		}

		private void InitializeBoardSlots()
		{
			_boardSlots.Clear();

			for (var i = 0; i < 6; i++)
			{
				var slot = new VisualElement();
				slot.AddToClassList("slot");

				var title = new Label { text = $"Slot {i + 1}" };
				title.AddToClassList("slot-title");

				var content = new Label { text = "(empty)" };
				content.AddToClassList("slot-content");

				slot.Add(title);
				slot.Add(content);
				_boardSlots.Add(slot);
			}
		}
	}
}

