using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickKontrol : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Image joystickBackGround;
    public Image joystick;

    public Vector2 kordinat2;
    public Vector3 kordinat3;

    void start()
    {
        joystickBackGround = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }


    public void OnDrag(PointerEventData eventData)
    {
        kordinat2 = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackGround.rectTransform, eventData.position, eventData.pressEventCamera, out kordinat2))
        {
            kordinat2.x = (kordinat2.x / joystickBackGround.rectTransform.sizeDelta.x);
            kordinat2.y = (kordinat2.y / joystickBackGround.rectTransform.sizeDelta.y);

            float x = (joystickBackGround.rectTransform.pivot.x == 1) ? kordinat2.x * 2 + 1 : kordinat2.x * 2 - 1;
            float y = (joystickBackGround.rectTransform.pivot.y == 1) ? kordinat2.y * 2 + 1 : kordinat2.y * 2 - 1;

            kordinat3 = new Vector3(x, 0, y);
            kordinat3 = (kordinat3.magnitude > 1.0f) ? kordinat3.normalized : kordinat3;

            joystick.rectTransform.anchoredPosition = new Vector3(kordinat3.x * (joystickBackGround.rectTransform.sizeDelta.x / 2),
                                                                  kordinat3.z * (joystickBackGround.rectTransform.sizeDelta.x / 7));
        }
    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        kordinat3 = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;

    }

    public float Yatay()
    {
        return kordinat3.x;
    }
    public float Dikey()
    {
        return kordinat3.z;
    }
}
