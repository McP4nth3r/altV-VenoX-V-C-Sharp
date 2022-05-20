using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AltV.Net;
using VenoX.Debug;

namespace VenoX.Core._RootCore_.Models
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
        public static IEnumerable<MethodInfo> Methods = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(x => x.GetTypes()) // returns all types defined in this assemblies
        .Where(x => x.IsClass) // only yields classes
        .SelectMany(x => x.GetMethods()) // returns all methods defined in those classes
        .Where(x => x.GetCustomAttributes(typeof(VenoXRemoteEventAttribute), false).FirstOrDefault() != null); // returns only methods that have VenoXRemoteEventAttribute

        [ScriptEvent(ScriptEventType.PlayerEvent)]
        public static void OnServerEventReceive(VnXPlayer player, string eventName, params object[] args)
        {
            try
            {
                /* Debug */
                //Core.Debug.OutputDebugStringColored("Called [OnServerEventReceive]", ConsoleColor.Green);

                foreach (MethodInfo method in Methods)
                {
                    object[] attr = method.GetCustomAttributes(typeof(VenoXRemoteEventAttribute), false);
                    if (attr is not null && attr.Length > 0)
                    {
                        VenoXRemoteEventAttribute obj = (VenoXRemoteEventAttribute)attr[0];
                        if (obj is not null && obj.Name == eventName)
                        {
                            /* Variables */
                            List<object> objList = new List<object> { player };
                            ParameterInfo[] methodParameters = method.GetParameters();
                            int i = 1;

                            /* Debug */
                            //Core.Debug.OutputDebugStringColored("Called EventName : [" + EventName + "]", ConsoleColor.Green);
                            //Core.Debug.OutputDebugString("[ServerEvent] : [" + player.Name + "] | [" + player.Username + "] called EventName : " + EventName + " | Args : " + string.Join(", ", args));

                            // Creating a new Instance
                            object instance = Activator.CreateInstance(method.DeclaringType);

                            // Fix - obj value types.
                            foreach (object v in args) { objList.Add(Convert.ChangeType(v, methodParameters[i].ParameterType)); i++; }

                            //Convert our list to a obj-Array.
                            object[] builder = objList.ToArray();
                            // invoke the method
                            method.Invoke(instance, builder);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex, "OnServerEventReceive - " + eventName); }
        }
    }
}
