using UnityEngine;

public class CloudCollider : MonoBehaviour
{
    bool fadeIn;
    bool fadeOut;
    public float max = 1f;
    public float min = 0f;
    public float speed = 2.0f;
    public float thresholdFadeIn = 0.9f;
    public float thresholdFadeOut = 0.95f;
    public SpriteRenderer sprite;
    public Score score;

    void OnMouseDown()
    {
        // fade in if correct
        int chain = score.RateElement(this.transform.parent.name);
        if(chain > 0)
        {
            fadeIn = true;
            fadeOut = false;
        }
    }

    void Update()
    {
        float step = speed * Time.deltaTime;

        // fade in, if correct cloud is clicked
        if (fadeIn)
        {
            sprite.color = new Color(1f, 1f, 1f, Mathf.Lerp(sprite.color.a, max, step));
            if(sprite.color.a >= thresholdFadeIn)
            {
                fadeIn = false;
                fadeOut = true;
            }
        }

        // fade out after faded in
        if (fadeOut)
        {
            sprite.color = new Color(1f, 1f, 1f, Mathf.Lerp(sprite.color.a, min, step));
            if (sprite.color.a <= thresholdFadeOut)
            {
                sprite.color = new Color(1f, 1f, 1f, 0f);
                fadeOut = false;
            }
        }
    }
}
