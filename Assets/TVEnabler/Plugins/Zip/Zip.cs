using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using Ionic.Zip;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace TVEnabler
{
	public class ZipUtil
	{
		#if UNITY_IPHONE || UNITY_TVOS
		[DllImport ("__Internal")]
		private static extern void unzip (string zipFilePath, string location);

		[DllImport ("__Internal")]
		private static extern void zip (string zipFilePath);

		[DllImport ("__Internal")]
		private static extern void addZipFile (string addFile);

		#endif

		public static void Unzip (string zipFilePath, string location)
		{
			#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX
			Directory.CreateDirectory (location);
			
			using (ZipFile zip = ZipFile.Read (zipFilePath)) {
				
				zip.ExtractAll (location, ExtractExistingFileAction.OverwriteSilently);
			}
			#elif UNITY_ANDROID
			using (AndroidJavaClass zipper = new AndroidJavaClass ("com.tsw.zipper")) {
				zipper.CallStatic ("unzip", zipFilePath, location);
			}
			#elif UNITY_IPHONE || UNITY_TVOS
			unzip (zipFilePath, location);
			#endif
		}

		public static void Zip (string zipFileName, params string[] files)
		{
			#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX
			string path = Path.GetDirectoryName (zipFileName);
			Directory.CreateDirectory (path);
			
			using (ZipFile zip = new ZipFile ()) {
				foreach (string file in files) {
					zip.AddFile (file, "");
				}
				zip.Save (zipFileName);
			}
			#elif UNITY_ANDROID
			using (AndroidJavaClass zipper = new AndroidJavaClass ("com.tsw.zipper")) {
				{
					zipper.CallStatic ("zip", zipFileName, files);
				}
			}
			#elif UNITY_IPHONE || UNITY_TVOS
			foreach (string file in files) {
				addZipFile (file);
			}
			zip (zipFileName);
			#endif
		}


		#if UNITY_EDITOR

		public static void ZipDirectoryWithHierarchy (string zipFileName, string zipDir, string password = null)
		{
			string path = Path.GetDirectoryName (zipFileName);
			Directory.CreateDirectory (path);

			using (ZipFile zip = new ZipFile ()) {
				zip.AddDirectory (zipDir);

				if (password != null) {
					zip.Password = password;
				}

				zip.Save (zipFileName);
			}
		}

		public static bool ValidZip (string zipFile)
		{
			bool ok = false;
			using (ZipFile zip = ZipFile.Read (zipFile)) {
				ok = true;
			}
			return ok;
		}
		
		#endif
	}
}
