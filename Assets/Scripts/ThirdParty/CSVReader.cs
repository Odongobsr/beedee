// https://bravenewmethod.com/2014/09/13/lightweight-csv-reader-for-unity/

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

public class CSVReader
{
	static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
	static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
	// static char[] TRIM_CHARS = { '\"' };
	static char[] TRIM_CHARS = { '\"' };

	public static List<Dictionary<string, string>> Read(TextAsset data, bool _verbose = false)
	{
        var list = new List<Dictionary<string, string>> ();

        //TextAsset data = Resources.Load (file) as TextAsset;

        var lines = Regex.Split (data.text, LINE_SPLIT_RE);

		if(lines.Length <= 1) return list;

		var header = Regex.Split(lines[0], SPLIT_RE);

		for(var i=1; i < lines.Length; i++) {

			var values = Regex.Split(lines[i], SPLIT_RE);
		
			if(values.Length == 0 ||values[0] == "") continue;

			var entry = new Dictionary<string, string>();

			for(var j=0; j < header.Length && j < values.Length; j++ ) {
        
        if (_verbose)
        {
          // Debug.Log (header [j]);
        }

				string value = values[j];
				value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");

        value = value.Replace ("@", "\n");
        value = value.Replace ("|", ",");

				string finalvalue = value;
//				int n;
//				float f;

//				if(int.TryParse(value, out n)) {
//					finalvalue = n;
//				} else if (float.TryParse(value, out f)) {
//					finalvalue = f;
//				}

				entry[header[j]] = finalvalue;

        if (_verbose)
        {
          Logger.Log (
            $"key: {header[j].Important ()} value: {finalvalue.Important ()}",
            null
          );
        }
			}

			list.Add (entry);
		}
		return list;
	}
}