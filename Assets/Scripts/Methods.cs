using System.Collections;
using UnityEngine;

public class Methods : MonoBehaviour
{
    [SerializeField]
    GameObject go;
    [Header("Color Change Experiment")]
    [SerializeField]

    float colorChangeInterval = 1f;

    [SerializeField]
    GameObject colorChangeObject;

    // Start is called before the first frame update
    void Start()
    {
        SayHello();
        Debug.Log("7 + 8 =" + AddTwoNumbers(7,8));
        int answer = AddTwoNumbers(400, 600);
        Debug.Log("400 + 600 = " + answer);

        StartCoroutine(ChangeColor(colorChangeObject, colorChangeInterval));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SayHello(){
        Debug.Log("Hello");
    }
    int AddTwoNumbers(int num1,int num2){
        int sum = num1 + num2;
        return sum;
    }
    IEnumerator Wait (GameObject go) {
        go.SetActive(false);
        yield return new WaitForSeconds(2f);
        go.SetActive(true);
    }
    IEnumerator ChangeColor(GameObject givenObject, float interval =0.5f)  {
        while (true) {
            yield return new WaitForSeconds(interval);

            givenObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }
       
}
    

