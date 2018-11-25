using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour, BasicRythmed {


    public void Tick() {
        // TODO Call anim

    }

    void Awake() {
        GameController.instance.AddBasicRythmed(this);
    }

}
