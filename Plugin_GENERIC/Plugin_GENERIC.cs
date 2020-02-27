using SEPlugin;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;

namespace Plugin_GENERIC
{
    [Export(typeof(IPlugin))]
    public class Plugin_GENERIC : IPlugin
    {

        public string Name
        {
            get
            {
                return "GENERIC";
            }
        }

        public List<ConnectionStructure> ConnectionStructure
        {
            get
            {
                return new List<ConnectionStructure>() {
                new ConnectionStructure() {
                    Name = "parameter1",
                    Label = "Parameter 1",
                    Required =  true,
                    Mask = false
                },
                  new ConnectionStructure() {
                    Name = "parameter2",
                    Label = "Parameter 2",
                    Required =  true,
                    Mask = true
                }

            };

            }
        }
        public List<MethodType> MethodTypes(List<ConnectionValue> Connection)
        {

            return new List<MethodType>() {

                new MethodType() {
                    Type = "GET",
                    Methods = new List<Method>() {
                        new Method() {
                            Name = "Info",
                            sampleInput = "",
                            sampleOutput  = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()
                        }
                    }
                },
                new MethodType() {
                    Type = "POST",
                    Methods = MethodList()
                }
            };
        }

        private static List<Method> MethodList()
        {
            return new List<Method>() {
                        new Method() {
                            Name = "Add",
                            sampleInput = "<add><input>1</input><input>2</input></add>",
                            sampleOutput  = "<result>3</result>"
                        },
                          new Method() {
                            Name = "Multiply",
                            sampleInput = "<multiply><input>2</input><input>3</input></add>",
                            sampleOutput  = "<result>6</result>"
                        }
                    };
        }

        public Method MethodInfo(List<ConnectionValue> Connection, string MethodType, string MethodName)
        {
            return MethodTypes(Connection).FirstOrDefault(x => x.Type == MethodType)?.Methods.FirstOrDefault(x => x.Name == MethodName);

        }

        public Result Do(List<ConnectionValue> Connection, string MethodType, string MethodName, string inputString)
        {
            //implement this

            if (MethodType == "GET")
            {
                //return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                return new Result()
                {
                    Success = true,
                    Output = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()
                };
            }

            //return "this is not implemented";
            return new Result()
            {
                Success = false,
                Output = "<Error>" + "this is not implemented" + "</Error>",
                ErrorMessage = "this is not implemented"
            };
        }

        public Result TestConnection(List<ConnectionValue> Connection)
        {

            return new Result
            {
                Success = false,
                ErrorMessage = "This is not implemented"
            };
        }

    }
}
