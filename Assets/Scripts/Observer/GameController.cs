using UnityEngine;
using System.Collections;

namespace ObserverPattern {
    public class GameController : MonoBehaviour {
        public GameObject bossObj;

        //The boxes that will jump
        public GameObject minion1Obj;
        public GameObject minion2Obj;
        public GameObject minion3Obj;
        public GameObject minion4Obj;//

        //Will send notifications that something has happened to whoever is interested
        Subject subject = new Subject();

        //player transform
        //Transform playerTransform = GameObject.FindWithTag("PlayerObject").transform;

        void Start() {
            //Create boxes that can observe events and give them an event to do
            Minion minion1 = new Minion(minion1Obj, new JumpLittle());
            Minion minion2 = new Minion(minion2Obj, new JumpMedium());
            Minion minion3 = new Minion(minion3Obj, new JumpHigh());
            Minion minion4 = new Minion(minion4Obj, new JumpHigh());//

            //Add the boxes to the list of objects waiting for something to happen
            subject.AddObserver(minion1);
            subject.AddObserver(minion2);
            subject.AddObserver(minion3);
            subject.AddObserver(minion4);
        }


        void Update() {
            //Notification condition
            //if ((GameObject.FindWithTag("PlayerObject").transform.position - GameObject.FindWithTag("Boss").transform.position).magnitude < 20.0f) {

            //Debug.Log(Vector3.Distance(sphereObj.transform.position, playerTransform.position));

            //Attempt 3 using hp
            if (bossObj.GetComponent<EnemyController>().life < 5) {
                Debug.Log("Minions should have been notified");
                subject.Notify();
            }


            /*if (Vector3.Distance(sphereObj.transform.position, playerTransform.position) < 10.0f) {
                Debug.Log("Minions have been notified");
                subject.Notify();
            }*/

            //The boxes should jump if the sphere is cose to origo
            /*if ((sphereObj.transform.position).magnitude < 0.5f) {
                subject.Notify();
            }*/
        }
    }
}