using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject explosionFX;
    [SerializeField] private int points;
    [SerializeField] private int health;
    ScoreBehavior scoreBehavior;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        scoreBehavior = FindObjectOfType<ScoreBehavior>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        health--;
        if (health < 0 && !isDead)
        {
            isDead = true;
            GameObject explosion = Instantiate(explosionFX, transform.position, Quaternion.identity);
            explosion.transform.parent = parent;
            Destroy(this.gameObject);
            ScoreBehavior.Instance.IncreaseScore(points);
            //scoreBehavior.IncreaseScore(points);
        }

    }
}
