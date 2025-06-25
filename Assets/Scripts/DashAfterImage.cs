using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAfterImage : MonoBehaviour
{
    [SerializeField] private PlayerDash playerDash;
    [SerializeField] private PlayerMove movement;
    [SerializeField] private GameObject playerAfterImage;
    [SerializeField] private SpriteRenderer playerArmour;
    [SerializeField] private SpriteRenderer playerBase;
    [SerializeField] private GameObject player;
    [SerializeField] private int afterImageCount;

    [SerializeField] private SpriteRenderer armourRenderer;
    [SerializeField] private SpriteRenderer baseRenderer;

    [SerializeField] private float afterImageInterval;

    private bool canProduce;

    public bool CanProduce
    {
        get => canProduce;
        set => canProduce = value;
    }

    private void Start()
    {
        baseRenderer = transform.Find("Base").GetComponent<SpriteRenderer>();
        if(transform.Find("Base").transform.Find("Armour") != null)
        {
            armourRenderer = transform.Find("Base").transform.Find("Armour").GetComponent<SpriteRenderer>();
            playerArmour = playerAfterImage.transform.Find("Base").transform.Find("Armour").GetComponent<SpriteRenderer>();
        }
        playerBase = playerAfterImage.transform.Find("Base").transform.GetComponent<SpriteRenderer>();
        canProduce = false;
    }
    private void Update()
    {
        CheckIfDashing();
    }
    void CheckIfDashing()
    {
        if (playerDash.dashing && !canProduce)
        {
            StartCoroutine(ProduceAfterImage(movement.FacingRight));
        }
    }
    IEnumerator ProduceAfterImage(bool facingRight)
    {
        canProduce = true;
        while (playerDash.dashing)
        {
            Sprite currentBaseSprite = baseRenderer.sprite;
            playerBase.sprite = currentBaseSprite;
            if(armourRenderer != null)
            {
                Sprite currentArmourSprite = armourRenderer.sprite;
                playerArmour.sprite = currentArmourSprite;
                playerArmour.flipX = !facingRight;
            }
            playerBase.flipX = !facingRight;
            Instantiate(playerAfterImage, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(afterImageInterval);
        }
        canProduce = false;
    }
}
