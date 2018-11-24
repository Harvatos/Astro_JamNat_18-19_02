using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public List<BasicRythmed> RythmedObjects;
    public float TickTime = 1;

    private float nextTick = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;

        nextTick += dt;

        if (nextTick >= TickTime) {
            foreach (BasicRythmed br in RythmedObjects) {
                br.Tick();
            }
            nextTick = 0;
        }
	}
}

public enum Direction { haut, bas, droite, gauche }