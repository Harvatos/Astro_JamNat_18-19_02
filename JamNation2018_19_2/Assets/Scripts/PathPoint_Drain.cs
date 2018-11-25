using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint_Drain : PathPoint {

	public bool contributeToSequenceTrigger;

	public override void ExecutePathBehavior(BlobCharacter blob)
	{
		if(contributeToSequenceTrigger)
		{
			GameController.instance.AddToSequenceTrigger(1);
		}
		//Despawn blob
	}

#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawCube(transform.position, new Vector3(0.5f,0.5f,0.5f));
	}
#endif
}