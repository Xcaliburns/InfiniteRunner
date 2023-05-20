using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclePrefab;
    public float startDelay = 1.0f;
    public float reapeatRate = 3.0f;
    [SerializeField] float repeatRateMin = 1f;
    [SerializeField] float repeatRateMax = 3f;
    private Vector3 spawnPosition = new Vector3(50, 0, 0);
    private PlayerController playerControllerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        // InvokeRepeating("SpawnObstacle", startDelay, reapeatRate);
        StartCoroutine(SpawnObstacle());
    }

    // Update is called once per frame
    void Update()
    {

    }

   // void SpawnObstacle()
    //{   
    //    if (playerControllerScript.gameOver == false) {
      //      Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        //}
        
    //}
    IEnumerator SpawnObstacle()
    {
        while (playerControllerScript.gameOver == false)
        {
            yield return new WaitForSeconds(reapeatRate);
            reapeatRate = Random.Range(repeatRateMin, repeatRateMax);
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}
