using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class popup_buttons : MonoBehaviour
{
   public void retry(){
        SceneManager.LoadScene("main");
    }
    public void play (){
        SceneManager.LoadScene("main");
    }
    public void lobby(){
        SceneManager.LoadScene("lobby");
    }


}
