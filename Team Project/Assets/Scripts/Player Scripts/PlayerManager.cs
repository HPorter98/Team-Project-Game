using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [Header("Player Attributes")]
    [SerializeField] protected float startingHealth = 100f;
    [SerializeField] protected float startingMana = 100f;
    [SerializeField] protected float startingStamina = 100f;
    [SerializeField] protected float attackDamage = 25f;
    [SerializeField] protected Transform attackPos;
    [SerializeField] protected float attackRange = 1;
    [SerializeField] protected LayerMask whatIsEnemy;

    [Header("Cooldowns")]
    [SerializeField] protected float sprintCooldown = 0.0f;
    

    [Header("Canvas")]
    public TMPro.TextMeshProUGUI textHealth;
    public TMPro.TextMeshProUGUI textStamina;
    public TMPro.TextMeshProUGUI textMana;

    static float health = 0.0f;
    static float mana = 0.0f;
    static float stamina = 0.0f;

    private bool isSpriting;

    // Start is called before the first frame update
    void Start()
    {
        if(health == 0.0f && stamina == 0.0f && mana == 0.0f)
        {
            health = startingHealth;
            stamina = startingStamina;
            mana = startingMana;
        }
        textHealth.text = health.ToString();
        textStamina.text = stamina.ToString();
        textMana.text = mana.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float attackDamage;
        if (collision.transform.tag == "Enemy")
        {
            attackDamage = collision.transform.GetComponent<EnemyManager>().Attack();
            health -= attackDamage;
            textHealth.text = health.ToString();

            if (health <= 0)
            {
                textHealth.text = "You Died";
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Potion")
        {
            if(health < 100f)
            {
                health += collision.transform.GetComponent<PickUp>().healthValue;
                if (health > 100f)
                {
                    health = 100f;
                    textHealth.text = health.ToString();
                }
                textHealth.text = health.ToString();
            }
            Destroy(collision.gameObject);
        }
    }

    public float ReturnStamina()
    {
        return stamina;
    }

    public void Attack()
    {
        Debug.Log("Attack!");
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemyManager>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
