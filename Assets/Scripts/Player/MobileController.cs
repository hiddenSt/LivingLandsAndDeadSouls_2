using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Player {
  public class MobileController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
    private Image _joystickBackGround;
    [SerializeField]
    private Image joystick;
    private Vector2 _inputVector;
    
    public void Start() { 
      _joystickBackGround = GetComponent<Image>();
      joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData pointerEventData) {
      OnDrag(pointerEventData);
    }

    public void OnPointerUp(PointerEventData pointerEventData) {
      _inputVector = Vector2.zero;
      joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnDrag(PointerEventData ped) {
      Vector2 pos;
      if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBackGround.rectTransform,
        ped.position,ped.pressEventCamera, out pos)) {
        pos.x = (pos.x/_joystickBackGround.rectTransform.sizeDelta.x);
        pos.y = (pos.y/_joystickBackGround.rectTransform.sizeDelta.x);
        _inputVector = new Vector2(pos.x*2, pos.y*2);
        _inputVector = ( _inputVector.magnitude>1.0f ) ? _inputVector.normalized : _inputVector;
        joystick.rectTransform.anchoredPosition = new Vector2
        (_inputVector.x*(_joystickBackGround.rectTransform.sizeDelta.x/2), 
          _inputVector.y*(_joystickBackGround.rectTransform.sizeDelta.y/2));
      }
    }

    public float GetXJoystickPos() {
      return _inputVector.x != 0 ? _inputVector.x : Input.GetAxis("Horizontal");
    }

    public float GetYJoystickPos() {
      return _inputVector.y != 0 ? _inputVector.y : Input.GetAxis("Vertical");
    }
  }
}
