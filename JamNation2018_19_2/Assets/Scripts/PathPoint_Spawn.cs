using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint_Spawn: PathPoint {

	public GameObject blobPrefab;

	public void SpawnBlob ()
	{
		GameObject newBlob = Instantiate(blobPrefab, transform);
		newBlob.GetComponent<BlobCharacter>().currentPoint = this;
		RotateObjectTowardPath(newBlob.transform);
	}

#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawCube(transform.position, new Vector3(0.5f,0.5f,0.5f));

		if (nextPathPoint)
		{
			Gizmos.color = Color.magenta;
			Gizmos.DrawLine(transform.position, nextPathPoint.transform.position);
		}
	}
#endif
}