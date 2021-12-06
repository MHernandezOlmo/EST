using UnityEngine;

// Script para el control del personaje. Basta añadirlo a cualquier GameObject con un Animator y un CharacterController. Encargado de:
// - Controlar el personaje
// - Aplicar gravedad
// - Animar al personaje

[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{
	const float GRAVITY = 10;
	const float GROUND_RAY_LENGTH = 0.3f;
	const float MAX_VERTICAL_SPEED = 20.0f;
	const float MAX_MOVEMENT_SPEED = 4f;
	const float TURN_SPEED = 15f;
	const float ACCEL = 11f;

	public bool Grounded => grounded;

	// PUBLIC VARIABLES
	public Vector3? autopilot = null;

	// DEPENDENCIES
	CharacterController motor;
	Animator anim;
	Transform cam;

	// CAMERA
	Vector3 camF;
	Vector3 camR;

	// INPUT
	Vector2 input;

	// PHYSICS
	Vector3 velocity;
	float CurrentMovementSpeed => velocity.xz().magnitude;

	// GRAVITY
	bool grounded = false;

	bool movementEnabled = true;
	bool rotationEnabled = true;

	void Start()
	{
		motor = GetComponent<CharacterController>();
		anim = GetComponentInChildren<Animator>();
		cam = Camera.main.transform;
	}

	void Update()
	{
        if(CurrentSceneManager._canMove && !movementEnabled)
        {
            EnableMovement();
        }
        if(!CurrentSceneManager._canMove && movementEnabled)
        {
            DisableMovement();    
        }

		DoInput();
		DoCamera();
		DoGround();
		DoMove();
		DoGravity();
		DoAnim();
		if (velocity != new Vector3(0f, -0.5f, 0f))
		{
			Vector3 finalVelocity = velocity * CurrentSceneManager.GetWalkSpeed();
			motor.Move(finalVelocity * Time.deltaTime);
		}
	}

	void DoInput()
	{

        input.x = PlayerInput._Joystick.x;
        input.y = PlayerInput._Joystick.y;

        input = Vector2.ClampMagnitude(input, 1);
	}

	void DoCamera()
	{
		camF = cam.forward.xz().normalized;
		camR = cam.right.xz().normalized;
	}

	void DoGround()
	{
		if (Physics.Raycast(transform.position + Vector3.up * 0.1f, -Vector3.up, GROUND_RAY_LENGTH))
		{
			grounded = true;
		}
		else
		{
			grounded = false;
		}
	}

	void DoMove()
	{
		Vector3 facing;
        if (autopilot.HasValue)
		{
			Vector3 myPos_xz = transform.position.xz();
			Vector3 targetPos_xz = autopilot.Value.xz();
			Vector3 direction_xz = (targetPos_xz - myPos_xz).normalized;
			facing = direction_xz;
			if (Vector3.Distance(targetPos_xz, myPos_xz) < 0.1f)
			{
				autopilot = null;
			}
		}
		else
		{
            facing = camF * input.y + camR * input.x;
        }

		if (input.magnitude > 0 && rotationEnabled)
		{
			Quaternion rot = Quaternion.LookRotation(facing);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, TURN_SPEED * Time.deltaTime);
		}

		Vector3 velocity_xz = velocity.xz();
        velocity_xz = Vector3.Lerp(velocity_xz, MAX_MOVEMENT_SPEED * transform.forward * facing.magnitude, ACCEL * Time.deltaTime);

        if (movementEnabled)
        {
            velocity = new Vector3(velocity_xz.x, velocity.y, velocity_xz.z);
        }
        else
        {
            velocity = Vector3.zero;
        }

	}

	void DoGravity()
	{
		if (grounded)
		{
			velocity.y = -0.5f;
		}
		else
		{
			velocity.y -= GRAVITY * Time.deltaTime;
		}

		velocity.y = Mathf.Clamp(velocity.y, -MAX_VERTICAL_SPEED, MAX_VERTICAL_SPEED);
	}

	void DoAnim()
	{
		float movementBlend = Mathf.InverseLerp(0f, MAX_MOVEMENT_SPEED, CurrentMovementSpeed);
		anim.SetFloat("MovementBlend", movementBlend);
	}

	public void EnableMovement()
	{
		movementEnabled = true;
		rotationEnabled = true;
	}
	public void DisableMovement()
	{
		movementEnabled = false;
		rotationEnabled = false;
		velocity.x = 0f;
		velocity.y = 0f;
	}
    
	public void SetRotationEnabled(bool b)
	{
		rotationEnabled = b;
	}
}
