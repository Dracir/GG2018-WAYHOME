
using System.IO;
using UnityEditor;
using UnityEngine;

public class Utils
{
	public static T CreateAsset<T>(string path) where T : ScriptableObject
	{
		T asset = ScriptableObject.CreateInstance<T>();

		string assetPath = AssetDatabase.GetAssetPath(Selection.activeObject);
		if (assetPath == "")
		{
			assetPath = "Assets";
		}
		else if (Path.GetExtension(assetPath) != "")
		{
			assetPath = assetPath.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
		}

		//string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(assetPath + "/New " + typeof(T).ToString() + ".asset");
		string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(assetPath + "/" + path + ".asset");

		Debug.Log(path + ".asset");
		AssetDatabase.CreateAsset(asset, path + ".asset");

		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = asset;

        return asset;
	}
}
