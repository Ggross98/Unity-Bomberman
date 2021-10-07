using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	private float countdown = 2f;
    private int range = 2;
    private int groupTag = Utils.PLAYER1;
    //private Sprite sprite;

    public void SetBomb(float countdown,int range,int group)
    {
        this.countdown = countdown;
        this.range = range;
        groupTag = group;
    }
	
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;

		if (countdown <= 0f)
		{
			FindObjectOfType<MapDestroyer>().Explode(transform.position,range,groupTag);
			Destroy(gameObject);
		}
	}

    public void Explode()
    {
        countdown = 0f;
    }

    public void SetCountdown(float time)
    {
        countdown = time;
    }
}
