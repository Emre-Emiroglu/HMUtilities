using UnityEditor;
using UnityEngine;

namespace CodeCatGames.HMUtilities.Editor
{
    public static class EditorUtilities
    {
        #region Executes
        public static void CreateTag(string tag)
        {
            Object asset = AssetDatabase.LoadMainAssetAtPath("ProjectSettings/TagManager.asset");
            
            if (asset == null)
                return;
            
            SerializedObject so = new SerializedObject(asset);
            SerializedProperty tags = so.FindProperty("tags");

            int numTags = tags.arraySize;
            
            for (int i = 0; i < numTags; i++)
            {
                SerializedProperty existingTag = tags.GetArrayElementAtIndex(i);
                
                if (existingTag.stringValue == tag)
                    return;
            }

            tags.InsertArrayElementAtIndex(numTags);
            tags.GetArrayElementAtIndex(numTags).stringValue = tag;
            
            so.ApplyModifiedProperties();
            so.Update();
        }
        #endregion
    }
}