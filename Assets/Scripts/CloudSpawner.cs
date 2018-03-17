using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    public Transform camera;
    public Transform destroyer;

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

    private void FixedUpdate()
    {
        camera.position = new Vector3(camera.position.x - cloudSpeed * Time.fixedDeltaTime, camera.position.y, camera.position.z);
        destroyer.position = new Vector3(destroyer.position.x - cloudSpeed * Time.fixedDeltaTime, destroyer.position.y, destroyer.position.z);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i].position = new Vector3(spawnPoints[i].position.x - cloudSpeed * Time.fixedDeltaTime, spawnPoints[i].position.y, spawnPoints[i].position.z);
        }
    }

    // Update is called once per frame
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

            timeStemp = Time.fixedTime;
        }
    }
}
