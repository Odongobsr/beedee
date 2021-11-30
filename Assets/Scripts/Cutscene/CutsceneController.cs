using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Bee
{
  public class CutsceneController : StateListener
  {
    [Header ("Configuration")]
    public bool isPlaying;
    /// <summary>
    /// What frame of the cutscene are we on?
    /// </summary>
    public int index;
    public float waitTime;

    [Header ("References")]
    public UIScreen UIScreen;
    public Image image;
    public Text text;
    public List<CutsceneFrame> frames;

    UnityAction onCompleteAction;

    public override void CheckAssertions()
    {
      base.CheckAssertions();

      Assert.IsNotNull (UIScreen);
      Assert.IsNotNull (image);
      Assert.IsNotNull (text);

      Assert.IsTrue (frames.Count > 0);
      Assert.IsFalse (frames.HasNull ());
    }

    void Update()
    {
      if (isPlaying)
      {
        // detect user input
        if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space))    
        {
          StopCutscene ();
        }
      }
    }

    /// <summary>
    /// Start cutscene
    /// <param name="_onCompleteAction">Function that is called when cutscene is complete</param>
    /// </summary>
    public void StartCutscene (UnityAction _onCompleteAction)
    {
      onCompleteAction = _onCompleteAction;
      StartCoroutine (CutsceneCoroutine ());
    }

    IEnumerator CutsceneCoroutine ()
    {
      Logger.Log (
        $"Start {name.Important ()}",
        this
      );

      yield return new WaitForSeconds (1);

      isPlaying = true;
      index = 0;

      while (index < frames.Count)
      {
        // show next frame
        image.sprite = frames [index].sprite;
        text.text = GameGlobals.Instance.registry.rosettaReader.GetKey (frames [index].text);

        Logger.Log (
          $"{image.sprite.name} - {text.text}",
          image.sprite
        );
      
        UIScreen.Activate ();

        yield return new WaitForSeconds (GameGlobals.Instance.registry.cutsceneFrameTime);

        UIScreen.Deactivate ();

        yield return new WaitForSeconds (1);
        index++;
      }

      StopCutscene ();
    }

    public void StopCutscene ()
    {
      StopAllCoroutines ();

      StartCoroutine (StopCutsceneCoroutine ());
    }

    IEnumerator StopCutsceneCoroutine ()
    {      
      Logger.Log (
        $"Finished {name}",
        this
      );
      isPlaying = false;

      UIScreen.Deactivate ();

      yield return new WaitForSeconds (1);

      // call on complete action
      onCompleteAction?.Invoke ();
    }
  }
}