using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    //movement keys
    public string forward = "w";
    public string backward = "s";
    public string left = "a";
    public string right = "d";
    public string jump = "space";
    public string turn_left = "left";
    public string turn_right = "right";

    public string walk = "left control";
    public string sprint = "left shift";

    //skills and abilities keys
    public string[] skills = {
        "1","2","3","4","5","6","7","8","9","0"
    };

    //action keys
    public string[] action = {
        "f","enter","m","i"
        
    };
    public string[] f = {
        "f1","f2","f3","f4","f5","f6","f7","f8","f9","f10","f11","f12"
    };

}
