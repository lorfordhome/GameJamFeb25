using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{

    public void ChangeScene(string sceneToChange) {
        SceneManager.LoadScene(sceneToChange);
    }

}
