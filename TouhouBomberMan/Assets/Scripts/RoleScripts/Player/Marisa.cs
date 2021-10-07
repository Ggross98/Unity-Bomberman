using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marisa : PlayerScript

{
    new protected void UseSpell()
    {
        BombAtPosition(2f,10);
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
