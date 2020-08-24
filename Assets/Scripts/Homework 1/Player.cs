using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallMotor))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 1;
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    [SerializeField]
    private int treasure = 0;
    public int Treasure { get => treasure; set => treasure = value; }
    [SerializeField]
    private UnityEngine.UI.Text treasureText;
    [SerializeField]
    private UnityEngine.UI.Text powerUpsText;
    [SerializeField]
    private UnityEngine.UI.Text healthText;

    [SerializeField]
    private List<PowerUpBase> powerUps = new List<PowerUpBase>();
    public bool AddPowerUp(PowerUpBase power)
    {
        foreach (PowerUpBase p in powerUps)
            if (p.GetType() == power.GetType())
            {
                p.duration = power.duration;
                return false;
            }
        powerUps.Add(power);
        return true;
    }
    public bool immune = false;

    public BallMotor motor;

    public int currentHealth;

    private void Start()
    {
        motor = GetComponent<BallMotor>();
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        ProcessMovement();
        ProcessPowerUps();
    }

    private void Update()
    {
        UpdateGUI();
    }

    private void ProcessPowerUps()
    {
        for(int i = 0; i < powerUps.Count; i++)
        {
            powerUps[i].duration -= Time.fixedDeltaTime;
            if (powerUps[i].duration <= 0) powerUps[i].PowerDown(this);
        }
        powerUps.RemoveAll(x => x.duration <= 0);
    }

    private void UpdateGUI()
    {
        if(treasureText)
            treasureText.text = "Treasure: "+treasure;
        if (powerUpsText)
        {
            string text = "";
            foreach (PowerUpBase p in powerUps)
                text += "\n" + p.GetType().Name + ": " + (int)p.duration + "s";
            powerUpsText.text = "Power Ups: "+text;
        }
            
        if (healthText)
            healthText.text = "Health: " + currentHealth+"/"+maxHealth;
    }

    private void ProcessMovement()
    {
        //TODO move into Input script
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        motor.Move(movement);
    }

    public void AdjustHealth(int amount)
    {
        if (immune && amount < 0) return;
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log("Current Health: " + currentHealth);
        if (currentHealth == 0) Die();
    }

    public void Die()
    {
        if (immune) return; 
        gameObject.SetActive(false);
    }
}
