using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;

namespace TVEnabler
{
	public class GenerateGamePackageBuildStep : IBuildStep
	{
		string Md5Sum(string strToEncrypt)
		{
			System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
			byte[] bytes = ue.GetBytes(strToEncrypt);

			// encrypt bytes
			System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
			byte[] hashBytes = md5.ComputeHash(bytes);

			// Convert the encrypted bytes back to a string (base 16)
			string hashString = "";

			for (int i = 0; i < hashBytes.Length; i++)
			{
				hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
			}

			return hashString.PadLeft(32, '0');
		}

		List<string> GetAllFilesInDir(string inputPath)
		{						
			List<string> files = new List<string> ();
			if (Directory.Exists (inputPath)) 
			{
				DirectoryInfo info = new DirectoryInfo (inputPath);
				FileInfo[] allFiles = info.GetFiles("*.*");
				foreach (FileInfo fi in allFiles)
				{				
					if (!fi.FullName.EndsWith (".DS_Store") )
					{
						string respath = fi.FullName;
						Debug.Log ("TVEnabler: Adding file: " + respath);
						files.Add (respath);
					}
				}

				DirectoryInfo[] subdirs = info.GetDirectories ();
				foreach (DirectoryInfo dir in subdirs)
				{					
					files.AddRange(GetAllFilesInDir(dir.FullName));
				}
			}
			return files;
		}

#region IBuildStep implementation

		public bool Execute (string buildPath)
		{
			string outputZipName = buildPath + "/GameData.package";
			string inputPath = new DirectoryInfo(buildPath + "/Data/").FullName;

			//	Remove old file
			if (File.Exists (outputZipName)) 
			{
				File.Delete (outputZipName);	
			} 

			//	Create a manifest of files
			//	Format:
			//	filenameLength|filename|MD5_BASE64
			string manifestPath = inputPath + "/TVEnabler.manifest";
			if (File.Exists(manifestPath))
			{
				File.Delete(manifestPath);
			}

			//	Build a list of files to compress
			List<string> files = GetAllFilesInDir (inputPath);
			
			string contents = "";
			foreach (string file in files) 
			{				
				string withoutRoot = file.Substring (inputPath.Length);
				withoutRoot = withoutRoot.Length + "|" + withoutRoot;

				using (var md5 = MD5.Create())
				{
					using (var stream = File.OpenRead(file))
					{
						string hash = Convert.ToBase64String(md5.ComputeHash(stream));
						withoutRoot += "|" + hash;
					}
				}

				contents += withoutRoot + "\n";
			}

			File.WriteAllText (manifestPath, contents);

			//	Do actual compression
			ZipUtil.ZipDirectoryWithHierarchy(outputZipName, inputPath, "1234");

			if (!File.Exists (outputZipName) || !ZipUtil.ValidZip(outputZipName)) 
			{
				Debug.LogError ("Can't find output package file " + outputZipName);
				return false;
			}

			return true;
		}

		#endregion

	}
}

