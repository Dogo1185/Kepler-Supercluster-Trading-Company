using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionsSystem : MonoBehaviour
{
    public int zipzipium;
    public int mony;
    public SelectableObject selected;
    public SelectableObject active;
    public int costIncrease = 100;

    [SerializeField] private TextMeshProUGUI zipzipiumBallanceText;
    [SerializeField] private TextMeshProUGUI monyBallanceText;

    public List<SelectableObject> ownedStars;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (selected == null)
        {
            selected = active;
        }
    }

    // Update is called once per frame
    void Update()
    {
        monyBallanceText.text = mony.ToString();
        zipzipiumBallanceText.text = zipzipium.ToString();
    }

    public void Buy()
    {
        if (mony >= selected.starActions.starCost)
        {
            selected.owned = true;
            ownedStars.Add(selected);
            selected.gameObject.GetComponent<StarGen>().genStar();
            selected.Activate();
            active.DeselectMe();    
            mony -= selected.starActions.starCost;
        }
    }

    public void Sell()
    {
        if (selected.owned == false)
        {
            mony += zipzipium * selected.starActions.exchange;
            zipzipium = 0;
        }
    }

    public void MineAll()
    {
        foreach (SelectableObject o in ownedStars)
        {
            zipzipium += o.starActions.Mine();
        }
    }

    public void Upgrade()
    {
        if (mony >= active.starActions.upgradeCost)
        {
            mony -= active.starActions.upgradeCost;
            active.starActions.level += 1;
            active.starActions.mineAmount += 5;
            active.starActions.mineMulti += 1;
            active.starActions.upgradeCost = active.starActions.upgradeCost + costIncrease;
        }        
    }

    public void AutoUpgrade()
    {
        if(mony >= active.starActions.autoCost && !active.starActions.autoOn)
        {
            mony -= active.starActions.autoCost;
            active.starActions.autoOn = true;
        }
    }
}
