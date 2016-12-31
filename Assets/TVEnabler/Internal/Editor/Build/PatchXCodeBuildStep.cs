using System;
using System.IO;
using UnityEngine;

namespace TVEnabler
{
	public class PatchXCodeBuildStep : IBuildStep
	{
		#region IBuildStep implementation

		public bool Execute (string buildPath)
		{
			string xcodeproj = buildPath + "/Unity-iPhone.xcodeproj/project.pbxproj";

			if (!File.Exists (xcodeproj)) 
			{
				Debug.LogError ("TVEnabler: Can find xcode project. " + xcodeproj);
				return false;
			}

			string[] allContents = File.ReadAllLines (xcodeproj);
			string output = "";

			foreach (string line in allContents)
			{
				//	Not containing
				if (line.IndexOf ("/* Data in Resources */") == -1) 
				{
					output += line + "\n";
				}
			};
			File.WriteAllText (xcodeproj, output);

			return true;
		}

		#endregion


	}
}

