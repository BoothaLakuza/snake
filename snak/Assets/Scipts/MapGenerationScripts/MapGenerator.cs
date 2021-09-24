using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Tilemaps;
using UnityEditor;

public class MapGenerator : MonoBehaviour
{
    public int width;
    public int height;

    public string seed;
    public bool useRandomSeed;

    [Range(0, 100)]
    public int randomFillPercent;

    [Range(1, 8)]
    public int birthLimit;
    [Range(1, 8)]
    public int deathLimit;


    int[,] map;

    public Tilemap topMap;
    public TileBase topTile;
    public TileBase botTile;

    public GridLayout gridLayout;

    void Start()
    {
        GenerateMap();
        InTile();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clearMap(true);
            InTile();
        }
    }

    void GenerateMap()
    {
        map = new int[width, height];
        RandomFillMap();

        for (int i = 0; i < 5; i++)
        {
             SmoothMap();
            map = genTilePos(map);
        }
      


    }


    void RandomFillMap()
    {
        if (useRandomSeed)
        {
            seed = Time.time.ToString();
        }

        System.Random pseudoRandom = new System.Random(seed.GetHashCode());

        for (int x = 0; x < width; x++)
        {
           

            for (int y = 0; y < height; y++)
            {

                
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    map[x, y] = 1;
                }
                else
                {
                    map[x, y] = (pseudoRandom.Next(0, 100) < randomFillPercent) ? 1 : 0;
                }

            }
        }





    }

    public int[,] genTilePos(int[,] oldMap)
    {
        int[,] newMap = new int[width, height];
        int neighb;
        BoundsInt myB = new BoundsInt(-1, -1, 0, 3, 3, 1);


        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                neighb = 0;
                foreach (var b in myB.allPositionsWithin)
                {
                    if (b.x == 0 && b.y == 0) continue;
                    if (x + b.x >= 0 && x + b.x < width && y + b.y >= 0 && y + b.y < height)
                    {
                        neighb += oldMap[x + b.x, y + b.y];
                    }
                    else
                    {
                        neighb++;
                    }
                }

                if (oldMap[x, y] == 1)
                {
                    if (neighb < deathLimit) newMap[x, y] = 0;

                    else
                    {
                        newMap[x, y] = 1;

                    }
                }

                if (oldMap[x, y] == 0)
                {
                    if (neighb > birthLimit) newMap[x, y] = 1;

                    else
                    {
                        newMap[x, y] = 0;
                    }
                }

            }

        }



        return newMap;
    }

    void SmoothMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int neighbourWallTiles = GetSurroundingWallCount(x, y);

                if (neighbourWallTiles > 4)
                    map[x, y] = 1;
                else if (neighbourWallTiles < 4)
                    map[x, y] = 0;

            }
        }
    }

    int GetSurroundingWallCount(int gridX, int gridY)
    {
        int wallCount = 0;
        for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
        {
            for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
            {
                if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height)
                {
                    if (neighbourX != gridX || neighbourY != gridY)
                    {
                        wallCount += map[neighbourX, neighbourY];
                    }
                }
                else
                {
                    wallCount++;
                }
            }
        }

        return wallCount;
    }

    public void clearMap(bool complete)
    {

        topMap.ClearAllTiles();
        if (complete)
        {
            map = null;
        }
        if (map == null)
        {
            GenerateMap();
            complete = false;
        }


    }



    void InTile()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (map[x, y] == 1)
                {
                    topMap.SetTile(new Vector3Int(x, y, 0), topTile);
                }
                if (y == 5)
                {
                    //topMap.SetTile(new Vector3Int(x, y, 0), botTile);
                    Vector3Int localPlace = (new Vector3Int(x, y, (int)topMap.transform.position.y));
                    //Vector3 place = topMap.CellToWorld(localPlace);
                    if (topMap.HasTile(localPlace))
                    {
                        topMap.SetTile(new Vector3Int(x, y, 0), botTile);
                    }
                }

            }
        }
    }


    //public int[,] MountainGen(int[,] map)
    //{
    //    int perlinHeight;

    //    return map;
    //}




    //void OnDrawGizmos()
    //{
    //    if (map != null)
    //    {
    //        for (int x = 0; x < width; x++)
    //        {
    //            for (int y = 0; y < height; y++)
    //            {
    //                Gizmos.color = (map[x, y] == 1) ? Color.black : Color.white;
    //                Vector3 pos = new Vector2(-width / 2 + x + .5f, -height / 2 + y + .5f); //
    //                Gizmos.DrawCube(pos, Vector2.one);
    //            }
    //        }
    //    }
    //}
}
