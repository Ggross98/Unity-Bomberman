using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float lifeTime=0.5f;
    private float damageTime = 0.3f;
    private int groupTag = Utils.PLAYER1;



    void Awake()
    {
        Destroy(gameObject, lifeTime);
        Invoke("DeleteTrigger",damageTime );
    }

    private void DeleteTrigger()
    {
        GetComponent<Collider2D>().enabled=false;
    }


    public void SetGroup(int tag)
    {
        groupTag = tag;
    }

    public int GetGroup()
    {
        return groupTag;
    }

}
