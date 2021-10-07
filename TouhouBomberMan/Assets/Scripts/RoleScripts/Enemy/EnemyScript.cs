using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : RoleScript
{
    protected void SelectRandomDir()
    {
        //preparing = true;
        int _dir;
        //do {
        _dir = Random.Range(0, 4);
        //} while (!Utils.instance.CanMoveTo(GetPosition(),_dir));
        direction = _dir;

    }

    protected void Update()
    {
        preparing = true;

        if (moving)
        {
            return;
        }
        else
        {
            SelectRandomDir();
            MoveCell(direction);
        }
    }
}
