using System;   // 어트리뷰트 만들 때 필요
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class AttributeController : MonoBehaviour
{
	// Scene에 있는 모든 Color 어트리뷰트를 찾아서 색을 입혀주는 역할로 만들고 싶다
	private void Start()
	{
		// Color Attribute를 가진 필드를 찾기
		BindingFlags bind = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
		// FindObjectsSortMode.None으로 하면 퍼포먼스가 조금 더 좋다.
		MonoBehaviour[] monoBehaviours = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);

		foreach (MonoBehaviour monoBehaviour in monoBehaviours)
		{
			Type type = monoBehaviour.GetType();    // 타입 정보 가져옴

			//List<FieldInfo> fieldInfos = new List<FieldInfo>(type.GetFields(bind));
			//List<FieldInfo> colorAttributeAttachedFields = fieldInfos.FindAll((x) =>
			//{
			//	return x.HasAttribute<ColorAttribute>();
			//});

			// List 등 Collection에서의 탐색은
			// Linq를 통해 간소화 가능
			// 1. Linq에서 제공하는 확장 메서드 사용
			IEnumerable<FieldInfo> colorAttachedFields = type.GetFields(bind).Where(x => x.HasAttribute<ColorAttribute>());

			// 2. SQL, 쿼리문과 비슷한 형태로도 사용 가능
			colorAttachedFields = from field in type.GetFields(bind)
								  where field.HasAttribute<ColorAttribute>()
								  select field;

			foreach (FieldInfo fieldInfo in colorAttachedFields)
			{
				ColorAttribute att = fieldInfo.GetCustomAttribute<ColorAttribute>();
				object value = fieldInfo.GetValue(monoBehaviour);

				//if(value is Renderer)
				//{
				//	Renderer rend = value as Renderer;
				//	rend.material.color = att.color;
				//}

				// 위를 간소화
				if (value is Renderer rend)
				{
					rend.material.color = att.color;
				}
				else if (value is Graphic graph)
				{
					graph.color = att.color;
				}
				else
				{
					Debug.LogError("Color 어트리뷰트가 잘못된 곳에 붙어있음");
				}
			}
		}
	}
}

// 자식이 부모를 상속했을 때 이 어트리뷰트도 같이 상속할 것인가? == Inherited
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class ColorAttribute : Attribute
{
	public Color color;
	public ColorAttribute(float r = 0, float g = 0, float b = 0, float a = 1)
	{
		color = new Color(r, g, b, a);
	}
}

// 확장 메서드
public static class AttributeHelper
{
	public static bool HasAttribute<T>(this MemberInfo info) where T : Attribute
	{
		// 아래의 경우에 어트리뷰트를 가지고 있다는 의미로 사용하겠다는 뜻
		return info.GetCustomAttributes(typeof(T), true).Length > 0;
	}
}