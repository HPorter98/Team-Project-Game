using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    [SerializeField] private float cooldown;

    private float startCooldown;
    private float health;
    private float mana;
    private float speed;
    private PlayerManager player;
    private PlayerMovement playerMove;

    public TMPro.TextMeshProUGUI textHealth;
    public TMPro.TextMeshProUGUI textStamina;
    public TMPro.TextMeshProUGUI textMana;
    // Start is called before the first frame update
    void Start()
    {
        startCooldown = cooldown;
        player.GetComponent<PlayerManager>();
        playerMove.GetComponent<PlayerMovement>();

        //health = player.health;

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpeedBoost()
    {

    }
}