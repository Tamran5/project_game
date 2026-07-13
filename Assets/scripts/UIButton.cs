using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public KontrolTrukWheel target;
    public string inputType; // "move" atau "steer"
    public float valueDown = 1f;

    private Image buttonImage;
    private Color normalColor;
    public Color highlightColor = new Color(1f, 1f, 0f, 0.8f);

    void Start()
    {
        buttonImage = GetComponent<Image>();
        if (buttonImage != null)
            normalColor = buttonImage.color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SetInput(valueDown);
        SetHighlight(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        SetInput(0);
        SetHighlight(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetHighlight(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetInput(0);
        SetHighlight(false);
    }

    void SetInput(float val)
    {
        if (target == null) return;
        if (inputType == "move") target.MoveInput(val);
        else target.SteerInput(val);
    }

    void SetHighlight(bool aktif)
    {
        if (buttonImage == null) return;
        buttonImage.color = aktif ? highlightColor : normalColor;
    }
}