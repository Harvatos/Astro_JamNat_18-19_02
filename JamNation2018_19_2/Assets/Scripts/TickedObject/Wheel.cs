using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour, ITick {

	public Animator anim;

    void Start()
	{
		if (GameController.instance)
		{
			GameController.instance.AddTickObject(this);
		}
    }

	[ContextMenu("Tick")]
	public void Tick()
	{
		//anim.SetTrigger("Tick");
    }



}
