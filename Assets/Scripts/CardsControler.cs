using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsControler : MonoBehaviour
{
    public bool show = false;
    public bool materialFinded = false;
    public int textureRand;
    public static int[] counters = new int[8];

    void Start()
    {
        textureRand = Random.Range(0,8);

        StartCoroutine(MaterialAssigner());
    }

    void Hide()
    {
        show = false;
    }

    void OnMouseDown()
    {
        show = true;
        Invoke("Hide",4);
    }

    IEnumerator MaterialAssigner()
    {
        while (true)
        {
            switch (textureRand)
            {
                case 0:
                    if (counters[0] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterial1;
                        ++counters[0];
                        materialFinded = true;
                        StopCoroutine(MaterialAssigner());
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 1:
                    if (counters[1] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterial2;
                        ++counters[1];
                        materialFinded = true;
                        StopCoroutine(MaterialAssigner());
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 2:
                    if (counters[2] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterial3;
                        ++counters[2];
                        materialFinded = true;
                        StopCoroutine(MaterialAssigner());
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 3:
                    if (counters[3] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterial4;
                        ++counters[3];
                        materialFinded = true;
                        StopCoroutine(MaterialAssigner());
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 4:
                    if (counters[4] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterial5;
                        ++counters[4];
                        materialFinded = true;
                        StopCoroutine(MaterialAssigner());
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 5:
                    if (counters[5] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterial6;
                        ++counters[5];
                        materialFinded = true;
                        StopCoroutine(MaterialAssigner());
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 6:
                    if (counters[6] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterial7;
                        ++counters[6];
                        materialFinded = true;
                        StopCoroutine(MaterialAssigner());
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 7:
                    if (counters[7] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterial8;
                        ++counters[7];
                        materialFinded = true;
                        StopCoroutine(MaterialAssigner());
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void Update() 
    {
        if (materialFinded)
            StopAllCoroutines();

        if (show)
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, Vector3.up * 180, 2 * Time.deltaTime));
        else
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, Vector3.zero, 2 * Time.deltaTime));
    }
}
