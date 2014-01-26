using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class branch: IEquatable<branch>
    {
        //Private vars
        private List<computer> branchComputers=new List<computer>(); //TODO: seperate class, implement IEnumerable
        
        //Simple properties
        public int No { get; set; }
        public string Name { get; set; }

        //Get-only properties
        public List<computer> Computers
        {
            get
            {
                return(branchComputers);
            }
        }

        //IEquateable
        public bool Equals(branch other)
        {
            return (this.No == other.No);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //Methods
        public ReturnValue Update(UpdateType What)
        {
            int intFailed=0, intPartial=0, intSuccess=0;
            foreach(computer branchComputer in branchComputers){
                switch(branchComputer.Update(What)){
                    case ReturnValue.Failed:
                        intFailed += 1;
                        break;
                    case ReturnValue.Partial:
                        intPartial += 1;
                        break;
                    case ReturnValue.Success:
                        intSuccess += 1;
                        break;
                }
            }
            if (intFailed + intPartial == 0 && intSuccess>0)
            {
                return (ReturnValue.Success);
            }
            else if (intPartial == 0 && intSuccess == 0)
            {
                return (ReturnValue.Failed);
            }
            else {
                return (ReturnValue.Partial);
            }
        }

    }
}
