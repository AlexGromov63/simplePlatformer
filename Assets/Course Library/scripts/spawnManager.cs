using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public List<GameObject> prefabs;
    public Vector3 spawnPos = new Vector3(25, 0, 0);

    public float startDelay = 2;
    public float repeatRate = 2;
    public float liveTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", startDelay, repeatRate);
        Invoke("Destroy", liveTime);
    }
    void Spawn()
    {
        var go  = Instantiate(prefabs[0], spawnPos, prefabs[0].transform.rotation);
        Destroy(go, liveTime);

        var prfb = prefabs[0];
        prefabs.RemoveAt(0);
        prefabs.Add(prfb);
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
