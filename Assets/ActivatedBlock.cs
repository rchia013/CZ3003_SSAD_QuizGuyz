using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedBlock : MonoBehaviour
{
    public Material material3;
    public Material material2;
    public Material material1;

    MeshRenderer rend;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<MeshRenderer>();
        rb = gameObject.GetComponent<Rigidbody>();

        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.Translate(Vector3.down * 0.1f);
            print("Give Question");

            StartCoroutine("Countdown");
        }
    }

    IEnumerator Countdown()
    { 

        int counter = 5;

        while (counter > 0)
        {
            yield return new WaitForSeconds(1);

            counter--;

            Material[] materials = rend.materials;

            switch (counter)
            {
                case 3:
                    materials[0] = material3;
                    break;

                case 2:
                    materials[0] = material2;
                    break;

                case 1:
                    materials[0] = material1;
                    break;

                case 0:
                    rb.isKinematic = false;
                    break;
            }

            rend.materials = materials;
        }
    }
}
