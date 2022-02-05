using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SheepController : MonoBehaviour
{
	public float timeForNewPath;
	//Animator
	private Animator _anim;
	private bool _beingChased;

	//Chase variables
	private const float CHASE_SPEED = 12.0f;
	private bool _inCoRoutine;
	private Vector3 _lastPosition = Vector3.zero;

	//AI variables
	private NavMeshAgent _nma;
	private NavMeshPath _path;
	private Vector3 _playerPos;
	private const float RUN_THIS_LONG = 4.0f;
	private float _speed;
	private Vector3 _target;
	private bool _validPath;
	private static readonly int Speed = Animator.StringToHash("speed");

	private void Awake() => _anim = GetComponent<Animator>();

	private void Start()
	{
		_nma = GetComponent<NavMeshAgent>();
		_path = new NavMeshPath();
	}
	private void Update()
	{
		UpdateAnimation();
		if (!_inCoRoutine) StartCoroutine(WalkRandom(timeForNewPath));
		if (_beingChased) CalculateRun(_playerPos);
	}

	//Run away from player ---------------------------------------------------
	private void OnTriggerStay(Collider other)
	{
		//Only run away from player
		if (!other.gameObject.CompareTag("Player")) return;
		if (Vector3.Distance(transform.position, other.transform.position) > 3.0f)
			_playerPos = other.transform.position;
		//Only restart run when it ends
		if (_beingChased) return;
		//Makes conditional true in Update function for sheep to run
		_beingChased = true;
		StartCoroutine(RunAway(RUN_THIS_LONG));
	}

	//Walk Randomly ---------------------------------------------------------
	private Vector3 GetNewRandomPosition()
	{
		//Time between generating new path
		timeForNewPath = Random.Range(2, 7);
		//Get random location
		//Walkable area is only between -60 and 60 but this gives more chances 
		//for the sheep to spread out, and not stick to the middle of the play area
		float x = Random.Range(-120, 70);
		float z = Random.Range(-120, 120);
		//Return position of new point to path towards
		var pos = new Vector3(x, 0.0f, z);
		return pos;
	}

	private IEnumerator WalkRandom(float time)
	{
		_inCoRoutine = true;
		GetNewPath();
		_validPath = _nma.CalculatePath(_target, _path);
		yield return new WaitForSeconds(time);
		while (!_validPath)
		{
			yield return new WaitForSeconds(0.01f);
			GetNewPath();
			_validPath = _nma.CalculatePath(_target, _path);
		}
		//validPath = transform.position
		_inCoRoutine = false;
	}
	private void GetNewPath()
	{
		_target = GetNewRandomPosition();
		_nma.SetDestination(_target);
	}

	private IEnumerator RunAway(float time)
	{
		_inCoRoutine = true;
		//Wait time seconds before the sheep stops being chased
		yield return new WaitForSeconds(time);
		_beingChased = false;
		_inCoRoutine = false;
	}

	private void CalculateRun(Vector3 playerPosition)
	{
		//Get distance of sheep from player
		var transform1 = transform;
		var distance = transform1.position - playerPosition;
		transform1.forward = distance;
		var moveForward = new Vector3(0.0f, 0.0f, CHASE_SPEED * Time.deltaTime);
		transform.Translate(moveForward);
	}

	private void UpdateAnimation()
	{
		//Get speed of sheep
		var position = transform.position;
		var movementPerFrame = Vector3.Distance(_lastPosition, position);
		_speed = movementPerFrame / Time.deltaTime;
		_lastPosition = position;
		//Set speed to animation variable
		_anim.SetFloat(Speed, _speed);
	}
}
