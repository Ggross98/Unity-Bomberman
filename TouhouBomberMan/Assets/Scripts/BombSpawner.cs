using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : MonoBehaviour {

	public Tilemap tilemap;

	public GameObject bombPrefab;

    public static BombSpawner instance;

    void Awake()
    {
        instance = this;
    }

	/*
	void Update () {

		if (Input.GetMouseButtonDown(0))
		{
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3Int cell = tilemap.WorldToCell(worldPos);
			//Vector3 cellCenterPos = tilemap.GetCellCenterWorld(cell);

            CreateBomb(cell ,1f,2);
			//GameObject bomb = Instantiate(bombPrefab, cellCenterPos, Quaternion.identity) as GameObject;
            //bomb.GetComponent<Bomb>().SetBomb(0.2f, 2);
		}
	}
    */

    public void CreateBomb(Vector3Int pos,float time,int range, int group)
    {
        Vector3 cellCenterPos = tilemap.GetCellCenterWorld(pos);

        CreateBomb(cellCenterPos, time, range,group);
    }



    public void CreateBomb(Vector3 position,float time,int range,int group)
    {
        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity) as GameObject;
        bomb.GetComponent<Bomb>().SetBomb(time,range,group);
    }
}
