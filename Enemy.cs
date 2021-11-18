using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem ps_explosion;
    public AudioSource sd_explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPartcleCollision(GameObject other)
    {
        ps_explosion.Play();
        sd_explosion.Play();
        Destroy(gameObject, 2f);
    }
}
