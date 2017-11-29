using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapPCG : TileMap
{
    public TileScriptableObject[] tileData;

    public void Start()
    {
        tiles = new int[NumberOfTilesWidth, NumberOfTilesHeight];
        Generate();
    }

    public override void Generate()
    {
        DeleteAllTiles();
        SetupSeed();

        float startX = transform.position.x - NumberOfTilesWidth / 2;
        float startY = transform.position.y + NumberOfTilesHeight / 2;

        float currentX = startX;
        float currentY = startY;
        List<int> validTiles = new List<int>();

        for (int x = 0; x < NumberOfTilesWidth; x++)
        {
            for (int y = 0; y < NumberOfTilesHeight; y++)
            {
                int leftTileID = -1;
                int topTileID = -1;
                int tileID = Random.Range(0, tileData.Length - 1);
                tiles[x, y] = tileID;
                float tileWidth = tileData[tileID].tileTexture.width;
                float tileHeight = tileData[tileID].tileTexture.height;

                //can we get a tile to the left and top
                if (x>0)
                {
                    leftTileID = tiles[x-1, y];
                }
                if (y>0)
                {
                    topTileID = tiles[x, y - 1];
                }
                CreateTile(string.Format("{0},{1}", x, y), new Vector2(currentX, currentY), tileID, tileData[tileID].tileTexture, tileWidth, tileHeight);
                currentX += 1.0f;
            }
            currentX = startX;
            currentY -= 1.0f;
        }
    }
}
