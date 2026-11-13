using UnityEngine;
using UnityEngine.EventSystems;

public class RaycastRouter : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Camera targetCamera;
    [SerializeField] private RectTransform rawImageRect;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (targetCamera == null) return;

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rawImageRect, eventData.position, eventData.pressEventCamera, out localPoint);

        float normalizedX = (localPoint.x - rawImageRect.rect.x) / rawImageRect.rect.width;
        float normalizedY = (localPoint.y - rawImageRect.rect.y) / rawImageRect.rect.height;

        float targetX = normalizedX * targetCamera.pixelWidth;
        float targetY = normalizedY * targetCamera.pixelHeight;
        Vector2 virtualScreenPos = new Vector2(targetX, targetY);

        Ray ray = targetCamera.ScreenPointToRay(virtualScreenPos);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.GetComponent<SelectableObject>())
            {    
                PointerEventData simulatedData = new PointerEventData(EventSystem.current);
                simulatedData.position = virtualScreenPos;

                hit.transform.GetComponent<SelectableObject>().OnPointerClick(simulatedData);
            }
        }
    }
}
