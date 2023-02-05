using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetBool("Red", true);
            anim.SetBool("Yellow", false);
            anim.SetBool("Green", false);
            anim.SetBool("Blue", false);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetBool("Red", false);
            anim.SetBool("Yellow", true);
            anim.SetBool("Green", false);
            anim.SetBool("Blue", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetBool("Red", false);
            anim.SetBool("Yellow", false);
            anim.SetBool("Green", true);
            anim.SetBool("Blue", false);

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            anim.SetBool("Red", false);
            anim.SetBool("Yellow", false);
            anim.SetBool("Green", false);
            anim.SetBool("Blue", true);

        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            anim.SetBool("Red", false);
            anim.SetBool("Yellow", false);
            anim.SetBool("Green", false);
            anim.SetBool("Blue", false);

        }
    }
}
