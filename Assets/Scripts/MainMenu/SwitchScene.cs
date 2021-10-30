// https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadSceneAsync.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void Switch ()
    {
      SwitchSceneParams parameters = GetComponent<SwitchSceneParams> ();

      if (null != parameters)
      {
        LoadYourAsyncScene (parameters.sceneToLoad.ToString ());
      }
    }

    IEnumerator LoadYourAsyncScene(string next)
    {
        Logger.Log ($"Try load {next} scene");

        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(next, LoadSceneMode.Additive);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Logger.Log ($"{next} scene has loaded");

        string current = SceneManager.GetActiveScene ().name;

        Logger.Log ($"Try unload {current} scene");

        // unload current scene
        asyncLoad = SceneManager.UnloadSceneAsync (current);
        
        // Wait until the asynchronous scene fully unloads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Logger.Log ($"{current} scene has unloaded");
    }
}
