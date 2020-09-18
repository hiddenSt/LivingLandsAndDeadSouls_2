using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobileController : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    public void Start()
    {
        joystickBackGround = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle
            (joystickBackGround.rectTransform,ped.position,ped.pressEventCamera,
            out pos))
        {
            pos.x = (pos.x/joystickBackGround.rectTransform.sizeDelta.x);
            pos.y = (pos.y/joystickBackGround.rectTransform.sizeDelta.x);

            inputVector = new Vector2(pos.x*2, pos.y*2);
            inputVector = ( inputVector.magnitude>1.0f ) ? 
                inputVector.normalized : inputVector;

            joystick.rectTransform.anchoredPosition = new Vector2
                (inputVector.x*(joystickBackGround.rectTransform.sizeDelta.x/2), 
                inputVector.y*(joystickBackGround.rectTransform.sizeDelta.y/2));
        }
    }

    public float Horizontal()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (inputVector.y != 0)
            return inputVector.y;
        else
            return Input.GetAxis("Vertical");
    }
    private Image joystickBackGround;
    [SerializeField]
    private Image joystick;
    private Vector2 inputVector;
}
