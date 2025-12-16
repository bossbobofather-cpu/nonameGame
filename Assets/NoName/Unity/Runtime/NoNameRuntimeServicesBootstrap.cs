using UnityEngine;

namespace NoName.Unity.Runtime
{
	/// <summary>
	/// 씬에 배치하지 않아도 런타임 서비스가 생성되도록 보장합니다.
	/// </summary>
	public static class NoNameRuntimeServicesBootstrap
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void EnsureServices()
		{
			if (NoNameServices.Instance != null)
			{
				return;
			}

			if (Object.FindAnyObjectByType<NoNameServices>() != null)
			{
				return;
			}

			var go = new GameObject("[NoName] Services");
			go.AddComponent<NoNameServices>();
		}
	}
}

