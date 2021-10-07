using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Utils : MonoBehaviour
{
    public static int DOWN = 0, LEFT = 1, RIGHT = 2, UP = 3;
    public static int ENEMY = 0, PLAYER1 = 1, PLAYER2 = 2;

    public static Utils instance;

    public Tile wallTile;
    public Tile destructibleTile;

    public Tilemap barrier;
    public Tilemap background;
    public GameObject explosionPrefab;

    void Awake()
    {
        instance = this;
        
    }

    void Start()
    {
        
    }

    public int GetTileType(Tile tile)
    {
        if(tile==wallTile)
        {
            return 1;
        }
        else if(tile==destructibleTile)
        {
            return 2;
        }
        else
        {
            return 0;
        }
    }

    public void CreateExplosionAt(Vector3Int cell,int group)
    {
        Vector3 pos = barrier.GetCellCenterWorld(cell);
        Explosion explosion=Instantiate(explosionPrefab, pos, Quaternion.identity).GetComponent<Explosion>();
        explosion.SetGroup(group);
    }

    public bool CanMoveTo(Vector3Int pos,int dir)
    {
        Vector3Int next = pos;
        switch (dir)
        {
            case 0:
                next += new Vector3Int(0,-1,0);
                break;
            case 1:
                next += new Vector3Int(-1, 0, 0);
                break;
            case 2:
                next += new Vector3Int(1, 0, 0);
                break;
            case 3:
                next += new Vector3Int(0, 1, 0);
                break;

        }
        Tile tile = barrier.GetTile<Tile>(next);
        return (GetTileType (tile)==0);

    }




}
