using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    public GameObject gridPrefab;
    private Grid grid;

    private Tilemap t_background, t_barrier, t_item;

    public int gameLevel;
    public int gameMode;

    public GameObject playerPrefab;
    private PlayerScript player;

    private List<EnemyScript> enemyList;
    private Utils utils;

    public bool gaming = false;


    private int x0, y0,x1,y1;
    private int row, column;


    void Awake()
    {
        GameObject g = Instantiate(gridPrefab);
        grid = g.GetComponent<Grid>();
        utils = GetComponent<Utils>();

        t_background = GameObject.Find("Tilemap_Background").GetComponent<Tilemap>();
        t_barrier = GameObject.Find("Tilemap_Barrier").GetComponent<Tilemap>();
        t_item = GameObject.Find("Tilemap_Item").GetComponent<Tilemap>();
        
        utils.background = t_background;
        utils.barrier = t_barrier;

        //寻找地图范围标记
        GameObject startPoint = GameObject.Find("Mark_LeftBottom");
        GameObject endPoint = GameObject.Find("Mark_RightTop");

        x0 = t_background.WorldToCell(startPoint.transform.position).x;
        y0 = t_background.WorldToCell(startPoint.transform.position).y;
        x1 = t_background.WorldToCell(endPoint.transform.position).x;
        y1 = t_background.WorldToCell(endPoint.transform.position).y;

        row = y1 - y0;
        column = x1 - x0;

        Debug.Log(x0 + "," + y0 + "to" + x1 + "," + y1 + ": " + row + "," + column);
        //Debug.Log(t_barrier);

        StartGame();
    }


    public void StartGame()
    {
        CreatePlayer();

        gaming = true;

    }

    public void CreatePlayer()
    {
        GameObject p = Instantiate(playerPrefab);
        player = p.GetComponent<PlayerScript>();
        player.SetTilemap(t_barrier);
        player.SetPosition(new Vector3Int(0, 0, 0));
    }

}
