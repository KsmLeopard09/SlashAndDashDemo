using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DashCooldown : MonoBehaviour
{
    [SerializeField] Image barFillImage;
    [SerializeField] PlayerDash playerDash;
    [SerializeField] private float emptyTimer;
    [SerializeField] private float fillTimer;
    // Start is called before the first frame update
    void Start()
    {
        emptyTimer = playerDash.DashDuration;
        fillTimer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDash.dashing)
        {
            fillTimer = 0;
            emptyTimer -= Time.deltaTime;
            barFillImage.fillAmount = emptyTimer / playerDash.DashDuration;
        }
        else if(!playerDash.dashing && barFillImage.fillAmount != 1)
        {
            emptyTimer = playerDash.DashDuration;
            fillTimer += Time.deltaTime;
            barFillImage.fillAmount = fillTimer/playerDash.DashCooldown;
        }
    }
}
