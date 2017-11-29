using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "tile", menuName = "PCG/Tile", order = 1)]
public class TileScriptableObject :ScriptableObject{
    public Texture2D tileTexture;
    public int[] topTilesAllowed;
    public int[] leftTilesAllowed;
}
