using System;
using System.Collections.Generic;
using System.Text;
using JSONSharp.Collections;
using JSONSharp;
using JSONSharp.Values;
using System.Reflection;

namespace Workflow.Util
{
    public class JSONUtils
    {
        public static String ToJSONString(Object objValue, IDictionary<Type, String> jsonPairs)
        {
            JSONValue jsonValue = GetJSONValue(objValue, jsonPairs);
            return jsonValue.ToString();
        }

        private static JSONObjectCollection ToJSONObjectCollection(Object objValue, IDictionary<Type, String> jsonPairs)
        {
            
            if (objValue == null) return null;
            if (!jsonPairs.Keys.Contains(objValue.GetType())) return null;    
            Type type = objValue.GetType();

            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);


            string jsonPropertyNames = jsonPairs[type];
            string[] jsonNames = jsonPropertyNames.Split(new char[] { ',' });
            JSONObjectCollection jsonObject = new JSONObjectCollection();

            foreach (PropertyInfo pi in properties)
            {
                // 如果没有包含在定制要求中，则忽略
                if (!Contains(jsonNames, pi.Name)) continue;

                object propertyValue = pi.GetValue(objValue, null);
                JSONValue propertyJSONValue = GetJSONValue(propertyValue, jsonPairs);

                //if (propertyJSONValue == null && propertyValue != null)
                //{
                //    Type propertyType = propertyValue.GetType();
                //    String jsonValueNameString = jsonPairs[propertyType];
                //    if (jsonValueNameString == null)
                //    {
                //        continue;
                //    }
                //    propertyJSONValue = ToJSONObjectCollection(propertyValue, jsonPairs);

                //}
                if (propertyJSONValue != null)
                {
                    jsonObject.Add(new JSONStringValue(pi.Name), propertyJSONValue);
                }
            }

            return jsonObject;
        }

        private static bool Contains(string[] sources, string target)
        {
            foreach (string source in sources)
            {
                if (source.Trim() == target.Trim())
                    return true;
            }

            return false;
        }

        private static JSONValue GetJSONValue(object objValue, IDictionary<Type, String> jsonPairs)
        {
            if (objValue == null) return null;
            Type thisType = objValue.GetType();
            JSONValue jsonValue = null;

            if (thisType == typeof(System.Int32))
            {
                jsonValue = new JSONNumberValue(Convert.ToInt32(objValue));
            }
            else if (thisType == typeof(System.Int64))
            {
                jsonValue = new JSONNumberValue(Convert.ToDecimal(objValue));
            }
            else if (thisType == typeof(System.Single))
            {
                jsonValue = new JSONNumberValue(Convert.ToSingle(objValue));
            }
            else if (thisType == typeof(System.Double))
            {
                jsonValue = new JSONNumberValue(Convert.ToDouble(objValue));
            }
            else if (thisType == typeof(System.Decimal))
            {
                jsonValue = new JSONNumberValue(Convert.ToDecimal(objValue));
            }
            else if (thisType == typeof(System.Byte))
            {
                jsonValue = new JSONNumberValue(Convert.ToByte(objValue));
            }
            else if (thisType == typeof(System.String))
            {
                jsonValue = new JSONStringValue(Convert.ToString(objValue));
            }
            else if (thisType == typeof(System.Boolean))
            {
                jsonValue = new JSONBoolValue(Convert.ToBoolean(objValue));
            }
            else if (thisType.BaseType == typeof(System.Enum))
            {
                jsonValue = new JSONStringValue(Enum.GetName(thisType, objValue));
            }
            else if (thisType.IsArray)
            {
                List<JSONValue> jsonValues = new List<JSONValue>();
                Array arrValue = (Array)objValue;
                for (int x = 0; x < arrValue.Length; x++)
                {
                    JSONValue jsValue = GetJSONValue(arrValue.GetValue(x), jsonPairs);
                    if (jsValue == null)
                        jsValue = ToJSONObjectCollection(jsValue, jsonPairs);
                    jsonValues.Add(jsValue);
                }
                jsonValue = new JSONArrayCollection(jsonValues);
            }
            // else if (thisType == typeof(IList))
            else if (thisType.FullName.IndexOf("System.Collections.Generic.List") > -1 || thisType.FullName.IndexOf("IBatisNet.DataMapper.Proxy.LazyListGeneric") > -1)
            {
                List<JSONValue> jsonValues = new List<JSONValue>();
                System.Collections.IEnumerator arrValue = ((System.Collections.IEnumerable)objValue).GetEnumerator();
                while (arrValue.MoveNext())
                {
                    JSONValue jsValue = GetJSONValue(arrValue.Current, jsonPairs);
                    if (jsValue == null)
                        jsValue = ToJSONObjectCollection(jsValue, jsonPairs);
                    jsonValues.Add(jsValue);
                }

                jsonValue = new JSONArrayCollection(jsonValues);
            }
            else
            {
                return ToJSONObjectCollection(objValue, jsonPairs);
            }

            return jsonValue;
        }

    }
}
