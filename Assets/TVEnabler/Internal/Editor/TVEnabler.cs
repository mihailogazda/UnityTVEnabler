using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace TVEnabler
{
	//	Uses: https://github.com/tsubaki/UnityZip
	public class TVEnabler
	{
		static List<IBuildStep> m_buildSteps = new List<IBuildStep>
		{
			new GenerateGamePackageBuildStep(),
			new CleanDataDirectory(),
			new PatchXCodeBuildStep(),
		};

		//	Enabling 
		public static void Enable(string buildPath)
		{
			bool success = true;

			foreach (IBuildStep buildStep in m_buildSteps) 
			{
				Debug.Log ("TVEnabler: Running build step: " + buildStep);
				success &= buildStep.Execute (buildPath);
			}				
		}

	}
}