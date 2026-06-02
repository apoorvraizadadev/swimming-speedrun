using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingController : MonoBehaviour
{
    public Camera main => Camera.main;
    public Rigidbody2D rb => GetComponent<Rigidbody2D>();
    public SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();

    public AnimationCurve acceleration;
    public float speed;
    public float time = 0;
    public float accelerationSpeed;
    public float distanceThreshold;
    public float timeThreshold = 0.4f;

    public bool isInvincible;
    public float invincibleTime = 5f;
    public float invincibleEffectSpeed;
    public float invincibleEffectTime;

    Vector2 mouse;
    public Vector2 lastInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouse = (Vector2)main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            lastInput = mouse;
            time += accelerationSpeed * Time.deltaTime;
        }

        else
        {
            time -= accelerationSpeed * Time.deltaTime * 2;
        }
        time = Mathf.Clamp(time, 0, 0.8f);
        if (time > timeThreshold && Vector2.Distance(mouse, (Vector2)transform.position) < distanceThreshold)
        {
            if (Input.GetMouseButton(0))
            {
                transform.position = mouse;
            }

            else
            {
                transform.position = lastInput;
            }
        }

        else
        {
            if (Input.GetMouseButton(0))
            {
                rb.velocity = ((Vector3)(mouse - (Vector2)transform.position).normalized) * acceleration.Evaluate(time) * speed;
                if (Vector2.Distance(mouse, (Vector2)transform.position) > distanceThreshold)
                {
                    transform.right = (mouse - (Vector2)transform.position).normalized;
                }
            }

            else
            {
                rb.velocity = ((Vector3)(lastInput - (Vector2)transform.position).normalized) * acceleration.Evaluate(time) * speed;
                if (Vector2.Distance(lastInput, (Vector2)transform.position) > distanceThreshold)
                {
                    transform.right = (lastInput - (Vector2)transform.position).normalized;
                }
            }
        }
        if (isInvincible)
        {
            invincibleEffectTime += invincibleEffectSpeed * Time.deltaTime;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Mathf.PingPong(invincibleEffectTime, 1));
        }
    }

    public IEnumerator Invincible()
    {
        invincibleEffectTime = 0;
        isInvincible = true;

        yield return new WaitForSeconds(invincibleTime);

        isInvincible = false;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
    }

    public void FlipFish()
    {
        //print(transform.eulerAngles.z);
        if (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 270)
        {
            spriteRenderer.flipX = true;
        }

        else
        {
            spriteRenderer.flipX = true;
        }
    }
}
