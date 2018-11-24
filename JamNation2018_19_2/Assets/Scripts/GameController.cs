using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    
    public List<GameObject> RythmedObjects;
    public float TickTime = 1;

    public static GameController instance;

    private float nextTick = 0;

    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

        // Use this for initialization
        void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;

        nextTick += dt;

        if (nextTick >= TickTime) {
            foreach (GameObject br in RythmedObjects) {
                br.GetComponent<BasicRythmed>().Tick();
            }
            nextTick = 0;
        }
	}
}

public enum Direction { haut, bas, droite, gauche }