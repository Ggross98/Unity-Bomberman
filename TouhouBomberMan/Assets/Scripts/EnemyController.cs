using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    List<EnemyScript> enemyList;

    void Update()
    {
        if (enemyList == null) return;

        for(int i =0;i<enemyList.Count; i++)
        {
            if(enemyList [i].life == 0)
            {
                Destroy(enemyList[i].gameObject);
                enemyList.RemoveAt(i);
            }
        }
    }

    public void CreateEnemyAt(int x, int y, int id)
    {

    }


}
