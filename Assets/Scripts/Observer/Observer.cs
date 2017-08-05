using UnityEngine;
using System.Collections;

namespace ObserverPattern {
    //Wants to know when another object does something interesting 
    public abstract class Observer {
        public abstract void OnNotify();
    }

    public class Minion : Observer {
        GameObject minionObj; //The box gameobject which will do something
        BoxEvents minionEvent; //What will happen when this box gets an event

        public Minion(GameObject minionObj, BoxEvents minionEvent) {
            this.minionObj = minionObj;
            this.minionEvent = minionEvent;
        }

        //What the minion will do if the event fits it
        public override void OnNotify() {
            //Jump(boxEvent.GetJumpForce());
            StartChasing();
        }

        //A function that makes the observers start chasing
        void StartChasing() {
            Debug.Log("The GameController told the Enemy Controller to start chasing");
            minionObj.GetComponent<EnemyController>().StartChasing();
        }




        //The box will always jump in this case
        void Jump(float jumpForce) {
            //If the box is close to the ground
            if (minionObj.transform.position.y < 0.55f) {
                minionObj.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
            }
        }
    }
}