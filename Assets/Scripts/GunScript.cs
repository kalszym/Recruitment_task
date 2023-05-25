using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public Animator gun;
    public ParticleSystem shoot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gun.SetBool("isShoot",true);
            shoot.Play();
            
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
            gun.SetBool("isShoot", false);

    }
}
