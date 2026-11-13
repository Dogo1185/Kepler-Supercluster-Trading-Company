using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject selectionMarker;
    [SerializeField] private GameObject activeMarker;
    private CinemachineCamera camera;
    public ActionsSystem actionsSystem;
    public StarActions starActions;

    public bool owned;

    private void Awake()
    {
        camera = GameObject.Find("OrbitCamera").GetComponent<CinemachineCamera>();
        actionsSystem = GameObject.Find("ActionsSystem").GetComponent<ActionsSystem>();
        starActions = GetComponent<StarActions>();

        if (owned)
        {
            Activate();
            actionsSystem.ownedStars.Add(this);
        }
    }

    public void SelectMe()
    {
        SelectableObject[] stars = GameObject.FindObjectsByType<SelectableObject>(FindObjectsSortMode.None);
        foreach (SelectableObject star in stars)
        {
            if (star != this)
            {
                star.DeselectMe();
            }
        }

        selectionMarker.SetActive(true);
        actionsSystem.selected = this;
    }

    public void DeselectMe()
    {
        selectionMarker.SetActive(false);
    }

    public void Activate()
    {
        SelectableObject[] stars = GameObject.FindObjectsByType<SelectableObject>(FindObjectsSortMode.None);
        foreach (SelectableObject star in stars)
        {
            if (star != this)
            {
                star.Deactivate();
            }
        }

        activeMarker.SetActive(true);
        camera.Follow = transform;
        actionsSystem.active = this;
    }

    public void Deactivate()
    {
        activeMarker.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (owned)
        {
            Activate();
        }
        else
        {
            SelectMe();
        }
    }
}
