using UnityEngine;
using System.Collections;

public class DemonMovement : MonoBehaviour {
    public UnityEngine.AI.NavMeshAgent agent;

	public Transform Player;
    public GameObject deathUI;

	public AudioSource src;

	int MoveSpeed = 2;
	double MinDist = 1.7;
	private Animator anim;
	int hIdles;
	int hAngry;
	int hAttack;
	int hGrabs;
	int hThumbsUp;


	public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;



	public float sightRange;

	public LayerMask whatIsGround, whatIsPlayer;

    public bool playerInSightRange;
		
	// Use this for initialization
	void Start () {
		deathUI.SetActive(false);
		anim = GetComponent<Animator> ();
		hIdles = Animator.StringToHash("Idles");
		hAngry = Animator.StringToHash("Angry");
		hAttack = Animator.StringToHash("Attack");
		hGrabs = Animator.StringToHash("Grabs");
		hThumbsUp = Animator.StringToHash("ThumbsUp");

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {
		playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
		
		if (!playerInSightRange) Patroling();
        if (playerInSightRange) ChasePlayer();

		if(Vector3.Distance(transform.position,Player.position) <= MinDist) {
			Player.transform.LookAt(transform);
		 	src.Play();
		 	anim.SetBool(hGrabs, true);
		 	deathUI.SetActive(true);
		}
		// transform.LookAt(Player);
		// if(Vector3.Distance(transform.position,Player.position) >= MinDist) {
		// 	anim.SetBool(hIdles, true);
		// 	transform.position += transform.forward * MoveSpeed*Time.deltaTime;
		// }
		// if(Vector3.Distance(transform.position,Player.position) <= MinDist) {
		// 	Player.transform.LookAt(transform);
		// 	src.Play();
		// 	anim.SetBool(hGrabs, true);
		// 	deathUI.SetActive(true);
		// }

	 }

	private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }


	private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

	private void ChasePlayer()
    {
        agent.SetDestination(Player.position);
    }
}