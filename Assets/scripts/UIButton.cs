using UnityEngine;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public KontrolTrukWheel target;
    public string inputType; // "move" atau "steer"
    public float valueDown = 1f;

    public void OnPointerDown(PointerEventData eventData)
    {
        SetInput(valueDown);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        SetInput(0);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetInput(valueDown); // Hover = langsung aktif
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetInput(0);
    }

    void SetInput(float val)
    {
        if (target == null) return;
        if (inputType == "move") target.MoveInput(val);
        else target.SteerInput(val);
    }
}