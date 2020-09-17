using UnityEngine;

namespace Player {
  public class PlayerController : MonoBehaviour {
    public Animator animator;
    public float PlayerSpeed = 0.25f;
    public Vector2 MoveVelocity;
    public int Direction;//0-вниз 1-вверх 2-вправо 3-влево
    public MobileController MobController;
    
    private int _height;
    private SpriteRenderer _spriteRenderer;
    private AudioSource _soundOfRun;
    private Rigidbody2D _rigidBody;
    private float _dirX;
    private float _dirY;
    private GameObject _bullet;
    public void Start() {
      _height = GameObject.Find("ParametersManager").GetComponent
        <Menu.ParameterManager>().MapSizeVector.y;
      _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
      _soundOfRun = GameObject.Find("RunSound").GetComponent<AudioSource>();
      animator = GetComponent<Animator>();
      MobController = GameObject.Find("JoystickBG").GetComponent<MobileController>();
      Debug.Log("Controller is initialized");
      _rigidBody = GetComponent<Rigidbody2D>();
      GetComponent<Animator>();
    }

    public void Update() {
      if (MobController.GetXJoystickPos() > 0.9) {
        Direction = 2;
        animator.Play("Move_right");
      } else if (MobController.GetXJoystickPos() < -0.9) {
        Direction = 3;
        animator.Play("Move_left");
      } else {
        if (MobController.GetYJoystickPos() > 0) {
          Direction = 1;
          animator.Play("Move_back");
        } else if (MobController.GetYJoystickPos() < 0) {
          Direction = 0;
          animator.Play("Move_face");
        } else {
          switch (Direction) {
            case 0:
              animator.Play("Idle_face");
              break;
            case 1 :
              animator.Play("Idle_back");
              break;
            case 2:
              animator.Play("Idle_right");
              break;
            case 3:
              animator.Play("Idle_left");
              break;
          }
        }
      }
        
      _dirX = MobController.GetXJoystickPos();
      _dirY = MobController.GetYJoystickPos();
      var moveInput = new Vector2(_dirX, _dirY);
      MoveVelocity = moveInput * PlayerSpeed;
      if (_dirX == 0 && _dirY == 0) {
        _soundOfRun.Stop();
      } else {
        if (!_soundOfRun.isPlaying) {
          _soundOfRun.Play();
        }
      }
    }

    public void FixedUpdate() {
      _rigidBody.MovePosition(_rigidBody.position + MoveVelocity);
      _spriteRenderer.sortingOrder = _height / 2 - (int)gameObject.transform.position.y + 1;
    }
  }
}
