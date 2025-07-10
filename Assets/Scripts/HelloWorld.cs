using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public string Message = "Hello World";
    public string name1 = "A";
    public string name2 = "V";
    public string myName = "M";


    void Start()
    {
        Debug.Log("My Name Is " + myName);
        myName = name1;
        Debug.Log("My Name Is " + myName);
        myName = name2;
        Debug.Log("My Name Is " + myName);
        name2 = name1;
        myName = name2;
        Debug.Log("My Name Is " + myName);


    }

    void Update()
    {
    }
}
