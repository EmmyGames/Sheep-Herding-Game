using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//Movement variables
	private const float MOVE_SPEED = 10.0f;
	private const float SPRINT_SPEED = 17.0f;
	private const float ROTATE_SPEED = 1800; //Degrees, this is divided by speed later
	private const float GRAVITY = 9.81f;
	public float speed;

	//Animator variables
	private Animator _anim;
	private CharacterController _cc;
	private Vector3 _lastPosition = Vector3.zero;
	private Vector3 _moveDirection = Vector3.zero;
	private float _moveSpeed;
	private float _moveX;
	private float _moveZ;
	private static readonly int Speed = Animator.StringToHash("speed");

	private void Awake() => _anim = GetComponent<Animator>();

	private void Start()
	{
		_cc = GetComponent<CharacterController>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void Update()
	{
		MovePlayer();
		UpdateAnimation();

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}

	private void MovePlayer()
	{
		if (Input.GetButton("Sprint") && _moveZ >= 0.0f)
			speed = SPRINT_SPEED;
		else if (_moveZ < 0.0f)
			speed = MOVE_SPEED * 0.5f;
		else
			speed = MOVE_SPEED;

		_moveX = Input.GetAxis("Horizontal");
		_moveZ = Input.GetAxis("Vertical");

		_moveDirection = transform.forward * _moveZ * speed;
		transform.Rotate(0.0f, _moveX * ROTATE_SPEED / speed * Time.deltaTime, 0.0f);
		_moveDirection.y -= GRAVITY;
		_cc.Move(_moveDirection * Time.deltaTime);
	}

	//Change animation based on speed (idle, walk, run)
	private void UpdateAnimation()
	{
		//Get speed of sheep
		var position = transform.position;
		var movementPerFrame = Vector3.Distance(_lastPosition, position);
		_moveSpeed = movementPerFrame / Time.deltaTime;
		_lastPosition = position;
		//Set speed to animation variable
		_anim.SetFloat(Speed, _moveSpeed);
	}
}
