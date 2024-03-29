﻿using System.IO;
using UnityEngine;
using UnityEditor;

public class AnimationEditor
{

    [MenuItem("Assets/Animations/提取动画.anim文件")]
    static void CopyClips()
    {
        foreach (Object o in Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets))
        {
            if (!(o is GameObject)) continue;
            if (!o.name.Contains("@")) continue;
            
            GameObject fbx = (GameObject)o;
            AnimationClip srcClip = AssetDatabase.LoadAssetAtPath<AnimationClip>(AssetDatabase.GetAssetPath(fbx));//fbx.GetComponent<Animation>().clip;
            
            AnimationClip clip = new AnimationClip();
            clip.name = srcClip.name;

            string dirPath = AnimationsPath(fbx);
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(AnimationsPath(fbx));

            string animPath = AnimationsPath(fbx) + clip.name + ".anim";
            AssetDatabase.CreateAsset(clip, animPath);
            AssetDatabase.Refresh();

            EditorUtility.CopySerialized(srcClip, clip);
        }
    }

    static string RootPath(GameObject go)
    {
        string root = AssetDatabase.GetAssetPath(go);
        return root.Substring(0, root.LastIndexOf('/') + 1);
    }
    
    static string AnimationsPath(GameObject go)
    {
        return RootPath(go) + "Clips/";
    }
}
