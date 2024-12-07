using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JetpackBootster : ItemBooster
{
    public float flyHeight;
    private bool canFall = true;

    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        transform.eulerAngles += new Vector3(0, 40 * 4 * Time.deltaTime);

        if (canFall)
            transform.position -= new Vector3(0, Time.deltaTime * 40 / 5, 0);
        else
            transform.position -= new Vector3(0, 0, GameManager.instance.roadManager.currentSpeed * Time.deltaTime);
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.energyCollected);

            Player player = other.GetComponent<Player>();
            player.jetpackBooster = FindObjectOfType<JetpackBootster>();
            player.jetpacking = true;
            itemManager.JetpackBooster(itemTime);
            gameObject.SetActive(false);
            Destroy(gameObject, itemTime);
        }
        /////
        if (other.gameObject.tag == "DestroyTrigger")
            Destroy(gameObject);

        if (other.gameObject.tag == "Coin")
            other.gameObject.SetActive(false);

        if (other.gameObject.name == "Plane" || other.gameObject.tag == "Wall")
            canFall = false;
    }
}
