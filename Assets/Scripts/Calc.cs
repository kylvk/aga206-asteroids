using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Properties;
using UnityEngine;

public class Calc : MonoBehaviour
{
    public float Number1;
    public float Number2;
    public float Screen;



    void Start()
    {

       // Screen = Add(Number1, Number2);
       // Debug.Log(Screen);
        //Screen = Subtract(Number1, Number2);
       // Debug.Log(Screen);
       // Screen = Multiply(Number1, Number2);
       // Debug.Log(Screen);
        //Screen = Divide(Number1, Number2);
        //Debug.Log(Screen);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Screen = Add(Number1, Number2);
            Debug.Log(Screen);
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            Screen = Subtract(Number1, Number2);
            Debug.Log(Screen);
        }
        if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            Screen = Multiply(Number1, Number2);
            Debug.Log(Screen);
        }
        if (Input.GetKeyDown(KeyCode.KeypadDivide))
        {
            Screen = Divide(Number1, Number2);
            Debug.Log(Screen);
        }
    }

    private float Add(float number1, float number2)
    {
        float result = number1 + number2;
        return result;
    }

    private float Multiply(float number1, float number2)
    {
        float result = number1 * number2;
        return result;
}
    private float Divide(float number1, float number2)
    {
        float result = number1 / number2;
        return result;
    }
    private float Subtract(float number1, float number2)
    {
        float result = number1 - number2;
        return result;
    }

}
