using UnityEngine;
using TMPro;

public class StarActions : MonoBehaviour
{
    public string starName;
    public int starCost;
    public int exchange = 2;
    public int level = 1;
    public int mineAmount = 1;
    public int mineMulti = 1;
    public int upgradeCost = 100;
    public int production;
    public bool autoOn;
    public int autoCost;

    [SerializeField] private TextMeshProUGUI namePlate;
    private float timer;
    private SelectableObject selectable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selectable = GetComponent<SelectableObject>();
        namePlate.text = starName;
        timer = 0;
        autoOn = false;
        starCost = selectable.actionsSystem.ownedStars.Count * 1000;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        production = mineAmount;
        if (timer >= 1)
        {
            if (autoOn)
            {
                selectable.actionsSystem.zipzipium += Mine();
            }
            timer = 0;
        }
    }

    public int Mine()
    {
        return mineAmount;
    }
}
