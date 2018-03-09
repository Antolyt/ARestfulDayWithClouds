 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteToCloud : MonoBehaviour {


    public Sprite sprite;
    public GameObject particleSystem;
    public int rate;
    public float size;
    //ParticleSystem e;
	// Use this for initialization
	void Start () {

        for(int i = 0; i < sprite.texture.height; i+= rate)
        {
            for (int j = 0; j < sprite.texture.width; j+= rate)
            {
                if(sprite.texture.GetPixel(i,j).a > 0.1f)
                {
                    //ParticleSystem e = new ParticleSystem();
                    GameObject e = GameObject.Instantiate<GameObject>(particleSystem);
                    e.transform.position = new Vector3((i - sprite.texture.height/2), j - sprite.texture.width/2)*size;
                    e.transform.parent = this.transform;
                }
            }
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(this.transform.position.x + 0.01f, 0, 0);
	}
}
