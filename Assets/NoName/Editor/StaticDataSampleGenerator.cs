using NoName.Unity.StaticData;
using UnityEditor;
using UnityEngine;

namespace NoName.Editor
{
	/// <summary>
	/// 정적 데이터(카드/캐릭터) 샘플 에셋을 생성합니다.
	/// </summary>
	public static class StaticDataSampleGenerator
	{
		private const string DataRoot = "Assets/NoName/StaticData";
		private const string SettingsPath = "Assets/NoName/Resources/NoName/StaticData/StaticDataSettings.asset";

		[MenuItem("NoName/Static Data/Create Sample Assets")]
		private static void CreateSampleAssets()
		{
			EnsureFolder("Assets/NoName");
			EnsureFolder(DataRoot);
			EnsureFolder("Assets/NoName/Resources");
			EnsureFolder("Assets/NoName/Resources/NoName");
			EnsureFolder("Assets/NoName/Resources/NoName/StaticData");

			var warrior = CreateOrReplaceCharacter($"{DataRoot}/CharacterDefinition_Warrior.asset", "character_warrior", "워리어", 100);
			var archer = CreateOrReplaceCharacter($"{DataRoot}/CharacterDefinition_Archer.asset", "character_archer", "아처", 70);

			var warriorCard = CreateOrReplaceCharacterCard(
				$"{DataRoot}/CardDefinition_Warrior.asset",
				"card_character_warrior",
				"워리어 카드",
				1,
				warrior
			);

			var archerCard = CreateOrReplaceCharacterCard(
				$"{DataRoot}/CardDefinition_Archer.asset",
				"card_character_archer",
				"아처 카드",
				1,
				archer
			);

			var catalog = CreateOrReplaceCatalog($"{DataRoot}/CardCatalog.asset", new CardDefinitionAssetBase[] { warriorCard, archerCard });
			CreateOrReplaceSettings(SettingsPath, catalog);

			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();

			Debug.Log("[NoName] 샘플 정적 데이터 생성 완료: Resources/NoName/StaticData/StaticDataSettings.asset");
		}

		private static CharacterDefinitionAsset CreateOrReplaceCharacter(string assetPath, string id, string displayName, int maxHp)
		{
			AssetDatabase.DeleteAsset(assetPath);

			var asset = ScriptableObject.CreateInstance<CharacterDefinitionAsset>();
			AssetDatabase.CreateAsset(asset, assetPath);

			var so = new SerializedObject(asset);
			so.FindProperty("_id").stringValue = id;
			so.FindProperty("_displayName").stringValue = displayName;
			so.FindProperty("_maxHp").intValue = maxHp;
			so.ApplyModifiedPropertiesWithoutUndo();

			return asset;
		}

		private static CharacterCardDefinitionAsset CreateOrReplaceCharacterCard(
			string assetPath,
			string id,
			string displayName,
			int cost,
			CharacterDefinitionAsset? character)
		{
			AssetDatabase.DeleteAsset(assetPath);

			var asset = ScriptableObject.CreateInstance<CharacterCardDefinitionAsset>();
			AssetDatabase.CreateAsset(asset, assetPath);

			var so = new SerializedObject(asset);
			so.FindProperty("_id").stringValue = id;
			so.FindProperty("_displayName").stringValue = displayName;
			so.FindProperty("_cost").intValue = cost;
			so.FindProperty("_character").objectReferenceValue = character;
			so.ApplyModifiedPropertiesWithoutUndo();

			return asset;
		}

		private static CardCatalogAsset CreateOrReplaceCatalog(string assetPath, CardDefinitionAssetBase[] cards)
		{
			AssetDatabase.DeleteAsset(assetPath);

			var asset = ScriptableObject.CreateInstance<CardCatalogAsset>();
			AssetDatabase.CreateAsset(asset, assetPath);

			var so = new SerializedObject(asset);
			var cardsProp = so.FindProperty("_cards");
			cardsProp.arraySize = cards.Length;
			for (var i = 0; i < cards.Length; i++)
			{
				cardsProp.GetArrayElementAtIndex(i).objectReferenceValue = cards[i];
			}
			so.ApplyModifiedPropertiesWithoutUndo();

			return asset;
		}

		private static void CreateOrReplaceSettings(string assetPath, CardCatalogAsset catalog)
		{
			AssetDatabase.DeleteAsset(assetPath);

			var asset = ScriptableObject.CreateInstance<StaticDataSettingsAsset>();
			AssetDatabase.CreateAsset(asset, assetPath);

			var so = new SerializedObject(asset);
			so.FindProperty("_cardCatalog").objectReferenceValue = catalog;
			so.ApplyModifiedPropertiesWithoutUndo();
		}

		private static void EnsureFolder(string path)
		{
			if (AssetDatabase.IsValidFolder(path))
			{
				return;
			}

			var parent = System.IO.Path.GetDirectoryName(path);
			var name = System.IO.Path.GetFileName(path);
			if (string.IsNullOrWhiteSpace(parent) || string.IsNullOrWhiteSpace(name))
			{
				return;
			}

			if (!AssetDatabase.IsValidFolder(parent))
			{
				EnsureFolder(parent);
			}

			AssetDatabase.CreateFolder(parent, name);
		}
	}
}

