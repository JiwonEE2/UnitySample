using System;   // ��Ʈ����Ʈ ���� �� �ʿ�
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class AttributeController : MonoBehaviour
{
	// Scene�� �ִ� ��� Color ��Ʈ����Ʈ�� ã�Ƽ� ���� �����ִ� ���ҷ� ����� �ʹ�
	private void Start()
	{
		// Color Attribute�� ���� �ʵ带 ã��
		BindingFlags bind = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
		// FindObjectsSortMode.None���� �ϸ� �����ս��� ���� �� ����.
		MonoBehaviour[] monoBehaviours = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);

		foreach (MonoBehaviour monoBehaviour in monoBehaviours)
		{
			Type type = monoBehaviour.GetType();    // Ÿ�� ���� ������

			//List<FieldInfo> fieldInfos = new List<FieldInfo>(type.GetFields(bind));
			//List<FieldInfo> colorAttributeAttachedFields = fieldInfos.FindAll((x) =>
			//{
			//	return x.HasAttribute<ColorAttribute>();
			//});

			// List �� Collection������ Ž����
			// Linq�� ���� ����ȭ ����
			// 1. Linq���� �����ϴ� Ȯ�� �޼��� ���
			IEnumerable<FieldInfo> colorAttachedFields = type.GetFields(bind).Where(x => x.HasAttribute<ColorAttribute>());

			// 2. SQL, �������� ����� ���·ε� ��� ����
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

				// ���� ����ȭ
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
					Debug.LogError("Color ��Ʈ����Ʈ�� �߸��� ���� �پ�����");
				}
			}
		}
	}
}

// �ڽ��� �θ� ������� �� �� ��Ʈ����Ʈ�� ���� ����� ���ΰ�? == Inherited
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class ColorAttribute : Attribute
{
	public Color color;
	public ColorAttribute(float r = 0, float g = 0, float b = 0, float a = 1)
	{
		color = new Color(r, g, b, a);
	}
}

// Ȯ�� �޼���
public static class AttributeHelper
{
	public static bool HasAttribute<T>(this MemberInfo info) where T : Attribute
	{
		// �Ʒ��� ��쿡 ��Ʈ����Ʈ�� ������ �ִٴ� �ǹ̷� ����ϰڴٴ� ��
		return info.GetCustomAttributes(typeof(T), true).Length > 0;
	}
}