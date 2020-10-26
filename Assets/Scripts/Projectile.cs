using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject projectilesParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";
    [Range(1f, 15f)] [SerializeField] float speed = 4;
    [SerializeField] float damage = 50f;


    private void Start()
    {
        CreateProjectilesParent();
    }

    private void CreateProjectilesParent()
    {
        projectilesParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectilesParent)
        {
            projectilesParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        
        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }

    }

}
