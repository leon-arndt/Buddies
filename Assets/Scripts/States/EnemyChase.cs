﻿using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyChase : IFSMState<EnemyController> {
    //private float speed = 8f;

    //Update playerTransform to get the closest player
    private Transform aPlayerTransform;
    private float notSeePlayerTime = 0;
    private float maxNotSeePlayerTime = 5.0f;
    private float chasingTime = 0; //was 5.0f before reverted to 0
    private NavMeshAgent agent;
    private ThirdPersonCharacter character;

    void Start() {
        //revert to this //aPlayerTransform = GameObject.FindWithTag("PlayerObject").transform; //gives us a player transform to work with
        Debug.Log("Chase thinks the aPlayer starts at " + aPlayerTransform);
    }

    public void Enter(EnemyController e) {
        aPlayerTransform = GameObject.FindWithTag("PlayerObject").transform;//remove when reverting
        agent = e.GetComponent<NavMeshAgent>();
        character = e.GetComponent<ThirdPersonCharacter>();
        agent.SetDestination(e.playerTransform.position); //revert to e.playerTransform.position                 was e.playerTransform.position, later aPlayerTransform.position
        Debug.Log("started chasing");
	}

	public void Exit(EnemyController e) {
		Debug.Log("stopped chasing");
	}

	public void Reason(EnemyController e) {
        //e.playerTransform.position = FindClosestPlayer(e).transform.position; //used to update playerTransform


        // can we see the player? If not, we get out of here (exit state)
        RaycastHit hit;
		var canSeePlayer = false;

        //Debug.Log("Chase Reasons thinks the player is at" + e.playerTransform.position);

		if( Physics.Raycast( e.transform.position, e.playerTransform.position - e.transform.position, out hit ) ) {
            if( hit.transform.tag == "PlayerObject" ) {
                canSeePlayer = true;
				Debug.DrawRay(e.transform.position, e.playerTransform.position - e.transform.position, Color.red);
			} else {
				Debug.DrawRay(e.transform.position, e.playerTransform.position - e.transform.position, Color.green);
			}
		}

		if (!canSeePlayer) {
			notSeePlayerTime += Time.deltaTime;
		} else {
			notSeePlayerTime = 0; //can see the player
		}

		if (notSeePlayerTime > maxNotSeePlayerTime)
            e.ChangeState(EnemyPatrol.Instance); //stop chasing
	}
		
	public void Update( EnemyController e ) {
        //update e playerTransform.postion?

        //Debug.Log("Chase Update thinks the player is at" + e.playerTransform.position); //Outputs xyz of the 

        chasingTime += Time.deltaTime;
		if (chasingTime > 0.1f) { //stop chasing, was 5.0f
			agent.SetDestination(e.playerTransform.position); //the player to target
			chasingTime = 0;
			Debug.Log("Setting Target...");
			character.Move(Vector3.zero, false, false);
		} else {
			character.Move(agent.desiredVelocity, false, false);
		}

		//run after the player!
		//var directionToPlayer = e.playerTransform.position - e.transform.position;
		//e.transform.rotation = Quaternion.LookRotation( directionToPlayer );
		//e.transform.position += ( directionToPlayer.normalized * speed * Time.deltaTime );
	}
}