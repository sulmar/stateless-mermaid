namespace Stateless.Graph
{
    public class MermaidGraphStyle : GraphStyleBase
    {
        public override string GetPrefix()
        {
            return "stateDiagram";
        }

        public override List<string> FormatAllTransitions(List<Transition> transitions)
        {
            var f = base.FormatAllTransitions(transitions);
            return f;
        }

        public override string FormatOneCluster(SuperState stateInfo)
        {
            string stateRepresentationString = "";
            return stateRepresentationString;
        }

        public override string FormatOneDecisionNode(string nodeName, string label)
        {
            return String.Empty;
        }

        public override string FormatOneState(State state)
        {
            return String.Empty;
        }

        public override string FormatOneTransition(string sourceNodeName, string trigger, IEnumerable<string> actions, string destinationNodeName, IEnumerable<string> guards)
        {
            string label = trigger ?? "";

            return FormatOneLine(sourceNodeName, destinationNodeName, label);
        }

        internal string FormatOneLine(string fromNodeName, string toNodeName, string label)
        {
            return $"\t{fromNodeName} --> {toNodeName} : {label}";
        }

    }
}
