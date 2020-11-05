using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerScript: MonoBehaviour
{
    public CharacterController controller;
    public Transform Player;
    public float speed = 10f;
    public float gravity = -10f;
    public float jumpHeight = 5f;
    public int currentHealth;
    public HealthBar healthBar;
    private int maxHealth = 5;
    public bool checkPointedLevel4 = false;
    public Transform respawnlvl4, respawnlvl4CP;
    public bool haveFallenLvl4 = false;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool tookAHit = false;
    public bool tookAHealing = false;
    public bool goingToBoss = false;
    public Transform spawningBossRoom;
    Vector3 velocity;
    bool isGrounded;
    void Start()
    {
        GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(false);
        currentHealth = maxHealth; 
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(tookAHit)
        {
            TakeDamage(1);
            tookAHit = false;
        }
        if(tookAHealing)//Colide with heart
        {
            Healing(maxHealth - currentHealth);
            tookAHealing = false;
        }
        if(currentHealth == 0)
        {
            Die();
        }
        if(haveFallenLvl4)//Collide with KillingFloor
        {
            if(checkPointedLevel4)
            {
                FallLvlCP4();
            }
            else
            {
                FallLvl4();
            }
            haveFallenLvl4 = false;
        }
        if(goingToBoss)
        {
            goToBossRoom();
            goingToBoss = false;
        }

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
        {   
            currentHealth = 0;
        }
        healthBar.SetHealth(currentHealth);
    }

    void Healing(int healing)
    {
        if(currentHealth<maxHealth)
        {
            currentHealth += healing;

            healthBar.SetHealth(currentHealth);
        }
    }
    void Die()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }

    void FallLvl4()
    {
        TakeDamage(1);
        Player.transform.position = respawnlvl4.transform.position;
    }
    void FallLvlCP4()
    {
        TakeDamage(1);
        Player.transform.position = respawnlvl4CP.transform.position;
    }
    void goToBossRoom()
    {
        Player.transform.position = spawningBossRoom.transform.position;
        GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(true);
    }
}
