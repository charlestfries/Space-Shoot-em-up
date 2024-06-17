using UnityEngine;
// Enemy that changes direction sporadically
public class Enemy_5 : Enemy
{
    [Header("Set in Inspector: Enemy_5")]
    public float changeDirectionTime = 2f; // How often enemy changes direction
    public float maxSpeed = 5f; // Enemy max speed

    private Vector3 direction; // Enemy current movement direction
    private float timeSinceLastChange; // Timer for next direction change

    void Start()
    {
        ChangeDirection(); // Start random direction movement
    }

    public override void Move()
    {
        MoveSporadically();

        // Change direction if needed
        if (Time.time - timeSinceLastChange > changeDirectionTime)
        {
            ChangeDirection();
        }

        if (showingDamage && Time.time > damageDoneTime)
        {
            HideDamage();
        }
    }

    void MoveSporadically()
    {
        transform.position += direction * maxSpeed * Time.deltaTime; // Update enemy's position
    }

    void ChangeDirection()
    {
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        timeSinceLastChange = Time.time;
    }

    // Mimic UnShowDamage
    void HideDamage()
    {
        if (materials != null && originalColors != null)
        {
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i].color = originalColors[i];
            }
        }
        showingDamage = false;
    }
}