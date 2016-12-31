using System;

namespace TVEnabler
{
	interface IBuildStep
	{
		bool Execute(string buildPath);
	}
}

