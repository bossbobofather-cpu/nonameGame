using UnityEngine;
using UnityEngine.UIElements;

namespace NoName.UI
{
	/// <summary>
	/// 씬에 배치하지 않아도 HUD가 표시되도록 보장합니다.
	/// </summary>
	public static class MainHudRuntimeBootstrap
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void EnsureHud()
		{
			if (Object.FindAnyObjectByType<MainHudController>() != null)
			{
				return;
			}

			var hudGo = new GameObject("[NoName] HUD");
			Object.DontDestroyOnLoad(hudGo);

			var uiDocument = hudGo.AddComponent<UIDocument>();
			uiDocument.panelSettings = ScriptableObject.CreateInstance<PanelSettings>();
			uiDocument.visualTreeAsset = Resources.Load<VisualTreeAsset>("NoName/UI/MainHud");

			hudGo.AddComponent<MainHudController>();
		}
	}
}

