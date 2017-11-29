using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TileMap : MonoBehaviour
{
    public GameObject tilePrefab;

    public int NumberOfTilesWidth;
    public int NumberOfTilesHeight;

    public int[,] tiles;
    public Texture2D[] tileTextures;

    public bool fixedSeed = false;
    public int seed=20;

	// Use this for initialization
	void Start () {
        tiles = new int[NumberOfTilesWidth,NumberOfTilesHeight];
        Generate();
	}

    protected void DeleteAllTiles()
    {
        for (int i=0;i<transform.childCount;i++)
        {
#if UNITY_EDITOR
            DestroyImmediate(transform.GetChild(i).gameObject);
#else
            Destroy(transform.GetChild(i).gameObject);
#endif
        }
    }

    protected void SetupSeed()
    {
        if (fixedSeed)
        {
            Random.InitState(seed);
        }
        else
        {
            seed = (int)System.DateTime.Now.Ticks;
            Random.InitState(seed);
        }
    }

    protected void CreateTile(string name,Vector2 pos,int tileID,Texture2D tileTexture, float tileWidth, float tileHeight)
    {
        GameObject currentTile = GameObject.Instantiate<GameObject>(tilePrefab);
        Tile tileData = currentTile.GetComponent<Tile>();
        tileData.tileID = tileID;
        currentTile.name = name;
        SpriteRenderer sr = currentTile.GetComponent<SpriteRenderer>();
        sr.sprite = Sprite.Create(tileTexture, new Rect(0.0f, 0.0f, tileWidth, tileHeight), new Vector2(0.5f, 0.5f), tileWidth);
        currentTile.transform.position = new Vector3(pos.x, pos.y);
        currentTile.transform.parent = transform;
    }

    public virtual void Generate()
    {
        DeleteAllTiles();
        SetupSeed();

        float startX=transform.position.x-NumberOfTilesWidth/2;
        float startY=transform.position.y+NumberOfTilesHeight/2;

        float currentX = startX;
        float currentY = startY;

        for (int x = 0; x < NumberOfTilesWidth; x++)
        {
            for (int y = 0; y < NumberOfTilesHeight; y++)
            {
                int tileID = Random.Range(0, tileTextures.Length - 1);
                tiles[x, y] = tileID;
                float tileWidth = tileTextures[tileID].width;
                float tileHeight = tileTextures[tileID].height;

                CreateTile(string.Format("{0},{1}", x, y), new Vector2(currentX, currentY), tileID, tileTextures[tileID],tileTextures[tileID].width,tileTextures[tileID].height);
                currentX += 1.0f;
            }
            currentX = startX;
            currentY -= 1.0f;
        }
    }
}
