using System;
using System.IO;

namespace TVEnabler
{
	public class CleanDataDirectory : IBuildStep
	{
		#region IBuildStep implementation

		public bool Execute (string buildPath)
		{
			string dataPath = buildPath + "/Data/";
			Directory.Delete (dataPath, true);
			return !Directory.Exists (dataPath);
		}

		#endregion
		
	}
}

