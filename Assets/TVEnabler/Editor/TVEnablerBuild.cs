using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;

public class TVEnablerBuild 
{
	[PostProcessBuildAttribute(1000000000)]
	static void OnPostBuildEvent(BuildTarget target, string buildPath)
	{
		Debug.Log ("TVEnabler: PostProcessing");
		if (target == BuildTarget.tvOS) 
		{
			TVEnabler.TVEnabler.Enable (buildPath);
		}
	}

	[MenuItem("TVEnabler/Execute")]
	static void OnExecute()
	{
		TVEnabler.TVEnabler.Enable ("./Builds/TV_2/");
	}
}
