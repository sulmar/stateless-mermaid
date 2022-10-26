using Stateless;
using Stateless.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace StatelessToMermaid
{
    public enum DeviceState
    {
        Ready,
        Waiting,
        Tanning,
        Cooling
    }

    public enum Trigger
    {
        Start,
        Stop,
        ElapsedTime
    }

   


    

    internal class Device
    {
        private StateMachine<DeviceState, Trigger> _machine;
       
        // public string Graph => Stateless.Graph.UmlDotGraph.Format(_machine.GetInfo());

        public string Graph3 => Stateless.Graph.MermaidGraph.Format(_machine.GetInfo());

        public string Graph
        {
            get
            {
                StringBuilder builder = new StringBuilder();

                builder.AppendLine("stateDiagram");
                

                var info = _machine.GetInfo();

                builder.AppendLine($"\t[*] --> {info.InitialState}");

                foreach (var state in info.States)
                {
                    foreach (var transition in state.FixedTransitions)
                    {
                        builder.AppendLine($"\t{state} --> {transition.DestinationState}: {transition.Trigger}");

                        
                    }
                }


                return builder.ToString();
            }
        }

        public Device()
        {
            
            _machine = new StateMachine<DeviceState, Trigger>(DeviceState.Ready);

            _machine.Configure(DeviceState.Ready)
                .Permit(Trigger.Start, DeviceState.Waiting);

            _machine.Configure(DeviceState.Waiting)
                .Permit(Trigger.Stop, DeviceState.Ready)
                .Permit(Trigger.Start, DeviceState.Tanning)
                .Permit(Trigger.ElapsedTime, DeviceState.Tanning);

            _machine.Configure(DeviceState.Tanning)
                .Permit(Trigger.ElapsedTime, DeviceState.Cooling)
                .Permit(Trigger.Stop, DeviceState.Cooling);

            _machine.Configure(DeviceState.Cooling)
                .Permit(Trigger.ElapsedTime, DeviceState.Ready);

            

        }
    }
}
