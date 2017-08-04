﻿using UnityEngine;
using System.Collections;


namespace ObserverPattern {
    //Events
    public abstract class BoxEvents { //basically the same as an interface
        public abstract float GetJumpForce();
    }


    public class JumpLittle : BoxEvents {
        public override float GetJumpForce() {
            return 30f;
        }
    }

    
    public class JumpMedium : BoxEvents {
        public override float GetJumpForce() {
            return 60f;
        }
    }


    public class JumpHigh : BoxEvents {
        public override float GetJumpForce() {
            return 90f;
        }
    }
}