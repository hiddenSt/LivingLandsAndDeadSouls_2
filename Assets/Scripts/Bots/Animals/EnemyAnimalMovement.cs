using HealthFight;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Animals {
  public class EnemyAnimalMovement : MonoBehaviour {
    private void Start() {
      _myRigidBody = GetComponent<Rigidbody2D>();
      _animator = GetComponent<Animator>();
      _waitCounter = waitTime;
      _walkCounter = waitTime;
      _playerHealthComponent = GameObject.Find("Player").GetComponent<HealthComponent>();
    }

    private void Update() {
      if (_isAttacking) {
        if (_attackDelay <= 0) {
          _playerHealthComponent.DecreaseHealth(damage);
          _attackDelay = 1f;
        }

        _attackDelay -= Time.deltaTime;
        return;
      }

      if (isWalking) {
        var a = Random.Range(-1.0f, 1.0f);
        _walkCounter -= Time.deltaTime;
        switch (_walkDirection) {
          case 0:
            _myRigidBody.velocity = new Vector2(-moveSpeed, a);
            _animator.Play("Move_left");
            break;
          case 1:
            _myRigidBody.velocity = new Vector2(moveSpeed, a);
            _animator.Play("Move_right");
            break;
        }

        if (!(_walkCounter < 0)) return;

        isWalking = false;
        _waitCounter = waitTime;
        switch (_walkDirection) {
          case 0:
            _animator.Play("Idle_left");
            break;
          case 1:
            _animator.Play("Idle_right");
            break;
        }
      }
      else {
        _waitCounter -= Time.deltaTime;
        _myRigidBody.velocity = Vector2.zero;
        if (_waitCounter < 0)
          ChoseDirection();
      }
    }

    private void ChoseDirection() {
      _walkDirection = Random.Range(0, 2);
      isWalking = true;
      _walkCounter = waitTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
      if (other.name == "Player") {
        _attackDelay = 1f;
        _isAttacking = true;
        _moveVelocity = _myRigidBody.velocity;
        _myRigidBody.velocity = new Vector2(0, 0);
        if (other.transform.position.x > transform.position.x)
          _animator.Play("Attack_right");
        else
          _animator.Play("Attack_left");
        other.GetComponent<HealthComponent>().DecreaseHealth(damage);
        return;
      }

      if (other.GetComponent<DamageComponent>() != null)
        return;
      switch (_walkDirection) {
        case 0:
          _walkDirection = 1;
          break;
        case 1:
          _walkDirection = 0;
          break;
      }

      if (isWalking != false) return;
      isWalking = true;
      _waitCounter = 0;
      _walkCounter = waitTime;
    }

    private void OnTriggerExit2D(Collider2D other) {
      if (other.name == "Player") {
        _isAttacking = false;
        _myRigidBody.velocity = _moveVelocity;
      }
    }


    //data members
    public float moveSpeed;
    public float waitTime;
    public bool isWalking;
    public int damage;

    private Rigidbody2D _myRigidBody;
    private Animator _animator;
    private float _walkCounter;
    private float _waitCounter;
    private int _walkDirection;
    private Vector2 _moveVelocity;
    private bool _isAttacking;
    private HealthComponent _playerHealthComponent;
    private float _attackDelay = 1f;
  }
}