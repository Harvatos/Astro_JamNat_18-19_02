using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePiston : MonoBehaviour, BasicRythmed {

    public float speed = 1;
    public Direction direction;
    public int distance;

    private bool switcher = true;

    void Goto(Vector3 to) {
        // TODO ANIME

        transform.position = to;

    }

    void BasicRythmed.Tick() {
        Vector3 newPos = gameObject.transform.position;

        switch (direction) {
            case Direction.haut:
                newPos.y = switcher ? newPos.y + distance : newPos.y - distance;
                break;
            case Direction.gauche:
                newPos.x = switcher ? newPos.x - distance : newPos.x + distance;
                break;
            case Direction.droite:
                newPos.x = switcher ? newPos.x + distance : newPos.x - distance;
                break;
            case Direction.bas:
                newPos.y = switcher ? newPos.y - distance : newPos.y + distance;
                break;
        }

        switcher = !switcher;
        Goto(newPos);
    }

    

}

