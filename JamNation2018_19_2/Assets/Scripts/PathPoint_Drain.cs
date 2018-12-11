using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint_Drain : PathPoint {

	public bool contributeToSequenceTrigger;

	public bool endGame = false;

	public List<PathPoint_Spawn> triggeredSpawnPoints;

	public override void ExecutePathBehavior(BlobCharacter blob)
	{
		if (endGame)
		{
			GameController.instance.EndGame();
		}

		if(contributeToSequenceTrigger)
		{
			GameController.instance.AddToSequenceTrigger(1);
		}
		blob.Despawn();

		foreach (PathPoint_Spawn sP in triggeredSpawnPoints)
		{
			sP.SpawnBlob();
		}
	}

#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawCube(transform.position, new Vector3(0.5f,0.5f,0.5f));
	}
#endif
}