using UnityEngine;
using UnityEngine.AI;
using C;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyPatrol : IFSMState<EnemyController> {
    /// <summary>
    /// This state controls how the enemy acts when not chasing the player.
    /// It is heavily based on the FSM state we created in class.
    /// The enemies use waypoints to patrol the map.
    /// </summary>
 
    private int currentWaypoint = 0;
    //private float closeEnoughToWaypoint = 0.5f;
    //private float speed = 8.0f;
    private NavMeshAgent agent;
    private ThirdPersonCharacter character;

	static readonly EnemyPatrol instance = new EnemyPatrol();
	public static EnemyPatrol Instance {
		get { return instance; }
	}

    public void Enter(EnemyController e) {
        agent = e.GetComponent<NavMeshAgent>();
        character = e.GetComponent<ThirdPersonCharacter>();
        agent.SetDestination(e.waypoints[currentWaypoint]);
		//Debug.Log( "started patrolling" );
	}

	public void Exit(EnemyController e) {
		//Debug.Log("stopped patrolling");
	}
		
	public void Reason(EnemyController e) {
        
		// can we see the player? if so, we gotta chase after him!
		RaycastHit hit;
		if( Physics.Raycast( e.transform.position, e.playerTransform.position - e.transform.position, out hit ) ) {
            if (hit.transform.tag == Tags.PLAYER){
                Debug.DrawRay(e.transform.position, e.playerTransform.position - e.transform.position, Color.red);
                e.ChangeState(new EnemyChase());
            } else {
                Debug.DrawRay(e.transform.position, e.playerTransform.position - e.transform.position, Color.green);
            }
		}
	}
		
	public void Update( EnemyController e ) {
		// really simple waypoint navigation. Just finds a waypoint to run to
		//if( Vector3.Distance( e.transform.position, e.waypoints[currentWaypoint] ) < closeEnoughToWaypoint ) {
        if (agent.remainingDistance <= agent.stoppingDistance) {
			currentWaypoint++;
			if( currentWaypoint >= e.waypoints.Count )
				currentWaypoint = 0;

            //Debug.Log("Changed Waypoint to #"+currentWaypoint);
			agent.SetDestination(e.waypoints[currentWaypoint]);
			
            //character.Move(Vector3.zero, false, false); //also throws error

		} else {
			//character.Move(agent.desiredVelocity, false, false); //this throws error NRE
		}



		//Vector3 directionToWaypoint = e.waypoints[currentWaypoint] - e.transform.position;
		//e.transform.rotation = Quaternion.LookRotation( directionToWaypoint );
        //e.transform.position += ( directionToWaypoint.normalized * speed * Time.deltaTime );

	}
}
