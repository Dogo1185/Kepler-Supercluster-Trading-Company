using UnityEngine;
using TMPro;

public class InfoPanelManager : MonoBehaviour
{
    [SerializeField] private ActionsSystem actionsSystem;
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private TextMeshProUGUI upCost;
    [SerializeField] private TextMeshProUGUI production;
    [SerializeField] private TextMeshProUGUI auto;
    [SerializeField] private TextMeshProUGUI autoCost;
    [SerializeField] private TextMeshProUGUI exchange;
    [SerializeField] private TextMeshProUGUI starCost;
    [SerializeField] private TextMeshProUGUI activeName;
    [SerializeField] private TextMeshProUGUI selectName;

    [SerializeField] private GameObject selectedPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!actionsSystem.selected)
            return;
        if (actionsSystem.selected.owned == true)
        {
            selectedPanel.SetActive(false);
        }
        else
        {
            selectedPanel.SetActive(true);
        }
        activeName.text = actionsSystem.active.starActions.starName;
        level.text = actionsSystem.active.starActions.level.ToString();
        upCost.text = actionsSystem.active.starActions.upgradeCost.ToString();
        production.text = actionsSystem.active.starActions.production.ToString();
        auto.text = actionsSystem.active.starActions.autoOn.ToString();
        autoCost.text = actionsSystem.active.starActions.autoCost.ToString();

        selectName.text = actionsSystem.selected.starActions.starName;
        exchange.text = actionsSystem.selected.starActions.exchange.ToString();
        starCost.text = actionsSystem.selected.starActions.starCost.ToString();
    }
}
