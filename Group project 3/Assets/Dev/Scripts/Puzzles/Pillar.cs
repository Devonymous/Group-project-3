using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pillar : MonoBehaviour
{
    public bool N,Z,O,W;
    bool N_active,Z_active,O_active,W_active;
    public Transform Pillar_pos;
    float speed = 3f, X_,Z_;
    public GameObject E_Img;
    public Text E_text;
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Move();
        }
    }

    

    void Move()
    {
        Vector3 targetpos = new Vector3(Pillar_pos.position.x + X_,Pillar_pos.position.y,Pillar_pos.position.z + Z_);
        if (N_active == true)
        {
            X_ = -2.6f; 
            Z_ = 0f;
        } else if (Z_active == true)
        {
            X_ = 2.6f;
            Z_ = 0f;
        } else if (O_active == true)
        {
            X_ = 0f;
            Z_ = 2.6f;
        } else if (W_active == true)
        {
            X_ = 0f;
            Z_ = -2.6f;
        }
        Pillar_pos.position = Vector3.MoveTowards(Pillar_pos.position, targetpos, speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            E_Img.SetActive(true);
            E_text.text = "Push";
            if (N == true)
            {
                N_active = true;
            } else if (Z == true)
            {
                Z_active = true;
            } else if (W == true)
            {
                W_active = true;
            } else if (O == true)
            {
                O_active = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        E_Img.SetActive(false);
        N_active = false;
        W_active = false;
        O_active = false;
        Z_active = false;
        Z_ = 0f;
        X_ = 0f;
    }
}
