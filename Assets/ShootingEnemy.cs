using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public GameObject projectile;
    public float proximity;
    public Transform player => GameObject.Find("Player").transform;
    public bool firing;
    public float fireTime;
    public float fireSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.position, transform.position) < proximity && !firing)
        {
            firing = true;
            GameObject projectileObj = Instantiate(projectile);
            projectileObj.transform.position = transform.position;
            projectileObj.GetComponent<Projectile>().direction = player.position - transform.position;
            projectileObj.GetComponent<Projectile>().speed = fireSpeed;
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(fireTime);
        firing = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, proximity);
    }
}
