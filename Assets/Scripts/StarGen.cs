using UnityEditor;
using UnityEngine;

public class StarGen : MonoBehaviour
{

    [SerializeField] private GameObject starPrefab;
    [SerializeField] private float range;
    [SerializeField] private float spawnAreaSize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void genStar()
    {
        Vector3 direction = transform.position.normalized;
        Vector3 spawnArea = direction * range + transform.position;
        GameObject s =
        Instantiate(starPrefab, new Vector3(Random.Range(-spawnAreaSize, spawnAreaSize), Random.Range(-spawnAreaSize, spawnAreaSize), Random.Range(-spawnAreaSize, spawnAreaSize)) + spawnArea, transform.rotation);
        s.GetComponent<SelectableObject>().owned = false;
        s.GetComponent<SelectableObject>().DeselectMe();
    }
}
