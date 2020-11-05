using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class TargetBoss : MonoBehaviour
{
	public float health = 20f;

	public Color defaut = Color.black;
	public Color degat = Color.red;
	private Renderer rend; 
	private float timer;
	public int currentHealth;
    public HealthBar healthBar;
    private float timeleft;
    private bool bossDead = false;
    //private int maxHealth = 20;

	void Start()
	{
		GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(false);
		rend = transform.GetComponent<Renderer>();
	}
	void Update()
	{
		if(timer >= 0)
		{	
			//Debug.Log("BG");
			rend.material.color = degat;
			timer -= Time.deltaTime;
		}
		else
		{
			rend.material.color = defaut;
		}

		if(bossDead)
		{
			timeleft -= Time.deltaTime;
			if(timeleft <= 0.0f)
			{
				GameOver();
			}
		}
	}

	public void TakeDamage(float amount)
	{
		timer = 0.5f;
		health -= amount;
		if(health <= 0f)
		{
			Die();
		}
		healthBar.SetHealth((int) health);
	}

	void Die()
	{
		bossDead = true;
		if(transform.parent != null)
		{
			GameObject.Find("Niveau5").transform.GetChild(10).GetComponent<BossAI>().killed = true;
			GameObject.Find("Niveau5").transform.GetChild(10).GetComponent<BossAI>().sightRange = 0.0f;
		}
		GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(true);
		timeleft = 3f;
	}
	
	private IEnumerator ExecuteAfterTime(float time)
 	{
     yield return new WaitForSeconds(time);
 
     GameOver();
 	}
	void GameOver()
	{
		Debug.Log("HEYEHYE");
		Application.Quit();
	}


}