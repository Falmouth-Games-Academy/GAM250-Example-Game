using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TileMap))]
public class TileMapEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TileMap tileMap = (TileMap)target;
        if (GUILayout.Button("Generate"))
        {
            tileMap.Generate();
        }
    }
}
