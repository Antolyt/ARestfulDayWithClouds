 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteToCloud : MonoBehaviour {


    public Sprite spawnMask;
    public GameObject particleSystemCloud;
    public SpriteRenderer blendImage;
    public PolygonCollider2D colliderCloud;
    public int rate;
    public float size;
    public float driftSpeed;

	// Use this for initialization
	void Start () {
        blendImage.color = new Color(1f, 1f, 1f, 0);

        for (int i = 0; i < spawnMask.texture.height; i+= rate)
        {
            for (int j = 0; j < spawnMask.texture.width; j+= rate)
            {
                if(spawnMask.texture.GetPixel(i,j).a > 0.1f)
                {
                    //ParticleSystem e = new ParticleSystem();
                    GameObject e = GameObject.Instantiate<GameObject>(particleSystemCloud);
                    e.transform.parent = this.transform;
                    //e.transform.localPosition = new Vector3((i - spawnMask.texture.height / 2), j - spawnMask.texture.width / 2) * size + transform.position;
                    e.transform.position = new Vector3((i - spawnMask.texture.height / 2)*transform.localScale.x, (j - spawnMask.texture.width / 2)*transform.localScale.y) * size  + transform.position;
                    e.transform.localScale = transform.localScale;
                }
            }
        }
        Quaternion quad = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward);
        transform.rotation = (quad);
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(this.transform.position.x + driftSpeed, this.transform.position.y, this.transform.position.z);
	}
}
