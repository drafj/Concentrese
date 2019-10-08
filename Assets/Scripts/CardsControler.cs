using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsControler : MonoBehaviour
{
    public bool show = false;
    public bool materialFinded = false;
    public int textureRand;
    public static int[] counters = new int[8];
    public CubesID mID;

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
        if (General.cubesVerificator[0] == null)
        General.cubesVerificator[0] = gameObject;
        else
        {
            General.cubesVerificator[1] = gameObject;
            Verification();
        }
        Invoke("Hide",4);
    }

    public void Verification()
    {
        if (General.cubesVerificator[0].GetComponent<CardsControler>().mID == General.cubesVerificator[1].GetComponent<CardsControler>().mID)
        {
            StartCoroutine(CubeDestroyer(General.cubesVerificator[0].gameObject, General.cubesVerificator[1].gameObject));
        }
        else
        {
            General.cubesVerificator[0] = null;
            General.cubesVerificator[1] = null;
        }
    }

    IEnumerator CubeDestroyer(GameObject uno, GameObject dos)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(uno);
        Destroy(dos);
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
                        gameObject.GetComponent<Renderer>().material = General.staticMaterials[0];
                        ++counters[0];
                        materialFinded = true;
                        mID = CubesID.C1;
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 1:
                    if (counters[1] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterials[1];
                        ++counters[1];
                        materialFinded = true;
                        mID = CubesID.C2;
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 2:
                    if (counters[2] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterials[2];
                        ++counters[2];
                        materialFinded = true;
                        mID = CubesID.C3;
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 3:
                    if (counters[3] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterials[3];
                        ++counters[3];
                        materialFinded = true;
                        mID = CubesID.C4;
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 4:
                    if (counters[4] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterials[4];
                        ++counters[4];
                        materialFinded = true;
                        mID = CubesID.C5;
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 5:
                    if (counters[5] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterials[5];
                        ++counters[5];
                        materialFinded = true;
                        mID = CubesID.C6;
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 6:
                    if (counters[6] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterials[6];
                        ++counters[6];
                        materialFinded = true;
                        mID = CubesID.C7;
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 7:
                    if (counters[7] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterials[7];
                        ++counters[7];
                        materialFinded = true;
                        mID = CubesID.C8;
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

public enum CubesID {C1,C2,C3,C4,C5,C6,C7,C8}