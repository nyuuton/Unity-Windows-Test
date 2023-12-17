using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Rotation : MonoBehaviour
{
    [SerializeField] bool isUpPressed = false;
    [SerializeField] bool isDownPressed = false;
    [SerializeField] bool isLeftPressed = false;
    [SerializeField] bool isRightPressed = false;

    [SerializeField] bool isButton0Pressed = false;
    [SerializeField] bool isShiftPressed = false;

    float speed_0 = 1;
    float speed_1 = 1;
    float speed_2 = 1;
    float speed_3 = 1;

    double state_0 = 0;
    double state_1_r = 0;
    double state_1_i = 0;
    double theta = 0;
    double phi = 0;
    double total = 1;
    Vector3 current_rotation = new Vector3 (0,0,0); 

    // Start is called before the first frame update
    void Start()
    {
        current_rotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            transform.rotation = new Quaternion(-.7f,.0f,.0f,.7f);
        }
        /*if(Input.GetKeyDown(KeyCode.LeftShift)){isShiftPressed = true;}
        if(Input.GetKeyUp(KeyCode.LeftShift)){isShiftPressed = false;}
        if (isShiftPressed){ s = 4;}
        else{ s = 1; }*/

        /*if(Input.GetKey("joystick button 0")){isButton0Pressed = true;}
        else{isButton0Pressed = false;}
        if (isButton0Pressed){transform.Rotate(-.5f*s,0,0);} */
        

        //Debug.Log(Input.GetAxis("Axis5")); //Axis2 = LT, Axis5 = RT
        if (Input.GetAxis("Axis2") != 0){
            speed_1 = 1-Input.GetAxis("Axis2")*.9f ;        
        } else{speed_1 = 1;}
        if (Input.GetAxis("Axis5") != 0){
            speed_2 = 1-Input.GetAxis("Axis5")*.9f ;    
        } else{speed_2 = 1;}

        if (Input.GetAxis("Axis1") != 0){
            transform.Rotate(10f*Input.GetAxis("Axis1") * speed_0 * speed_1 * speed_2 * speed_3,0,0);
        }
        if (Input.GetAxis("Axis0") != 0){
            transform.Rotate(0,-10f*Input.GetAxis("Axis0") * speed_0 * speed_1 * speed_2 * speed_3,0);
        }

        if (Input.GetKey("joystick button 4") && Input.GetKey("joystick button 5") ){
            speed_0 = 0.015625f;
        }
        else if (!Input.GetKey("joystick button 4") && Input.GetKey("joystick button 5") ){
            speed_0 = 0.0625f;
        }
        else if (Input.GetKey("joystick button 4") && !Input.GetKey("joystick button 5") ){
            speed_0 = 0.25f;
        }
        else { speed_0 = 1; }

        if(current_rotation != transform.rotation.eulerAngles){
            //Debug.Log(transform.rotation.eulerAngles);
            current_rotation = transform.rotation.eulerAngles;
            //File.WriteAllText(@"test.txt", current_rotation.ToString());
            
            GameObject zero = GameObject.Find("0");
            phi = (360 - current_rotation[1])* System.Math.PI/180;
            if(current_rotation[0]>270){theta = (current_rotation[0]-270) * System.Math.PI/180;}
            else{theta = (current_rotation[0]+90) * System.Math.PI/180;}
            state_0 = System.Math.Cos(theta/2 );
            state_1_r = System.Math.Cos(phi)*System.Math.Sin(theta/2);
            state_1_i = System.Math.Sin(phi)*System.Math.Sin(theta/2);
            zero.GetComponent<TextMeshProUGUI>().text = "0:"+state_0.ToString("0.00");
            GameObject one = GameObject.Find("1");
            one.GetComponent<TextMeshProUGUI>().text = "1:"+state_1_r.ToString("0.00")+"+"+state_1_r.ToString("0.00")+"j";
                    
            GameObject test = GameObject.Find("Purity");

            total = System.Math.Pow(state_0,2) + System.Math.Pow(state_1_r,2) + System.Math.Pow(state_1_i,2);
            test.GetComponent<TextMeshProUGUI>().text = total.ToString();
            //test.GetComponent<TextMeshProUGUI>().text = current_rotation.ToString();
        }

        if (Input.GetKey("joystick button 9")){
            transform.rotation = new Quaternion(-.7f,.0f,.0f,.7f);
        }

        /*if(Input.GetKeyDown(KeyCode.UpArrow)){isUpPressed = true;}
        if(Input.GetKeyUp(KeyCode.UpArrow)){isUpPressed = false;}
        if (isUpPressed){transform.Rotate(-.5f*s,0,0);}

        if(Input.GetKeyDown(KeyCode.DownArrow)){isDownPressed = true;}
        if(Input.GetKeyUp(KeyCode.DownArrow)){isDownPressed = false;}
        if (isDownPressed){transform.Rotate(.5f*s,0,0);}
        
        if(Input.GetKeyDown(KeyCode.LeftArrow)){isLeftPressed = true;}
        if(Input.GetKeyUp(KeyCode.LeftArrow)){isLeftPressed = false;}
        if (isLeftPressed){transform.Rotate(0,.5f*s,0);}

        if(Input.GetKeyDown(KeyCode.RightArrow)){isRightPressed = true;}
        if(Input.GetKeyUp(KeyCode.RightArrow)){isRightPressed = false;}
        if (isRightPressed){transform.Rotate(0,-.5f*s,0);}
        */
        //if (isUpPressed){
        //        }

    }
}
