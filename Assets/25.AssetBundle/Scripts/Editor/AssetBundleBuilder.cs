using System.IO;
using UnityEditor;
using UnityEngine;

// AssetBundle: 개발자가 프로젝트에 활용될 리소스를
// 유니티의 바이너리 데이터 생성 방식과 동일한 방식으로 직접 생성하여
// 활용할 수 있도록 하는 기능.
// 필수적으로 Asset Bundle을 따로 유니티 바이너리 생성 방식으로 빌드 해야 한다.

// Asset Bundle을 Build해주는 역할
public class AssetBundleBuilder
{
	[MenuItem("에셋번들/빌드하기")]
	static void AssetBundleBuild()
	{
		// %프로젝트 경로%/Bundle
		string bundlePath = "./Bundle";
		if (false == Directory.Exists(bundlePath))
		{
			// 번들을 빌드할 경로에 폴더가 존재하지 않으면 폴더 생성
			Directory.CreateDirectory(bundlePath);
		}

		// UnityEngine.AssetBundleManifest
		// UnityEditor.BuildPipeline
		AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(bundlePath,
			BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);

		// 빌드 성공
		if (manifest)
		{
			EditorUtility.DisplayDialog("번들 빌드",
				"Asset Bundle을 빌드하였습니다.", "확인");
		}
		// 빌드 실패
		else
		{
			EditorUtility.DisplayDialog("번들 빌드",
				"Asset Bundle을 빌드하지 못했습니다.", "확인");
		}
	}
}