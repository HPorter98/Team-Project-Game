using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    [SerializeField] protected float cooldown = 0.0f;
    

    [Header("Canvas")]
    public TMPro.TextMeshProUGUI textHealth;
    public TMPro.TextMeshProUGUI textStamina;
    public TMPro.TextMeshProUGUI textMana;

    public Image imgArmour;
    public Image imgBoots;
    public Image imgDamage;

    static float health = 0.0f;
    static float mana = 0.0f;
    static float stamina = 0.0f;

    private bool speedBoost;

    private float speed;
    private float startingCooldown;
    private float damageResistance;

    private PlayerMovement playerMove;

    // Start is called before the first frame update
    void Start()
    {
        if(health <= 0.0f && stamina <= 0.0f && mana <= 0.0f)
        {
            health = startingHealth;
            stamina = startingStamina;
            mana = startingMana;
        }

        textHealth.text = health.ToString();
        textStamina.text = stamina.ToString();
        textMana.text = mana.ToString();

        playerMove = GetComponent<PlayerMovement>();

        startingCooldown = cooldown;
        imgDamage.enabled = false;
        imgBoots.enabled = false;
        imgArmour.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        //if (speedBoost == true)
        //{
        //    playerMove.movementSpeed = speed * 1.5f;
        //    cooldown -= Time.deltaTime;
        //    if (cooldown <= 0)
        //    {
        //        speedBoost = false;
        //        playerMove.movementSpeed = speed;
        //    }
        //}
        //else
        //{
        //    speedBoost = false;
        //    cooldown = startingCooldown;
        //    //playerMove.movementSpeed = speed;
        //}
        if (speedBoost == true)
        {
            playerMove.movementSpeed = speed * 1.25f;
        }
        //if (attackBoost == true)
        //{
        //    attackDamage = attackDamage * 1.25f;
        //    Debug.Log(attackDamage);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float Damage;
        if (collision.transform.tag == "Enemy")
        {
            Damage = collision.transform.GetComponent<EnemyManager>().Attack() - damageResistance;
            health -= Damage;
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
        if (collision.transform.CompareTag("Health"))
        {
            if (health < 100f)
            {
                health += collision.transform.GetComponent<PickUp>().healthValue;
                if (health > 100f)
                {
                    health = 100f;
                    textHealth.text = health.ToString();
                }
                textHealth.text = health.ToString();
                Destroy(collision.gameObject);
            }
        }

        if (collision.transform.CompareTag("Mana"))
        {
            if (mana < 100f)
            {
                mana += collision.transform.GetComponent<PickUp>().manaValue;
                if (mana > 100f)
                {
                    mana = 100f;
                    textMana.text = mana.ToString();
                }
                textMana.text = mana.ToString();
                Destroy(collision.gameObject);
            }
        }

        if (collision.transform.CompareTag("Speed"))
        {
            speedBoost = true;
            speed = playerMove.movementSpeed;
            imgBoots.enabled = true;
            Destroy(collision.gameObject);
        }

        if (collision.transform.CompareTag("Sword"))
        {
            attackDamage = attackDamage * 1.25f;
            imgDamage.enabled = true;
            Destroy(collision.gameObject);
        }

        if (collision.transform.CompareTag("Armour"))
        {

            damageResistance = 25 / 3;
            imgArmour.enabled = true;
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

    public void Respawn()
    {
        Debug.Log("Respawing");
        health = 100;
        mana = 100;
        stamina = 100;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
