// See https://aka.ms/new-console-template for more information
using StatelessToMermaid;

Console.WriteLine("Hello, World!");


Device device = new Device();
Console.WriteLine(device.Graph);
Console.WriteLine(device.Graph3);


var expected = @"stateDiagram
    [*]-- > Ready
    Ready-- > Waiting: Start
    Waiting --> Tanning: ElapsedTime
    Waiting --> Tanning: StartImmediate
    Tanning --> Cooling: ElapsedTime
    Tanning --> Cooling: Stop
    Cooling --> Ready: ElapsedTime";


Console.WriteLine(device.Graph == expected);