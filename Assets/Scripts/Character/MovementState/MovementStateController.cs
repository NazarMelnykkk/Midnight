using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateController : MonoBehaviour, ICommandHandler
{
    [Header("Components")]
    [SerializeField] private CharacterController _controller;
    public CharacterAnimationController Animator;

    private Command _command;

    [Header("Move Configuration")]
    [HideInInspector] public float CurrentMoveSpeed = 3f;
    [HideInInspector] public float WalkSpeed = 1f;
    [HideInInspector] public float RunSpeed = 3f;

    [HideInInspector] public float HorizontalDirection, VerticalDirection;
    [HideInInspector] public Vector3 Direction;

    [Header("Gravity Configuration")]
    [SerializeField] private float _groundYOffset;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _gravity = -9.81f;

    private Vector3 _velocity;
    private Vector3 _spherePos;

    [Header("States")]
    private MovementBaseState currentState;

    public IdleState Idle = new IdleState();
    public WalkState Walk = new WalkState();
    public JumpState Jump = new JumpState();
    public RunState Run = new RunState();

    public bool IsRunning = false;
    public bool IsJumping = false;

    public void ProcessCommand(Command command)
    {
        _command = command;
        Move();

    }

    private void Start()
    {
        SwitchState(Idle);
    }

    private void Update()
    {
        Gravity();

        currentState.UpdateState(this);
    }

    public void SwitchState(MovementBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    private void Move()
    {
        HorizontalDirection = _command.Direction.x;
        VerticalDirection = _command.Direction.y;

        Direction = transform.forward * VerticalDirection + transform.right * HorizontalDirection;

        _controller.Move(Direction.normalized * CurrentMoveSpeed * Time.deltaTime);

        Animator.Horizontal(HorizontalDirection);
        Animator.Vertical(VerticalDirection);

        if (_command.Direction == Vector2.zero)
        {
            _command.IsComplete = true;
            return;
        }

    }

    private bool IsGrounded()
    {
        _spherePos = new Vector3(transform.position.x, transform.position.y - _groundYOffset, transform.position.z);

        if (Physics.CheckSphere(_spherePos, _controller.radius - 0.05f, _groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Gravity()
    {
        if(IsGrounded() == false)
        {
            _velocity.y += _gravity * Time.deltaTime;
        }
        else if(_velocity.y < 0)
        {
            _velocity.y = -2;
        }

        _controller.Move(_velocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_spherePos, _controller.radius - 0.05f);
    }

}
