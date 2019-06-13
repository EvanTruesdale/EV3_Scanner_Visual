using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Generate_Points : MonoBehaviour {

	void Start () 
    {
        StreamReader reader = new StreamReader("Assets/scanner_output_1.txt");
        while (reader.Peek() >= 0)
        {
            string[] coor_string;
            float[] coor = new float[3];
            coor_string = reader.ReadLine().Split(' ');
            for (int i=0; i<3; i++)
            {
                coor[i] = float.Parse(coor_string[i]);
            }
            print(coor[0] + " " + coor[1] + " " + coor[2]);
            float distance = 70f * (coor[2] / 100);

            //In Unity, Y is up, but I want Z to be up, so the equations are switched

            Vector3 position = new Vector3(distance * Mathf.Sin(Mathf.Deg2Rad * coor[1]) * Mathf.Cos(Mathf.Deg2Rad * coor[0]),
                                           distance * Mathf.Cos(Mathf.Deg2Rad * coor[1]),
                                           distance * Mathf.Sin(Mathf.Deg2Rad * coor[1]) * Mathf.Sin(Mathf.Deg2Rad * coor[0]));

            GameObject point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            point.transform.position = position;
        }
	}

}
