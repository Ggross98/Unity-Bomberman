using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour {

	public Tilemap tilemap;

    static int NOTHING = 0;
    static int WALL = 1;
    static int DESTRUCTIVE = 2;

    public void Explode(Vector2 worldPos,int range,int group)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);
        ExplodeCell(originCell,group);
        //◊Û
        for(int i = 1; i <= range; i++)
        {
            if(ExplodeCell(originCell + new Vector3Int(-i,0, 0),group)!=0)
            {
                break;
            }
        }
        //”“
        for (int i = 1; i <= range; i++)
        {
            if (ExplodeCell(originCell + new Vector3Int(i, 0, 0), group) != 0)
            {
                break;
            }
        }
        //…œ
        for (int i = 1; i <= range; i++)
        {
            if (ExplodeCell(originCell + new Vector3Int(0, i, 0), group) != 0)
            {
                break;
            }
        }
        //œ¬
        for (int i = 1; i <= range; i++)
        {
            if (ExplodeCell(originCell + new Vector3Int(0, -i, 0), group) != 0)
            {
                break;
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cell"></param>
    /// <returns>
    /// 0:Œﬁ’œ∞≠£¨Œ¥∆∆ªµ
    /// 1:”–’œ∞≠£¨Œﬁ∑®∆∆ªµ
    /// 2:”–’œ∞≠£¨“—∆∆ªµ
    /// 
    /// </returns>
	int ExplodeCell (Vector3Int cell,int group)
	{
		Tile tile = tilemap.GetTile<Tile>(cell);
        //Vector3 pos = tilemap.GetCellCenterWorld(cell);

        int result = Utils.instance.GetTileType(tile);
        switch (result)
        {
            case 0:
                //Instantiate(explosionPrefab, pos, Quaternion.identity);
                Utils.instance.CreateExplosionAt(cell,group);
                break;
            case 1:
                break;
            case 2:
                tilemap.SetTile(cell, null);
                Debug.Log("destroy a cell");
                //Instantiate(explosionPrefab, pos, Quaternion.identity);
                Utils.instance.CreateExplosionAt(cell,group);
                break;
        }

        return result;
	}



}
