using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private List<ITick> tickedObjects;
    public float TickTime = 1;

    public static GameController instance;

    private float nextTick = 0;

    private bool SpacePressed = false;

    private void Awake()
	{
        if (instance != null)
		{
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void AddTickObject(ITick toAdd)
	{
		tickedObjects.Add(toAdd);
    }
	

	private void Update ()
	{
        float dt = Time.deltaTime;
        SpacePressed = Input.GetKey(KeyCode.Space);

        nextTick += dt;

        if (nextTick >= TickTime) {
            foreach (ITick br in tickedObjects) {
                br.Tick();
            }
            nextTick = 0;
        }
	}
}