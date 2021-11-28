using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Bee
{
  /// <summary>
  /// Class that stores player-related data
  /// </summary>
  [System.Serializable]
  public class UserData 
  {
    /// <summary>
    /// Current language (english, swahili, ?)
    /// </summary>
    public string language;

    /// <summary>
    /// Has user selected current language?
    /// </summary>
    public bool hasSelectedLanguage;

    /// <summary>
    /// Should sound effects be heard?
    /// </summary>
    public bool useSound;
    
    /// <summary>
    /// Should debug stats be shown?
    /// </summary>
    public bool showDebugStats;

    /// <summary>
    /// Stage that was last completed by player.
    /// We assume that all stages with an index lower than [lastCompletedStage]
    /// have been completed
    /// </summary>
    public int lastCompletedStage = -1;

    public override string ToString()
    {
      var sb = new StringBuilder ();

      sb.Append ("Language:" + language.Print ().Important ());
      sb.Append ("\nHas selected lanugage:" + hasSelectedLanguage.ToString ().Important ());
      sb.Append ("\nSound:" + useSound.ToString ().Important ());
      sb.Append ("\nLast completed stage:" + lastCompletedStage.ToString ().Important ());
      sb.Append ("\nShow debug stats:" + showDebugStats.ToString ().Important ());

      return sb.ToString ();
    }
  }
}
