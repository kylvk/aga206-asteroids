using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] AsteroidRefs; // john to spawn
    public float CheckInterval = 3f; // interv of time to check if can spawn
    public float PushForce = 100f; // the force to push john
    public float SpawnThreshold = 10; // the limit of the ast we can spawn
    private float checkTimer = 0f;
    public float Inaccuracy = 2f;

    void Start()
    {
        Debug.Log(TotalAsteroidValue());
    }

    private void Update()
    {
        checkTimer += Time.deltaTime;
        if (checkTimer > CheckInterval)
        {
            checkTimer = 0f;

            if (TotalAsteroidValue() < SpawnThreshold)
            {
                SpawnAsteroid();
            }
        }
    }
    private void SpawnAsteroid()
    {
        int asteroidIndex = Random.Range(0, AsteroidRefs.Length);
        GameObject asteroidRef = AsteroidRefs[asteroidIndex];

        // find random spawn point
        Vector3 spawnPoint = RandomOffscreenPoint();
        spawnPoint.z = transform.position.z;

        //spawn the john
        GameObject asteroid = Instantiate(asteroidRef, spawnPoint, transform.rotation);

        //push the john
        Vector2 force = PushDirection(spawnPoint) * PushForce;
        Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
        rb.AddForce(force);
    }

    private Vector3 RandomOffscreenPoint()
    {
        Vector2 randomPos = Random.insideUnitCircle;
        Vector2 direction = randomPos.normalized;
        Vector2 finalPos = (Vector2)transform.position + direction * 2f;

        return Camera.main.ViewportToWorldPoint(finalPos);
    }




    public int TotalAsteroidValue()
    {
        Asteroid[] asteroids = FindObjectsByType<Asteroid>(FindObjectsSortMode.None);
        int value = 0;
        for (int i = 0; i < asteroids.Length; i++)
        {
            value += asteroids[i].SpawnValue;

        }
        return value;

    }

    private Vector2 PushDirection(Vector2 from)
    {
        Vector2 miss = Random.insideUnitCircle * Inaccuracy;
        Vector2 destination = (Vector2)transform.position + miss;
        Vector2 direction = (destination - from).normalized;

        return direction;
    }
}