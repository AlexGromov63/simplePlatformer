using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public List<GameObject> prefabs;
    public Vector3 spawnPos = new Vector3(25, 0, 0);

    public float startDelay = 2;
    public float repeatRateMin = 1;
    public float repeatRateMax = 4;
    public float liveTime = 3;
    public float speedModifier = 1;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", startDelay);
        Invoke("Destroy", liveTime);
    }
    void Spawn()
    {
        var go  = Instantiate(prefabs[0], spawnPos, prefabs[0].transform.rotation);
        go.GetComponent<moveLeft>().speed *= speedModifier;
        Destroy(go, liveTime);
       
        var prfb = prefabs[0];
        prefabs.RemoveAt(0);
        prefabs.Add(prfb); 
        
        Invoke("Spawn", Random.RandomRange(repeatRateMin, repeatRateMax));
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
