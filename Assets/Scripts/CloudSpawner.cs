using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject[] cloudVariants;

    public float cloudSpeed;
    public float spawnOffset;
    private int currentSpawnPoint;

    float timeStemp;

    // Update is called once per frame
    void Update () {

        if(Time.fixedTime > timeStemp + spawnOffset)
        {
            int random = Mathf.RoundToInt(Random.Range(0, cloudVariants.Length));
            GameObject cloud = GameObject.Instantiate<GameObject>(cloudVariants[random]);
            cloud.name = cloudVariants[random].name.Split('_')[1];
            cloud.transform.parent = this.transform;
            cloud.transform.position = spawnPoints[currentSpawnPoint].position;
            cloud.transform.localScale = cloud.transform.localScale + new Vector3(0.1f, 0.1f) * Random.Range(-1,2);
            //cloud.transform.Rotate(this.transform.rotation.eulerAngles);
            currentSpawnPoint = (currentSpawnPoint + 1) % spawnPoints.Length;
            SpriteToCloud sTC = cloud.GetComponent<SpriteToCloud>();
            sTC.driftSpeed = cloudSpeed;

            timeStemp = Time.fixedTime;
        }
    }
}
