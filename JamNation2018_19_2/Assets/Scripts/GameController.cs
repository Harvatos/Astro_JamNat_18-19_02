using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private List<BasicRythmed> RythmedObjects;
    public float TickTime = 1;

    public static GameController instance;

    private float nextTick = 0;

    private bool SpacePressed = false;

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

    public void AddBasicRythmed(BasicRythmed basic) {
        RythmedObjects.Add(basic);
    }
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;
        SpacePressed = Input.GetKey(KeyCode.Space);

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