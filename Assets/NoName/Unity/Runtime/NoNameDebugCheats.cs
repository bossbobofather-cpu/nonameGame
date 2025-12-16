using NoName.Core.Phases;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NoName.Unity.Runtime
{
	/// <summary>
	/// 개발용 치트입니다. (에디터/개발 빌드에서만 활성)
	/// </summary>
	public sealed class NoNameDebugCheats : MonoBehaviour
	{
		private void Update()
		{
			var services = NoNameServices.Instance;
			if (services == null)
			{
				return;
			}

			var keyboard = Keyboard.current;
			if (keyboard == null)
			{
				return;
			}

			if (keyboard.digit1Key.wasPressedThisFrame)
			{
				AddCardByIndex(0);
			}

			if (keyboard.digit2Key.wasPressedThisFrame)
			{
				AddCardByIndex(1);
			}

			if (keyboard.nKey.wasPressedThisFrame)
			{
				AddRandomCard();
			}

			if (keyboard.pKey.wasPressedThisFrame)
			{
				services.GamePhase.Advance();
				Debug.Log($"[NoName] Phase={services.GamePhase.CurrentPhase}");
			}

			if (keyboard.f1Key.wasPressedThisFrame)
			{
				services.GamePhase.SetPhase(GamePhase.Placement);
			}

			if (keyboard.f2Key.wasPressedThisFrame)
			{
				services.GamePhase.SetPhase(GamePhase.Battle);
			}

			if (keyboard.f3Key.wasPressedThisFrame)
			{
				services.GamePhase.SetPhase(GamePhase.Resolution);
			}
		}

		private void AddCardByIndex(int index)
		{
			var services = NoNameServices.Instance;
			if (services == null)
			{
				return;
			}

			var defs = services.StaticData.GetAllCardDefinitions();
			if (defs.Count <= index)
			{
				return;
			}

			var def = defs[index];
			services.CardInventory.AddCard(def.Id);
			Debug.Log($"[NoName] AddCard: {def.DisplayName} ({def.Id})");
		}

		private void AddRandomCard()
		{
			var services = NoNameServices.Instance;
			if (services == null)
			{
				return;
			}

			var defs = services.StaticData.GetAllCardDefinitions();
			if (defs.Count == 0)
			{
				return;
			}

			var def = defs[Random.Range(0, defs.Count)];
			services.CardInventory.AddCard(def.Id);
			Debug.Log($"[NoName] AddCard: {def.DisplayName} ({def.Id})");
		}
	}
}
