using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float EnginePower = 10f;
    public float TurnPower = 10f;

    [Header("Health")]
    public int HealthMax = 3;
    public int HealthCurrent;

    [Header("Bullets")]
    public GameObject BulletPreFab;
    public float BulletSpeed = 100f;
    public float FiringRate = 0.33f;
    private float fireTimer = 0f;

    [Header("Sound")]
    public SoundPlayer HitsSounds;

    [Header("UI")]
    public ScreenFlash Flash;
    public ScreenShake Shake;
    public GameOverUI GameOverUI;

    [Header("Score")]
    public int Score;
    public int HighScore;

   


    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        HealthCurrent = HealthMax;
        HighScore = GetHighScore();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        ApplyThrust(vertical);
        ApplyTorque(horizontal);
        UpdateFiring();
    }

    private void UpdateFiring()
    {
        bool isFiring = Input.GetButton("Fire1");
        fireTimer -= Time.deltaTime;

        if (isFiring && fireTimer <= 0)
        {
            FireBullet();
            fireTimer = FiringRate;
        }
    }

    private void ApplyThrust(float amount)
    {
        Vector2 thrust = transform.up * EnginePower * Time.deltaTime * amount;
        rb2D.AddForce(thrust);
    }

    private void ApplyTorque(float amount)
    {
        float torque = amount * TurnPower * Time.deltaTime;
        rb2D.AddTorque(-torque);
    }

    public void TakeDamage(int damage)
    {
        HealthCurrent -= damage;
        HitsSounds.PlayRandomSound();

        StartCoroutine(Flash.FlashRoutine());

        if (HealthCurrent <= 0)
        {
            Explode();
        }
    }

    public void Explode()
    {
        //DieSounds.PlaySound(false);

        //Debug.Log("Game Over");
        GameOver();
        Destroy(gameObject);
    }

    public void FireBullet()
    {
        GameObject bullet = Instantiate(BulletPreFab, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 force = transform.up * BulletSpeed;
        rb.AddForce(force);
    }
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }
    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", Score);
    }

    public void GameOver()
    {
        bool celebrateHighScore = false;
        if(Score > GetHighScore() && celebrateHighScore == false)
        {
            SetHighScore(Score);
            celebrateHighScore = true;
        }
        GameOverUI.Show(celebrateHighScore, Score, GetHighScore());
    }

}