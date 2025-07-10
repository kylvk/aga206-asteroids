using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float EnginePower = 10f;
    public float TurnPower = 20f;

    private Rigidbody2D rb2D;



    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        
    }



    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        ApplyThrust(vertical);
        ApplyTorque(horizontal);


    }
    [Header("Sound")]
    public SoundPlayer HitSounds;


    public void TakeDamage(int damage)
    {
        HealthCurrent = HealthCurrent - damage;


    }
    HitSounds.PlaySound();

    private void ApplyThrust(float amount)

    {
        //Debug.Log("Thrust amount is " + amount);

        Vector2 thrust = transform.up * EnginePower * Time.deltaTime * amount;
        rb2D.AddForce(thrust);

    }
    private void ApplyTorque(float amount)
    {
        float torque = amount * TurnPower * Time.deltaTime;
        rb2D.AddTorque(-torque);
    }

}
