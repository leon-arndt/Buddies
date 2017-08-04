using UnityEngine;
using System.Collections;

namespace ObserverPattern {
    public class GameController : MonoBehaviour {
        public GameObject sphereObj;

        //The boxes that will jump
        public GameObject box1Obj;
        public GameObject box2Obj;
        public GameObject box3Obj;
        public GameObject box4Obj;//

        //Will send notifications that something has happened to whoever is interested
        Subject subject = new Subject();

        //player transform
        //Transform playerTransform = GameObject.FindWithTag("PlayerObject").transform;

        void Start() {
            //Create boxes that can observe events and give them an event to do
            Box box1 = new Box(box1Obj, new JumpLittle());
            Box box2 = new Box(box2Obj, new JumpMedium());
            Box box3 = new Box(box3Obj, new JumpHigh());
            Box box4 = new Box(box4Obj, new JumpHigh());//

            //Add the boxes to the list of objects waiting for something to happen
            subject.AddObserver(box1);
            subject.AddObserver(box2);
            subject.AddObserver(box3);
            subject.AddObserver(box4);//
        }


        void Update() {
            //Notification condition
            //if ((GameObject.FindWithTag("PlayerObject").transform.position - GameObject.FindWithTag("Boss").transform.position).magnitude < 20.0f) {

            //Debug.Log(Vector3.Distance(sphereObj.transform.position, playerTransform.position));

            //Attempt 3 using hp
            if (sphereObj.GetComponent<EnemyController>().life < 5) {
                Debug.Log("Minions have been notified");
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