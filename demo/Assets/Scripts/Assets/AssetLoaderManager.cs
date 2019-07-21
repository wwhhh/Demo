using Framework;
using UnityEditor;
using UnityEngine;

public class AssetLoaderManager : Singleton<AssetLoaderManager>
{

    public AssetLoader<T> LoadAsset<T>(string assetPath) where T : UnityEngine.Object
    {
        AssetLoader<T> loader = new AssetLoader<T>(assetPath);
        return loader;
    }

    static public void UnloadAsset<T>(AssetLoader<T> loader) where T : UnityEngine.Object
    {
        if (loader != null)
            loader.UnLoadAsset();
    }

}

public class AssetLoader<T> where T : UnityEngine.Object
{

    string _path;

    public T asset
    {
        get;
        private set;
    }

    public AssetLoader(string assetPath)
    {
        asset = default(T);
        LoadAsset(assetPath);
    }

    private void LoadAsset(string assetPath)
    {
        _path = assetPath;
        //asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
        asset = Resources.Load<T>(assetPath);
    }

    public void UnLoadAsset()
    {
    }

}
