using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public Transform cloudTypes;
    public GameObject[] cloudVariants;

    public float cloudSpeed;
    public float spawnOffset;
    private int currentSpawnPoint;

    public Transform spawnedCloudsParent;

    float timeStemp;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    /// <summary>
    /// Spawn Clouds every spawnOffset on next spawnPoint
    /// </summary>
    void Update () {

        if(Time.fixedTime > timeStemp + spawnOffset)
        {
            int random = Mathf.RoundToInt(Random.Range(0, cloudVariants.Length));
            GameObject cloud = GameObject.Instantiate<GameObject>(cloudVariants[random]);
            cloud.name = cloudVariants[random].name.Split('_')[1];
            cloud.transform.parent = spawnedCloudsParent;
            cloud.transform.position = spawnPoints[currentSpawnPoint].position;
            cloud.transform.localScale = cloud.transform.localScale + new Vector3(0.1f, 0.1f) * Random.Range(-1,2);
            currentSpawnPoint = (currentSpawnPoint + 1) % spawnPoints.Length;
            SpriteToCloud sTC = cloud.GetComponent<SpriteToCloud>();
            sTC.cloudSpeed = this.cloudSpeed;

            timeStemp = Time.fixedTime;
        }
    }
}
