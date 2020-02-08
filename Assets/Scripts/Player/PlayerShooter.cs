using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class PlayerShooter : MonoBehaviour
{
    public float shootingSpeed=0.5f;
    public GameObject spellPrefab;
    public Transform spellSpawnPoint;

    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("Preping", true);
            anim.speed = 1 / shootingSpeed;
        }
        else {
            anim.speed = 1;
            anim.SetBool("Preping", false);
        }

        if (Input.GetButtonUp("Fire1")) anim.SetTrigger("Fired");
    }


    public void Fire()
    {
        Debug.Log("Fired");
        Instantiate(spellPrefab, spellSpawnPoint.position, spellSpawnPoint.rotation);
    }
}
