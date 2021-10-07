using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reimu : PlayerScript
{
    new protected void UseSpell()
    {
        Vector3Int pos0 = GetPosition();
        Vector3Int pos;
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                pos = pos0 + new Vector3Int(i, j, 0);
                if (pos != pos0)
                {
                    Utils.instance.CreateExplosionAt(pos, group);
                }
            }
        }
    }

    new protected void Update()
    {

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
        if (Input.GetKeyDown(CreateBomb))
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
