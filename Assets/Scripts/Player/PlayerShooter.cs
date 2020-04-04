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

    bool isPreping = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        isPreping = Input.GetButton("Fire1");

        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetTrigger("Fired");
            isPreping = false;
        }

        anim.SetBool("Preping", isPreping);
    }


    public void Fire()
    {
        Instantiate(spellPrefab, spellSpawnPoint.position, spellSpawnPoint.rotation);
    }
}
