using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoleScript : MonoBehaviour
{
    protected Tilemap tilemap;//障碍物地图

    protected void SetTilemap(Tilemap t)
    {
        tilemap = t;
    }

    //只有preparing==true&&moving==false时开始移动协程
    protected bool moving = false; //正在运动
    protected bool preparing = false; //准备运动

    protected int direction = Utils.DOWN;

    public float tileTime = 0.15f;//走完一个格子所需时间

    public bool telepathy = false;//是否受友军伤害

    public int group = Utils.PLAYER1;//阵营

    public int range = 2;//炸弹攻击范围
    public float bombTime = 2f;//炸弹延迟时间


    public int life = 1;//残机数
    public int maxHp=1;//血量
    protected int hp = 1;

    protected Animator animator;

    public Vector3Int pos = new Vector3Int();


    void Start()
    {
        
        animator = GetComponent<Animator>();
        if(tilemap != null)
            transform.position= tilemap.GetCellCenterWorld(GetPosition ());
        
    }


    protected void Hit()
    {
        hp--;
        if (hp == 0)
        {
            Miss();
        }
    }

    protected void Miss()
    {
        life--;
        if (life == 0)
        {
            //Destroy(gameObject);
        }
        else
        {
            hp = maxHp;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Explosion explosion = collider.GetComponent<Explosion>();
        if ( explosion != null)
        {
            if(telepathy && (explosion.GetGroup() == group)) //无视友军伤害
            {
                return;
            }
            else
            {
                Hit();
            }
            
        }
    }

    protected IEnumerator MoveOneTile(Vector3Int goal)
    {
        //preparing = false;
        //moving = true;
        //animator.SetBool("_moving", true);

        yield return new WaitForSeconds(0.05f);
        Vector3 pos1 = transform.position;
        Vector3 pos2 = tilemap.GetCellCenterWorld(goal);
        //Debug.Log(pos1 + "**" + pos2);
        transform.position += (pos2 - pos1).normalized / tileTime * 0.05f;



        while (transform.position != pos2)
        {
            yield return new WaitForSeconds(0.05f);
            transform.position += (pos2 - pos1).normalized / tileTime * 0.05f;
            
        }

        ShowStopAnimation();
        moving = false;

        //animator.SetBool("_moving", false);

        yield return null;
    }

    public void BombAtPosition(float time, int range)
    {
        BombSpawner.instance.CreateBomb(GetPosition(), time,range,group);
    }

    /*
    public bool Move(int dir)
    {
        Vector3Int cell = GetPosition();
        
        direction = dir;
        moving = true;
        
        Tile tile;
        switch (dir)
        {
            case 0:
                tile = tilemap.GetTile<Tile>(cell+new Vector3Int (0,-1,0));
                //directionVector = Vector3.down;
                break;
            case 1:
                tile = tilemap.GetTile<Tile>(cell + new Vector3Int(-1,0,0));
                //directionVector = Vector3.left;
                break;
            case 2:
                tile = tilemap.GetTile<Tile>(cell + new Vector3Int(1, 0,0));
                //directionVector = Vector3.right;
                break;
            case 3:
                tile = tilemap.GetTile<Tile>(cell + new Vector3Int(0, 1,0));
                //directionVector = Vector3.up;
                break;
        }

        return false;
    }
    */

    public void MoveCell(int dir)
    {
        //animator.SetInteger("_direction", dir);
        Vector3Int cell = GetPosition();
        //Debug.Log(cell);
        switch (dir)
        {
            case 0:
                cell = cell + new Vector3Int(0, -1, 0);
                break;
            case 1:
                cell = cell + new Vector3Int(-1, 0, 0);
                break;
            case 2:
                cell = cell + new Vector3Int(1, 0, 0);
                break;
            case 3:
                cell = cell + new Vector3Int(0, 1, 0);
                break;
        }
        ShowStopAnimation();

        Tile tile = tilemap.GetTile<Tile>(cell);
        //Debug.Log(tile);
        
        if (tile == null)
        {
            ShowMoveAnimation(dir);

            //animator.SetBool("_moving", true);
            moving = true;

            StartCoroutine(MoveOneTile (cell));
            //transform.position = tilemap.GetCellCenterWorld(cell);
        }
        /*
        if (Utils.instance.GetTileType(tile) == 0)
        {
            transform.position = tilemap.GetCellCenterWorld(cell);
        }*/


    }

    protected void ShowMoveAnimation(int dir)
    {
        switch (dir)
        {
            case 0:
                animator.Play("run_down");
                break;
            case 1:
                animator.Play("run_left");

                break;
            case 2:
               animator.Play("run_right");

                break;
            case 3:
                animator.Play("run_up");

                break;
        }
    }

    protected void ShowStopAnimation()
    {
        //Debug.Log(direction);
        switch(direction)
        {
            case 0:
                animator.Play("idle_down");
                break;
            case 1:
                animator.Play("idle_left");
                break;
            case 2:
                animator.Play("idle_right");
                break;
            case 3:
                animator.Play("idle_up");
                break;
        }
    }

    public Vector3Int GetPosition()
    {
        if(tilemap == null)
        {
            return new Vector3Int();
        }
        //Vector3 worldPos = Camera.main.ScreenToWorldPoint(transform.position);
        Vector3Int cell = tilemap.WorldToCell(transform.position);

        return cell;
    }

    public void SetPosition(Vector3Int c)
    {
        this.pos = c;
        if(tilemap != null)
        {
            transform.position = tilemap.GetCellCenterWorld(pos);
        }
    }

    public bool IsMoving()
    {
        return moving;
    }

    public int GetDirection()
    {
        return direction;
    }

}
