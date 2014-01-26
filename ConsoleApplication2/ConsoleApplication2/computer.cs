using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
namespace ConsoleApplication2
{
    enum ComputerType { Till, PC}
    enum ComputerRole { Primary, Secondrary}
    enum UpdateType { FileSystem, Registry, All}
    enum ReturnValue { Success, Partial, Failed }

    class computer
    {
        public IPAddress IpAddress { get; set; }
        public ComputerType Type { get; set; }
        public ComputerRole Role { get; set; }
        public NetworkCredential Credential { get; set; }
        public String DeployFolder { get; set; }
        public String DeployRegistry { get; set; }

        public ReturnValue Update(UpdateType What)
        {
            ReturnValue returnValue = ReturnValue.Success;
            if (What == UpdateType.All || What == UpdateType.FileSystem)
            {
                //update file system
                returnValue = updateFileSystem(DeployFolder, Path.GetFullPath("\\" + IpAddress), Credential);
            }
            if (What == UpdateType.All || What == UpdateType.Registry)
            {
                //todo: update registry
            }
            return(returnValue);
        }
        private ReturnValue updateFileSystem(String fromPath, String toPath, NetworkCredential remoteCredential)
        {
            if(Directory.Exists(fromPath))
            return (ReturnValue.Success);
        }
    }
}
