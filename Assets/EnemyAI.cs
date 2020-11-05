using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{	
	public NavMeshAgent enemy;
	public Transform Player;

	//Patroling
	public Vector3 walkPoint;
	bool walkPointSet;
	public float walkPointRange;
	public float timeBetweenAttacks = 0.5f;
	public bool awake, sleeping;
	public bool alreadyAttacked;
	public float sightRange, attackRange;
	public bool playerInSightRange, playerInAttackRange;
	public GameObject projectile;
	public SpriteRenderer chaser, sleepy;
	
    // Start is called before the first frame update
    void Start()
    {
    	
        sleepy.enabled = true;
		chaser.enabled = false;
		sleeping = true;
		awake = false;
    }
    
    // Update is called once per frame
    void Update()
    {
    	if((Player.position - transform.position).magnitude <= sightRange)
    	{
    	    playerInSightRange = true;
    	}
    	else
    	{
    		playerInSightRange = false;
    	}
    	if((Player.position - transform.position).magnitude <= attackRange)
    	{
    	    playerInAttackRange = true;
    	}
    	else
    	{
    		playerInAttackRange = false;
    	}

    	if(!playerInSightRange && !playerInAttackRange)
    	{
    		Sleep();
    		awake = false;
    		sleeping = true;
    	}
		if(playerInSightRange && !playerInAttackRange)
		{
			ChasePlayer();
			awake = true;
			sleeping = false;
		}
		if(playerInSightRange && playerInAttackRange)
		{
			AttackPlayer();
			//angry = true;
			awake = true;
		}
		if(sleeping)
		{
			sleepy.enabled = true;
			chaser.enabled = false;
		}
		if(awake)
		{
			sleepy.enabled = false;
			chaser.enabled = true;
		}	
		
    }
    
	private void ChasePlayer()
	{
		Vector3 goal = Player.position;
		enemy.SetDestination(goal);
	}

	private void Sleep()
	{
		enemy.SetDestination(transform.position);
		transform.Rotate(Vector3.right * 100 * Time.deltaTime);
	}

	private void AttackPlayer()
	{	
		enemy.SetDestination(Player.position);

		transform.LookAt(Player);

		if(!alreadyAttacked)
		{
			//ATTACK CODE
			GameObject project = Instantiate(projectile, transform.position, Quaternion.identity);
			Rigidbody rb = project.GetComponent<Rigidbody>();
			rb.AddForce((Player.position-transform.position).normalized*70f, ForceMode.Impulse);
			/////

			Destroy(project, 1.5f);
			alreadyAttacked = true;
			Invoke(nameof(ResetAttack), timeBetweenAttacks);
		}

	}
	private void ResetAttack()
	{
		alreadyAttacked = false;
	}
}













/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
	public NavMeshAgent agent;

	public Transform player;

	public LayerMask whatIsGround, whatIsPlayer;

	//Patroling
	public Vector3 walkPoint;
	bool walkPointSet;
	public float walkPointRange;

	//Attacking
	public float timeBetweenAttacks;
	bool alreadyAttacked;
	public GameObject projectile;
	//States
	public float sightRange, attackRange;
	public bool playerInSightRange, playerInAttackRange;

	private void Awake()
	{
		player = GameObject.Find("Player").transform;
		agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
		playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

		if(!playerInSightRange && !playerInAttackRange){Patroling();}
		if(playerInSightRange && !playerInAttackRange){ChasePlayer();}
		if(playerInSightRange && playerInAttackRange){AttackPlayer();}
	}


	private void ChasePlayer()
	{
		agent.SetDestination(player.position);
	}

	private void AttackPlayer()
	{	
		agent.SetDestination(transform.position);

		transform.LookAt(player);

		if(!alreadyAttacked)
		{
			//ATTACK CODE
			Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
			rb.AddForce(transform.forward*32f, ForceMode.Impulse);
			rb.AddForce(transform.up*8f, ForceMode.Impulse);
			/////

			alreadyAttacked = true;
			Invoke(nameof(ResetAttack), timeBetweenAttacks);
		}

	}
	private void ResetAttack()
	{
		alreadyAttacked = false;
	}
		
}*/
