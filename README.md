# MeshStreamingGrasshopper
Plugin for Grasshopper to stream mesh geometry through web socket with example to communicate with Unity.

## Installation

1. Put all dlls and gha files inside Libraries folder for Grasshopper (Usually in C:\Users\xxx\AppData\Roaming\Grasshopper\Libraries). Unblock all dlls and gha files.

2. Make sure you have [Microsoft .NET Framework 4.5](https://www.microsoft.com/en-US/download/details.aspx?id=30653) installed.

## Notes

- Be careful not to have duplicate dlls (like Newtonsoft.Json) in the Grasshopper's libraries folder.

## Usage (for examples)

1. Run Node server (README available under Examples/MeshStreamingServer).

2. Run Unity project (README available under Examples/MeshReceivingUnityClient).

3. Send mesh geometry as follows in Grasshopper.

[![HowtoVideo](https://img.youtube.com/vi/is-zpw4A8oM/0.jpg)](https://www.youtube.com/watch?v=is-zpw4A8oM)




*Modifications*
- `MeshSerializeComponent` can also send data as JSON rathter than `ZeroFormatter` via `JSON` boolean.

## Dependencies
<<<<<<< HEAD
- [SocketIoClientDotNet](https://github.com/Quobject/SocketIoClientDotNet)
- [ZeroFormatter](https://github.com/neuecc/ZeroFormatter)


## Usage

![](http://c.mnmly.com/kThn/Image%202017-05-15%20at%206.49.18%20PM.png)

Refer to [compatible websocket server example](https://github.com/mnmly/MeshStreamingServer/tree/feature/json)

=======
- [SocketIoClientDotNet 0.9.13](https://www.nuget.org/packages/SocketIoClientDotNet)
- [EngineIoClientDotNet 0.9.22](https://www.nuget.org/packages/EngineIoClientDotNet)
- [Newtonsoft.Json 8.0.1](https://www.nuget.org/packages/Newtonsoft.Json)
- [WebSocket4Net 0.14.1](https://www.nuget.org/packages/WebSocket4Net)
- [ZeroFormatter 4.0.30319](https://www.nuget.org/packages/ZeroFormatter)
>>>>>>> master
