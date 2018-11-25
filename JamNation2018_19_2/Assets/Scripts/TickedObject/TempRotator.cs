using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempRotator : MonoBehaviour, ITick {

	void Start ()
	{
		GameController.instance.AddTickObject(this);
	}
	
	public void Tick()
	{
		transform.Rotate(new Vector3(0f, 45f, 0f));
	}
}
