using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fibbonacci : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cube;
   // public Transform t;
   
        public static int Fibonacci(int n)
        {
            int a = 0;
            int b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }

        public void Start()
        {
            for (int i = 0; i < 15; i++)
            {
            Debug.Log(Fibonacci(i));
            int f = Fibonacci(i);
          //  t.position = new Vector3(f, f, f);
            Quaternion rot = Quaternion.Euler(f, f, f);
            Instantiate(cube, new Vector3(f, f, f), rot);
            }
        }
    
}
