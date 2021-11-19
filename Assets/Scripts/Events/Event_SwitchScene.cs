using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bee
{
[CreateAssetMenu (
  fileName = "Event - Switch scene",
  menuName = "Events/Switch scene"
)]
public class Event_SwitchScene : AbstractEvent
{
  public Scenes nextScene;

  public override void RunEvent(MonoBehaviour runner = null)
  {
    // Logger.Log ($"Try switch scene to {nextScene}");
    runner.StartCoroutine (LoadYourAsyncScene (nextScene.ToString ()));
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
}
