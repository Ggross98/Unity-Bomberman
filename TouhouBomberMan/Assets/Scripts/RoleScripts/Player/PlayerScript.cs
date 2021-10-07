using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerScript : RoleScript
{
    public KeyCode Down = KeyCode.DownArrow, Right = KeyCode.RightArrow, Left = KeyCode.LeftArrow, Up = KeyCode.UpArrow;
    public KeyCode CreateBomb = KeyCode.Z;
    public KeyCode Spell = KeyCode.X;

    public int maxSpell = 3;
    protected int leftSpell = 3;

    new public void SetTilemap(Tilemap t)
    {
        tilemap = t;
    }

    virtual protected void UseSpell()
    {
        Debug.Log("virtual");
    }


    // Update is called once per frame
    virtual protected void Update()
    {
        this.pos = GetPosition();

        #region 移动
        if (!(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        {
            preparing = false;
            /*
            if (!moving)
            {
                ShowStopAnimation();
            }*/
        }
        else
        {
            preparing = true;

            if (Input.GetKey(Down))
            {
                direction = 0;
            }
            if (Input.GetKey(Left))
            {
                direction = 1;
            }
            if (Input.GetKey(Right))
            {
                direction = 2;
            }
            if (Input.GetKey(Up))
            {
                direction = 3;
            }

            if (!moving)
                MoveCell(direction);
        }

        #endregion


        #region 射击
        if (Input.GetKeyDown(CreateBomb ))
        {
            BombAtPosition(bombTime, range);
        }
        if (Input.GetKeyDown(Spell))
        {
            UseSpell();
        }
        #endregion

    }
}
