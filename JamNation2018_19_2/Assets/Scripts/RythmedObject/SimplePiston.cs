using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePiston : MonoBehaviour, BasicRythmed {
    public bool IsMortal = false;


    void Awake() {
        GameController.instance.AddBasicRythmed(this);
    }

    void BasicRythmed.Tick() {

        //CALL ANIM 

        IsMortal = !IsMortal;

    }

    

}

