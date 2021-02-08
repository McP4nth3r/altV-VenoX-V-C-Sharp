using AltV.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VenoXV._RootCore_.Models
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class VenoXRemoteEventAttribute : Attribute
    {
        public string Name { get; }
        public VenoXRemoteEventAttribute(string name = null)
        {
            Name = name;
        }
    }

    public class EventAssets : IScript
    {
        [ScriptEvent(ScriptEventType.PlayerEvent)]
        public static void OnServerEventReceive(VnXPlayer player, string EventName, params object[] args)
        {
            try
            {
                //Core.Debug.OutputDebugStringColored("Called [OnServerEventReceive]", ConsoleColor.Green);
                var methods = AppDomain.CurrentDomain.GetAssemblies() // Returns all currenlty loaded assemblies
               .SelectMany(x => x.GetTypes()) // returns all types defined in this assemblies
               .Where(x => x.IsClass) // only yields classes
               .SelectMany(x => x.GetMethods()) // returns all methods defined in those classes
               .Where(x => x.GetCustomAttributes(typeof(VenoXRemoteEventAttribute), false).FirstOrDefault() != null); // returns only methods that have the InvokeAttribute

                foreach (var method in methods) // iterate through all found methods
                {
                    object[] _Attr = method.GetCustomAttributes(typeof(VenoXRemoteEventAttribute), false);
                    if (_Attr is not null && _Attr.Length > 0)
                    {
                        VenoXRemoteEventAttribute __obj = (VenoXRemoteEventAttribute)_Attr[0];
                        if (__obj is not null && __obj.Name == EventName)
                        {
                            //Core.Debug.OutputDebugStringColored("Called EventName : [" + EventName + "]", ConsoleColor.Green);
                            var obj = Activator.CreateInstance(method.DeclaringType); // Instantiate the class
                            //Core.Debug.OutputDebugString("[ServerEvent] : [" + player.Name + "] | [" + player.Username + "] called EventName : " + EventName + " | Args : " + string.Join(", ", args));

                            List<object> objList = new List<object> { player };
                            ParameterInfo[] __MethodParameters = method.GetParameters();
                            int i = 1;
                            foreach (object value in args)
                            {
                                objList.Add(Convert.ChangeType(value, __MethodParameters[i].ParameterType));
                                i++;
                            }
                            object[] builder = objList.ToArray();
                            // invoke the method
                            method.Invoke(obj, builder);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex, "OnServerEventReceive - " + EventName); }
        }
    }
}
